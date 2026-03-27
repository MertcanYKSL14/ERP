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

namespace ÜretimTakipSistemi
{
    public partial class Sevkiyat_Urun_Gecmisi : Form
    {
        public Sevkiyat_Urun_Gecmisi()
        {
            InitializeComponent();
        }
         SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr; 
        DataTable tablo = new DataTable();
      
        private void Sevkiyat_Urun_Giris_Cikis_TümList()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select TOP(300) *from Depo_Yrd_Malzeme_Giris_Cikis_TümList order by ID desc", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Sevkiyat_Urun_Giris_Cikis_Tablosu.DataSource = tablo;
            baglanti.Close();
           
        } // DataBase'den geçmiş kayıtların alınması...
       
        private void Sevkiyat_Urun_Gecmisi_Load(object sender, EventArgs e)
        {
          Sevkiyat_Urun_Giris_Cikis_TümList();
        } // Form yüklendiğinde açılacak ekran...

        private void Detaylı_Arama_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Stok Numarası giriniz...");
            }
            else
            {
                tablo.Clear();
                baglanti.Open();
                adtr = new SqlDataAdapter("Select *From Depo_Yrd_Malzeme_Giris_Cikis_TümList where Stok_Kodu='" + textBox1.Text + "' order by ID desc", baglanti);
                adtr.Fill(tablo);
                Sevkiyat_Urun_Giris_Cikis_Tablosu.DataSource = tablo;
                baglanti.Close();
                textBox1.Clear();
            }
        } // Tüm geçmişi arama butonu...

        private void Tum_Liste_Click(object sender, EventArgs e)
        {
            Sevkiyat_Urun_Giris_Cikis_TümList();
            textBox1.Clear();
        } // Listesiyi yenileme butonu...

        private void Sevkiyat_Urun_Giris_Cikis_Tablosu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < Sevkiyat_Urun_Giris_Cikis_Tablosu.Rows.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (Sevkiyat_Urun_Giris_Cikis_Tablosu.Rows[i].Cells[6].Value.ToString() == "Giris")
                {
                    renk.BackColor = System.Drawing.Color.FromArgb(84, 255, 159);
                    //renk.ForeColor = Color.Blue;
                }
                if (Sevkiyat_Urun_Giris_Cikis_Tablosu.Rows[i].Cells[6].Value.ToString() == "Cikis")
                {
                    renk.BackColor = System.Drawing.Color.FromArgb(255, 246, 143);
                    // renk.ForeColor = Color.Red;
                }
                Sevkiyat_Urun_Giris_Cikis_Tablosu.Rows[i].DefaultCellStyle = renk;
            }
        }
    }
}
