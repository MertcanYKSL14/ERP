using System;
using System.Data;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoProfilStokEditorDal : IProfilStokEditorDal
    {
        public DataTable GetProfilStoklari(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ProfilStok ORDER BY ProfilEbati", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
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

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ProfilStok", conn))
            using (SqlCommandBuilder cb = new SqlCommandBuilder(da))
            {
                da.Update(dataTable);
            }
        }
    }
}
