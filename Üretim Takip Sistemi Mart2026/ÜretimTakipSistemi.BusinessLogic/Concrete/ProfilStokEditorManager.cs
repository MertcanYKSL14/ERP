using System;
using System.Data;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.DataAccess.Abstract;

namespace ÜretimTakipSistemi.BusinessLogic.Concrete
{
    public class ProfilStokEditorManager : IProfilStokEditorService
    {
        private readonly IProfilStokEditorDal _profilStokEditorDal;

        public ProfilStokEditorManager(IProfilStokEditorDal profilStokEditorDal)
        {
            _profilStokEditorDal = profilStokEditorDal;
        }

        public DataTable GetProfilStoklari(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            DataTable dt = _profilStokEditorDal.GetProfilStoklari(connectionString);

            if (dt.Columns.Contains("KayitTarihi"))
            {
                dt.Columns["KayitTarihi"].DefaultValue = DateTime.Now;
            }

            if (dt.Columns.Contains("GuncellemeTarihi"))
            {
                dt.Columns["GuncellemeTarihi"].DefaultValue = DateTime.Now;
            }

            if (dt.Columns.Contains("StokAdedi"))
            {
                dt.Columns["StokAdedi"].DefaultValue = 0;
            }

            if (dt.Columns.Contains("MinimumStok"))
            {
                dt.Columns["MinimumStok"].DefaultValue = 10;
            }

            return dt;
        }

        public void SaveProfilStoklari(string connectionString, DataTable dataTable)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (dataTable == null)
            {
                throw new InvalidOperationException("Kaydedilecek veri bulunamadi.");
            }

            foreach (DataRow row in dataTable.Rows)
            {
                if (row.RowState == DataRowState.Modified && dataTable.Columns.Contains("GuncellemeTarihi"))
                {
                    row["GuncellemeTarihi"] = DateTime.Now;
                }
            }

            _profilStokEditorDal.SaveProfilStoklari(connectionString, dataTable);
        }
    }
}
