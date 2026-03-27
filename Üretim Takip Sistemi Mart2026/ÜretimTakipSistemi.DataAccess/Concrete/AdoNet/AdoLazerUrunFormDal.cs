using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoLazerUrunFormDal : ILazerUrunFormDal
    {
        public List<LazerProfilSecenek> GetProfilListesi(string connectionString)
        {
            List<LazerProfilSecenek> liste = new List<LazerProfilSecenek>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT DISTINCT ProfilEbati, ProfilUzunlugu,
                                   ProfilEbati + ' - ' + CAST(ProfilUzunlugu AS VARCHAR) + 'mm' AS ProfilBilgi
                                   FROM ProfilStok
                                   ORDER BY ProfilEbati, ProfilUzunlugu";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new LazerProfilSecenek
                        {
                            ProfilEbati = reader["ProfilEbati"].ToString(),
                            ProfilUzunlugu = reader["ProfilUzunlugu"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ProfilUzunlugu"]),
                            ProfilBilgi = reader["ProfilBilgi"].ToString()
                        });
                    }
                }
            }

            return liste;
        }

        public LazerUrunDuzenlemeModel GetUrunDuzenlemeModel(string connectionString, int urunId)
        {
            LazerUrunDuzenlemeModel model = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT UrunID, UrunKodu, UrunAdi, LazerTipi, Aciklama, GrupluUrunMu,
                                   UrunBoyu, ProfilEbati, ProfilUzunlugu, SacKalinligi
                                   FROM Urunler WHERE UrunID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", urunId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model = new LazerUrunDuzenlemeModel
                            {
                                UrunId = Convert.ToInt32(reader["UrunID"]),
                                UrunKodu = SafeGetString(reader, "UrunKodu"),
                                UrunAdi = SafeGetString(reader, "UrunAdi"),
                                LazerTipi = SafeGetString(reader, "LazerTipi"),
                                Aciklama = SafeGetString(reader, "Aciklama"),
                                GrupluUrunMu = SafeGetBoolean(reader, "GrupluUrunMu"),
                                UrunBoyu = SafeGetNullableDecimal(reader, "UrunBoyu"),
                                ProfilEbati = SafeGetString(reader, "ProfilEbati"),
                                ProfilUzunlugu = SafeGetNullableDecimal(reader, "ProfilUzunlugu"),
                                SacKalinligi = SafeGetNullableDecimal(reader, "SacKalinligi")
                            };
                        }
                    }
                }

                if (model == null)
                {
                    return null;
                }

                if (model.GrupluUrunMu && model.LazerTipi == "Boru")
                {
                    string detayQuery = @"SELECT ParcaAdi, Adet, UrunBoyu, ProfilEbati, ProfilUzunlugu
                                          FROM UrunDetayBoru
                                          WHERE UrunID = @ID
                                          ORDER BY Sira";

                    using (SqlCommand detayCmd = new SqlCommand(detayQuery, conn))
                    {
                        detayCmd.Parameters.AddWithValue("@ID", urunId);

                        using (SqlDataReader detayReader = detayCmd.ExecuteReader())
                        {
                            while (detayReader.Read())
                            {
                                model.AltUrunler.Add(new LazerAltUrunDetay
                                {
                                    ParcaAdi = detayReader["ParcaAdi"].ToString(),
                                    Adet = Convert.ToInt32(detayReader["Adet"]),
                                    UrunBoyu = Convert.ToDecimal(detayReader["UrunBoyu"]),
                                    ProfilEbati = detayReader["ProfilEbati"].ToString(),
                                    ProfilUzunlugu = Convert.ToDecimal(detayReader["ProfilUzunlugu"])
                                });
                            }
                        }
                    }
                }
            }

            return model;
        }

        public void KaydetUrun(string connectionString, LazerUrunKaydetTalep talep)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                VeritabaniKolonlariniKontrolEt(conn);

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int urunId;

                        if (talep.UrunId.HasValue)
                        {
                            string updateQ = @"UPDATE Urunler SET
                                UrunKodu=@Kod, UrunAdi=@Adi, LazerTipi=@LazerTipi,
                                Aciklama=@Aciklama, GrupluUrunMu=@GrupluUrunMu,
                                GuncellemeTarihi=GETDATE(),
                                UrunBoyu=@UrunBoyu, ProfilEbati=@ProfilEbati,
                                ProfilUzunlugu=@ProfilUzunlugu, SacKalinligi=@SacKalinligi
                                WHERE UrunID=@ID";

                            using (SqlCommand updCmd = new SqlCommand(updateQ, conn, transaction))
                            {
                                DoldurKaydetParametreleri(updCmd, talep);
                                updCmd.Parameters.AddWithValue("@ID", talep.UrunId.Value);
                                updCmd.ExecuteNonQuery();
                            }

                            using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM UrunDetayBoru WHERE UrunID=@ID", conn, transaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@ID", talep.UrunId.Value);
                                deleteCmd.ExecuteNonQuery();
                            }

                            urunId = talep.UrunId.Value;
                        }
                        else
                        {
                            string insQ = @"INSERT INTO Urunler
                                (UrunKodu, UrunAdi, LazerTipi, Aciklama, GrupluUrunMu, AktifMi,
                                 KayitTarihi, UrunBoyu, ProfilEbati, ProfilUzunlugu, SacKalinligi)
                                VALUES (@Kod, @Adi, @LazerTipi, @Aciklama, @GrupluUrunMu, 1,
                                        GETDATE(), @UrunBoyu, @ProfilEbati, @ProfilUzunlugu, @SacKalinligi);
                                SELECT SCOPE_IDENTITY();";

                            using (SqlCommand insCmd = new SqlCommand(insQ, conn, transaction))
                            {
                                DoldurKaydetParametreleri(insCmd, talep);
                                urunId = Convert.ToInt32(insCmd.ExecuteScalar());
                            }
                        }

                        if (talep.GrupluUrunMu && talep.LazerTipi == "Boru")
                        {
                            AltUrunleriKaydet(conn, transaction, urunId, talep.AltUrunler);
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<LazerAltUrunSecimItem> GetAltUrunSecenekleri(string connectionString)
        {
            List<LazerAltUrunSecimItem> liste = new List<LazerAltUrunSecimItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT MIN(DetayID) AS DetayID, ParcaAdi AS UrunBilgi,
                                    MIN(UrunBoyu) AS UrunBoyu, MIN(ProfilEbati) AS ProfilEbati,
                                    MIN(ProfilUzunlugu) AS ProfilUzunlugu
                                    FROM UrunDetayBoru GROUP BY ParcaAdi ORDER BY ParcaAdi";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new LazerAltUrunSecimItem
                        {
                            DetayId = reader["DetayID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["DetayID"]),
                            UrunBilgi = reader["UrunBilgi"].ToString(),
                            UrunBoyu = reader["UrunBoyu"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["UrunBoyu"]),
                            ProfilEbati = reader["ProfilEbati"] == DBNull.Value ? string.Empty : reader["ProfilEbati"].ToString(),
                            ProfilUzunlugu = reader["ProfilUzunlugu"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["ProfilUzunlugu"])
                        });
                    }
                }
            }

            return liste;
        }

        public LazerAltUrunDetay GetAltUrunDetayi(string connectionString, string parcaAdi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT TOP 1 ParcaAdi, UrunBoyu, ProfilEbati, ProfilUzunlugu
                                 FROM UrunDetayBoru WHERE ParcaAdi=@ParcaAdi ORDER BY DetayID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ParcaAdi", parcaAdi);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        return new LazerAltUrunDetay
                        {
                            ParcaAdi = reader["ParcaAdi"].ToString(),
                            UrunBoyu = reader["UrunBoyu"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["UrunBoyu"]),
                            ProfilEbati = reader["ProfilEbati"] == DBNull.Value ? string.Empty : reader["ProfilEbati"].ToString(),
                            ProfilUzunlugu = reader["ProfilUzunlugu"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ProfilUzunlugu"])
                        };
                    }
                }
            }
        }

        public DataTable GetTumUrunler(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                                    SELECT 
                                        U.UrunID,
                                        U.UrunKodu AS 'Ürün Kodu',
                                        U.UrunAdi AS 'Ürün Adı',
                                        U.LazerTipi AS 'Lazer Tipi',
                                        CASE WHEN U.GrupluUrunMu = 1 THEN 'Evet' ELSE 'Hayır' END AS 'Gruplu',
                                        CASE 
                                            WHEN EXISTS (SELECT 1 FROM UrunDetayBoru D WHERE D.UrunID = U.UrunID)
                                            THEN 
                                                STUFF((
                                                    SELECT ' | ' + D.ParcaAdi + ' (x' + CAST(D.Adet AS VARCHAR) + ') - ' + D.ProfilEbati
                                                    FROM UrunDetayBoru D
                                                    WHERE D.UrunID = U.UrunID
                                                    ORDER BY D.Sira
                                                    FOR XML PATH('')
                                                ), 1, 3, '')
                                            ELSE 
                                                ISNULL(U.ProfilEbati + ' - ' + CAST(U.ProfilUzunlugu AS VARCHAR) + 'mm', 
                                                       ISNULL(CAST(U.SacKalinligi AS VARCHAR) + 'mm', 'Detay Yok'))
                                        END AS 'Alt Ürün Detayları',
                                        U.Aciklama AS 'Açıklama'
                                    FROM Urunler U
                                    WHERE U.AktifMi = 1
                                    ORDER BY U.LazerTipi, U.UrunKodu";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void UrunuPasifeAl(string connectionString, int urunId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE Urunler SET AktifMi = 0 WHERE UrunID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", urunId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetBoruLazerUrunleri(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT UrunID, UrunKodu + ' - ' + UrunAdi AS UrunBilgi
                                 FROM Urunler
                                 WHERE LazerTipi = 'Boru' AND AktifMi = 1
                                 ORDER BY UrunKodu";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetBoruUrunDetaylari(string connectionString, int urunId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT 
                                    ParcaAdi AS 'Parça Adı',
                                    Adet AS 'Adet',
                                    UrunBoyu AS 'Ürün Boyu (mm)',
                                    ProfilEbati AS 'Profil Ebatı',
                                    ProfilUzunlugu AS 'Profil Uzunluğu (mm)',
                                    CAST(FLOOR(ProfilUzunlugu / UrunBoyu) AS INT) AS 'Profil Başına Adet'
                                 FROM UrunDetayBoru
                                 WHERE UrunID = @UrunID
                                 ORDER BY Sira";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@UrunID", urunId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetProfilStokListesi(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT
                                    ProfilID,
                                    ProfilEbati,
                                    ProfilUzunlugu,
                                    StokAdedi,
                                    MinimumStok,
                                    CASE WHEN StokAdedi <= MinimumStok THEN 'Kritik Seviye !!'
                                         WHEN StokAdedi <= MinimumStok * 2 THEN 'Dikkat !'
                                         ELSE 'Normal' END AS 'Durum'
                                 FROM ProfilStok
                                 ORDER BY ProfilEbati";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void GuncelleProfilStok(string connectionString, int profilId, int oncekiStok, int yeniStok)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE ProfilStok SET StokAdedi = @Stok, GuncellemeTarihi = GETDATE() WHERE ProfilID = @ID",
                            conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Stok", yeniStok);
                            cmd.Parameters.AddWithValue("@ID", profilId);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand hareketCmd = new SqlCommand(@"
                            INSERT INTO StokHareketleri (HareketTipi, ReferansID, IslemTipi, Miktar, OncekiStok, YeniStok, Aciklama, IslemTarihi)
                            VALUES ('Profil', @RefID, 'Manuel Düzenleme', @Miktar, @OncekiStok, @YeniStok, @Aciklama, GETDATE())",
                            conn, transaction))
                        {
                            hareketCmd.Parameters.AddWithValue("@RefID", profilId);
                            hareketCmd.Parameters.AddWithValue("@Miktar", yeniStok - oncekiStok);
                            hareketCmd.Parameters.AddWithValue("@OncekiStok", oncekiStok);
                            hareketCmd.Parameters.AddWithValue("@YeniStok", yeniStok);
                            hareketCmd.Parameters.AddWithValue("@Aciklama", "Manuel stok düzenleme");
                            hareketCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public DataTable GetSacStokListesi(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT
                                    SacID,
                                    SacKalinligi,
                                    SacEbatX,
                                    SacEbatY,
                                    StokAdedi,
                                    MinimumStok,
                                    CASE WHEN StokAdedi <= MinimumStok THEN 'Kritik Seviye ⚠️'
                                         WHEN StokAdedi <= MinimumStok * 2 THEN 'Dikkat !'
                                         ELSE 'Normal' END AS 'Durum'
                                 FROM SacStok
                                 ORDER BY SacKalinligi, SacEbatX, SacEbatY";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void GuncelleSacStok(string connectionString, int sacId, int oncekiStok, int yeniStok)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE SacStok SET StokAdedi = @Stok, GuncellemeTarihi = GETDATE() WHERE SacID = @ID",
                            conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Stok", yeniStok);
                            cmd.Parameters.AddWithValue("@ID", sacId);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand hareketCmd = new SqlCommand(@"
                            INSERT INTO StokHareketleri (HareketTipi, ReferansID, IslemTipi, Miktar, OncekiStok, YeniStok, Aciklama, IslemTarihi)
                            VALUES ('Sac', @RefID, 'Manuel Düzenleme', @Miktar, @OncekiStok, @YeniStok, @Aciklama, GETDATE())",
                            conn, transaction))
                        {
                            hareketCmd.Parameters.AddWithValue("@RefID", sacId);
                            hareketCmd.Parameters.AddWithValue("@Miktar", yeniStok - oncekiStok);
                            hareketCmd.Parameters.AddWithValue("@OncekiStok", oncekiStok);
                            hareketCmd.Parameters.AddWithValue("@YeniStok", yeniStok);
                            hareketCmd.Parameters.AddWithValue("@Aciklama", "Manuel stok düzenleme");
                            hareketCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public LazerSacStokKaydetSonuc KaydetSacStok(string connectionString, LazerSacStokKaydetTalep talep)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand chkCmd = new SqlCommand(
                            "SELECT COUNT(*) FROM SacStok WHERE SacKalinligi=@K AND SacEbatX=@X AND SacEbatY=@Y",
                            conn, transaction))
                        {
                            chkCmd.Parameters.AddWithValue("@K", talep.SacKalinligi);
                            chkCmd.Parameters.AddWithValue("@X", talep.SacEbatX);
                            chkCmd.Parameters.AddWithValue("@Y", talep.SacEbatY);

                            bool mevcutKayitVar = Convert.ToInt32(chkCmd.ExecuteScalar()) > 0;

                            if (mevcutKayitVar)
                            {
                                using (SqlCommand updCmd = new SqlCommand(
                                    @"UPDATE SacStok SET StokAdedi = StokAdedi + @Adet, GuncellemeTarihi = GETDATE()
                                      WHERE SacKalinligi=@K AND SacEbatX=@X AND SacEbatY=@Y", conn, transaction))
                                {
                                    updCmd.Parameters.AddWithValue("@Adet", talep.StokAdedi);
                                    updCmd.Parameters.AddWithValue("@K", talep.SacKalinligi);
                                    updCmd.Parameters.AddWithValue("@X", talep.SacEbatX);
                                    updCmd.Parameters.AddWithValue("@Y", talep.SacEbatY);
                                    updCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                using (SqlCommand insCmd = new SqlCommand(
                                    @"INSERT INTO SacStok (SacKalinligi, SacEbatX, SacEbatY, StokAdedi, MinimumStok, KayitTarihi)
                                      VALUES (@K, @X, @Y, @Adet, @Min, GETDATE())", conn, transaction))
                                {
                                    insCmd.Parameters.AddWithValue("@K", talep.SacKalinligi);
                                    insCmd.Parameters.AddWithValue("@X", talep.SacEbatX);
                                    insCmd.Parameters.AddWithValue("@Y", talep.SacEbatY);
                                    insCmd.Parameters.AddWithValue("@Adet", talep.StokAdedi);
                                    insCmd.Parameters.AddWithValue("@Min", talep.MinimumStok);
                                    insCmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            return new LazerSacStokKaydetSonuc
                            {
                                MevcutKaydaEklendi = mevcutKayitVar,
                                EklenenStokAdedi = talep.StokAdedi
                            };
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public DataTable GetPlakaLazerUrunleri(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT UrunID, UrunKodu + ' - ' + UrunAdi AS UrunBilgi
                                 FROM Urunler
                                 WHERE LazerTipi = 'Plaka' AND AktifMi = 1
                                 ORDER BY UrunKodu";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetPlakaUrunDetaylari(string connectionString, int urunId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT
                                    ParcaAdi AS 'ParÃ§a AdÄ±',
                                    Adet AS 'Adet',
                                    SacKalinligi AS 'Sac KalÄ±nlÄ±ÄŸÄ± (mm)',
                                    SacEbatX AS 'Sac Ebat X (mm)',
                                    SacEbatY AS 'Sac Ebat Y (mm)',
                                    BirimSacKapasitesi AS 'Sac BaÅŸÄ±na Adet'
                                 FROM UrunDetayPlaka
                                 WHERE UrunID = @UrunID
                                 ORDER BY Sira";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@UrunID", urunId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public int GetSacStokAdedi(string connectionString, decimal sacKalinligi, decimal sacEbatX, decimal sacEbatY)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT StokAdedi FROM SacStok
                      WHERE SacKalinligi = @Kalinlik AND SacEbatX = @EbatX AND SacEbatY = @EbatY", conn))
                {
                    cmd.Parameters.AddWithValue("@Kalinlik", sacKalinligi);
                    cmd.Parameters.AddWithValue("@EbatX", sacEbatX);
                    cmd.Parameters.AddWithValue("@EbatY", sacEbatY);

                    object sonuc = cmd.ExecuteScalar();
                    return sonuc == null || sonuc == DBNull.Value ? 0 : Convert.ToInt32(sonuc);
                }
            }
        }

        public int GetProfilStokAdedi(string connectionString, string profilEbati, decimal profilUzunlugu)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT ISNULL(StokAdedi,0) FROM ProfilStok WHERE ProfilEbati=@E AND ProfilUzunlugu=@U", conn))
                {
                    cmd.Parameters.AddWithValue("@E", profilEbati);
                    cmd.Parameters.AddWithValue("@U", profilUzunlugu);

                    object sonuc = cmd.ExecuteScalar();
                    return sonuc == null || sonuc == DBNull.Value ? 0 : Convert.ToInt32(sonuc);
                }
            }
        }

        private static string SafeGetString(SqlDataReader reader, string columnName)
        {
            try
            {
                int o = reader.GetOrdinal(columnName);
                return reader.IsDBNull(o) ? string.Empty : reader.GetString(o);
            }
            catch
            {
                return string.Empty;
            }
        }

        private static decimal? SafeGetNullableDecimal(SqlDataReader reader, string columnName)
        {
            try
            {
                int o = reader.GetOrdinal(columnName);
                return reader.IsDBNull(o) ? (decimal?)null : reader.GetDecimal(o);
            }
            catch
            {
                return null;
            }
        }

        private static bool SafeGetBoolean(SqlDataReader reader, string columnName)
        {
            try
            {
                int o = reader.GetOrdinal(columnName);
                return !reader.IsDBNull(o) && reader.GetBoolean(o);
            }
            catch
            {
                return false;
            }
        }

        private static void DoldurKaydetParametreleri(SqlCommand cmd, LazerUrunKaydetTalep talep)
        {
            cmd.Parameters.AddWithValue("@Kod", talep.UrunKodu.Trim());
            cmd.Parameters.AddWithValue("@Adi", talep.UrunAdi.Trim());
            cmd.Parameters.AddWithValue("@LazerTipi", talep.LazerTipi);
            cmd.Parameters.AddWithValue("@Aciklama", string.IsNullOrWhiteSpace(talep.Aciklama) ? (object)DBNull.Value : talep.Aciklama.Trim());
            cmd.Parameters.AddWithValue("@GrupluUrunMu", talep.GrupluUrunMu);
            cmd.Parameters.AddWithValue("@UrunBoyu", talep.UrunBoyu.HasValue ? (object)talep.UrunBoyu.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@ProfilEbati", string.IsNullOrWhiteSpace(talep.ProfilEbati) ? (object)DBNull.Value : talep.ProfilEbati);
            cmd.Parameters.AddWithValue("@ProfilUzunlugu", talep.ProfilUzunlugu.HasValue ? (object)talep.ProfilUzunlugu.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@SacKalinligi", talep.SacKalinligi.HasValue ? (object)talep.SacKalinligi.Value : DBNull.Value);
        }

        private static void AltUrunleriKaydet(SqlConnection conn, SqlTransaction transaction, int hedefUrunId, List<LazerAltUrunDetay> altUrunler)
        {
            for (int i = 0; i < altUrunler.Count; i++)
            {
                LazerAltUrunDetay au = altUrunler[i];
                string insDetayQ = @"INSERT INTO UrunDetayBoru
                    (UrunID, ParcaAdi, Adet, UrunBoyu, ProfilEbati, ProfilUzunlugu, Sira)
                    VALUES (@UrunID,@ParcaAdi,@Adet,@UrunBoyu,@ProfilEbati,@ProfilUzunlugu,@Sira)";

                using (SqlCommand cmd = new SqlCommand(insDetayQ, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@UrunID", hedefUrunId);
                    cmd.Parameters.AddWithValue("@ParcaAdi", au.ParcaAdi);
                    cmd.Parameters.AddWithValue("@Adet", au.Adet);
                    cmd.Parameters.AddWithValue("@UrunBoyu", au.UrunBoyu);
                    cmd.Parameters.AddWithValue("@ProfilEbati", au.ProfilEbati);
                    cmd.Parameters.AddWithValue("@ProfilUzunlugu", au.ProfilUzunlugu);
                    cmd.Parameters.AddWithValue("@Sira", i + 1);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void VeritabaniKolonlariniKontrolEt(SqlConnection conn)
        {
            try
            {
                using (SqlCommand c1 = new SqlCommand(
                    "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Urunler' AND COLUMN_NAME='ProfilUzunlugu'",
                    conn))
                {
                    if (Convert.ToInt32(c1.ExecuteScalar()) == 0)
                    {
                        using (SqlCommand alter1 = new SqlCommand("ALTER TABLE Urunler ADD ProfilUzunlugu DECIMAL(10,2) NULL", conn))
                        {
                            alter1.ExecuteNonQuery();
                        }
                    }
                }

                using (SqlCommand c2 = new SqlCommand(
                    "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Urunler' AND COLUMN_NAME='SacKalinligi'",
                    conn))
                {
                    if (Convert.ToInt32(c2.ExecuteScalar()) == 0)
                    {
                        using (SqlCommand alter2 = new SqlCommand("ALTER TABLE Urunler ADD SacKalinligi DECIMAL(5,2) NULL", conn))
                        {
                            alter2.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
