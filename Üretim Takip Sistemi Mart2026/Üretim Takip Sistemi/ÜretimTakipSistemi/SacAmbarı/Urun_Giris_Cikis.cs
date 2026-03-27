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
    public partial class Urun_Giris_Cikis : Form
    {
        public Urun_Giris_Cikis()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut, komut1;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
        string degisken;
        Int64 barkod_sablon_sayisi = 900000000000;//Barkod değeri elle oluşturuldu...
        Int64 sayac_int;
        Int64 toplam;
        string SonKayitID, Saat, Tarih, Bilgi = "Giris";

        private void Urun_G_C_listele()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from SacAmbariStokListesi order by Barkod desc", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Urun_G_C_Listesi.DataSource = tablo;
            baglanti.Close();
        }  //Ürün Giriş Çıkış bölümü tablosunun adresten alınıp ekrana basılması...

        private void Urun_Ekle() // Ürün ekleme fonksiyonu 
        {
            baglanti.Open(); // Barkodda verilerin kaydedilmesi
            komut1 = new SqlCommand("INSERT INTO SacAmbariBarkod(StokKodu,StokAdi,Barkod,Kalite,Miktar,Kalinlik,TbEn,TbBoy,Saat,Tarih) values ('" + textBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox10.Text.ToString() + "',@Saat,@Tarih)", baglanti);
            komut1.Parameters.AddWithValue("@Saat", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
            komut1.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            komut1.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            komut = new SqlCommand("INSERT INTO SacAmbariStokListesi(StokKodu,StokAdi,Barkod,Kalite,Miktar,Kalinlik,TbEn,TbBoy,Tarih,Saat,R_P,Operator,Müsteri,Irsaliye,BobinNo) values ('" + textBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + degisken.ToString() + "',@Tarih,@Saat,'"
                   + comboBox2.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox12.Text.ToString() + "','" + textBox5.Text.ToString() + "'); SELECT SCOPE_IDENTITY();", baglanti);
            komut.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            komut.Parameters.AddWithValue("@Saat", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
            komut.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            komut = new SqlCommand("INSERT INTO SacAmbariUrunGecmisi(StokKodu,StokAdi,Barkod,Kalite,Miktar,R_P,Kalinlik,TbEn,TbBoy,Operator,Tarih,Saat,Müsteri,Bilgi,Irsaliye,BobinNo) values ('" + textBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox7.Text.ToString() + "','"
                + comboBox2.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + degisken.ToString() + "','" + comboBox1.Text.ToString() + "',@Tarih,@Saat,'" + comboBox4.Text.ToString() + "','" + Bilgi + "','" + textBox12.Text.ToString() + "','" + textBox5.Text.ToString() + "')", baglanti);
            komut.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            komut.Parameters.AddWithValue("@Saat", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
            komut.ExecuteNonQuery();
            baglanti.Close();

            Urun_G_C_listele();// Kaydettikden sonra tabloda en alt satıra gidiyor
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox10.Clear();
            textBox12.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
        }

        private void Urun_Silme() //Ürünleri Silme fonksiyonu 
        {
            baglanti.Open();  //Urun Giriş Çıkıştan Silme
            komut = new SqlCommand("DELETE FROM SacAmbariStokListesi Where Barkod='" + textBox4.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();  //Barkoddan Silme
            komut1 = new SqlCommand("DELETE FROM SacAmbariBarkod Where Barkod='" + textBox4.Text + "'", baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();

            textBox1.Clear();
            textBox6.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox2.Clear();
            textBox7.Clear();
            comboBox1.Text = "";
            textBox10.Clear();
            textBox12.Clear();
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            Urun_G_C_listele();
        }

        private void Urun_Guncelle()// Ürünlerin yanlış bölümlerini yada eksik yerlerini günceller
        {
            baglanti.Open(); // Ürün Giriş Çıkıştan Güncelleme

            komut = new SqlCommand("Update SacAmbariStokListesi set StokKodu='" + textBox1.Text + "',StokAdi='" + textBox3.Text + "',Barkod='" + textBox4.Text + "',Kalite='" + comboBox3.Text + "',Miktar='" + textBox7.Text + "',R_P='" + comboBox2.Text + "',Kalinlik='" + textBox6.Text + "',TbEn='" + textBox2.Text + "',TbBoy='" + textBox10.Text + "',Operator='" + comboBox1.Text + "',Müsteri='" + comboBox4.Text + "',Irsaliye='" + textBox12.Text + "',BobinNo='" + textBox5.Text.ToString() + "' where Barkod='" + textBox4.Text.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open(); //Barkoddan Güncelleme
            komut1 = new SqlCommand("Update SacAmbariBarkod set StokKodu='" + textBox1.Text + "',StokAdi='" + textBox3.Text + "',Barkod='" + textBox4.Text + "',Kalite='" + comboBox3.Text + "',Miktar='" + textBox7.Text + "',Kalinlik='" + textBox6.Text + "',TbEn='" + textBox2.Text + "',TbBoy='" + textBox10.Text + "' where Barkod='" + textBox4.Text.ToString() + "'", baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();

            Urun_G_C_listele(); // İşlemler bittikten sonra tabloyu tekrar ekranda güncelliyor 
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox10.Clear();
            textBox12.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
        }

        private void Urun_G_C_Ekle_Click(object sender, EventArgs e)// Kaydetme Butonu
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox3.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox2.Text == "" || comboBox2.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("Boş Alanlar Var.");//Boş alan varsa doldurmadan işlem yapılmasını engelleme
            }
            else
            {
                Urun_Ekle();
            }
        }

        private void Urun_Giris_Cikis_Load(object sender, EventArgs e)//Başlangıç anında ekrana direk listenin gelmesi 
        {
            Urun_G_C_listele();
        }

        private void Stok_Sil_Click(object sender, EventArgs e)//Silme Butonu ==> Barkod numarasına göre silme işlemi gerçekeleşiyor
        {
            Urun_Silme();
        }

        private void Stok_Güncelle_Btn_Click(object sender, EventArgs e)//Güncelleme Butonu
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Boş Alanlar Var.");//Boş alan varsa doldurmadan işlem yapılmasını engelleme
            }
            else
            {
                Urun_Guncelle();
            }
        }

        private void bul_Click(object sender, EventArgs e)// Bul butonuna basıldığında Stok_Kartı tablosunu açıyor
        {
            textBox1.Clear();
            textBox6.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox2.Clear();
            textBox7.Clear();
            comboBox1.Text = "";
            textBox10.Clear();
            textBox12.Clear();
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            Urun_G_C_Bul yeni = new Urun_G_C_Bul(); // Yeni bir form açtık, Ürün_G_C bölümünden ilgili textBoxları
            AddOwnedForm(yeni);                  // Public yaptık ve açılan formdan seçilen değerleri ilgili yerlere
            yeni.ShowDialog();                   // çekme işlemini gerçekleştiriyoruz.
        }

        private void textBox4_KeyDown_1(object sender, KeyEventArgs e)//f2 ye basıldığında otomatik barkod atama
        {
            if (e.KeyCode == Keys.F2)
            {
                baglanti.Open();
                komut = new SqlCommand("Select ident_current('SacAmbariStokListesi')", baglanti);
                SonKayitID = komut.ExecuteScalar().ToString();
                baglanti.Close();

                sayac_int = Convert.ToInt64(SonKayitID) + 1;
                toplam = sayac_int + barkod_sablon_sayisi;
                textBox4.Text = toplam.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)// Ürün Çıkart Butonu
        {
            Urun_Cikart yeni = new Urun_Cikart();
            yeni.Show();//Tablonun bulunduğu form
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "R")// Eğer R seçilirse Boy bilgisi girişini engelliyor
            {
                textBox10.Enabled = false;
                textBox10.Clear();
            }
            else
            {
                textBox10.Enabled = true;
            }
        }

        private void Urun_G_C_Listesi_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Urun_G_C_Listesi.CurrentRow.Cells[1].Value.ToString(); // Stok_Kodu
            textBox3.Text = Urun_G_C_Listesi.CurrentRow.Cells[2].Value.ToString(); // Stok_Adı
            textBox4.Text = Urun_G_C_Listesi.CurrentRow.Cells[3].Value.ToString(); // Barkod
            comboBox3.Text = Urun_G_C_Listesi.CurrentRow.Cells[4].Value.ToString();// Kalite
            textBox7.Text = Urun_G_C_Listesi.CurrentRow.Cells[5].Value.ToString(); // Miktar
            textBox6.Text = Urun_G_C_Listesi.CurrentRow.Cells[6].Value.ToString();// Kalınlık
            textBox2.Text = Urun_G_C_Listesi.CurrentRow.Cells[7].Value.ToString(); // Tb_En
            textBox10.Text = Urun_G_C_Listesi.CurrentRow.Cells[8].Value.ToString(); // Tb_Boy
            comboBox2.Text = Urun_G_C_Listesi.CurrentRow.Cells[11].Value.ToString();// R_P
            comboBox1.Text = Urun_G_C_Listesi.CurrentRow.Cells[12].Value.ToString(); // Operator
            comboBox4.Text = Urun_G_C_Listesi.CurrentRow.Cells[13].Value.ToString();// tedarikçi
            textBox12.Text = Urun_G_C_Listesi.CurrentRow.Cells[14].Value.ToString();//İrsaliye
            textBox5.Text = Urun_G_C_Listesi.CurrentRow.Cells[15].Value.ToString();//BobinNo
        }
    }
}
