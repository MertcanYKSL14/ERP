using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoLazerSiparisDetayDal : ILazerSiparisDetayDal
    {
        public LazerSiparisDetayBaslik GetSiparisBaslik(string connectionString, int siparisId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT SiparisNo, Musteri,
                                        CONVERT(VARCHAR(10), SiparisTarihi, 103) AS SiparisTarihi,
                                        CONVERT(VARCHAR(10), TeslimTarihi, 103) AS TeslimTarihi,
                                        Durum, Aciklama
                                 FROM Siparisler
                                 WHERE SiparisID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", siparisId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        return new LazerSiparisDetayBaslik
                        {
                            SiparisNo = reader["SiparisNo"].ToString(),
                            Musteri = reader["Musteri"].ToString(),
                            SiparisTarihiText = reader["SiparisTarihi"].ToString(),
                            TeslimTarihiText = reader["TeslimTarihi"] == DBNull.Value ? string.Empty : reader["TeslimTarihi"].ToString(),
                            Durum = reader["Durum"].ToString(),
                            Aciklama = reader["Aciklama"] == DBNull.Value ? string.Empty : reader["Aciklama"].ToString()
                        };
                    }
                }
            }
        }

        public DataTable GetSiparisDetaylari(string connectionString, int siparisId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT
                                    SD.SiparisDetayID,
                                    U.UrunKodu AS 'Ürün Kodu',
                                    U.UrunAdi AS 'Ürün Adı',
                                    U.LazerTipi AS 'Lazer Tipi',
                                    SD.SiparisAdedi AS 'Sipariş Adedi',
                                    ISNULL(SD.UretilenAdet, 0) AS 'Üretilen Adet',
                                    (SD.SiparisAdedi - ISNULL(SD.UretilenAdet, 0)) AS 'Kalan Adet',
                                    SD.Durum AS 'Durum',
                                    CAST(CASE
                                        WHEN ISNULL(SD.UretilenAdet, 0) = 0 THEN 0
                                        ELSE (CAST(SD.UretilenAdet AS FLOAT) / SD.SiparisAdedi * 100)
                                    END AS DECIMAL(5,1)) AS 'Tamamlanma %'
                                 FROM SiparisDetay SD
                                 INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                                 WHERE SD.SiparisID = @SiparisID";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@SiparisID", siparisId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public List<LazerProfilOptimizasyonUrunu> GetProfilOptimizasyonUrunleri(string connectionString, int siparisId)
        {
            List<LazerProfilOptimizasyonUrunu> urunler = new List<LazerProfilOptimizasyonUrunu>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string anaQuery = @"SELECT U.UrunKodu, U.UrunAdi, U.UrunBoyu, U.ProfilEbati, SD.SiparisAdedi,
                                          PS.ProfilUzunlugu
                                   FROM SiparisDetay SD
                                   INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                                   LEFT JOIN ProfilStok PS ON U.ProfilEbati = PS.ProfilEbati
                                   WHERE SD.SiparisID = @SiparisID
                                   AND U.LazerTipi = 'Boru'
                                   AND U.GrupluUrunMu = 0
                                   AND U.UrunBoyu IS NOT NULL";

                using (SqlCommand anaCmd = new SqlCommand(anaQuery, conn))
                {
                    anaCmd.Parameters.AddWithValue("@SiparisID", siparisId);

                    using (SqlDataReader anaReader = anaCmd.ExecuteReader())
                    {
                        while (anaReader.Read())
                        {
                            decimal profilUzunlugu = anaReader["ProfilUzunlugu"] == DBNull.Value
                                ? 6000m
                                : Convert.ToDecimal(anaReader["ProfilUzunlugu"]);

                            urunler.Add(new LazerProfilOptimizasyonUrunu
                            {
                                UrunKodu = anaReader["UrunKodu"].ToString(),
                                UrunAdi = anaReader["UrunAdi"].ToString(),
                                UrunBoyu = Convert.ToDecimal(anaReader["UrunBoyu"]),
                                ProfilEbati = anaReader["ProfilEbati"] == DBNull.Value ? string.Empty : anaReader["ProfilEbati"].ToString(),
                                ProfilUzunlugu = profilUzunlugu,
                                Adet = Convert.ToInt32(anaReader["SiparisAdedi"])
                            });
                        }
                    }
                }

                string grupluQuery = @"SELECT UDB.ParcaAdi, UDB.UrunBoyu, UDB.ProfilEbati,
                                              (UDB.Adet * SD.SiparisAdedi) AS ToplamAdet,
                                              U.UrunKodu,
                                              PS.ProfilUzunlugu
                                       FROM SiparisDetay SD
                                       INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                                       INNER JOIN UrunDetayBoru UDB ON U.UrunID = UDB.UrunID
                                       LEFT JOIN ProfilStok PS ON UDB.ProfilEbati = PS.ProfilEbati
                                       WHERE SD.SiparisID = @SiparisID
                                       AND U.LazerTipi = 'Boru'
                                       AND U.GrupluUrunMu = 1";

                using (SqlCommand grupluCmd = new SqlCommand(grupluQuery, conn))
                {
                    grupluCmd.Parameters.AddWithValue("@SiparisID", siparisId);

                    using (SqlDataReader grupluReader = grupluCmd.ExecuteReader())
                    {
                        while (grupluReader.Read())
                        {
                            decimal profilUzunlugu = grupluReader["ProfilUzunlugu"] == DBNull.Value
                                ? 6000m
                                : Convert.ToDecimal(grupluReader["ProfilUzunlugu"]);

                            urunler.Add(new LazerProfilOptimizasyonUrunu
                            {
                                UrunKodu = grupluReader["UrunKodu"].ToString() + " - " + grupluReader["ParcaAdi"].ToString(),
                                UrunAdi = grupluReader["ParcaAdi"].ToString(),
                                UrunBoyu = Convert.ToDecimal(grupluReader["UrunBoyu"]),
                                ProfilEbati = grupluReader["ProfilEbati"] == DBNull.Value ? string.Empty : grupluReader["ProfilEbati"].ToString(),
                                ProfilUzunlugu = profilUzunlugu,
                                Adet = Convert.ToInt32(grupluReader["ToplamAdet"])
                            });
                        }
                    }
                }
            }

            return urunler;
        }

        public void GuncelleUretimBilgisi(string connectionString, LazerSiparisDetayGuncelleTalep talep)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string updateDetayQuery = @"UPDATE SiparisDetay
                                                   SET UretilenAdet = @UretilenAdet,
                                                       Durum = @Durum,
                                                       GuncellemeTarihi = GETDATE()
                                                   WHERE SiparisDetayID = @ID";

                        using (SqlCommand cmd = new SqlCommand(updateDetayQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UretilenAdet", talep.UretilenAdet);
                            cmd.Parameters.AddWithValue("@Durum", talep.Durum);
                            cmd.Parameters.AddWithValue("@ID", talep.SiparisDetayId);
                            cmd.ExecuteNonQuery();
                        }

                        string yeniDurum = HesaplaSiparisDurumu(conn, transaction, talep.SiparisId);

                        using (SqlCommand updateSiparisCmd = new SqlCommand(
                            "UPDATE Siparisler SET Durum = @Durum WHERE SiparisID = @ID",
                            conn,
                            transaction))
                        {
                            updateSiparisCmd.Parameters.AddWithValue("@Durum", yeniDurum);
                            updateSiparisCmd.Parameters.AddWithValue("@ID", talep.SiparisId);
                            updateSiparisCmd.ExecuteNonQuery();
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

        private static string HesaplaSiparisDurumu(SqlConnection conn, SqlTransaction transaction, int siparisId)
        {
            using (SqlCommand checkCmd = new SqlCommand(
                @"SELECT COUNT(*)
                  FROM SiparisDetay
                  WHERE SiparisID = @ID AND Durum != 'Tamamlandı'",
                conn,
                transaction))
            {
                checkCmd.Parameters.AddWithValue("@ID", siparisId);
                int tamamlanmayanSayisi = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (tamamlanmayanSayisi == 0)
                {
                    return "Tamamlandı";
                }
            }

            using (SqlCommand uretimdeCmd = new SqlCommand(
                @"SELECT COUNT(*)
                  FROM SiparisDetay
                  WHERE SiparisID = @ID AND Durum = 'Üretimde'",
                conn,
                transaction))
            {
                uretimdeCmd.Parameters.AddWithValue("@ID", siparisId);
                int uretimdeSayisi = Convert.ToInt32(uretimdeCmd.ExecuteScalar());
                return uretimdeSayisi > 0 ? "Üretimde" : "Beklemede";
            }
        }
    }
}
