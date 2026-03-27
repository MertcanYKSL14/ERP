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
    public partial class Sevkiyat_Depo_Urun_Gecmisi : Form
    {
        public Sevkiyat_Depo_Urun_Gecmisi()
        {
            InitializeComponent();
        }
        SqlConnection Baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        DataTable Tablo = new DataTable();
        SqlCommand Komut;
        SqlDataAdapter Adtr;

        private void Depo_Giris_Cikis_Listesi()
        {
            Tablo.Clear();
            Baglanti.Open();
            Komut = new SqlCommand("Select *from Sevkiyat_Depo_Giris_Cikis_TümList order by ID desc", Baglanti);
            Adtr = new SqlDataAdapter(Komut);
            Adtr.Fill(Tablo);
            Depo_Ürün_Gecmisi_Tablosu.DataSource = Tablo;
            Baglanti.Close();
        }

        private void Sevkiyat_Depo_Urun_Gecmisi_Load(object sender, EventArgs e)
        {
            Depo_Giris_Cikis_Listesi();
        }
    }
}
