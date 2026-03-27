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
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;

namespace ÜretimTakipSistemi
{
    public partial class Stok_Listesi : Form
    {
        public Stok_Listesi()
        {
            InitializeComponent();
       //   _sacAmbariStokListesiService =InstanceFactory.GetInstance<ISacAmbariStokListesiService>();
        }

       // private ISacAmbariStokListesiService _sacAmbariStokListesiService;
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
        int Adet,Kg;

        //private void SacAmbariStoklistesi()  
        //{
        //    dgwStokListesiTablosu.DataSource=_sacAmbariStokListesiService.GetAll();
        //}
        private void Urun_G_C_listesi()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from SacAmbariStokListesi order by Barkod desc", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Stok_Listesi_Tablosu.DataSource = tablo;
            baglanti.Close();
        }


        private void Tabloya_Tıklama()
        {
            Kg = 0;
            Adet = 0;
            baglanti.Open();
            komut = new SqlCommand("Select *from SacAmbariStokListesi", baglanti);
            SqlDataReader okuma = komut.ExecuteReader();
            while (okuma.Read())
            {
                int secilen = Stok_Listesi_Tablosu.SelectedCells[0].RowIndex;
                if (Stok_Listesi_Tablosu.Rows[secilen].Cells[0].Value.ToString() == okuma["StokKodu"].ToString() && "P" == okuma["R_P"].ToString())
                {
                    Adet += Convert.ToInt32(okuma["Miktar"].ToString());                   
                }
                if (Stok_Listesi_Tablosu.Rows[secilen].Cells[0].Value.ToString() == okuma["StokKodu"].ToString() && "R" == okuma["R_P"].ToString())
                {
                    Kg += Convert.ToInt32(okuma["Miktar"].ToString());
                }
            }
            baglanti.Close();
            R_Toplam.Text = Kg.ToString();
            P_Toplam.Text = Adet.ToString();
        }

        private void Stok_Listesi_Load(object sender, EventArgs e)
        {
            Urun_G_C_listesi();
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
      
        private void Cikan_Listesi_Btn_Click(object sender, EventArgs e)
        {
            Cikan_Listesi yeni = new Cikan_Listesi();
            yeni.Show();//Tablonun bulunduğu form
        }
       
        private void Stok_Listesi_Tablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  Tabloya_Tıklama();
        }
      
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Urun_G_C_listesi();
            R_P_Text.Text = "";
            Stok_Kodu_Text.Clear();
            Stok_Adı_Text.Clear();
            Barkod_Text.Clear();
            Kalite_Text.Text = "";
            Kalinlik_Text.Clear();
        }

        private void Kalinlik_Text_TextChanged(object sender, EventArgs e)
        {
            //DataView dv = tablo.DefaultView;
            //dv.RowFilter = "Kalınlık LIKE '" + Kalinlik_Text.Text + "%'";
            //Stok_Listesi_Tablosu.DataSource = dv;
        }

        private void Stok_Kodu_Text_TextChanged(object sender, EventArgs e)
        {
            DataView dv = tablo.DefaultView;
            dv.RowFilter = "StokKodu LIKE'" + Stok_Kodu_Text.Text + "%'";
            Stok_Listesi_Tablosu.DataSource = dv;
        }

        private void Stok_Adı_Text_TextChanged(object sender, EventArgs e)
        {
            DataView dv = tablo.DefaultView;
            dv.RowFilter = "StokAdi LIKE'" + Stok_Adı_Text.Text + "%'";
            Stok_Listesi_Tablosu.DataSource = dv;
        }

        private void P_Birim_Click(object sender, EventArgs e)
        {

        }

        private void SacAmbarı_Giris_Cikis_TümList_Click(object sender, EventArgs e)
        {
            SacAmbari_Gecmis_TümList yeni = new SacAmbari_Gecmis_TümList();
            yeni.Show();
            
        }
    }
}
