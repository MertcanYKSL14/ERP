using System.Data;

namespace ÜretimTakipSistemi.BusinessLogic.Abstract
{
    public interface ITumSiparisUrunleriService
    {
        DataTable GetTumSiparisUrunleri(string connectionString);
    }
}
