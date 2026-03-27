using System.Data;
using System.Collections.Generic;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.BusinessLogic.Abstract
{
    public interface ILazerUrunFormService
    {
        List<LazerProfilSecenek> GetProfilListesi(string connectionString);
        LazerUrunDuzenlemeModel GetUrunDuzenlemeModel(string connectionString, int urunId);
        void KaydetUrun(string connectionString, LazerUrunKaydetTalep talep);
        List<LazerAltUrunSecimItem> GetAltUrunSecenekleri(string connectionString);
        LazerAltUrunDetay GetAltUrunDetayi(string connectionString, string parcaAdi);
        DataTable GetTumUrunler(string connectionString);
        void UrunuPasifeAl(string connectionString, int urunId);
        DataTable GetBoruLazerUrunleri(string connectionString);
        DataTable GetBoruUrunDetaylari(string connectionString, int urunId);
        DataTable GetProfilStokListesi(string connectionString);
        void GuncelleProfilStok(string connectionString, int profilId, int oncekiStok, int yeniStok);
        DataTable GetSacStokListesi(string connectionString);
        void GuncelleSacStok(string connectionString, int sacId, int oncekiStok, int yeniStok);
        LazerSacStokKaydetSonuc KaydetSacStok(string connectionString, LazerSacStokKaydetTalep talep);
        DataTable GetPlakaLazerUrunleri(string connectionString);
        DataTable GetPlakaUrunDetaylari(string connectionString, int urunId);
        int GetSacStokAdedi(string connectionString, decimal sacKalinligi, decimal sacEbatX, decimal sacEbatY);
        int GetProfilStokAdedi(string connectionString, string profilEbati, decimal profilUzunlugu);
    }
}
