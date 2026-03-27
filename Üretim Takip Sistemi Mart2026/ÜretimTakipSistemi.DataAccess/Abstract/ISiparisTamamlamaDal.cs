using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Abstract
{
    public interface ISiparisTamamlamaDal
    {
        SiparisTamamlamaSonuc Tamamla(SiparisTamamlamaTalep talep);
    }
}
