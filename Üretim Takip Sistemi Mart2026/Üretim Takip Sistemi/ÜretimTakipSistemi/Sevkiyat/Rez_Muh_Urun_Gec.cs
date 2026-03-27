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
    public partial class Rez_Muh_Urun_Gec : Form
    {
        public Rez_Muh_Urun_Gec()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable Tablo = new DataTable();

        private void Rez_Muh_Urun_Gecmisi()
        {
            Tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *From Sevkiyat_Giris_Cikis_TümList ", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(Tablo);
            Rez_Muh_Urun_Giris_Cikis_Tablosu.DataSource = Tablo;
            baglanti.Close();
        }

        private void Rez_Muh_Giris_cikis_TümList()
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Aramak istediğiniz Stok kodunu giriniz...");
            }
            else
            {
                Tablo.Clear();
                baglanti.Open();
                adtr = new SqlDataAdapter("Select *From Sevkiyat_Giris_Cikis_TümList where Stok_Kodu='" + textBox1.Text + "' order by ID desc", baglanti);
                adtr.Fill(Tablo);
                Rez_Muh_Urun_Giris_Cikis_Tablosu.DataSource = Tablo;
                baglanti.Close();
                textBox1.Clear();
            }
        }
        private void Rez_Muh_Urun_Gec_Load(object sender, EventArgs e)
        {
            Rez_Muh_Urun_Gecmisi();
        }

        private void Tum_Liste_Click(object sender, EventArgs e)
        {
            Rez_Muh_Urun_Gecmisi();
            textBox1.Clear();
        }

        private void Detaylı_Arama_Click(object sender, EventArgs e)
        {
            Rez_Muh_Giris_cikis_TümList();
        }

        private void Rez_Muh_Urun_Giris_Cikis_Tablosu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
