using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoSiparisChatDal : ISiparisChatDal
    {
        public void DosyaGonder(string gonderen, string dosyaAdi, byte[] dosyaVerisi)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SiparisContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("SiparisContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand komut = baglanti.CreateCommand())
            {
                komut.CommandText = @"INSERT INTO FabrikaChat (Gonderen, Mesaj, DosyaVerisi, DosyaAdi)
                                      VALUES (@gonderen, @mesaj, @dosyaVerisi, @dosyaAdi)";
                komut.Parameters.AddWithValue("@gonderen", gonderen);
                komut.Parameters.AddWithValue("@mesaj", "[Dosya Paylaşıldı]");
                komut.Parameters.AddWithValue("@dosyaVerisi", dosyaVerisi);
                komut.Parameters.AddWithValue("@dosyaAdi", dosyaAdi);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }

        public void MesajGonder(string gonderen, string mesaj)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SiparisContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("SiparisContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand komut = baglanti.CreateCommand())
            {
                komut.CommandText = "INSERT INTO FabrikaChat (Gonderen, Mesaj) VALUES (@gonderen, @mesaj)";
                komut.Parameters.AddWithValue("@gonderen", gonderen);
                komut.Parameters.AddWithValue("@mesaj", mesaj);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }

        public void MesajSil(int mesajId)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SiparisContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("SiparisContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand komut = baglanti.CreateCommand())
            {
                komut.CommandText = "UPDATE FabrikaChat SET Silindi = 1 WHERE ID = @id";
                komut.Parameters.AddWithValue("@id", mesajId);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }

        public List<SiparisChatMesaji> GetMesajlar(int sonMesajId)
        {
            var sonuc = new List<SiparisChatMesaji>();
            var connectionString = ConfigurationManager.ConnectionStrings["SiparisContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("SiparisContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand komut = baglanti.CreateCommand())
            {
                komut.CommandText = @"
                    SELECT ID, Gonderen, Mesaj, Tarih, DosyaAdi, DosyaVerisi
                    FROM FabrikaChat
                    WHERE ID > @sonID AND Silindi = 0
                    ORDER BY ID ASC";

                komut.Parameters.AddWithValue("@sonID", sonMesajId);
                baglanti.Open();

                using (SqlDataReader oku = komut.ExecuteReader())
                {
                    while (oku.Read())
                    {
                        sonuc.Add(new SiparisChatMesaji
                        {
                            Id = Convert.ToInt32(oku["ID"]),
                            Gonderen = oku["Gonderen"]?.ToString(),
                            Mesaj = oku["Mesaj"]?.ToString(),
                            Tarih = Convert.ToDateTime(oku["Tarih"]),
                            DosyaAdi = oku["DosyaAdi"] == DBNull.Value ? null : oku["DosyaAdi"].ToString(),
                            DosyaVerisi = oku["DosyaVerisi"] == DBNull.Value ? null : (byte[])oku["DosyaVerisi"]
                        });
                    }
                }
            }

            return sonuc;
        }
    }
}
