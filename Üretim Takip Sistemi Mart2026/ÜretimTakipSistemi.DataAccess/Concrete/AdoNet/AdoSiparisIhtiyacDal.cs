using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoSiparisIhtiyacDal : ISiparisIhtiyacDal
    {
        public List<SiparisIhtiyacSonuc> GetIhtiyacListesi(List<SiparisIhtiyacTalep> talepler)
        {
            var sonuc = new List<SiparisIhtiyacSonuc>();
            var connectionString = ConfigurationManager.ConnectionStrings["SiparisContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("SiparisContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                foreach (var talep in talepler)
                {
                    string sorgu = @"
                        SELECT 
                            ALT.UrunKodu, 
                            ALT.UrunAdi, 
                            UA.Miktar AS BirimSarfiyat,
                            (@adet * UA.Miktar) AS ToplamIhtiyac,
                            ALT.StokMiktari AS MevcutStok,
                            (ALT.StokMiktari - (@adet * UA.Miktar)) AS KalanStok
                        FROM [UrunAgaciDB].[dbo].[UrunAgaci] UA
                        INNER JOIN [UrunAgaciDB].[dbo].[Urunler] UST ON UA.AnaUrunID = UST.UrunID
                        INNER JOIN [UrunAgaciDB].[dbo].[Urunler] ALT ON UA.AltUrunID = ALT.UrunID
                        WHERE UST.UrunKodu = @kod
                        UNION ALL
                        SELECT 
                            U.UrunKodu, 
                            U.UrunAdi, 
                            1 AS BirimSarfiyat,
                            @adet AS ToplamIhtiyac,
                            U.StokMiktari AS MevcutStok,
                            (U.StokMiktari - @adet) AS KalanStok
                        FROM [UrunAgaciDB].[dbo].[Urunler] U
                        WHERE U.UrunKodu = @kod 
                        AND NOT EXISTS (SELECT 1 FROM [UrunAgaciDB].[dbo].[UrunAgaci] UA WHERE UA.AnaUrunID = U.UrunID)";

                    using (SqlCommand cmd = new SqlCommand(sorgu, baglanti))
                    {
                        cmd.Parameters.AddWithValue("@kod", talep.StokNo);
                        cmd.Parameters.AddWithValue("@adet", talep.Adet);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                string urunKodu = row["UrunKodu"].ToString();
                                var mevcut = sonuc.FirstOrDefault(x => x.UrunKodu == urunKodu);

                                if (mevcut != null)
                                {
                                    mevcut.ToplamIhtiyac += Convert.ToDecimal(row["ToplamIhtiyac"]);
                                    mevcut.KalanStok = mevcut.MevcutStok - mevcut.ToplamIhtiyac;
                                }
                                else
                                {
                                    sonuc.Add(new SiparisIhtiyacSonuc
                                    {
                                        UrunKodu = urunKodu,
                                        UrunAdi = row["UrunAdi"].ToString(),
                                        BirimSarfiyat = Convert.ToDecimal(row["BirimSarfiyat"]),
                                        ToplamIhtiyac = Convert.ToDecimal(row["ToplamIhtiyac"]),
                                        MevcutStok = Convert.ToDecimal(row["MevcutStok"]),
                                        KalanStok = Convert.ToDecimal(row["KalanStok"])
                                    });
                                }
                            }
                        }
                    }
                }
            }

            foreach (var item in sonuc)
            {
                decimal stokOrani = item.MevcutStok > 0 ? (item.KalanStok / item.MevcutStok) * 100 : 0;

                if (item.KalanStok < 0)
                {
                    item.Durum = "EKSIK";
                    item.Aciliyet = "KRITIK";
                }
                else if (stokOrani < 30)
                {
                    item.Durum = "AZ";
                    item.Aciliyet = "YUKSEK";
                }
                else if (stokOrani < 60)
                {
                    item.Durum = "ORTA";
                    item.Aciliyet = "ORTA";
                }
                else
                {
                    item.Durum = "YETERLI";
                    item.Aciliyet = "DUSUK";
                }
            }

            return sonuc;
        }
    }
}
