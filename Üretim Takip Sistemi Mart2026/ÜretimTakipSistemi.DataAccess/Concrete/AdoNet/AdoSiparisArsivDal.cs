using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoSiparisArsivDal : ISiparisArsivDal
    {
        public List<BitenSiparisKaydi> GetBitenSiparisler(DateTime baslangic, DateTime bitis)
        {
            var sonuc = new List<BitenSiparisKaydi>();
            var connectionString = ConfigurationManager.ConnectionStrings["SiparisContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("SiparisContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand cmd = baglanti.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT *
                    FROM BitenSiparisler
                    WHERE TamamlanmaTarihi BETWEEN @bas AND @bit
                    ORDER BY TamamlanmaTarihi DESC";

                cmd.Parameters.AddWithValue("@bas", baslangic.Date);
                cmd.Parameters.AddWithValue("@bit", bitis.Date.AddDays(1));

                baglanti.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sonuc.Add(new BitenSiparisKaydi
                        {
                            SiparisID = reader["SiparisID"] != DBNull.Value ? Convert.ToInt32(reader["SiparisID"]) : 0,
                            StokNo = reader["StokNo"]?.ToString(),
                            MusteriAdi = reader["MusteriAdi"]?.ToString(),
                            ParcaAdi = reader["ParcaAdi"]?.ToString(),
                            Bolum = reader["Bolum"]?.ToString(),
                            SiparisAdeti = reader["SiparisAdeti"] != DBNull.Value ? Convert.ToInt32(reader["SiparisAdeti"]) : 0,
                            Durum = reader["Durum"]?.ToString(),
                            KayitTarihi = reader["KayitTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["KayitTarihi"]) : DateTime.MinValue,
                            SiparisNotu = reader["SiparisNotu"]?.ToString(),
                            TamamlanmaTarihi = reader["TamamlanmaTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["TamamlanmaTarihi"]) : DateTime.MinValue,
                            UretimSuresiGun = reader["UretimSuresiGun"] != DBNull.Value ? Convert.ToInt32(reader["UretimSuresiGun"]) : (int?)null,
                            UretilenMiktar = reader["UretilenMiktar"] != DBNull.Value ? Convert.ToInt32(reader["UretilenMiktar"]) : (int?)null
                        });
                    }
                }
            }

            return sonuc;
        }
    }
}
