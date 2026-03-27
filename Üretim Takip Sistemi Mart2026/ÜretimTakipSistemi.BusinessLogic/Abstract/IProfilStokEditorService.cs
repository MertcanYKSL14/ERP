using System.Data;

namespace ÜretimTakipSistemi.BusinessLogic.Abstract
{
    public interface IProfilStokEditorService
    {
        DataTable GetProfilStoklari(string connectionString);
        void SaveProfilStoklari(string connectionString, DataTable dataTable);
    }
}
