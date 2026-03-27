using System.Data;

namespace ÜretimTakipSistemi.DataAccess.Abstract
{
    public interface IProfilStokEditorDal
    {
        DataTable GetProfilStoklari(string connectionString);
        void SaveProfilStoklari(string connectionString, DataTable dataTable);
    }
}
