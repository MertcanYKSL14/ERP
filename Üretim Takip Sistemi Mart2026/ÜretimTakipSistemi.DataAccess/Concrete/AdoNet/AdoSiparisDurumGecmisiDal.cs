using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoSiparisDurumGecmisiDal : ISiparisDurumGecmisiDal
    {
        public void Add(SiparisDurumGecmisiKayitTalep talep)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SiparisContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("SiparisContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand cmd = baglanti.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO DurumGecmisi
                    (SiparisID, StokNo, UrunAdi, EskiDurum, YeniDurum,
                     DegistirenKullanici, DegisiklikTarihi, UretilenMiktar, Aciklama)
                    VALUES
                    (@siparisID, @stokNo, @urunAdi, @eskiDurum, @yeniDurum,
                     @kullanici, GETDATE(), @miktar, @aciklama)";

                cmd.Parameters.AddWithValue("@siparisID", talep.SiparisID);
                cmd.Parameters.AddWithValue("@stokNo", (object)talep.StokNo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@urunAdi", (object)talep.UrunAdi ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@eskiDurum", (object)talep.EskiDurum ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@yeniDurum", talep.YeniDurum);
                cmd.Parameters.AddWithValue("@kullanici", (object)talep.DegistirenKullanici ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@miktar", talep.UretilenMiktar.HasValue
                    ? (object)talep.UretilenMiktar.Value
                    : DBNull.Value);
                cmd.Parameters.AddWithValue("@aciklama", (object)talep.Aciklama ?? DBNull.Value);

                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<SiparisDurumGecmisi> GetBySiparisId(int siparisId)
        {
            var sonuc = new List<SiparisDurumGecmisi>();
            var connectionString = ConfigurationManager.ConnectionStrings["SiparisContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("SiparisContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand cmd = baglanti.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT
                        EskiDurum,
                        YeniDurum,
                        DegistirenKullanici,
                        DegisiklikTarihi,
                        UretilenMiktar,
                        Aciklama
                    FROM DurumGecmisi
                    WHERE SiparisID = @siparisID
                    ORDER BY DegisiklikTarihi DESC";

                cmd.Parameters.AddWithValue("@siparisID", siparisId);
                baglanti.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sonuc.Add(new SiparisDurumGecmisi
                        {
                            EskiDurum = reader["EskiDurum"]?.ToString(),
                            YeniDurum = reader["YeniDurum"]?.ToString(),
                            DegistirenKullanici = reader["DegistirenKullanici"]?.ToString(),
                            DegisiklikTarihi = Convert.ToDateTime(reader["DegisiklikTarihi"]),
                            UretilenMiktar = reader["UretilenMiktar"] != DBNull.Value
                                ? Convert.ToInt32(reader["UretilenMiktar"])
                                : (int?)null,
                            Aciklama = reader["Aciklama"]?.ToString()
                        });
                    }
                }
            }

            return sonuc;
        }
    }
}
