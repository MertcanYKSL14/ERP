using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoLazerSiparisFormDal : ILazerSiparisFormDal
    {
        public LazerSiparisDuzenlemeModel GetSiparisDuzenlemeModel(string connectionString, int siparisId)
        {
            LazerSiparisDuzenlemeModel model = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string siparisQuery = @"SELECT SiparisNo, Musteri, SiparisTarihi, Aciklama
                                        FROM Siparisler
                                        WHERE SiparisID = @ID";

                using (SqlCommand cmd = new SqlCommand(siparisQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", siparisId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model = new LazerSiparisDuzenlemeModel
                            {
                                SiparisNo = reader["SiparisNo"].ToString(),
                                Musteri = reader["Musteri"].ToString(),
                                SiparisTarihi = Convert.ToDateTime(reader["SiparisTarihi"]),
                                Aciklama = reader["Aciklama"] == DBNull.Value ? string.Empty : reader["Aciklama"].ToString()
                            };
                        }
                    }
                }

                if (model == null)
                {
                    return null;
                }

                bool teslimKolonuVar = TeslimTarihiKolonuVarMi(conn);

                string detayQuery = teslimKolonuVar
                    ? @"SELECT SD.UrunID, U.UrunKodu, U.UrunAdi, U.LazerTipi, SD.SiparisAdedi, SD.TeslimTarihi
                        FROM SiparisDetay SD
                        INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                        WHERE SD.SiparisID = @ID"
                    : @"SELECT SD.UrunID, U.UrunKodu, U.UrunAdi, U.LazerTipi, SD.SiparisAdedi, NULL AS TeslimTarihi
                        FROM SiparisDetay SD
                        INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                        WHERE SD.SiparisID = @ID";

                using (SqlCommand detayCmd = new SqlCommand(detayQuery, conn))
                {
                    detayCmd.Parameters.AddWithValue("@ID", siparisId);

                    using (SqlDataReader detayReader = detayCmd.ExecuteReader())
                    {
                        while (detayReader.Read())
                        {
                            model.Detaylar.Add(new LazerSiparisDetaySatiri
                            {
                                UrunID = Convert.ToInt32(detayReader["UrunID"]),
                                UrunKodu = detayReader["UrunKodu"].ToString(),
                                UrunAdi = detayReader["UrunAdi"].ToString(),
                                LazerTipi = detayReader["LazerTipi"].ToString(),
                                SiparisAdedi = Convert.ToInt32(detayReader["SiparisAdedi"]),
                                TeslimTarihi = detayReader["TeslimTarihi"] == DBNull.Value
                                    ? (DateTime?)null
                                    : Convert.ToDateTime(detayReader["TeslimTarihi"])
                            });
                        }
                    }
                }
            }

            return model;
        }

        public List<LazerSiparisUrunSecimItem> GetAktifUrunler(string connectionString)
        {
            List<LazerSiparisUrunSecimItem> urunler = new List<LazerSiparisUrunSecimItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT UrunID, UrunKodu, UrunAdi, LazerTipi
                                 FROM Urunler
                                 WHERE AktifMi = 1
                                 ORDER BY UrunKodu";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        urunler.Add(new LazerSiparisUrunSecimItem
                        {
                            UrunID = Convert.ToInt32(reader["UrunID"]),
                            UrunKodu = reader["UrunKodu"].ToString(),
                            UrunAdi = reader["UrunAdi"].ToString(),
                            LazerTipi = reader["LazerTipi"].ToString()
                        });
                    }
                }
            }

            return urunler;
        }

        public LazerSiparisUrunSecimItem GetUrunById(string connectionString, int urunId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT UrunID, UrunKodu, UrunAdi, LazerTipi
                                 FROM Urunler
                                 WHERE UrunID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", urunId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        return new LazerSiparisUrunSecimItem
                        {
                            UrunID = Convert.ToInt32(reader["UrunID"]),
                            UrunKodu = reader["UrunKodu"].ToString(),
                            UrunAdi = reader["UrunAdi"].ToString(),
                            LazerTipi = reader["LazerTipi"].ToString()
                        };
                    }
                }
            }
        }

        public void KaydetSiparis(string connectionString, LazerSiparisKaydetTalep talep)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                bool teslimKolonuVar = TeslimTarihiKolonuVarMi(conn);

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int siparisId = talep.SiparisId ?? 0;

                        if (talep.SiparisId.HasValue)
                        {
                            using (SqlCommand deleteCmd = new SqlCommand(
                                "DELETE FROM SiparisDetay WHERE SiparisID = @ID",
                                conn,
                                transaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@ID", talep.SiparisId.Value);
                                deleteCmd.ExecuteNonQuery();
                            }

                            string updateQ = @"UPDATE Siparisler SET SiparisNo=@No, Musteri=@Musteri,
                                              SiparisTarihi=@SipTarihi, Aciklama=@Aciklama WHERE SiparisID=@ID";

                            using (SqlCommand updCmd = new SqlCommand(updateQ, conn, transaction))
                            {
                                updCmd.Parameters.AddWithValue("@No", talep.SiparisNo);
                                updCmd.Parameters.AddWithValue("@Musteri", talep.Musteri);
                                updCmd.Parameters.AddWithValue("@SipTarihi", talep.SiparisTarihi);
                                updCmd.Parameters.AddWithValue("@Aciklama", string.IsNullOrWhiteSpace(talep.Aciklama) ? (object)DBNull.Value : talep.Aciklama);
                                updCmd.Parameters.AddWithValue("@ID", talep.SiparisId.Value);
                                updCmd.ExecuteNonQuery();
                            }

                            siparisId = talep.SiparisId.Value;
                        }
                        else
                        {
                            string insQ = @"INSERT INTO Siparisler (SiparisNo, Musteri, SiparisTarihi, Aciklama, Durum)
                                           VALUES (@No, @Musteri, @SipTarihi, @Aciklama, 'Beklemede');
                                           SELECT SCOPE_IDENTITY();";

                            using (SqlCommand insCmd = new SqlCommand(insQ, conn, transaction))
                            {
                                insCmd.Parameters.AddWithValue("@No", talep.SiparisNo);
                                insCmd.Parameters.AddWithValue("@Musteri", talep.Musteri);
                                insCmd.Parameters.AddWithValue("@SipTarihi", talep.SiparisTarihi);
                                insCmd.Parameters.AddWithValue("@Aciklama", string.IsNullOrWhiteSpace(talep.Aciklama) ? (object)DBNull.Value : talep.Aciklama);
                                siparisId = Convert.ToInt32(insCmd.ExecuteScalar());
                            }
                        }

                        DetaylariKaydet(conn, transaction, siparisId, talep.Detaylar, teslimKolonuVar);
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

        public LazerExcelSiparisAktarSonuc AktarExcelSiparisi(string connectionString, LazerExcelSiparisAktarTalep talep)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        LazerExcelSiparisAktarSonuc sonuc = new LazerExcelSiparisAktarSonuc();

                        string siparisInsert = @"
                            INSERT INTO Siparisler (SiparisNo, Musteri, SiparisTarihi, TeslimTarihi, Durum, Aciklama)
                            VALUES (@SiparisNo, @Musteri, GETDATE(), NULL, 'Beklemede', @Aciklama);
                            SELECT SCOPE_IDENTITY();";

                        int siparisId;
                        using (SqlCommand siparisCmd = new SqlCommand(siparisInsert, conn, transaction))
                        {
                            siparisCmd.Parameters.AddWithValue("@SiparisNo", talep.SiparisNo);
                            siparisCmd.Parameters.AddWithValue("@Musteri", talep.Musteri);
                            siparisCmd.Parameters.AddWithValue("@Aciklama",
                                string.IsNullOrWhiteSpace(talep.Aciklama) ? (object)DBNull.Value : talep.Aciklama);
                            siparisId = Convert.ToInt32(siparisCmd.ExecuteScalar());
                        }

                        bool teslimKolonuVar;
                        using (SqlCommand chkCmd = new SqlCommand(
                            "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='SiparisDetay' AND COLUMN_NAME='TeslimTarihi'",
                            conn,
                            transaction))
                        {
                            teslimKolonuVar = Convert.ToInt32(chkCmd.ExecuteScalar()) > 0;
                        }

                        string detayQuery = teslimKolonuVar
                            ? @"INSERT INTO SiparisDetay (SiparisID, UrunID, SiparisAdedi, Durum, TeslimTarihi)
                                VALUES (@SiparisID, @UrunID, @Adet, 'Beklemede', @TeslimTarihi)"
                            : @"INSERT INTO SiparisDetay (SiparisID, UrunID, SiparisAdedi, Durum)
                                VALUES (@SiparisID, @UrunID, @Adet, 'Beklemede')";

                        foreach (LazerExcelSiparisSatiri satir in talep.Satirlar)
                        {
                            if (string.IsNullOrWhiteSpace(satir.StokKodu))
                            {
                                continue;
                            }

                            if (satir.Adet <= 0)
                            {
                                sonuc.HataliSatirSayisi++;
                                sonuc.HataMesajlari.Add($"• '{satir.StokKodu}' - Geçersiz adet: {satir.Adet}");
                                continue;
                            }

                            object urunIdObj;
                            using (SqlCommand urunBulCmd = new SqlCommand(
                                "SELECT UrunID FROM Urunler WHERE UrunKodu = @Kod AND AktifMi = 1",
                                conn,
                                transaction))
                            {
                                urunBulCmd.Parameters.AddWithValue("@Kod", satir.StokKodu);
                                urunIdObj = urunBulCmd.ExecuteScalar();
                            }

                            if (urunIdObj == null)
                            {
                                sonuc.HataliSatirSayisi++;
                                sonuc.HataMesajlari.Add($"• '{satir.StokKodu}' - Sistemde bulunamadı.");
                                continue;
                            }

                            using (SqlCommand detayCmd = new SqlCommand(detayQuery, conn, transaction))
                            {
                                detayCmd.Parameters.AddWithValue("@SiparisID", siparisId);
                                detayCmd.Parameters.AddWithValue("@UrunID", Convert.ToInt32(urunIdObj));
                                detayCmd.Parameters.AddWithValue("@Adet", satir.Adet);

                                if (teslimKolonuVar)
                                {
                                    detayCmd.Parameters.AddWithValue("@TeslimTarihi",
                                        satir.TeslimTarihi.HasValue ? (object)satir.TeslimTarihi.Value : DBNull.Value);
                                }

                                detayCmd.ExecuteNonQuery();
                            }

                            sonuc.BasariliSatirSayisi++;
                        }

                        transaction.Commit();
                        return sonuc;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public DataTable GetSiparisListesi(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                bool teslimKolonuVar = TeslimTarihiKolonuVarMi(conn);
                string enYakinTeslimSub = teslimKolonuVar
                    ? "(SELECT MIN(SD2.TeslimTarihi) FROM SiparisDetay SD2 WHERE SD2.SiparisID = S.SiparisID AND SD2.TeslimTarihi IS NOT NULL)"
                    : "NULL";

                string query = $@"SELECT 
                                    S.SiparisID,
                                    S.SiparisNo AS 'Sipariş No',
                                    S.Musteri AS 'Müşteri',
                                    CONVERT(VARCHAR(10), S.SiparisTarihi, 103) AS 'Sipariş Tarihi',
                                    CONVERT(VARCHAR(10), S.TeslimTarihi, 103) AS 'Sipariş Teslim',
                                    CONVERT(VARCHAR(10), {enYakinTeslimSub}, 103) AS 'Ürün Teslim (En Yakın)',
                                    S.Durum AS 'Durum',
                                    ISNULL(COUNT(SD.SiparisDetayID), 0) AS 'Ürün Çeşidi',
                                    ISNULL(SUM(SD.SiparisAdedi), 0) AS 'Toplam Adet',
                                    S.Aciklama AS 'Açıklama'
                                 FROM Siparisler S
                                 LEFT JOIN SiparisDetay SD ON S.SiparisID = SD.SiparisID
                                 GROUP BY S.SiparisID, S.SiparisNo, S.Musteri, S.SiparisTarihi, S.TeslimTarihi, S.Durum, S.Aciklama
                                 ORDER BY S.SiparisTarihi DESC";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public string UretSiparisNo(string connectionString)
        {
            string tarihKismi = DateTime.Now.ToString("yyyyMMdd");
            string prefix = $"SP-{tarihKismi}-";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Siparisler WHERE SiparisNo LIKE @Prefix",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@Prefix", prefix + "%");
                    int bugunSayisi = Convert.ToInt32(cmd.ExecuteScalar());
                    return $"{prefix}{bugunSayisi + 1:D3}";
                }
            }
        }

        public void SilSiparis(string connectionString, int siparisId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmdDetay = new SqlCommand(
                            "DELETE FROM SiparisDetay WHERE SiparisID = @ID",
                            conn,
                            transaction))
                        {
                            cmdDetay.Parameters.AddWithValue("@ID", siparisId);
                            cmdDetay.ExecuteNonQuery();
                        }

                        using (SqlCommand cmdAna = new SqlCommand(
                            "DELETE FROM Siparisler WHERE SiparisID = @ID",
                            conn,
                            transaction))
                        {
                            cmdAna.Parameters.AddWithValue("@ID", siparisId);
                            cmdAna.ExecuteNonQuery();
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

        private bool TeslimTarihiKolonuVarMi(SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME=@T AND COLUMN_NAME=@C",
                conn))
            {
                cmd.Parameters.AddWithValue("@T", "SiparisDetay");
                cmd.Parameters.AddWithValue("@C", "TeslimTarihi");
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private static void DetaylariKaydet(
            SqlConnection conn,
            SqlTransaction transaction,
            int siparisId,
            List<LazerSiparisDetaySatiri> detaylar,
            bool teslimKolonuVar)
        {
            string detayQ = teslimKolonuVar
                ? @"INSERT INTO SiparisDetay (SiparisID, UrunID, SiparisAdedi, Durum, TeslimTarihi)
                    VALUES (@SiparisID, @UrunID, @Adet, 'Beklemede', @TeslimTarihi)"
                : @"INSERT INTO SiparisDetay (SiparisID, UrunID, SiparisAdedi, Durum)
                    VALUES (@SiparisID, @UrunID, @Adet, 'Beklemede')";

            foreach (LazerSiparisDetaySatiri detay in detaylar)
            {
                using (SqlCommand cmd = new SqlCommand(detayQ, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@SiparisID", siparisId);
                    cmd.Parameters.AddWithValue("@UrunID", detay.UrunID);
                    cmd.Parameters.AddWithValue("@Adet", detay.SiparisAdedi);

                    if (teslimKolonuVar)
                    {
                        cmd.Parameters.AddWithValue("@TeslimTarihi",
                            detay.TeslimTarihi.HasValue ? (object)detay.TeslimTarihi.Value : DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
