using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ÜretimTakipSistemi
{
    class PressTakipDal
    {
        SqlConnection _baglanti = new SqlConnection();

        public List<PressTakip> UrunListele()
        {
            BaglantiKontrol();
            SqlCommand komut = new SqlCommand("Select *From PressTakipSayac", _baglanti);
            SqlDataReader okuma = komut.ExecuteReader();
            List<PressTakip> pressTakip = new List<PressTakip>();
            while (okuma.Read())
            {
                PressTakip pressTakip1 = new PressTakip
                {
                    Id = Convert.ToInt32(okuma["Id"]),
                    PressId = Convert.ToInt32(okuma["PressId"]),
                    DurumId = Convert.ToInt32(okuma["DurumId"]),
                    StokKodu = okuma["StokKodu"].ToString(),
                    StokAdi = okuma["StokAdi"].ToString(),
                    Operasyon = okuma["Operasyon"].ToString(),
                    Adet = Convert.ToInt32(okuma["Adet"].ToString()),
                    Saat = Convert.ToDateTime(okuma["Saat"].ToString()),
                    Tarih = Convert.ToDateTime(okuma["Tarih"].ToString())
                };
                pressTakip.Add(pressTakip1);
            }
            okuma.Close();
            _baglanti.Close();
            return pressTakip;
        }
        public void BaglantiKontrol()
        {
            _baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["UretimTakipSistemiContext"].ConnectionString;
            if (_baglanti.State == ConnectionState.Closed)
            {
                _baglanti.Open();
            }
        }
    }
}
