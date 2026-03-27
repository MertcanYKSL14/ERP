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

namespace ÜretimTakipSistemi
{
    public partial class Cikan_Listesi : Form
    {
        public Cikan_Listesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
       
        private void Urun_Cikis_listesi()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from SacAmbariStokListesi order by Barkod desc", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Urun_Cikis_Listesi_Tablosu.DataSource = tablo;
            baglanti.Close();
        }
       
        private void Cikan_Listesi_Load(object sender, EventArgs e)
        {
            Urun_Cikis_listesi();
        }
       
        private void Tüm_Listesi_Btn_Click(object sender, EventArgs e)
        {
            Barkod_Text.Clear();
            Urun_Cikis_listesi();
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Urun_Cikis_listesi();
            Stok_Kodu_Text.Clear();
            Stok_Adı_Text.Clear();
            Barkod_Text.Clear();
            Kalite_Text.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test yeni = new Test();
            yeni.Show();
        }

        private void Alt_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Kapat_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
