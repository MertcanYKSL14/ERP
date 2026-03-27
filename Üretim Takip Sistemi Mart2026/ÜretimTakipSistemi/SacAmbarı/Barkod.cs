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
using System.Drawing.Printing;// ekledik

namespace ÜretimTakipSistemi
{
    public partial class Barkod : Form
    {
        PrintDocument pDoc; // Bir PrintDocument Yaratiyoruz.
        string StokKodu,StokAdi,Agirlik,Tarih,Saat,Boy,Stok_Ismi;

        public Barkod()
        {
            InitializeComponent();
            pDoc = new PrintDocument(); // PrintDocument nesnemizin tanimlamasi gerceklesiyor.
            pDoc.PrintPage += new PrintPageEventHandler(pDoc_PrintPage);// Print event'i yaratiliyor.
        }
        SqlConnection baglanti = new SqlConnection("Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;");
        SqlCommand komut;
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
       
        private void Barkod_listesi()
        {
            tablo.Clear();
            baglanti.Open();
            komut = new SqlCommand("Select *from SacAmbariBarkod order by Barkod desc", baglanti);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            Barkod_Tablosu.DataSource = tablo;
            baglanti.Close();
        }
       
        void pDoc_PrintPage(object sender, PrintPageEventArgs e)// Print Fonksionu
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter; // Bundan sonra X, Y, Genislik, Yukseklik gibi olculerde
            System.Drawing.Graphics Cerceve;               // Pixel degil Milimetre kullanicahiz
            Cerceve = this.CreateGraphics();
            Pen Kalem = new Pen(System.Drawing.Color.Black, 1);
            Rectangle Dikdortgen = new Rectangle(3, 3, 145, 90);
            Pen Düz_Cizgi = new Pen(System.Drawing.Color.Black, 1);

            Font aFont = new System.Drawing.Font("Arial", 24); //Yazı boyutları ayarlanıyor
            Font bFont = new System.Drawing.Font("Arial", 18);
            Font cFont = new System.Drawing.Font("Arial", 20);
            Font dFont = new System.Drawing.Font("Arial", 20);
            Font eFont = new System.Drawing.Font("Arial", 16);
            Font fFont = new System.Drawing.Font("Arial", 16);  
            Font hFont = new System.Drawing.Font("Arial", 28);
            Font kFont = new System.Drawing.Font("Arial", 28);

            Rectangle rect; //Dikdörtgen çizdirmek için 
            rect = new Rectangle(17, 65, 55, 30);
            e.Graphics.DrawString("Serdar Makina Sanayi", aFont, Brushes.Black, 35f, 4f); 
            e.Graphics.DrawString(StokAdi, bFont, Brushes.Black, 5f, 17f);
            e.Graphics.DrawString("Stok Kodu:"+StokKodu, cFont, Brushes.Black, 5f, 27f);
            if(Boy!="") // Eğer boy bilgisi varsa stok ismi değişiyor bu nedenle Urun_G_C' dan Stok adı çekiliyor.
            {
            e.Graphics.DrawString("Adet=" + Agirlik, dFont, Brushes.Black, 5f, 35f); // Boy girilmişse adet olarak kayıt işlemi gerçekleşiyor
                baglanti.Open();    //barkoddan verilerin alınması ve okuma işleminin gerçekleştirilmesi
                komut = new SqlCommand("Select *from SacAmbariUrunGecmisi where Barkod like '" + textBox1.Text.ToString() + "'");
                SqlDataReader okuma = komut.ExecuteReader();
                while (okuma.Read())
                {
                    Stok_Ismi = okuma["StokAdi"].ToString();
                }
                baglanti.Close();
                int len = Stok_Ismi.Length;
                if(len>25)
                {
                    string Tümü = Stok_Ismi.Substring(0, 24);
                    string Devamı = Stok_Ismi.Substring(24);
                    e.Graphics.DrawString(Tümü+"-", hFont, Brushes.Black, 5f, 45f);
                    e.Graphics.DrawString(Devamı, kFont, Brushes.Black, 5f, 55f);
                }
                else
                {
                    e.Graphics.DrawString(Stok_Ismi, hFont, Brushes.Black, 5f, 45f);
                }
            }
            else // Boy bilgisi yoksa Ağırlık olarak kayıt işlemi gerçekleşiyor
            {
            e.Graphics.DrawString("Ağırlık=" + Agirlik + "kg", dFont, Brushes.Black, 5f, 35f);
            baglanti.Open();    //barkoddan verilerin alınması ve okuma işleminin gerçekleştirilmesi
            komut = new SqlCommand("Select *from SacAmbariUrunGecmisi where Barkod like '" + textBox1.Text.ToString() + "'", baglanti);
            SqlDataReader okuma = komut.ExecuteReader();
            while (okuma.Read())
            {
                Stok_Ismi = okuma["StokAdi"].ToString();
            }
            baglanti.Close();
            int lenn = Stok_Ismi.Length;
            if (lenn > 25)
            {
                 string Tümü = Stok_Ismi.Substring(0, 24);
                 string Devamı = Stok_Ismi.Substring(24);
                 e.Graphics.DrawString(Tümü + "-", hFont, Brushes.Black, 5f, 45f);
                 e.Graphics.DrawString(Devamı, kFont, Brushes.Black, 5f, 55f);
            }
            else
            {
                 e.Graphics.DrawString(Stok_Ismi, hFont, Brushes.Black, 5f, 45f);
            }
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum; // Barkod oluşturma işlemi 
                var barcodeImage = barcode.Draw(textBox1.Text, 50);
                var resultImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 14); // 20 is bottom padding, adjust to your text
                using (var graphics = Graphics.FromImage(resultImage))
                using (var font = new Font("Consolas", 10)) // Barkod teknik özellikler
                using (var brush = new SolidBrush(Color.Black))
                using (var format = new StringFormat()
                {
                    Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
                    LineAlignment = StringAlignment.Far
                })
                {
                    graphics.Clear(Color.White);
                    graphics.DrawImage(barcodeImage, 0, 0);
                    graphics.DrawString(textBox1.Text, font, brush, resultImage.Width / 2, resultImage.Height, format);
                }
                pictureBox1.Image = resultImage;
                e.Graphics.DrawString("Giriş Tarihi", eFont, Brushes.Black, 107f, 27f);
                e.Graphics.DrawString(Tarih + " " + Saat, fFont, Brushes.Black, 95f, 35f);
                e.Graphics.DrawImage(pictureBox1.Image, rect);
                e.Graphics.DrawRectangle(Kalem, Dikdortgen);
                e.Graphics.DrawLine(Düz_Cizgi, 3, 15, 148, 15);
                e.Graphics.DrawLine(Düz_Cizgi, 3, 27, 148, 27);
                //   e.Graphics.DrawImage(pictureBox2.Image, 100, 70, 35,40);
                //  Image aImg = Image.FromFile(@"D:\C# çalışmaları\EMAS2\ERP\ERP\bin\Debug\Resimler\a.png");
                // e.Graphics.DrawImage(aImg, 100, 50, 45, 40);
            }
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Önce Barkod Seçiniz");
            }
            else
            {
               pDoc.Print();
               textBox1.Clear();
            }
        }
        
        private void Barkod_Load(object sender, EventArgs e)
        {
            Barkod_listesi();
        }
       
        private void Barkod_Tablosu_CellClick_1(object sender, DataGridViewCellEventArgs e) //Barkod kağıdı için tablodan gerekli bilgilerin seçilme işlemi
        {
            textBox1.Text = Barkod_Tablosu.CurrentRow.Cells[3].Value.ToString();
            StokKodu = Barkod_Tablosu.CurrentRow.Cells[1].Value.ToString();
            StokAdi = Barkod_Tablosu.CurrentRow.Cells[2].Value.ToString();
            Agirlik = Barkod_Tablosu.CurrentRow.Cells[5].Value.ToString();
            Saat = Barkod_Tablosu.CurrentRow.Cells[9].Value.ToString();
            Tarih = Barkod_Tablosu.CurrentRow.Cells[10].Value.ToString();
            Boy = Barkod_Tablosu.CurrentRow.Cells[8].Value.ToString();
         }
    }
}
