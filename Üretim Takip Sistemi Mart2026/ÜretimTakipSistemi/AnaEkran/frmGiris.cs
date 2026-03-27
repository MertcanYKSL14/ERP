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


namespace ÜretimTakipSistemi
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsd, int wparam, int lparam);
        
        private void Giris_Enter(object sender, EventArgs e)
        {
            if(lblGiris.Text=="GİRİŞ")
            {
                lblGiris.Text = "";
                lblGiris.ForeColor = Color.White;
            }
        }
        private void Giris_Leave(object sender, EventArgs e)
        {
            if(lblGiris.Text=="")
            {
                lblGiris.Text = "GİRİŞ";
                lblGiris.ForeColor = Color.White;
            }
        }
        private void Parola_Enter(object sender, EventArgs e)
        {
            if (lblParola.Text == "PAROLA")
            {
                lblParola.Text = "";
                lblParola.ForeColor = Color.White;
                lblParola.UseSystemPasswordChar = true;
            }
        }
        private void Parola_Leave(object sender, EventArgs e)
        {
            if (lblParola.Text == "")
            {
                lblParola.Text = "PAROLA";
                lblParola.ForeColor = Color.White;
                lblParola.UseSystemPasswordChar = false;
            }
        }
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnAlt_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            frmAnaEkran ana_ekrana_gec = new frmAnaEkran();
            ana_ekrana_gec.Show();
            this.Hide();
        }

        private void btnSifreUnutma_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void btnHesapOlstur_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHesapOlustur yeni = new frmHesapOlustur();
            yeni.Show();


        }
    }
}
