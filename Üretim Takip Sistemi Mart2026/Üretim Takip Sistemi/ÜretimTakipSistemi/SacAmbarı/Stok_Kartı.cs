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
    public partial class Stok_Kartı : Form
    {
        public Stok_Kartı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
        bool Durum;
        private void listele()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from SacAmbariStokKarti order by StokKodu asc", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Stok_Kartı_TümList.DataSource = tablo;
            baglanti.Close();
        }
        private void Kayıt_Varsa_Engelle()
        {
            Durum = true;
            baglanti.Open();
            komut = new SqlCommand("Select *from SacAmbariStokKarti", baglanti);
            SqlDataReader okuma = komut.ExecuteReader();
            while(okuma.Read())
            {
                if(textBox1.Text==okuma["StokKodu"].ToString() || textBox1.Text=="")
                {
                    Durum = false;
                }
            }
            if (Durum == true)
            {
                textBox2.Text = textBox3.Text.ToString() + "-" + comboBox1.Text.ToString() + "-" + comboBox2.Text.ToString();
                baglanti.Open();
                komut = new SqlCommand("INSERT INTO SacAmbariStokKarti(StokKodu,StokAdi,Kalinlik,Kalite,SacKalitesi) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele();
                Stok_Kartı_TümList.FirstDisplayedScrollingRowIndex = Stok_Kartı_TümList.RowCount - 1;
                MessageBox.Show("Kayıt eklenmiştir...");
            }
            else
            {
                MessageBox.Show("Böyle bir kayıt vardır...");
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox2.Text = "";
            comboBox1.Text = "";
            baglanti.Close();
        }
        private void SacAmbari_Stok_Kartı_Sil()
        {
            baglanti.Open();
            komut = new SqlCommand("DELETE FROM SacAmbariStokKarti Where StokKodu='" + textBox1.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
        private void SacAmbari_Stok_Karti_Güncelle()
        {
            textBox2.Text = textBox3.Text.ToString() + "-" + comboBox1.Text.ToString() + "-" + comboBox2.Text.ToString();
            baglanti.Open();
            komut= new SqlCommand("Update SacAmbariStokKarti set StokKodu='" + textBox1.Text + "',StokAdi='" + textBox2.Text + "',Kalinlik='" + textBox3.Text + "',Kalite='" + comboBox1.Text + "',SacKalitesi='" + comboBox2.Text + "'where StokKodu='" + textBox5.Text + "'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
        private void Btn_Stok_Kart_Kaydet_Click(object sender, EventArgs e)
        {
            Kayıt_Varsa_Engelle();
        }
          private void Stok_Kartı_Sil_Click(object sender, EventArgs e)
        {
            SacAmbari_Stok_Kartı_Sil();
        }
        private void Stok_Kartı_Load(object sender, EventArgs e)
        {
            listele();
        }
        private void Stok_Kartı_Güncelle_Click(object sender, EventArgs e)
        {
            SacAmbari_Stok_Karti_Güncelle();
        }
        private void Stok_Kartı_TümList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Stok_Kartı_TümList.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = Stok_Kartı_TümList.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = Stok_Kartı_TümList.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = Stok_Kartı_TümList.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = Stok_Kartı_TümList.CurrentRow.Cells[5].Value.ToString();
        }

        private void Stok_Kartı_TümList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
