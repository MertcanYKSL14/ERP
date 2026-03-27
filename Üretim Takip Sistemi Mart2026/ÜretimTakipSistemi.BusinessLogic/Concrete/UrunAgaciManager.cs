using System;
using System.Collections.Generic;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.BusinessLogic.Concrete
{
    public class UrunAgaciManager : IUrunAgaciService
    {
        private readonly IUrunAgaciDal _urunAgaciDal;

        public UrunAgaciManager(IUrunAgaciDal urunAgaciDal)
        {
            _urunAgaciDal = urunAgaciDal;
        }

        public List<UrunAgaciUrunDto> GetUrunAgaci(string connectionString)
        {
            BaglantiKontrol(connectionString);
            return _urunAgaciDal.GetUrunAgaci(connectionString);
        }

        public List<UrunAgaciUrunDto> GetTumUrunler(string connectionString)
        {
            BaglantiKontrol(connectionString);
            return _urunAgaciDal.GetTumUrunler(connectionString);
        }

        public void VeritabaniHazirla(string connectionString)
        {
            BaglantiKontrol(connectionString);
            _urunAgaciDal.VeritabaniHazirla(connectionString);
        }

        public void KaydetUrunAgaci(string connectionString, UrunAgaciKaydetTalep talep)
        {
            BaglantiKontrol(connectionString);

            if (talep == null)
            {
                throw new InvalidOperationException("Kaydedilecek urun bilgisi bulunamadi.");
            }

            if (string.IsNullOrWhiteSpace(talep.UrunKodu))
            {
                throw new InvalidOperationException("Ana urun kodu zorunludur.");
            }

            if (string.IsNullOrWhiteSpace(talep.UrunAdi))
            {
                throw new InvalidOperationException("Ana urun adi zorunludur.");
            }

            if (talep.AltUrunEklenecek)
            {
                if (string.IsNullOrWhiteSpace(talep.AltUrunKodu))
                {
                    throw new InvalidOperationException("Alt urun kodu zorunludur.");
                }

                if (string.IsNullOrWhiteSpace(talep.AltUrunAdi))
                {
                    throw new InvalidOperationException("Alt urun adi zorunludur.");
                }

                if (talep.Miktar <= 0)
                {
                    throw new InvalidOperationException("Alt urun miktari sifirdan buyuk olmalidir.");
                }
            }

            _urunAgaciDal.KaydetUrunAgaci(connectionString, talep);
        }

        public void SilUrunAgaci(string connectionString, int urunId)
        {
            BaglantiKontrol(connectionString);

            if (urunId <= 0)
            {
                throw new InvalidOperationException("Gecerli bir urun secilmelidir.");
            }

            _urunAgaciDal.SilUrunAgaci(connectionString, urunId);
        }

        public void GuncelleUrunAdi(string connectionString, int urunId, string yeniAd)
        {
            BaglantiKontrol(connectionString);

            if (urunId <= 0)
            {
                throw new InvalidOperationException("Gecerli bir urun secilmelidir.");
            }

            if (string.IsNullOrWhiteSpace(yeniAd))
            {
                throw new InvalidOperationException("Urun adi bos olamaz.");
            }

            _urunAgaciDal.GuncelleUrunAdi(connectionString, urunId, yeniAd.Trim());
        }

        public void GuncelleTeknikCizim(string connectionString, int urunId, byte[] teknikCizim)
        {
            BaglantiKontrol(connectionString);

            if (urunId <= 0)
            {
                throw new InvalidOperationException("Gecerli bir urun secilmelidir.");
            }

            if (teknikCizim == null || teknikCizim.Length == 0)
            {
                throw new InvalidOperationException("Yuklenecek teknik cizim bulunamadi.");
            }

            _urunAgaciDal.GuncelleTeknikCizim(connectionString, urunId, teknikCizim);
        }

        public byte[] GetTeknikCizim(string connectionString, int urunId)
        {
            BaglantiKontrol(connectionString);

            if (urunId <= 0)
            {
                throw new InvalidOperationException("Gecerli bir urun secilmelidir.");
            }

            return _urunAgaciDal.GetTeknikCizim(connectionString, urunId);
        }

        private static void BaglantiKontrol(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }
        }
    }
}
