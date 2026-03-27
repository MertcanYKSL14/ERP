using System.Collections.Generic;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Abstract
{
    public interface IStokGuncelleDal
    {
        List<StokGuncelleUrunu> GetUrunler();
        StokGuncelleUrunu GetUrunById(int urunId);
        void StokGuncelle(int urunId, int miktar, bool ekle);
    }
}
