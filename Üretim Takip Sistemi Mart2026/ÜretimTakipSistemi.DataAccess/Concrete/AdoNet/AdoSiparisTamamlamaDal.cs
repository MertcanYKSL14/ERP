using System;
using System.Configuration;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoSiparisTamamlamaDal : ISiparisTamamlamaDal
    {
        public SiparisTamamlamaSonuc Tamamla(SiparisTamamlamaTalep talep)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SiparisContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("SiparisContext baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                using (SqlTransaction trans = baglanti.BeginTransaction())
                {
                    try
                    {
                        string bitenEkleSorgu = @"
                            INSERT INTO BitenSiparisler
                            (StokNo, MusteriAdi, ParcaAdi, Bolum, SiparisAdeti, Durum, KayitTarihi, SiparisNotu, TamamlanmaTarihi, UretilenMiktar)
                            SELECT
                                StokNo, MusteriAdi, ParcaAdi, Bolum, @uretilenAdet, 'Tamamlandı', KayitTarihi, SiparisNotu, GETDATE(), @uretilenAdet
                            FROM Siparisler WHERE SiparisID = @id";

                        using (SqlCommand cmd = new SqlCommand(bitenEkleSorgu, baglanti, trans))
                        {
                            cmd.Parameters.AddWithValue("@id", talep.SiparisID);
                            cmd.Parameters.AddWithValue("@uretilenAdet", talep.UretilenAdet);
                            cmd.ExecuteNonQuery();
                        }

                        int kalanAdet = talep.SiparisAdeti - talep.UretilenAdet;
                        string siparisGuncelleSorgu;
                        string yeniDurum;
                        string aciklama;

                        if (kalanAdet > 0)
                        {
                            siparisGuncelleSorgu = "UPDATE Siparisler SET SiparisAdeti = @yeniAdet, Durum = 'Beklemede' WHERE SiparisID = @id";
                            yeniDurum = "Beklemede";
                            aciklama = $"{talep.UretilenAdet} adet üretildi. {kalanAdet} adet için sipariş beklemeye alındı.";
                        }
                        else
                        {
                            siparisGuncelleSorgu = "UPDATE Siparisler SET SiparisAdeti = 0, Durum = 'Tamamlandı' WHERE SiparisID = @id";
                            yeniDurum = "Tamamlandı";
                            aciklama = $"Siparişin tamamı ({talep.UretilenAdet} adet) üretildi ve stoktan düşüldü.";
                        }

                        using (SqlCommand cmd = new SqlCommand(siparisGuncelleSorgu, baglanti, trans))
                        {
                            cmd.Parameters.AddWithValue("@id", talep.SiparisID);
                            if (kalanAdet > 0)
                            {
                                cmd.Parameters.AddWithValue("@yeniAdet", kalanAdet);
                            }

                            cmd.ExecuteNonQuery();
                        }

                        string gecmisSorgu = @"
                            INSERT INTO DurumGecmisi
                            (SiparisID, StokNo, UrunAdi, EskiDurum, YeniDurum, DegistirenKullanici, DegisiklikTarihi, UretilenMiktar, Aciklama)
                            VALUES
                            (@siparisID, @stokNo, @urunAdi, @eskiDurum, @yeniDurum, @kullanici, GETDATE(), @miktar, @aciklama)";

                        using (SqlCommand cmd = new SqlCommand(gecmisSorgu, baglanti, trans))
                        {
                            cmd.Parameters.AddWithValue("@siparisID", talep.SiparisID);
                            cmd.Parameters.AddWithValue("@stokNo", talep.StokNo);
                            cmd.Parameters.AddWithValue("@urunAdi", talep.UrunAdi);
                            cmd.Parameters.AddWithValue("@eskiDurum", talep.EskiDurum);
                            cmd.Parameters.AddWithValue("@yeniDurum", yeniDurum);
                            cmd.Parameters.AddWithValue("@kullanici", talep.DegistirenKullanici);
                            cmd.Parameters.AddWithValue("@miktar", talep.UretilenAdet);
                            cmd.Parameters.AddWithValue("@aciklama", aciklama);
                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();

                        return new SiparisTamamlamaSonuc
                        {
                            KalanAdet = kalanAdet,
                            YeniDurum = yeniDurum,
                            Aciklama = aciklama
                        };
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
