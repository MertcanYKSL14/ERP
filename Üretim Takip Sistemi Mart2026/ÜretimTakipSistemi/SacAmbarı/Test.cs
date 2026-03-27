using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ÜretimTakipSistemi.SacAmbarı;
using ClosedXML;
using ClosedXML.Excel;

namespace ÜretimTakipSistemi.SacAmbarı
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=CNC; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();

 
        private void Test_Tablo()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from tbl_CNC_Giris_Log ", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Test_Tablosu.DataSource = tablo;
            baglanti.Close();
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Test_Tablo();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string searchTerm = textBox1.Text.Trim();  // Kullanıcıdan alınan arama terimi
            // DataGridView'deki her satırı kontrol ediyoruz
            foreach (DataGridViewRow row in Test_Tablosu.Rows)
            {
                // Yeni satır (DataGridView'in son satırı) ise, göz ardı et
                if (row.IsNewRow)
                {
                    continue;
                }

                bool rowMatches = false; // Satırın arama terimiyle eşleşip eşleşmediğini kontrol etmek için

                // Her hücreyi kontrol et, arama terimi içeriyorsa satırı göster
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchTerm.ToLower()))
                    {
                        rowMatches = true;  // Satırda eşleşme buldu
                        textBox1.Text = "";
                        break;  // Eşleşme bulduktan sonra başka hücreleri kontrol etmeye gerek yok
                    }
                }

                // Eşleşen satır varsa, göster; yoksa gizle
                row.Visible = rowMatches;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Test_Tablo();
            textBox1.Text = "";
            //sıfırlama kodları
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UrunAgaciApp yeni = new UrunAgaciApp();
            yeni.Show();

        }
        private void btnExcelAktar_Click(object sender, EventArgs e)
        {
            try
            {
                string sablonYolu = Application.StartupPath + @"\DENEMEPROFILLAZERSİPARİSLİSTESİDENEME.xlsx";
                string yeniDosyaAdi = "Siparis_Listesi_" + DateTime.Now.ToString("dd_MM_yyyy_HHmm") + ".xlsx";

                using (var workbook = new XLWorkbook(sablonYolu))
                {
                    var worksheet = workbook.Worksheet(1);
                    int excelSatir = 2; // Verilerin başlayacağı satır

                    // SQL bağlantısını açıyoruz
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                    foreach (DataGridViewRow row in dgwSacAmbariUrunler.Rows)
                    {
                        if (row.Cells["StokKodu"].Value != null && !row.IsNewRow)
                        {
                            string stokKodu = row.Cells["StokKodu"].Value.ToString();
                            string miktar = row.Cells["Miktar"].Value.ToString();
                            string dogruStokAdi = "";

                            // SQL'den güncel Stok Adını çekiyoruz
                            // Not: Tablo adınızın 'SacAmbariStokListesi' olduğunu varsaydım
                            using (SqlCommand sqlKomut = new SqlCommand("SELECT TOP 1 StokAdi FROM SacAmbariStokListesi WHERE StokKodu = @p1", baglanti))
                            {
                                sqlKomut.Parameters.AddWithValue("@p1", stokKodu);
                                object sonuc = sqlKomut.ExecuteScalar();
                                dogruStokAdi = (sonuc != null) ? sonuc.ToString() : "STOK BULUNAMADI!";
                            }

                            // Excel Sütun Eşleşmeleri:
                            // B (2) -> Stok Kodu
                            // C (3) -> SQL'den Gelen Doğru Stok Adı
                            // D (4) -> DataGridView'deki Adet (Miktar)
                            worksheet.Cell(excelSatir, 2).Value = stokKodu;
                            worksheet.Cell(excelSatir, 3).Value = dogruStokAdi;
                            worksheet.Cell(excelSatir, 4).Value = miktar;

                            excelSatir++;
                        }
                    }

                    baglanti.Close();
                    workbook.SaveAs(yeniDosyaAdi);
                }

                MessageBox.Show("Sipariş listesi SQL verileriyle doğrulandı ve oluşturuldu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(yeniDosyaAdi);
            }
            catch (Exception ex)
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
                MessageBox.Show("Hata: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
