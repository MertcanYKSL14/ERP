using System.Collections.Generic;
using System.Data;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Abstract
{
    public interface ILazerSiparisDetayDal
    {
        LazerSiparisDetayBaslik GetSiparisBaslik(string connectionString, int siparisId);
        DataTable GetSiparisDetaylari(string connectionString, int siparisId);
        List<LazerProfilOptimizasyonUrunu> GetProfilOptimizasyonUrunleri(string connectionString, int siparisId);
        void GuncelleUretimBilgisi(string connectionString, LazerSiparisDetayGuncelleTalep talep);
    }
}
