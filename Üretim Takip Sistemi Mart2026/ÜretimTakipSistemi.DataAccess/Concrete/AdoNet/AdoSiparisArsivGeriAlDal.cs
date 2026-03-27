using System;
using System.Configuration;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoSiparisArsivGeriAlDal : ISiparisArsivGeriAlDal
    {
        public void GeriAl(int siparisId)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SiparisContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("SiparisContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                string geriSorgu = @"
                    INSERT INTO Siparisler (StokNo, MusteriAdi, ParcaAdi, Bolum, SiparisAdeti, SiparisNotu, Durum, KayitTarihi)
                    SELECT StokNo, MusteriAdi, ParcaAdi, Bolum, SiparisAdeti, SiparisNotu, 'Beklemede', KayitTarihi
                    FROM BitenSiparisler WHERE SiparisID = @id;
                            
                    DELETE FROM BitenSiparisler WHERE SiparisID = @id;";

                using (SqlCommand cmd = new SqlCommand(geriSorgu, baglanti))
                {
                    cmd.Parameters.AddWithValue("@id", siparisId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
