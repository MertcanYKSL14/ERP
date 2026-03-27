using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.EntityFramework
{
    public class EfSiparisDal : EfEntityRepositoryBase<Siparis, SiparisContext>, ISiparisDal
    {
    }
}
