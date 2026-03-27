using System;
using System.Configuration;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoSiparisArsivlemeDal : ISiparisArsivlemeDal
    {
        public int ArsivleTamamlananSiparisler()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SiparisContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("SiparisContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                string query = @"
                    INSERT INTO BitenSiparisler (SiparisID, StokNo, MusteriAdi, ParcaAdi, Bolum, SiparisAdeti, Durum, KayitTarihi, SiparisNotu, TamamlanmaTarihi, UretimSuresiGun)
                    SELECT SiparisID, StokNo, MusteriAdi, ParcaAdi, Bolum, SiparisAdeti, Durum, KayitTarihi, SiparisNotu, GETDATE(), DATEDIFF(day, KayitTarihi, GETDATE())
                    FROM Siparisler WHERE Durum = 'Tamamlandı';

                    DELETE FROM Siparisler WHERE Durum = 'Tamamlandı';";

                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                {
                    int etkilenenKayit = cmd.ExecuteNonQuery();
                    return etkilenenKayit > 0 ? etkilenenKayit / 2 : 0;
                }
            }
        }
    }
}
