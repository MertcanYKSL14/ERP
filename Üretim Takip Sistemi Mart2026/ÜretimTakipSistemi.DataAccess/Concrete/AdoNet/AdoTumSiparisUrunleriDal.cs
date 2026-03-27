using System;
using System.Data;
using System.Data.SqlClient;
using ÜretimTakipSistemi.DataAccess.Abstract;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoTumSiparisUrunleriDal : ITumSiparisUrunleriDal
    {
        public DataTable GetTumSiparisUrunleri(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand chkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='SiparisDetay' AND COLUMN_NAME='TeslimTarihi'",
                    conn);

                bool teslimKolonuVar = Convert.ToInt32(chkCmd.ExecuteScalar()) > 0;
                string teslimSutun = teslimKolonuVar
                    ? "SD.TeslimTarihi AS 'Teslim Tarihi',"
                    : "NULL AS 'Teslim Tarihi',";

                string query = $@"
                    SELECT 
                        SD.SiparisDetayID,
                        S.SiparisID,
                        S.SiparisNo AS 'Sipariş No',
                        S.Musteri AS 'Müşteri',
                        U.UrunKodu AS 'Ürün Kodu',
                        U.UrunAdi AS 'Ürün Adı',
                        U.LazerTipi AS 'Lazer Tipi',
                        SD.SiparisAdedi AS 'Sipariş Adedi',
                        ISNULL(SD.UretilenAdet,0) AS 'Üretilen Adet',
                        SD.SiparisAdedi - ISNULL(SD.UretilenAdet,0) AS 'Kalan Adet',
                        {teslimSutun}
                        SD.Durum AS 'Durum',
                        CONVERT(VARCHAR(10), S.SiparisTarihi, 103) AS 'Sipariş Tarihi'
                    FROM SiparisDetay SD
                    INNER JOIN Siparisler S ON SD.SiparisID = S.SiparisID
                    INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                    WHERE S.Durum <> 'Tamamlandı'
                    ORDER BY {(teslimKolonuVar ? "SD.TeslimTarihi ASC, " : "")}S.SiparisTarihi ASC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}
