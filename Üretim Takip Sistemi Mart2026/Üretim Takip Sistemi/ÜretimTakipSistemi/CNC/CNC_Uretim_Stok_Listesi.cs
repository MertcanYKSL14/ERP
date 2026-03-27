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
    public partial class CNC_Uretim_Stok_Listesi : Form
    {
        public CNC_Uretim_Stok_Listesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
        //int Adet, Kg;

        private void Urun_G_C_listesi()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from CNCUretimStokListesi", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Stok_Listesi_Tablosu.DataSource = tablo;
            baglanti.Close();
        }

        private void CNC_Uretim_Stok_Listesi_Load(object sender, EventArgs e)
        {
            Urun_G_C_listesi();
        }

        private void Cikan_Listesi_Btn_Click(object sender, EventArgs e)
        {

        }

        private void Tüm_Listesi_Btn_Click(object sender, EventArgs e)
        {
            label8.Text = "Toplam=";
            R_Toplam.Text = "Rulo";
            Birim.Text = "Kg";
            label9.Text = "Toplam=";
            P_Toplam.Text = "Plaka";
            P_Birim.Text = "Adet";
            Barkod_Text.Clear();
            Urun_G_C_listesi();
        }
    }
}
