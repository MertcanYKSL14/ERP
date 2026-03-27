using System.Collections.Generic;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Abstract
{
    public interface ISiparisDurumGecmisiDal
    {
        List<SiparisDurumGecmisi> GetBySiparisId(int siparisId);
        void Add(SiparisDurumGecmisiKayitTalep talep);
    }
}
