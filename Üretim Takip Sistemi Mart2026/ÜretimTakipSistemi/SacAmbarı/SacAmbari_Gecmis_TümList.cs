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
    public partial class SacAmbari_Gecmis_TümList : Form
    {
        public SacAmbari_Gecmis_TümList()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand Komut;
        SqlDataAdapter adtr;
        DataTable Tablo = new DataTable();
        
        private void SacAmbari_Giris_Cikis_TümListe()
        {
            Tablo.Clear();
            baglanti.Open();
            Komut = new SqlCommand("Select TOP(500) *From SacAmbariUrunGecmisi order by ID desc", baglanti);
            adtr = new SqlDataAdapter(Komut);
            adtr.Fill(Tablo);
            SacAmbari_Urun_Giris_Cikis_Tablosu.DataSource = Tablo;
            baglanti.Close();
        }

        private void SacAmbari_Gecmis_TümList_Load(object sender, EventArgs e)
        {
            SacAmbari_Giris_Cikis_TümListe();
        }

        private void Tum_Liste_Click(object sender, EventArgs e)
        {
            SacAmbari_Giris_Cikis_TümListe();
            textBox1.Clear();
        }

        private void Detaylı_Arama_Click(object sender, EventArgs e)
        {
            Tablo.Clear();
            baglanti.Open();
            Komut = new SqlCommand("Select *From SacAmbariUrunGecmisi where StokKodu='" + textBox1.Text + "' order by Id desc", baglanti);
            adtr = new SqlDataAdapter(Komut);
            adtr.Fill(Tablo);
            SacAmbari_Urun_Giris_Cikis_Tablosu.DataSource = Tablo;
            baglanti.Close();
            textBox1.Clear();
            
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tablo.Clear();
            baglanti.Open();
            Komut = new SqlCommand("Select *From SacAmbariUrunGecmisi where StokAdi like '%" + textBox2.Text + "%' order by Id desc", baglanti);
            adtr = new SqlDataAdapter(Komut);
            adtr.Fill(Tablo);
            SacAmbari_Urun_Giris_Cikis_Tablosu.DataSource = Tablo;
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Tam_Ekran_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {

                this.WindowState = FormWindowState.Normal;
            }
            else
            {

                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void Alt_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
