using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoStokGuncelleDal : IStokGuncelleDal
    {
        public List<StokGuncelleUrunu> GetUrunler()
        {
            var urunler = new List<StokGuncelleUrunu>();
            string connectionString = ConfigurationManager.ConnectionStrings["UrunAgaciContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("UrunAgaciContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand cmd = baglanti.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT UrunID, UrunKodu, UrunAdi, StokMiktari
                    FROM Urunler
                    ORDER BY UrunKodu ASC";

                baglanti.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        urunler.Add(new StokGuncelleUrunu
                        {
                            UrunID = reader["UrunID"] != DBNull.Value ? Convert.ToInt32(reader["UrunID"]) : 0,
                            UrunKodu = reader["UrunKodu"]?.ToString(),
                            UrunAdi = reader["UrunAdi"]?.ToString(),
                            StokMiktari = reader["StokMiktari"] != DBNull.Value ? Convert.ToInt32(reader["StokMiktari"]) : 0
                        });
                    }
                }
            }

            return urunler;
        }

        public StokGuncelleUrunu GetUrunById(int urunId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UrunAgaciContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("UrunAgaciContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand cmd = baglanti.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT UrunID, UrunKodu, UrunAdi, StokMiktari
                    FROM Urunler
                    WHERE UrunID = @id";

                cmd.Parameters.AddWithValue("@id", urunId);
                baglanti.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new StokGuncelleUrunu
                    {
                        UrunID = reader["UrunID"] != DBNull.Value ? Convert.ToInt32(reader["UrunID"]) : 0,
                        UrunKodu = reader["UrunKodu"]?.ToString(),
                        UrunAdi = reader["UrunAdi"]?.ToString(),
                        StokMiktari = reader["StokMiktari"] != DBNull.Value ? Convert.ToInt32(reader["StokMiktari"]) : 0
                    };
                }
            }
        }

        public void StokGuncelle(int urunId, int miktar, bool ekle)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UrunAgaciContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("UrunAgaciContext baglanti bilgisi bulunamadi.");
            }

            string operatorIsareti = ekle ? "+" : "-";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand cmd = baglanti.CreateCommand())
            {
                cmd.CommandText = $@"
                    UPDATE Urunler
                    SET StokMiktari = StokMiktari {operatorIsareti} @miktar
                    WHERE UrunID = @id";

                cmd.Parameters.AddWithValue("@miktar", miktar);
                cmd.Parameters.AddWithValue("@id", urunId);

                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
