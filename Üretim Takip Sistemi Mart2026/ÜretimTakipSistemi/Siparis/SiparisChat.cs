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
using System.Drawing.Drawing2D;
using System.IO;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using SiparisChatMesajiEntity = ÜretimTakipSistemi.Entities.Concrete.SiparisChatMesaji;

namespace ÜretimTakipSistemi.Siparis
{
    public partial class SiparisChat : Form
    {
        string baglantiCumlesi = "Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=SiparisDB; User Id=ADMIN; Password=1;";
        string aktifKullanici = "Yonetim"; 
        int sonMesajID = 0;
        private readonly ISiparisService _siparisService;

        public SiparisChat()
        {
            InitializeComponent();
            _siparisService = InstanceFactory.GetInstance<ISiparisService>();
            yenilemeZamanlayicisi.Start(); // Timer'ı başlat
            MesajlariCek(); // İlk açılışta mesajları çek
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMesaj.Text)) return;

            try
            {
                _siparisService.ChatMesajiGonder(aktifKullanici, txtMesaj.Text);
                txtMesaj.Clear();
                MesajlariCek(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void yenilemeZamanlayicisi_Tick(object sender, EventArgs e)
        {
            MesajlariCek();
        }

        private void btnDosyaEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim ve Belgeler|*.jpg;*.png;*.pdf;*.docx;*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] dosyaByte = File.ReadAllBytes(ofd.FileName);
                string dosyaAdi = Path.GetFileName(ofd.FileName);

                DosyaGonder(dosyaAdi, dosyaByte);
            }
        }

        private void DosyaGonder(string ad, byte[] veri)
        {
            try
            {
                _siparisService.ChatDosyasiGonder(aktifKullanici, ad, veri);
                MesajlariCek(); // Dosya gönderildikten sonra mesajları yenile
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya gönderilirken hata: " + ex.Message);
            }
        }

        private void txtMesaj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true; // Enter sesini engelle
                btnGonder.PerformClick();
            }
        }

        private void pnlSohbetAkisi_SizeChanged(object sender, EventArgs e)
        {
            // Pencere boyutu değişirse mesajların genişliğini ayarla
            foreach (Control c in pnlSohbetAkisi.Controls)
            {
                c.Width = pnlSohbetAkisi.ClientSize.Width - 30;
            }
        }

        private void MesajlariCek()
        {
            try
            {
                List<SiparisChatMesajiEntity> mesajlar = _siparisService.GetChatMesajlari(sonMesajID);
                bool yeniMesajGeldi = false;

                foreach (SiparisChatMesajiEntity mesaj in mesajlar)
                {
                    BaloncukEkle(
                        mesaj.Id,
                        mesaj.Gonderen,
                        mesaj.Mesaj,
                        mesaj.Tarih,
                        mesaj.DosyaVarMi,
                        mesaj.DosyaAdi,
                        mesaj.DosyaVerisi);

                    if (mesaj.Id > sonMesajID)
                    {
                        sonMesajID = mesaj.Id;
                        yeniMesajGeldi = true;
                    }
                }

                // Yeni mesaj geldiyse en aşağıya kaydır
                if (yeniMesajGeldi && pnlSohbetAkisi.Controls.Count > 0)
                {
                    pnlSohbetAkisi.ScrollControlIntoView(pnlSohbetAkisi.Controls[pnlSohbetAkisi.Controls.Count - 1]);
                }
            }
            catch (Exception ex)
            {
                // Hata ayıklama için (isteğe bağlı)
                MessageBox.Show("Mesajlar yazılırken hata: " + ex.Message);
            }
        }

        private void BaloncukEkle(int mesajID, string gonderen, string mesaj, DateTime tarih, bool dosyaVarMi, string dosyaAdi, byte[] dosyaByte)
        {
            bool benimMesajim = (gonderen == aktifKullanici);

            // Satır Paneli (Hizalama için)
            Panel pnlSatir = new Panel();
            pnlSatir.Width = pnlSohbetAkisi.ClientSize.Width - 30;
            pnlSatir.Padding = new Padding(5);
            pnlSatir.BackColor = Color.Transparent;

            // Görsel Baloncuk
            Panel pnlBalon = new Panel();
            pnlBalon.BackColor = benimMesajim ? Color.FromArgb(0, 92, 75) : Color.FromArgb(32, 44, 51);
            pnlBalon.Padding = new Padding(10);
            pnlBalon.Tag = mesajID; // Mesaj ID'sini Tag olarak sakla

            // Mesaj Metni
            Label lblMesaj = new Label();
            lblMesaj.Text = mesaj;
            lblMesaj.ForeColor = Color.White;
            lblMesaj.Font = new Font("Segoe UI", 10);
            lblMesaj.AutoSize = true;
            lblMesaj.MaximumSize = new Size(300, 0);

            // Bilgi Metni (Saat ve İsim)
            Label lblInfo = new Label();
            lblInfo.Text = benimMesajim ? $"{tarih:HH:mm}" : $"{gonderen} • {tarih:HH:mm}";
            lblInfo.ForeColor = Color.Silver;
            lblInfo.Font = new Font("Segoe UI", 7);
            lblInfo.AutoSize = true;

            // Balonun içine ekle
            pnlBalon.Controls.Add(lblMesaj);
            pnlBalon.Controls.Add(lblInfo);
            lblMesaj.Location = new Point(10, 10);
            lblInfo.Location = new Point(10, lblMesaj.Bottom + 5);

            // Dosya varsa link ekle
            if (dosyaVarMi)
            {
                LinkLabel lnkDosya = new LinkLabel();
                lnkDosya.Text = "📁 " + dosyaAdi;
                lnkDosya.LinkColor = Color.LightSkyBlue;
                lnkDosya.AutoSize = true;

                lnkDosya.Click += (s, ev) =>
                {
                    string yol = Path.Combine(
                        Path.GetTempPath(),
                        Guid.NewGuid() + "_" + dosyaAdi);

                    File.WriteAllBytes(yol, dosyaByte);
                    System.Diagnostics.Process.Start(yol);
                };

                pnlBalon.Controls.Add(lnkDosya);
                lnkDosya.Location = new Point(10, lblInfo.Bottom + 5);
            }

            // Balon boyutunu ayarla
            pnlBalon.AutoSize = true;
            pnlBalon.MaximumSize = new Size(350, 0);

            // Yuvarlatılmış Köşeler
            pnlBalon.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle r = new Rectangle(0, 0, pnlBalon.Width, pnlBalon.Height);
                int radius = 15;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(r.X, r.Y, radius, radius, 180, 90);
                    path.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90);
                    path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();
                    pnlBalon.Region = new Region(path);
                }
            };

            // Sağ tık menüsü (Mesaj silme) - Sadece mesaj sahibi veya yönetici için
            if (benimMesajim || aktifKullanici == "Yonetim")
            {
                ContextMenuStrip cms = new ContextMenuStrip();
                ToolStripItem silItem = cms.Items.Add("🗑 Mesajı Sil");
                silItem.Click += (s, e) =>
                {
                    if (MessageBox.Show("Mesajı silmek istediğinize emin misiniz?",
                        "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MesajSil(mesajID);
                    }
                };
                pnlBalon.ContextMenuStrip = cms;
            }

            pnlSatir.Controls.Add(pnlBalon);

            // Sağa/Sola Yasla
            if (benimMesajim)
                pnlBalon.Location = new Point(pnlSatir.Width - pnlBalon.Width - 10, 5);
            else
                pnlBalon.Location = new Point(10, 5);

            pnlSatir.Height = pnlBalon.Height + 15;
            pnlSohbetAkisi.Controls.Add(pnlSatir);
        }

        private void MesajSil(int mesajID)
        {
            try
            {
                _siparisService.ChatMesajiSil(mesajID);

                // Paneli temizle ve tüm mesajları yeniden çek
                pnlSohbetAkisi.Controls.Clear();
                sonMesajID = 0;
                MesajlariCek();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesaj silinirken hata: " + ex.Message);
            }
        }
    }
}
