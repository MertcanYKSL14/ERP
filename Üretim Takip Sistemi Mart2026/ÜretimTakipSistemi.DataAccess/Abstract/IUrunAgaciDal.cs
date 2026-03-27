using System.Collections.Generic;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Abstract
{
    public interface IUrunAgaciDal
    {
        List<UrunAgaciUrunDto> GetUrunAgaci(string connectionString);
        List<UrunAgaciUrunDto> GetTumUrunler(string connectionString);
        void VeritabaniHazirla(string connectionString);
        void KaydetUrunAgaci(string connectionString, UrunAgaciKaydetTalep talep);
        void SilUrunAgaci(string connectionString, int urunId);
        void GuncelleUrunAdi(string connectionString, int urunId, string yeniAd);
        void GuncelleTeknikCizim(string connectionString, int urunId, byte[] teknikCizim);
        byte[] GetTeknikCizim(string connectionString, int urunId);
    }
}
