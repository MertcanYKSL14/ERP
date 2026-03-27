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
    public partial class Sevkiyat_Bul : Form
    {
        public Sevkiyat_Bul()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
        private void Sevkiyat_Bul_Listele()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from Urunler order by StokKodu asc", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Sevkiyat_Bul_Tablo.DataSource = tablo;
            baglanti.Close();
        } // Ürünleri Bulma Butonu...
        private void Sevkiyat_Bul_Load(object sender, EventArgs e)
        {
            Sevkiyat_Bul_Listele();
        } // Ürünlerin bulunduğu tablonun yüklendiği ana ekran...
        private void Sec_Btn_Click(object sender, EventArgs e)
        {
            if(textBox16.Text=="")
            {
                MessageBox.Show("Boş alan var!"); 
            }
            else
            {
                Sevkiyat frm = Owner as Sevkiyat;
                 frm.textBox1.Text = Sevkiyat_Bul_Tablo.CurrentRow.Cells[0].Value.ToString();
                frm.textBox3.Text = Sevkiyat_Bul_Tablo.CurrentRow.Cells[1].Value.ToString();
                this.Close();
            }
        } // Seç Butonu...
        private void TümList_Btn_Click(object sender, EventArgs e)
        {
            textBox16.Clear();
            textBox17.Clear();
            Sevkiyat_Bul_Listele();
        } // Arama yapıldıktan sonra tektar Listeleme Butonu...
        private void Sevkiyat_Bul_Tablo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Sevkiyat frm = Owner as Sevkiyat;
            frm.textBox1.Text = Sevkiyat_Bul_Tablo.CurrentRow.Cells[1].Value.ToString();
            frm.textBox3.Text = Sevkiyat_Bul_Tablo.CurrentRow.Cells[2].Value.ToString();
            this.Close();
        } // Çift Tıklayarak ana ekrana verileri atma...
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            DataView dv = tablo.DefaultView;
            dv.RowFilter = "StokKodu LIKE '" + textBox16.Text + "%'";
            Sevkiyat_Bul_Tablo.DataSource = dv; 
        } // Süzme yaprak arama...
        private void Sevkiyat_Bul_Shown(object sender, EventArgs e)
        {
            textBox16.Focus();
        } // Direk arama textine focuslma...
    }
}
