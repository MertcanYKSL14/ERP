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
    }
}
