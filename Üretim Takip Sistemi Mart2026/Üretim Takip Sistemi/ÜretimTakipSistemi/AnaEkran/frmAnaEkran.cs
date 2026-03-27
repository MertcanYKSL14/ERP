using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ÜretimTakipSistemi.CNC;
using ÜretimTakipSistemi.SacAmbarı;

namespace ÜretimTakipSistemi
{
    public partial class frmAnaEkran : Form
    {
        public frmAnaEkran()
        {
            InitializeComponent();
        }
        private Form kontrolEkrani;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void buton_Kaydırma_Click(object sender, EventArgs e)
        {
            if (pnlDikeyMenu.Width == 160)
            {
                pnlDikeyMenu.Width = 50;
                labelBaslik.Visible = false;
            }
            else
            {
                pnlDikeyMenu.Width = 160;
                labelBaslik.Visible = true;
            }
        }
        private void Kapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Alt_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Ust_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Stok_ListesiPanel(Form KontrolEkrani)
        {
            Ana_Panel.Controls.Clear();
            kontrolEkrani = KontrolEkrani;
            KontrolEkrani.TopLevel = false;
            KontrolEkrani.FormBorderStyle = FormBorderStyle.None;
            KontrolEkrani.Dock = DockStyle.Fill;
            Ana_Panel.Controls.Add(KontrolEkrani);
            Ana_Panel.Tag = KontrolEkrani;
            KontrolEkrani.BringToFront();
            KontrolEkrani.Show();


        }
        //private void Stok_ListesiPanel(object Stok_Form)
        //{
        //    if (this.Ana_Panel.Controls.Count > 0)// Ana ekrandaki panel 
        //        this.Ana_Panel.Controls.RemoveAt(0);
        //    Form fh = Stok_Form as Form;
        //    fh.TopLevel = false; //formu en üst düzey pencere olarak göstermek için true; Aksi takdirde, false.Varsayılan, true değeridir.
        //    fh.Dock = DockStyle.Fill;
        //    this.Ana_Panel.Controls.Add(fh);
        //    this.Ana_Panel.Tag = fh;
        //    fh.Show();
        //}
        private void Stok_Listesi_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            panel2.BackColor = Color.Black;
            panel3.BackColor = Color.Black;
            panel4.BackColor = Color.Black;
            panel5.BackColor = Color.Black;
            panel6.BackColor = Color.Black;
            panel7.BackColor = Color.Black;
            Stok_ListesiPanel(new Stok_Listesi());
        }
        private void Stok_Karti_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Black;
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.Black;
            panel4.BackColor = Color.Black;
            panel5.BackColor = Color.Black;
            panel6.BackColor = Color.Black;
            panel7.BackColor = Color.Black;
            Stok_ListesiPanel(new Stok_Kartı());
        }

        private void Urun_G_C_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Black;
            panel2.BackColor = Color.Black;
            panel3.BackColor = Color.White;
            panel4.BackColor = Color.Black;
            panel5.BackColor = Color.Black;
            panel6.BackColor = Color.Black;
            panel7.BackColor = Color.Black;
            Stok_ListesiPanel(new Urun_Giris_Cikis());
        }

        private void Barkod_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Black;
            panel2.BackColor = Color.Black;
            panel3.BackColor = Color.Black;
            panel4.BackColor = Color.White;
            panel5.BackColor = Color.Black;
            panel6.BackColor = Color.Black;
            panel7.BackColor = Color.Black;
            Stok_ListesiPanel(new Barkod());
        }
        private void Sevkiyat_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Black;
            panel2.BackColor = Color.Black;
            panel3.BackColor = Color.Black;
            panel4.BackColor = Color.Black;
            panel5.BackColor = Color.White;
            panel6.BackColor = Color.Black;
            panel7.BackColor = Color.Black;
            Stok_ListesiPanel(new Sevkiyat());
        }

        private void Tam_Ekran_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }


        }

        private void Ana_Ekran_Load_1(object sender, EventArgs e)
        {
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Black;
            panel2.BackColor = Color.Black;
            panel3.BackColor = Color.Black;
            panel4.BackColor = Color.Black;
            panel5.BackColor = Color.Black;
            panel6.BackColor = Color.White;
            panel7.BackColor = Color.Black;
            Stok_ListesiPanel(new Sevkiyat_Stok_Kartı());
        }
        private void Press_Btn_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Black;
            panel2.BackColor = Color.Black;
            panel3.BackColor = Color.Black;
            panel4.BackColor = Color.Black;
            panel5.BackColor = Color.Black;
            panel6.BackColor = Color.Black;
            panel7.BackColor = Color.White;
            Stok_ListesiPanel(new Press_Bolumu());
        }

        private void Ana_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelBaslik_Click(object sender, EventArgs e)
        {

        }

        private void CNC_Btn_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Black;
            panel2.BackColor = Color.Black;
            panel3.BackColor = Color.Black;
            panel4.BackColor = Color.Black;
            panel5.BackColor = Color.Black;
            panel6.BackColor = Color.Black;
            panel7.BackColor = Color.White;
            Stok_ListesiPanel(new CNC_Bölümü());
        }

        

        private void Lazer_Btn_Click(object sender, EventArgs e)
        {
            UrunAgaciApp yeni = new UrunAgaciApp();
            yeni.Show();
        }

        private void UrunAgaciV1_Btn_Click(object sender, EventArgs e)
        {
            UrunAgaciV1 yeni = new UrunAgaciV1();
            yeni.Show();
        }
    }
}
