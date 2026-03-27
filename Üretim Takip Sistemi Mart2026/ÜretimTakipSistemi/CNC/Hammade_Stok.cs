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
using ÜretimTakipSistemi.CNC;

namespace ÜretimTakipSistemi.CNC
{
    public partial class Hammade_Stok : Form
    {
        public Hammade_Stok()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
        private void Ham_Cinsi_Listesi()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from CNCHammaddeCinsi ", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Ham_Stok_Tablo.DataSource = tablo;
            baglanti.Close();
        }
        private void Ham_Stok_Listesi()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from CNCHammaddestokListesi ", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Ham_Stok_Tablo.DataSource = tablo;
            baglanti.Close();
        }
        private void Ham_Stok_Listesi_Cıkıs()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from CNCHammaddestokListesiCikis", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Ham_Stok_Tablo.DataSource = tablo;
            baglanti.Close();
        }
        private void Ham_Stok_Listesi_Giris()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from CNCHammaddeStokListesiGiris ", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Ham_Stok_Tablo.DataSource = tablo;
            baglanti.Close();
        }
        private void Ham_Stok_Listesi_Gecmis()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from CNCHammaddestokListesiGecmisi ", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Ham_Stok_Tablo.DataSource = tablo;
            baglanti.Close();
        }



        private void Ham_Cinsi_Btn_Click(object sender, EventArgs e)
        {
            Ham_Cinsi_Dznle_Btn.Visible = true;
            Ham_Stok_List_Dznle_Btn.Visible = false;
            Ham_Stok_List_Gecmis_Dznle_Btn.Visible = false;
            Ham_Stok_List_Cıkıs_Dznle_Btn.Visible = false;
            Ham_Stok_List_Giris_Dznle_Btn.Visible = false;
            Ham_Cinsi_Listesi();
        }

        private void Ham_Stok_List_Btn_Click(object sender, EventArgs e)
        {
            Ham_Stok_List_Dznle_Btn.Visible = true;
            Ham_Cinsi_Dznle_Btn.Visible = false;
            Ham_Stok_List_Cıkıs_Dznle_Btn.Visible = false;
            Ham_Stok_List_Giris_Dznle_Btn.Visible = false;
            Ham_Stok_List_Gecmis_Dznle_Btn.Visible = false;
            Ham_Stok_Listesi();
        }

        private void Ham_Stok_List_Dznle_Btn_Click(object sender, EventArgs e)
        {

        }

        private void Ham_Stok_List_Cıkıs_Btn_Click(object sender, EventArgs e)
        {
            Ham_Stok_List_Cıkıs_Dznle_Btn.Visible = true;
            Ham_Cinsi_Dznle_Btn.Visible = false;
            Ham_Stok_List_Dznle_Btn.Visible = false;
            Ham_Stok_List_Gecmis_Dznle_Btn.Visible = false;
            Ham_Stok_List_Giris_Dznle_Btn.Visible = false;
            Ham_Stok_Listesi_Cıkıs();
        }

        private void Ham_Stok_List_Gecmis_Btn_Click(object sender, EventArgs e)
        {
            Ham_Stok_List_Gecmis_Dznle_Btn.Visible = true;
            Ham_Cinsi_Dznle_Btn.Visible = false;
            Ham_Stok_List_Dznle_Btn.Visible = false;
            Ham_Stok_List_Cıkıs_Dznle_Btn.Visible = false;
            Ham_Stok_List_Giris_Dznle_Btn.Visible = false;
            Ham_Stok_Listesi_Gecmis();
        }

        private void Ham_Stok_List_Giris_Btn_Click(object sender, EventArgs e)
        {
            Ham_Stok_List_Giris_Dznle_Btn.Visible = true;
            Ham_Stok_List_Cıkıs_Dznle_Btn.Visible = false;
            Ham_Cinsi_Dznle_Btn.Visible = false;
            Ham_Stok_List_Dznle_Btn.Visible = false;
            Ham_Stok_List_Gecmis_Dznle_Btn.Visible = false;
            Ham_Stok_Listesi_Giris();
        }
    }
}
