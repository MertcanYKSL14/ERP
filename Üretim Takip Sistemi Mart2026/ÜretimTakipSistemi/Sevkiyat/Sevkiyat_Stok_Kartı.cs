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
    public partial class Sevkiyat_Stok_Kartı : Form
    {
        public Sevkiyat_Stok_Kartı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter Adtr;
        DataTable tablo = new DataTable();
        bool Durum; // Kayıt kontrolü için kullanıldı
     
        private void Sevkiyat_Stok_Kartı_Listesi()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from Urunler order by StokKodu asc", baglanti);
            Adtr = new SqlDataAdapter(komut);
            Adtr.Fill(tablo);
            Sevkiyat_Stok_Kartı_TümList.DataSource = tablo;
            baglanti.Close();
        } // Stok Kartı Listesinin DataBase'den alınması...
      
        private void Kayıt_Varsa_Engelle() 
        {
            Durum = true;
            baglanti.Open();
            komut = new SqlCommand("Select *from Urunler", baglanti);
            SqlDataReader okuma = komut.ExecuteReader();
            while(okuma.Read())
            {
                if(textBox1.Text==okuma["StokKodu"].ToString() || textBox1.Text=="")
                {
                    Durum = false;
                }
            }
            baglanti.Close();
            if (Durum == true)       // kayıt var bilgisi veriyor    
            {
                baglanti.Open();
                komut = new SqlCommand("INSERT INTO Urunler(StokKodu,StokAdi) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Sevkiyat_Stok_Kartı_Listesi();
                MessageBox.Show("Kayıt eklenmiştir...");
            }
            else
            {
                MessageBox.Show("Böyle bir kayıt vardır...");
            }
            textBox1.Clear();
            textBox2.Clear();
        } // Eğer önceden kayıt olup olmadığını kontrol ediyor varsa engelliyor...
      
        private void Kayit_Sil()
        {
            baglanti.Open();
            komut = new SqlCommand("DELETE FROM Urunler Where StokKodu='" + textBox1.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Sevkiyat_Stok_Kartı_Listesi();
            textBox1.Clear();
            textBox2.Clear();
        } // Var olan kaydı silme fonksiyonu...
      
        private void Kayit_Güncelle()
        {
            baglanti.Open();
            komut = new SqlCommand("Update Urunler set StokKodu='" + textBox1.Text + "',StokAdi='" + textBox2.Text + "'where StokKodu='" + textBox1.Text + "'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Sevkiyat_Stok_Kartı_Listesi();
            textBox1.Clear();
            textBox2.Clear();
        } // Kaydı Güncelleme fonksiyonu...
      
        private void Btn_Stok_Kart_Kaydet_Click(object sender, EventArgs e)
        {
            Kayıt_Varsa_Engelle();//Öncelikle kayıt varmı kontrol ediyor eğer varsa ekrana kayıt var 
        } // DataBaseye veriler kaydetme butonu...
     
        private void Stok_Kartı_Sil_Click(object sender, EventArgs e)
        {
            Kayit_Sil();
        } // DataBase'den kayıtları silme butonu...
      
        private void Stok_Kartı_Güncelle_Click(object sender, EventArgs e)
        {
            Kayit_Güncelle();
        } // DataBase'den kayıtları silme butonu...
      
        private void Sevkiyat_Stok_Kartı_Load(object sender, EventArgs e)
        {
            Sevkiyat_Stok_Kartı_Listesi();
        } // Form açıldığında listenin ekrana yüklenmesi...
      
        private void Sevkiyat_Stok_Kartı_TümList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox1.Text = Sevkiyat_Stok_Kartı_TümList.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = Sevkiyat_Stok_Kartı_TümList.CurrentRow.Cells[2].Value.ToString();
        } // Tabloya tıklandığında verilerin TB'lara yazdırılması...

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
