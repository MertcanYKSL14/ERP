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
    public partial class Sevkiyat_CikanListesi : Form
    {
        public Sevkiyat_CikanListesi()
        {
            InitializeComponent();
        }
       SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
       
        private void Sevkiyat_Urun_Cikis_listesi()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select Top(500) *from Depo_Yrd_Malzeme_Cikan_Listesi order by ID desc", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Sevkiyat_Urun_Cikis_Listesi_Tablosu.DataSource = tablo;
            baglanti.Close();
        } // DataBaseden Çıkan Listesini alma...
     
        private void Sevkiyat_CikanListesi_Load(object sender, EventArgs e)
        {
            Sevkiyat_Urun_Cikis_listesi();
        } // Çıkan Listesini ekrana yazdırma...
      
        private void Tüm_Listesi_Btn_Click(object sender, EventArgs e)
        {
            Stok_Kodu_Text.Clear();
            Sevkiyat_Urun_Cikis_listesi();
        } // Arama yapıldıktan sonra Çıkan Listesini tekrardan ekrana yazdırma...

        private void Stok_Kodu_Text_TextChanged(object sender, EventArgs e)
        {
            DataView dv = tablo.DefaultView;
            dv.RowFilter = "Stok_Kodu LIKE'" + Stok_Kodu_Text.Text + "%'";
            Sevkiyat_Urun_Cikis_Listesi_Tablosu.DataSource = dv;
        } // Tablodan Süzme yaparak arama...

        private void Tüm_Gecmis_Arama_Btn_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            baglanti.Open();
            adtr = new SqlDataAdapter("Select *From Depo_Yrd_Malzeme_Cikan_Listesi where Stok_Kodu='" + Stok_Kodu_Text.Text + "' order by ID desc", baglanti);
            adtr.Fill(tablo);
            Sevkiyat_Urun_Cikis_Listesi_Tablosu.DataSource = tablo;
            baglanti.Close();
        } // Detaylı Tüm Geçmişi Arama Butonu...
    }
}
 