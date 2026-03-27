using System.Data;
using System.Collections.Generic;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Abstract
{
    public interface ILazerSiparisFormDal
    {
        LazerSiparisDuzenlemeModel GetSiparisDuzenlemeModel(string connectionString, int siparisId);
        List<LazerSiparisUrunSecimItem> GetAktifUrunler(string connectionString);
        LazerSiparisUrunSecimItem GetUrunById(string connectionString, int urunId);
        void KaydetSiparis(string connectionString, LazerSiparisKaydetTalep talep);
        LazerExcelSiparisAktarSonuc AktarExcelSiparisi(string connectionString, LazerExcelSiparisAktarTalep talep);
        DataTable GetSiparisListesi(string connectionString);
        string UretSiparisNo(string connectionString);
        void SilSiparis(string connectionString, int siparisId);
    }
}
