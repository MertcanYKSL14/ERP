using System.Collections.Generic;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Abstract
{
    public interface ISiparisIhtiyacDal
    {
        List<SiparisIhtiyacSonuc> GetIhtiyacListesi(List<SiparisIhtiyacTalep> talepler);
    }
}
