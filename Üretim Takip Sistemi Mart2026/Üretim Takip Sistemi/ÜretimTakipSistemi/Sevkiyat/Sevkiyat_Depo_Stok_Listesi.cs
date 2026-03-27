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
    public partial class Sevkiyat_Depo_Stok_Listesi : Form
    {
        public Sevkiyat_Depo_Stok_Listesi()
        {
            InitializeComponent();
        }

        SqlConnection Baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand Komut;
        SqlDataAdapter adtr;
        DataTable Tablo = new DataTable();
        string Durum = "Giris";
        string ID;
        int Adet;

        private void Depo_Stok_List()
        {
            Tablo.Clear();
            Baglanti.Open();
            Komut = new SqlCommand("Select *From Sevkiyat_Depo_Stok_Listesi order by ID desc", Baglanti);
            adtr = new SqlDataAdapter(Komut);
            adtr.Fill(Tablo);
            Depo_Stok_Listesi_Tablosu.DataSource = Tablo;
            Baglanti.Close();
        }
       
        private void Urun_Ekle()
        {
            // Tarih ve Saati değişkene atayıp 2 kere yazmayı engelle 

            Baglanti.Open();
            Komut = new SqlCommand("INSERT INTO Sevkiyat_Depo_Stok_Listesi(Stok_Kodu,Stok_Adı,Miktar,Tarih,Saat,Kasa_No,Operator) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "',@Tarih,@Saat,'" + textBox4.Text + "','" + textBox5.Text + "' )", Baglanti);
            Komut.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(DateTime.Now.ToShortDateString())); 
            Komut.Parameters.AddWithValue("@Saat", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
            Komut.ExecuteNonQuery();
            Baglanti.Close();

            Baglanti.Open();
            Komut = new SqlCommand("INSERT INTO Sevkiyat_Depo_Giris_Cikis_TümList(Stok_Kodu,Stok_Adı,Miktar,G_tarih,Saat,Kasa_No,Operator,Durum) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "',@G_Tarih,@Saat,'" + textBox4.Text + "','" + textBox5.Text + "','" + Durum + "')", Baglanti);
            Komut.Parameters.AddWithValue("@G_Tarih", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            Komut.Parameters.AddWithValue("@Saat", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
            Komut.ExecuteNonQuery();
            Baglanti.Close();
            Depo_Stok_List();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void Urun_Sil()
        {
            Baglanti.Open();
            Komut = new SqlCommand("DELETE FROM Sevkiyat_Depo_Stok_Listesi Where ID='" + ID + "'", Baglanti);
            Komut.ExecuteNonQuery();
            Baglanti.Close();
            Depo_Stok_List();
        }

        private void Urun_Guncelle()
        {
            Baglanti.Open();
            Komut = new SqlCommand("Update Sevkiyat_Depo_Stok_Listesi set Miktar='" + textBox3.Text + "',Kasa_No='" + textBox4.Text + "' where ID='" + ID + "'", Baglanti);
            Komut.ExecuteNonQuery();
            Baglanti.Close();
            Depo_Stok_List();
        }

        private void Tabloya_Tıklama()
        {
            Adet = 0;
            Baglanti.Open();
            Komut = new SqlCommand("Select *From Sevkiyat_Depo_Stok_Listesi", Baglanti);
            SqlDataReader Okuma = Komut.ExecuteReader();
            while(Okuma.Read())
            {
                if(Depo_Stok_Listesi_Tablosu.CurrentRow.Cells[0].Value.ToString()==Okuma["Stok_Kodu"].ToString())
                {
                    Adet += Convert.ToInt32(Okuma["Miktar"].ToString());
                }
            }
            Baglanti.Close();
            label7.Text = Adet.ToString();
        }
        private void Depo_Stok_Listesi_Load(object sender, EventArgs e)
        {
            Depo_Stok_List();
            label6.Text = "Toplam=";
            label7.Text = "Adet";
        }

        private void Urun_Gecmisi_Btn_Click(object sender, EventArgs e)
        {
            Sevkiyat_Depo_Urun_Gecmisi yeni = new Sevkiyat_Depo_Urun_Gecmisi();
            yeni.Show();
        }

        private void Ekle_btn_Click(object sender, EventArgs e)
        {
          //  Urun_Ekle();
        }

        private void Depo_Stok_Listesi_Tablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Tabloya_Tıklama();
            //textBox1.Text = Depo_Stok_Listesi_Tablosu.CurrentRow.Cells[0].Value.ToString();// Stok_Kodu
            //textBox2.Text = Depo_Stok_Listesi_Tablosu.CurrentRow.Cells[1].Value.ToString();// Stok_Adı
            //textBox3.Text = Depo_Stok_Listesi_Tablosu.CurrentRow.Cells[3].Value.ToString();// Miktar
            //textBox4.Text = Depo_Stok_Listesi_Tablosu.CurrentRow.Cells[4].Value.ToString();// Kasa_No
            //textBox5.Text = Depo_Stok_Listesi_Tablosu.CurrentRow.Cells[7].Value.ToString();// Operatör
            //ID = Depo_Stok_Listesi_Tablosu.CurrentRow.Cells[9].Value.ToString();// ID
        }

        private void Sil_Btn_Click(object sender, EventArgs e)
        {
          //  Urun_Sil();
        }

        private void Guncelle_Btn_Click(object sender, EventArgs e)
        {
           // Urun_Guncelle();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = Tablo.DefaultView;
            dv.RowFilter = "Stok_Kodu LIKE '" + textBox1.Text + "%'";
            Depo_Stok_Listesi_Tablosu.DataSource = dv;
        }
    }
}
