using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ÜretimTakipSistemi
{
    public partial class Sevkiyat_StokListesi : Form
    {
        public Sevkiyat_StokListesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut,komut1,komut2,komut3;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
        DataTable tablo1 = new DataTable();
        string Cikan_Miktar,Eski_Miktar, Bilgi = "Cikis", ID, Mesaj; 
        int Eksi_Eski_miktar,Son_Miktar;
        int Adet,Parça,Sınır,Genel_Toplam;

        private void Sevkiyat_Urun_Stok_listesi()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from Depo_Yrd_Malzeme_Stok_Listesi order by ID desc", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Sevkiyat_Urun_Stok_Listesi_Tablosu.DataSource = tablo;
            baglanti.Close();

        } //DataBaseden Stok listesinin alınması...
      
        private void Sevkiyat_UrunCikart()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || textBox5.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Boş Alanlar Var!");
            }
            else
            {
                Cikan_Miktar = textBox3.Text;
                Eski_Miktar = textBox7.Text;
                Son_Miktar = Convert.ToInt32(Eski_Miktar) - Convert.ToInt32(Cikan_Miktar);
                if (Son_Miktar < 0)
                {
                    MessageBox.Show("(-) Değerli bir sonuç olamaz!");
                }
                else
                {
                   // Saat = System.DateTime.Now.ToLongTimeString();
                   // Tarih = System.DateTime.Now.ToShortDateString();
                    baglanti.Open();//Çıkan ürünü Urun_Cikise kaydediyor.
                    komut = new SqlCommand("INSERT INTO Depo_Yrd_Malzeme_Cikan_Listesi(Stok_Kodu,Stok_Adı,Miktar,Operator,Durum,Saat,Tarih) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + Cikan_Miktar.ToString() + "','" + textBox5.Text.ToString() + "','" + comboBox1.Text.ToString() + "',@Saat,@Tarih)", baglanti);
                    komut.Parameters.AddWithValue("@Saat", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
                    komut.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    Eksi_Eski_miktar = -1 * (Convert.ToInt32(Cikan_Miktar));
                    baglanti.Open();//Çıkan ürünü Urun_Cikis_TümListe kaydediyor.
                    komut1 = new SqlCommand("INSERT INTO Depo_Yrd_Malzeme_Giris_Cikis_TümList(Stok_Kodu,Stok_Adı,Miktar,Saat,Tarih,Durum,Bilgi,Operator) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + Eksi_Eski_miktar.ToString() + "',@Saat,@Tarih,'" + comboBox1.Text.ToString() + "','" + Bilgi + "','" + textBox5.Text.ToString() + "')", baglanti);
                    komut1.Parameters.AddWithValue("@Saat", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
                    komut1.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                    komut1.ExecuteNonQuery();
                    baglanti.Close();

                    if (Son_Miktar == 0)
                    {
                        baglanti.Open();  //Eğer sonuç=0 ise
                        komut = new SqlCommand("DELETE FROM Depo_Yrd_Malzeme_Stok_Listesi Where ID='" + ID + "'", baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    else
                    {
                        baglanti.Open();
                        komut = new SqlCommand("Update Depo_Yrd_Malzeme_Stok_Listesi set Miktar='" + Son_Miktar.ToString() + "' where ID like '" + ID + "'", baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    baglanti.Open();
                    komut2 = new SqlCommand("Select *from Depo_Yrd_Malzeme_Stok_Listesi", baglanti);
                    SqlDataReader okuma = komut2.ExecuteReader();
                    while (okuma.Read())
                    {
                        if (textBox1.Text == okuma["Stok_Kodu"].ToString())
                        {
                            Genel_Toplam += Convert.ToInt32(okuma["Miktar"].ToString());
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
                    }
                    baglanti.Close();
                    if (Genel_Toplam< Sınır)
                    {
                        Mesaj = "Siparis Ver";
                    }
                    else
                    {
                        Mesaj = "Normal";
                    }
                    baglanti.Open();
                    komut2 = new SqlCommand("Update Depo_Yrd_Malzeme_Stok_Listesi set Mesaj='" + Mesaj + "' where Stok_Kodu='" + textBox1.Text + "'", baglanti);
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                }
                Sevkiyat_Urun_Stok_listesi();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.Text = "";
                textBox5.Clear();
                textBox7.Clear();
            }
        } // Ürün Çıkarma fonksiyonu...
       
        private void Tabloya_Tıklama() 
        {
            int secilen = Sevkiyat_Urun_Stok_Listesi_Tablosu.SelectedCells[0].RowIndex;
            textBox1.Text = Sevkiyat_Urun_Stok_Listesi_Tablosu.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = Sevkiyat_Urun_Stok_Listesi_Tablosu.Rows[secilen].Cells[1].Value.ToString();
            textBox7.Text = Sevkiyat_Urun_Stok_Listesi_Tablosu.Rows[secilen].Cells[2].Value.ToString();
            ID = Sevkiyat_Urun_Stok_Listesi_Tablosu.Rows[secilen].Cells[8].Value.ToString();
            Parça = 0;
            Adet = 0;
            baglanti.Open();
            komut = new SqlCommand("Select *from Depo_Yrd_Malzeme_Stok_Listesi", baglanti);
            SqlDataReader okuma = komut.ExecuteReader();
            while (okuma.Read())
            {
                if (Sevkiyat_Urun_Stok_Listesi_Tablosu.Rows[secilen].Cells[0].Value.ToString() == okuma["Stok_Kodu"].ToString())
                {
                    Adet += Convert.ToInt32(okuma["Miktar"].ToString());
                }
                if (Sevkiyat_Urun_Stok_Listesi_Tablosu.Rows[secilen].Cells[0].Value.ToString() == okuma["Stok_Kodu"].ToString())
                {
                    Parça++;
                }
            }
            baglanti.Close();
            Toplam.Text = Adet.ToString();
            Kasa_Palet_Koli.Text = Parça.ToString();
            textBox5.Text = "MURAT";
        } // Tabloya tıklayarak istenilen verileri TB'lere atıyor ve tıklanan ürünün toplam miktar ve grup halini gösteriyor...
       
        private void Stok_Sil()
        {
            baglanti.Open();
            komut = new SqlCommand("DELETE FROM Depo_Yrd_Malzeme_Stok_Listesi Where ID='" + ID + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Sevkiyat_Urun_Stok_listesi();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            textBox5.Clear();
            textBox7.Clear();
            Stok_Adı_Text.Clear();
            Stok_Kodu_Text.Clear();
        }  // Stoktan Silme fonksiyonu...

        private void Sevkiyat_StokListesi_Load(object sender, EventArgs e)
        {
            Sevkiyat_Urun_Stok_listesi();
            Stok_Kodu_Text.Focus();
        } // Form yüklendiğinde tablonun ekranda görünmesi...
        
        private void Sevkiyat_Urun_Cikart_Btn_Click(object sender, EventArgs e)
        {
            Sevkiyat_UrunCikart();
            Toplam.Text = "Adet";
            Kasa_Palet_Koli.Text = "Kasa,Palet,Koli";
        } // Ürün Çıkarma Butonu...
      
        private void Sevkiyat_Urun_Stok_Listesi_Tablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Tabloya_Tıklama();
        } // Tabloya tıklama...
         
        private void Tüm_Listesi_Btn_Click(object sender, EventArgs e)
        {
            tablo1.Clear();
            baglanti.Open();
            // komut = new SqlCommand("SELECT Stok_Kodu,SUM(Miktar) FROM deneme GROUP BY Stok_Kodu order by Stok_Kodu desc", baglanti);
            komut = new SqlCommand("SELECT Stok_Kodu,SUM(Miktar) FROM Depo_Yrd_Malzeme_Stok_Listesi GROUP BY Stok_Kodu", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo1);
            Sevkiyat_Urun_Stok_Listesi_Tablosu.DataSource = tablo1;
            baglanti.Close();

        } // Arama yapıldıktan sonra Tüm Listeyi tekrar ekranda gösterme butonu...
      
        private void Stok_Kodu_Text_TextChanged(object sender, EventArgs e)
        {
            DataView dv = tablo.DefaultView;
            dv.RowFilter = "Stok_Kodu LIKE '" + Stok_Kodu_Text.Text + "%'";
            Sevkiyat_Urun_Stok_Listesi_Tablosu.DataSource = dv;
        } // Stok Kodu ile filtreleme yapma...
      
        private void Sevkiyat_UrunGecmisi_Btn_Click(object sender, EventArgs e)
        {
            Toplam.Text = "Adet";
            Kasa_Palet_Koli.Text = "Kasa,Palet,Koli";
            Sevkiyat_Urun_Gecmisi yeni = new Sevkiyat_Urun_Gecmisi();
            yeni.Show();
        } // Ürün Geçmişi Butonu...
      
        private void Stok_Güncelle_Btn_Click(object sender, EventArgs e)
        {
            Toplam.Text = "Adet";
            Kasa_Palet_Koli.Text = "Kasa,Palet,Koli";
        } // Güncelle Butonu...
       
        private void Sil_Btn_Click(object sender, EventArgs e)
        {
            Toplam.Text = "Adet";
            Kasa_Palet_Koli.Text = "Kasa,Palet,Koli";
            Stok_Sil();
        } // Sil Butonu...

        private void Listele_Btn_Click(object sender, EventArgs e)
        {
            Toplam.Text = "Adet";
            Kasa_Palet_Koli.Text = "Kasa,Palet,Koli";
            Stok_Kodu_Text.Clear();
            Stok_Adı_Text.Clear();
            Sevkiyat_Urun_Stok_listesi();
        } // Listele Butonu...

        private void Yrd_Malzeme_Cikan_Listesi_Btn_Click(object sender, EventArgs e)
        {
            Sevkiyat_CikanListesi yeni = new Sevkiyat_CikanListesi();
            yeni.Show();
        } // Çıkan ürünlerin geçmiş sayfası Butonu...

        private void Sevkiyat_Urun_Stok_Listesi_Tablosu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < Sevkiyat_Urun_Stok_Listesi_Tablosu.Rows.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (Sevkiyat_Urun_Stok_Listesi_Tablosu.Rows[i].Cells[9].Value.ToString() == "Siparis Ver")
                {
                    renk.BackColor = System.Drawing.Color.FromArgb(255,50,20);
                }
                Sevkiyat_Urun_Stok_Listesi_Tablosu.Rows[i].DefaultCellStyle = renk;
            }
        }
    }
}
