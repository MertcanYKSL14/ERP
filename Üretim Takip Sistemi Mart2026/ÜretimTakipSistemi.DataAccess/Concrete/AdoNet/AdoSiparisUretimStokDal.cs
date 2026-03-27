using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoSiparisUretimStokDal : ISiparisUretimStokDal
    {
        public void UretimStoklariniGuncelle(string stokNo, int uretilenAdet)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UrunAgaciContext"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("UrunAgaciContext baglanti bilgisi bulunamadi.");
            }

            SqlTransaction urunAgaciTransaction = null;

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open();
                    urunAgaciTransaction = baglanti.BeginTransaction();

                    string sorgu = "SELECT UrunID FROM Urunler WHERE UrunKodu = @stokNo";
                    SqlCommand cmd = new SqlCommand(sorgu, baglanti, urunAgaciTransaction);
                    cmd.Parameters.AddWithValue("@stokNo", stokNo);

                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        urunAgaciTransaction.Rollback();
                        throw new InvalidOperationException($"Stok No '{stokNo}' ürünler tablosunda bulunamadı.");
                    }

                    int anaUrunID = Convert.ToInt32(result);

                    sorgu = "SELECT COUNT(*) FROM UrunAgaci WHERE AnaUrunID = @anaUrunID";
                    cmd = new SqlCommand(sorgu, baglanti, urunAgaciTransaction);
                    cmd.Parameters.AddWithValue("@anaUrunID", anaUrunID);

                    int altUrunSayisi = Convert.ToInt32(cmd.ExecuteScalar());

                    if (altUrunSayisi > 0)
                    {
                        sorgu = @"SELECT AltUrunID, Miktar FROM UrunAgaci WHERE AnaUrunID = @anaUrunID ORDER BY SiraNo";
                        cmd = new SqlCommand(sorgu, baglanti, urunAgaciTransaction);
                        cmd.Parameters.AddWithValue("@anaUrunID", anaUrunID);

                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable altUrunler = new DataTable();
                        altUrunler.Load(reader);

                        foreach (DataRow row in altUrunler.Rows)
                        {
                            int altUrunID = Convert.ToInt32(row["AltUrunID"]);
                            decimal altUrunMiktar = Convert.ToDecimal(row["Miktar"]);
                            decimal dusulecekMiktar = altUrunMiktar * uretilenAdet;

                            sorgu = @"UPDATE Urunler
                                     SET StokMiktari = StokMiktari - @miktar
                                     WHERE UrunID = @urunID";

                            SqlCommand updateCmd = new SqlCommand(sorgu, baglanti, urunAgaciTransaction);
                            updateCmd.Parameters.AddWithValue("@miktar", dusulecekMiktar);
                            updateCmd.Parameters.AddWithValue("@urunID", altUrunID);
                            updateCmd.ExecuteNonQuery();
                        }

                        sorgu = @"UPDATE Urunler
                                 SET StokMiktari = StokMiktari + @miktar
                                 WHERE UrunID = @urunID";

                        cmd = new SqlCommand(sorgu, baglanti, urunAgaciTransaction);
                        cmd.Parameters.AddWithValue("@miktar", uretilenAdet);
                        cmd.Parameters.AddWithValue("@urunID", anaUrunID);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        sorgu = @"UPDATE Urunler
                                 SET StokMiktari = StokMiktari - @miktar
                                 WHERE UrunID = @urunID";

                        cmd = new SqlCommand(sorgu, baglanti, urunAgaciTransaction);
                        cmd.Parameters.AddWithValue("@miktar", uretilenAdet);
                        cmd.Parameters.AddWithValue("@urunID", anaUrunID);
                        cmd.ExecuteNonQuery();
                    }

                    urunAgaciTransaction.Commit();
                }
                catch
                {
                    if (urunAgaciTransaction != null)
                    {
                        urunAgaciTransaction.Rollback();
                    }

                    throw;
                }
            }
        }
    }
}
