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
    public partial class Urun_Cikart : Form
    {
        public Urun_Cikart()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        string Eski_Miktar;
        int Deger1,Deger2,Yeni_Miktar;
        string Bilgi = "Çıkış";
      
        private void Kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        private void Alt_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
     
        private void Urun_Cıkart()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "")
            {
                MessageBox.Show("Boş Alan Var!");
            }
            else
            {

                baglanti.Open();  //Çıkan ürünü SacAmbari_UrunCikis_Listesi'ne kaydediyor.
                komut = new SqlCommand("INSERT INTO SacAmbari_UrunCikis_Listesi(Stok_Kodu,Stok_Adı,Barkod,Kalite,Miktar,R_P,Kalınlık,Tb_En,Tb_Boy,Operator,Tarih,Saat,Müsteri) values ('" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox7.Text.ToString() + "','"
                + textBox11.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox9.Text.ToString() + "','" + textBox13.Text.ToString() + "',@Tarih,@Saat,'" + textBox12.Text.ToString() + "')", baglanti);
                komut.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                komut.Parameters.AddWithValue("@Saat", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
                komut.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();//Çıkan ürünü SacAmbari_Urun_GirisCikis_TümList'e kaydediyor.
                komut = new SqlCommand("INSERT INTO SacAmbari_Urun_GirisCikis_TümList(Stok_Kodu,Stok_Adı,Barkod,Kalite,Miktar,R_P,Kalınlık,Tb_En,Tb_Boy,Operator,Tarih,Saat,Müsteri,Bilgi) values ('" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox7.Text.ToString() + "','"
                + textBox11.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox9.Text.ToString() + "','" + textBox13.Text.ToString() + "',@Tarih,@Saat,'" + textBox12.Text.ToString() + "','" + Bilgi + "')", baglanti);
                komut.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                komut.Parameters.AddWithValue("@Saat", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
                komut.ExecuteNonQuery();
                baglanti.Close();

                if (textBox7.Text == Eski_Miktar)
                {
                    baglanti.Open();  //Urun Giriş Çıkıştan Silme
                    komut = new SqlCommand("DELETE FROM SacAmbari_Urun_Giris_Cikis Where Barkod='" + textBox1.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();  //Barkoddan Silme
                    komut = new SqlCommand("DELETE FROM SacAmbari_Barkod Where Barkod='" + textBox1.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();  //Alternatif_Hurdadan Silme
                    komut = new SqlCommand("DELETE FROM SacAmbari_Alternatif_Hurda Where Barkod='" + textBox1.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    textBox1.Clear();
                }
                else //Eğer bir miktar kullanılırsa kalanı güncelliyor
                {
                    Deger1 = Convert.ToInt32(textBox7.Text);
                    Deger2 = Convert.ToInt32(Eski_Miktar);
                    Yeni_Miktar = Deger2 - Deger1;
                    textBox7.Text = Yeni_Miktar.ToString();
                    baglanti.Open();
                    komut = new SqlCommand("Update SacAmbari_Barkod set Miktar='" + textBox7.Text + "' where Barkod = '" + textBox4.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    komut = new SqlCommand("Update SacAmbari_Urun_Giris_Cikis set Miktar='" + textBox7.Text + "' where Barkod = '" + textBox4.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    komut = new SqlCommand("Update SacAmbari_Alternatif_Hurda set Miktar='" + textBox7.Text + "' where Barkod='" + textBox4.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
                this.Close();
            }
        }
       
        private void Barkod_Bul()
        {
            baglanti.Open();//barkoddan verilerin alınması ve okuma işleminin gerçekleştirilmesi
            komut = new SqlCommand("Select *from SacAmbari_Urun_Giris_Cikis where Barkod like '" + textBox1.Text.ToString() + "'", baglanti);
            SqlDataReader okuma = komut.ExecuteReader();
            while (okuma.Read())
            {
                textBox2.Text = okuma["Stok_Kodu"].ToString();
                textBox3.Text = okuma["Stok_Adı"].ToString();
                textBox4.Text = okuma["Barkod"].ToString();
                textBox5.Text = okuma["Kalite"].ToString();
                textBox6.Text = okuma["Kalınlık"].ToString();
                textBox11.Text = okuma["R_P"].ToString();
                textBox8.Text = okuma["Tb_En"].ToString();
                textBox9.Text = okuma["Tb_Boy"].ToString();
                textBox12.Text = okuma["Müsteri"].ToString();
                Eski_Miktar = okuma["Miktar"].ToString();
                if (textBox9.Text != "") //Eğer boy bilgisi varsa direk miktar bizim girmemizi istiyor
                {
                    textBox7.Text = "";
                }
                else
                {
                    textBox7.Text = okuma["Miktar"].ToString();//Boy bilgisi yoksa var olan miktar girilecek
                }
            }
            baglanti.Close();
        }
      
        private void Urun_Cikart_Btn_Click(object sender, EventArgs e)
        {
            Urun_Cıkart();
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Barkod_Bul();
        }
    }
}
