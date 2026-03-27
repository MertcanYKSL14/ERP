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
    public partial class CNC_Bölümü : Form
    {
        public CNC_Bölümü()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=CNC; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();


        private void CNC_G_C_Listesi()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from tbl_CNC_Giris_Log ", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            CNC_Liste_Tablo.DataSource = tablo;
            baglanti.Close();
        }
        private void Calısan_Listesi()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from tbl_CNC_Users ", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            CNC_Liste_Tablo.DataSource = tablo;
            baglanti.Close();
        }


        private void G_C_Btn_Click(object sender, EventArgs e)
        {
            Calısan_Ekle_Btn.Visible = false;
            Calısan_Kaldır_Btn.Visible = false;

            CNC_G_C_Listesi();
        }

        private void Users_Btn_Click(object sender, EventArgs e)
        {
            Calısan_Ekle_Btn.Visible = true;
            Calısan_Kaldır_Btn.Visible = true;
            Calısan_Listesi();
        }

        private void Hammade_Stok_Btn_Click(object sender, EventArgs e)
        {
            Calısan_Ekle_Btn.Visible = false;
            Calısan_Kaldır_Btn.Visible = false;
            Hammade_Stok yeni = new Hammade_Stok();
            yeni.Show();
        }

        private void Uretim_Stok_List_Btn_Click(object sender, EventArgs e)
        {
            CNC_Uretim_Stok_Listesi yeni = new CNC_Uretim_Stok_Listesi();
            yeni.Show();
        }

        
    }
}
