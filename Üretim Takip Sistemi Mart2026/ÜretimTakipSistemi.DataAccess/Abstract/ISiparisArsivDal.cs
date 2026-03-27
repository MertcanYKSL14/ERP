using System;
using System.Collections.Generic;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Abstract
{
    public interface ISiparisArsivDal
    {
        List<BitenSiparisKaydi> GetBitenSiparisler(DateTime baslangic, DateTime bitis);
    }
}
