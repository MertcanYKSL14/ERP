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
    public partial class Urun_G_C_Bul : Form
    {
        public Urun_G_C_Bul()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
      
        private void Stok_Kartı_listele()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from SacAmbari_Stok_Kartı order by Stok_Kodu asc", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Urun_G_C_Bul_Tablo.DataSource = tablo;
            baglanti.Close();
        }

        private void Urun_G_C_Bul_Load(object sender, EventArgs e)//Bul butonuna basıldığında Stok Kartı tablosunun ekrana getirilmesi
        {
            Stok_Kartı_listele();
        }
     
        private void button1_Click(object sender, EventArgs e)//Arama yapma bölümü
        {
            tablo.Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select *From SacAmbari_Stok_Kartı where Stok_Kodu='" + textBox17.Text + "'", baglanti);
            adtr.Fill(tablo);
            Urun_G_C_Bul_Tablo.DataSource = tablo;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)//Seç butonu ile seçilen verilerin Form1'de yerlerine gönderilmesi işlemi gerçekleşir
        {
            Urun_Giris_Cikis frm = Owner as Urun_Giris_Cikis;
            if (checkBox1.Checked==true) //Eğer Hurda yada Alternatif seçilirse isimi kendimiz yazıcaz 
            {
                frm.textBox1.Text = Urun_G_C_Bul_Tablo.CurrentRow.Cells[0].Value.ToString();
                frm.textBox6.Text = Urun_G_C_Bul_Tablo.CurrentRow.Cells[2].Value.ToString();
                frm.comboBox3.Text = Urun_G_C_Bul_Tablo.CurrentRow.Cells[3].Value.ToString();
                frm.comboBox2.Text = "P";
            }
            else
            {
                frm.comboBox2.Text = "R";
                frm.textBox1.Text = Urun_G_C_Bul_Tablo.CurrentRow.Cells[0].Value.ToString();
                frm.textBox3.Text = Urun_G_C_Bul_Tablo.CurrentRow.Cells[1].Value.ToString();
                frm.textBox6.Text = Urun_G_C_Bul_Tablo.CurrentRow.Cells[2].Value.ToString();
                frm.comboBox3.Text = Urun_G_C_Bul_Tablo.CurrentRow.Cells[3].Value.ToString();
                frm.textBox13.Text = Urun_G_C_Bul_Tablo.CurrentRow.Cells[4].Value.ToString();
            }
            this.Close();
        }
      
        private void button3_Click(object sender, EventArgs e)
        {
            textBox16.Clear();
            textBox17.Clear();
            Stok_Kartı_listele();
        }
       
        private void Urun_G_C_Bul_Tablo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = Urun_G_C_Bul_Tablo.SelectedCells[0].RowIndex;
            textBox17.Text = Urun_G_C_Bul_Tablo.Rows[secilen].Cells[0].Value.ToString();
            textBox16.Text = Urun_G_C_Bul_Tablo.Rows[secilen].Cells[1].Value.ToString();
        }
    }
}
