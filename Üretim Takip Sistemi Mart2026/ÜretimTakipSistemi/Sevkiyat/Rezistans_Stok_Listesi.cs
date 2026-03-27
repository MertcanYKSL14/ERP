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
    public partial class Rezistans_Stok_Listesi : Form
    {
        public Rezistans_Stok_Listesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        private SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
        SqlDataReader oku;
        string Tarih,Saat,İcerik,Birim="ÜPY",Secim; // Üpeye yazısının değerini dinamik yap ve kullanıcı adına göre düzenle
      
        private void Rezistans_Stok_List()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from Sevkiyat_Rezistans_Stok_Listesi order by Barkod desc", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Rezistans_Gruplama_StokList_Tablosu.DataSource = tablo;
            baglanti.Close();
        } // DataBaseden Rezistans kayıtlarının alınması...

        private void Mesaj_Silme()
        {
            baglanti.Open();
            komut = new SqlCommand("DELETE FROM mesaj Where Mesaj='" + Secim + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SetSelected(listBox1.Items.Count - 1, false); // Ekranda son mesajı seçip seçilmeyeceğine karar veriyoruz.
        } // 

        private void Mesaj_Ekleme()
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Mesaj Yazmadınız...");
            }
            else
            {
                Saat = System.DateTime.Now.ToLongTimeString();
                Tarih = System.DateTime.Now.ToShortDateString();
                İcerik = "$<" + Tarih + " " + Saat + ">$<ÜPY>$ " + textBox3.Text.ToString();
                listBox1.Items.Add(İcerik);
                baglanti.Open();
                komut = new SqlCommand("INSERT INTO mesaj(Mesaj,Birim,Tarih,Saat) values('" + İcerik + "','" + Birim + "',@tarih,@saat)", baglanti);
                komut.Parameters.AddWithValue("@tarih", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                komut.Parameters.AddWithValue("@saat", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
                komut.ExecuteNonQuery();
                baglanti.Close();
                textBox3.Clear();
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.SetSelected(listBox1.Items.Count - 1, false); // Ekranda son mesajı seçip seçilmeyeceğine karar veriyoruz.
            }
        }
        private void Mesajlasma()
        {
            listBox1.Items.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *From mesaj order by ID asc", baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                listBox1.Items.Add(oku["Mesaj"]);
            }
            baglanti.Close();
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SetSelected(listBox1.Items.Count - 1, false); // Ekranda son mesajı seçip seçilmeyeceğine karar veriyoruz.
        } // Mesajların DataBaseden alınması...

        private void Rezistans_Stok_Listesi_Load(object sender, EventArgs e)
        {
            Rezistans_Stok_List();
            Mesajlasma();
        } // Rezistans kayıtlarının ekrana yazdırılması...

        private void Mesaj_Gönder_Click(object sender, EventArgs e)
        {
            Mesaj_Ekleme();
            Mesajlasma();
        }

        private void Mesaj_Sil_Click(object sender, EventArgs e)
        {
            Mesaj_Silme();
            Mesajlasma();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Secim = listBox1.Text;
        }
    }
}
