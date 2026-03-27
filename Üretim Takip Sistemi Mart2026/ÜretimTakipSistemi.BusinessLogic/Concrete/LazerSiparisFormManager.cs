using System;
using System.Data;
using System.Collections.Generic;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.BusinessLogic.Concrete
{
    public class LazerSiparisFormManager : ILazerSiparisFormService
    {
        private readonly ILazerSiparisFormDal _lazerSiparisFormDal;

        public LazerSiparisFormManager(ILazerSiparisFormDal lazerSiparisFormDal)
        {
            _lazerSiparisFormDal = lazerSiparisFormDal;
        }

        public LazerSiparisDuzenlemeModel GetSiparisDuzenlemeModel(string connectionString, int siparisId)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (siparisId <= 0)
            {
                throw new InvalidOperationException("Gecerli siparis secilmelidir.");
            }

            return _lazerSiparisFormDal.GetSiparisDuzenlemeModel(connectionString, siparisId);
        }

        public List<LazerSiparisUrunSecimItem> GetAktifUrunler(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            return _lazerSiparisFormDal.GetAktifUrunler(connectionString);
        }

        public LazerSiparisUrunSecimItem GetUrunById(string connectionString, int urunId)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (urunId <= 0)
            {
                throw new InvalidOperationException("Gecerli urun secilmelidir.");
            }

            return _lazerSiparisFormDal.GetUrunById(connectionString, urunId);
        }

        public void KaydetSiparis(string connectionString, LazerSiparisKaydetTalep talep)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (talep == null)
            {
                throw new InvalidOperationException("Kayit bilgisi bulunamadi.");
            }

            if (string.IsNullOrWhiteSpace(talep.SiparisNo))
            {
                throw new InvalidOperationException("Siparis no zorunludur.");
            }

            if (string.IsNullOrWhiteSpace(talep.Musteri))
            {
                throw new InvalidOperationException("Musteri secilmelidir.");
            }

            if (talep.Detaylar == null || talep.Detaylar.Count == 0)
            {
                throw new InvalidOperationException("En az bir urun eklenmelidir.");
            }

            foreach (LazerSiparisDetaySatiri detay in talep.Detaylar)
            {
                if (detay.UrunID <= 0)
                {
                    throw new InvalidOperationException("Gecerli urun secilmelidir.");
                }

                if (detay.SiparisAdedi <= 0)
                {
                    throw new InvalidOperationException("Siparis adedi sifirdan buyuk olmalidir.");
                }
            }

            _lazerSiparisFormDal.KaydetSiparis(connectionString, talep);
        }

        public LazerExcelSiparisAktarSonuc AktarExcelSiparisi(string connectionString, LazerExcelSiparisAktarTalep talep)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (talep == null)
            {
                throw new InvalidOperationException("Aktarim bilgisi bulunamadi.");
            }

            if (string.IsNullOrWhiteSpace(talep.SiparisNo))
            {
                throw new InvalidOperationException("Siparis no olusturulamadi.");
            }

            if (string.IsNullOrWhiteSpace(talep.Musteri))
            {
                throw new InvalidOperationException("Musteri bilgisi zorunludur.");
            }

            if (talep.Satirlar == null || talep.Satirlar.Count == 0)
            {
                throw new InvalidOperationException("Aktarilacak satir bulunamadi.");
            }

            return _lazerSiparisFormDal.AktarExcelSiparisi(connectionString, talep);
        }

        public DataTable GetSiparisListesi(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            return _lazerSiparisFormDal.GetSiparisListesi(connectionString);
        }

        public string UretSiparisNo(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            return _lazerSiparisFormDal.UretSiparisNo(connectionString);
        }

        public void SilSiparis(string connectionString, int siparisId)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (siparisId <= 0)
            {
                throw new InvalidOperationException("Gecerli siparis secilmelidir.");
            }

            _lazerSiparisFormDal.SilSiparis(connectionString, siparisId);
        }
    }
}
