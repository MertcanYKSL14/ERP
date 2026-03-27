using System.Data;

namespace ÜretimTakipSistemi.DataAccess.Abstract
{
    public interface ITumSiparisUrunleriDal
    {
        DataTable GetTumSiparisUrunleri(string connectionString);
    }
}
