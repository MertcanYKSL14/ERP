using System.Collections.Generic;
using System.Data;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.BusinessLogic.Abstract
{
    public interface ILazerSiparisDetayService
    {
        LazerSiparisDetayBaslik GetSiparisBaslik(string connectionString, int siparisId);
        DataTable GetSiparisDetaylari(string connectionString, int siparisId);
        List<LazerProfilOptimizasyonUrunu> GetProfilOptimizasyonUrunleri(string connectionString, int siparisId);
        void GuncelleUretimBilgisi(string connectionString, LazerSiparisDetayGuncelleTalep talep);
    }
}
