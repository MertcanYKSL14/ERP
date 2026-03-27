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
    public partial class Sevkiyat : Form
    {
        public Sevkiyat()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut,komut1,komut2,komut3;
        //string Saat,Tarih;
        int Adet, Sınır,Toplam;
        string Mesaj;

        private void Urun_Ekle()
        {
            // Bu bölümde öncelikle kayıt edilecek değer ile birlikte Databasedeki değeri toplayıp sınır değerini geçip geçmediğini kontrol ediyor ve 
            // sınır değerine göre renklendirme işlemini gerçekleştiriyor. Daha sonra eklenecek miktarı ilgili yere ekliyor.
           // Saat = System.DateTime.Now.ToLongTimeString();
          //  Tarih = System.DateTime.Now.ToShortDateString();

            baglanti.Open();
            komut2 = new SqlCommand("Select *from Depo_Yrd_Malzeme_Stok_Listesi", baglanti);
            SqlDataReader okuma = komut2.ExecuteReader();
            while (okuma.Read())
            {
                if (textBox1.Text == okuma["Stok_Kodu"].ToString())
                {
                    Adet += Convert.ToInt32(okuma["Miktar"].ToString());
                }
            }
            baglanti.Close();

            baglanti.Open();
            komut3 = new SqlCommand("Select *from Sınır_Deger", baglanti);
            SqlDataReader okuma1 = komut3.ExecuteReader();
            while (okuma1.Read())
            {
                if (textBox1.Text == okuma1["Stok_Kodu"].ToString())
                {
                    Sınır = Convert.ToInt32(okuma1["Sınır"].ToString());
                }
                else
                {
                    Sınır = 0;
                }
            }
            baglanti.Close();
            Toplam = Adet + Convert.ToInt32(textBox7.Text);
            if(Toplam<Sınır)
            {
                Mesaj = "Siparis Ver";
            }
            else
            {
                Mesaj = "Normal";
            }

            baglanti.Open();  
            komut = new SqlCommand("INSERT INTO Depo_Yrd_Malzeme_Stok_Listesi(Stok_Kodu,Stok_Adı,Miktar,Operator,Saat,Tarih,Müsteri,İrsaliye,Mesaj) values ('" + textBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox5.Text.ToString() + "',@Saat,@Tarih,'" + textBox2.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + Mesaj + "')", baglanti);
            komut.Parameters.AddWithValue("@Saat", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
            komut.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            komut.ExecuteNonQuery();
            baglanti.Close();
           
            string Bilgi = "Giris";
            baglanti.Open();
            komut1 = new SqlCommand("INSERT INTO Depo_Yrd_Malzeme_Giris_Cikis_TümList(Stok_Kodu,Stok_Adı,Miktar,Saat,Tarih,Durum,Bilgi,Operator,İrsaliye) values ('" + textBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox7.Text.ToString() + "',@Saat,@Tarih,'" + textBox2.Text.ToString() + "','" + Bilgi + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", baglanti);
            komut1.Parameters.AddWithValue("@Saat", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
            komut1.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            komut1.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            komut2 = new SqlCommand("Update Depo_Yrd_Malzeme_Stok_Listesi set Mesaj='" + Mesaj + "' where Stok_Kodu='" + textBox1.Text + "'", baglanti);
            komut2.ExecuteNonQuery();
            baglanti.Close();

            textBox1.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox2.Clear();
            textBox6.Clear();
        } // DataBase'ye eklenecek ürünlerin Ekle fonksiyonu... 
       
        private void Yrd_Malzeme_Stok_Listesi_Btn_Click(object sender, EventArgs e)
        {
            Sevkiyat_StokListesi yeni = new Sevkiyat_StokListesi();
            yeni.Show();
        } // Stok Listesi Butonu...
       
        private void Bul_Click(object sender, EventArgs e) 
        {
            Sevkiyat_Bul yeni = new Sevkiyat_Bul();
            AddOwnedForm(yeni);   // Public yaptık ve açılan formdan seçilen değerleri ilgili yerlere
            yeni.Show();
        } // Bul Listesi Butonu...
      
        private void Yrd_Malzeme_Urun_Ekle_Btn_Click(object sender, EventArgs e)
        {
                if (textBox1.Text == "" || textBox3.Text == "" || textBox7.Text == "" || textBox5.Text == "" || textBox2.Text=="")
                {
                    MessageBox.Show("Boş Alanlar Var!");
                }
                else
                { 
                    Urun_Ekle();
                    MessageBox.Show("Ürün Eklendi...");
                }
        } // DataBase'ye Ürün Ekleme Butonu...

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Muhafaza_Stok_Listesi_Btn_Click(object sender, EventArgs e)
        {
            Muhafaza_Stok_Listesi yeni = new Muhafaza_Stok_Listesi();
            yeni.Show();
        } // Muhafaza Stok Listesi Butonu...

        private void Rezistans_Stok_Listesi_Btn_Click(object sender, EventArgs e)
        {
            Rezistans_Stok_Listesi yeni = new Rezistans_Stok_Listesi();
            yeni.Show();
        } // Rezistans Stok Listesi Butonu...

        private void Depo_Stok_Listesi_Btn_Click(object sender, EventArgs e)
        {
            Sevkiyat_Depo_Stok_Listesi yeni = new Sevkiyat_Depo_Stok_Listesi();
            yeni.Show();
        }

        private void Sevkiyat_Load(object sender, EventArgs e)
        {
          // Grafikler konulacak
          // muhafaza bu gğn üretilen değer yazılacak
          // Rezistans o gün üretilecek veri yazılacak 
          // Rapor alma butonları eklenecek
        }

        private void Rez_Muh_Urun_Gec_Click(object sender, EventArgs e)
        {
            Rez_Muh_Urun_Gec yeni = new Rez_Muh_Urun_Gec();
            yeni.Show();
        }
    }
}
