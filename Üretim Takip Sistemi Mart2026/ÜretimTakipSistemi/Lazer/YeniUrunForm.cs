using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.Lazer
{
    public partial class YeniUrunForm : Form
    {
        private string connectionString;
        private int? urunID;
        private bool duzenlemeModunda = false;
        private List<AltUrun> altUrunler = new List<AltUrun>();
        private readonly ILazerUrunFormService _lazerUrunFormService;

        private class AltUrun
        {
            public int? MevcutUrunID { get; set; }
            public string ParcaAdi { get; set; }
            public int Adet { get; set; }
            public decimal UrunBoyu { get; set; }
            public string ProfilEbati { get; set; }
            public decimal ProfilUzunlugu { get; set; }
        }

        public YeniUrunForm(string connString)
        {
            InitializeComponent();
            this.connectionString = connString;
            this.duzenlemeModunda = false;
            _lazerUrunFormService = InstanceFactory.GetInstance<ILazerUrunFormService>();
            this.Text = "Yeni Ürün Ekle";
        }

        public YeniUrunForm(string connString, int urunID)
        {
            InitializeComponent();
            this.connectionString = connString;
            this.urunID = urunID;
            this.duzenlemeModunda = true;
            _lazerUrunFormService = InstanceFactory.GetInstance<ILazerUrunFormService>();
            this.Text = "Ürün Düzenle";
        }

        private void YeniUrunForm_Load(object sender, EventArgs e)
        {
            cmbLazerTipi.Items.AddRange(new string[] { "Boru", "Plaka" });
            cmbLazerTipi.SelectedIndex = 0;

            ProfilListesiniYukle();
            AltUrunGridiniHazirla();

            if (duzenlemeModunda && urunID.HasValue)
            {
                UrunBilgileriniYukle();
            }
        }

        private void ProfilListesiniYukle()
        {
            try
            {
                List<LazerProfilSecenek> profilListesi = _lazerUrunFormService.GetProfilListesi(connectionString);

                cmbProfilEbati.Items.Clear();
                cmbProfilEbati.Items.Add("");

                foreach (LazerProfilSecenek profil in profilListesi)
                {
                    cmbProfilEbati.Items.Add(profil.ProfilBilgi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Profil listesi yüklenirken hata: " + ex.Message);
            }
        }

        private void AltUrunGridiniHazirla()
        {
            dgvAltUrunler.Columns.Clear();
            dgvAltUrunler.Columns.Add("ParcaAdi", "Parça Adı");
            dgvAltUrunler.Columns.Add("Adet", "Adet");
            dgvAltUrunler.Columns.Add("UrunBoyu", "Ürün Boyu (mm)");
            dgvAltUrunler.Columns.Add("ProfilEbati", "Profil Ebatı");
            dgvAltUrunler.Columns.Add("ProfilUzunlugu", "Profil Uzunluğu (mm)");

            dgvAltUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAltUrunler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAltUrunler.MultiSelect = false;
            dgvAltUrunler.AllowUserToAddRows = false;

            dgvAltUrunler.BorderStyle = BorderStyle.None;
            dgvAltUrunler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgvAltUrunler.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAltUrunler.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvAltUrunler.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAltUrunler.EnableHeadersVisualStyles = false;
            dgvAltUrunler.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAltUrunler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvAltUrunler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAltUrunler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvAltUrunler.RowTemplate.Height = 35;
        }

        private void UrunBilgileriniYukle()
        {
            try
            {
                LazerUrunDuzenlemeModel model = _lazerUrunFormService.GetUrunDuzenlemeModel(connectionString, urunID ?? 0);

                if (model == null)
                {
                    throw new InvalidOperationException("Urun kaydi bulunamadi.");
                }

                txtUrunKodu.Text = model.UrunKodu;
                txtUrunAdi.Text = model.UrunAdi;
                if (!string.IsNullOrEmpty(model.LazerTipi))
                    cmbLazerTipi.SelectedItem = model.LazerTipi;
                txtAciklama.Text = model.Aciklama ?? string.Empty;
                chkGrupluUrun.Checked = model.GrupluUrunMu;

                if (!model.GrupluUrunMu && cmbLazerTipi.SelectedItem?.ToString() == "Boru")
                {
                    if (model.UrunBoyu.HasValue && model.UrunBoyu.Value > 0)
                        numUrunBoyu.Value = model.UrunBoyu.Value;

                    if (!string.IsNullOrEmpty(model.ProfilEbati) && model.ProfilUzunlugu.HasValue && model.ProfilUzunlugu.Value > 0)
                        cmbProfilEbati.Text = model.ProfilEbati + " - " + model.ProfilUzunlugu.Value + "mm";
                }

                if (cmbLazerTipi.SelectedItem?.ToString() == "Plaka" && model.SacKalinligi.HasValue && model.SacKalinligi.Value > 0)
                {
                    numSacKalinligi.Value = model.SacKalinligi.Value;
                }

                altUrunler.Clear();
                foreach (LazerAltUrunDetay altUrun in model.AltUrunler)
                {
                    altUrunler.Add(new AltUrun
                    {
                        ParcaAdi = altUrun.ParcaAdi,
                        Adet = altUrun.Adet,
                        UrunBoyu = altUrun.UrunBoyu,
                        ProfilEbati = altUrun.ProfilEbati,
                        ProfilUzunlugu = altUrun.ProfilUzunlugu
                    });
                }

                AltUrunleriGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün bilgileri yüklenirken hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────────
        // Panel görünürlüğü
        // ──────────────────────────────────────────────────────────────
        private void PanelleriGuncelle()
        {
            bool isBoru = cmbLazerTipi.SelectedItem?.ToString() == "Boru";
            bool isPlaka = cmbLazerTipi.SelectedItem?.ToString() == "Plaka";

            // Boru panelleri
            chkGrupluUrun.Visible = isBoru;
            pnlAnaUrun.Visible = isBoru && !chkGrupluUrun.Checked;
            pnlAltUrunler.Visible = isBoru && chkGrupluUrun.Checked;

            // Plaka paneli
            pnlPlakaKalinlik.Visible = isPlaka;

            // Form yüksekliği
            if (isPlaka)
                this.Height = 450;
            else if (isBoru && chkGrupluUrun.Checked)
                this.Height = 750;
            else
                this.Height = 500;
        }

        private void chkGrupluUrun_CheckedChanged(object sender, EventArgs e)
        {
            PanelleriGuncelle();
        }

        private void cmbLazerTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelleriGuncelle();
        }

        // ──────────────────────────────────────────────────────────────
        // Alt ürün işlemleri
        // ──────────────────────────────────────────────────────────────
        private void btnAltUrunEkle_Click(object sender, EventArgs e)
        {
            AltUrunEkleDialog dialog = new AltUrunEkleDialog(connectionString);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                altUrunler.Add(new AltUrun
                {
                    MevcutUrunID = dialog.MevcutUrunID,
                    ParcaAdi = dialog.ParcaAdi,
                    Adet = dialog.Adet,
                    UrunBoyu = dialog.UrunBoyu,
                    ProfilEbati = dialog.ProfilEbati,
                    ProfilUzunlugu = dialog.ProfilUzunlugu
                });
                AltUrunleriGuncelle();
            }
        }

        private void btnAltUrunSil_Click(object sender, EventArgs e)
        {
            if (dgvAltUrunler.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Seçili alt ürünü silmek istediğinizden emin misiniz?", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    altUrunler.RemoveAt(dgvAltUrunler.SelectedRows[0].Index);
                    AltUrunleriGuncelle();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir alt ürün seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AltUrunleriGuncelle()
        {
            dgvAltUrunler.Rows.Clear();
            foreach (var au in altUrunler)
                dgvAltUrunler.Rows.Add(au.ParcaAdi, au.Adet, au.UrunBoyu, au.ProfilEbati, au.ProfilUzunlugu);
        }

        // ──────────────────────────────────────────────────────────────
        // Kaydet
        // ──────────────────────────────────────────────────────────────
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string lazerTipi = cmbLazerTipi.SelectedItem?.ToString();
                string profilEbati = null;
                decimal? profilUzunlugu = null;

                if (!chkGrupluUrun.Checked && lazerTipi == "Boru"
                    && !string.IsNullOrWhiteSpace(cmbProfilEbati.Text))
                {
                    string[] parts = cmbProfilEbati.Text.Split(new[] { " - " }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        profilEbati = parts[0];
                        profilUzunlugu = decimal.Parse(parts[1].Replace("mm", "").Trim());
                    }
                }

                LazerUrunKaydetTalep talep = new LazerUrunKaydetTalep
                {
                    UrunId = duzenlemeModunda ? urunID : null,
                    UrunKodu = txtUrunKodu.Text,
                    UrunAdi = txtUrunAdi.Text,
                    LazerTipi = lazerTipi,
                    Aciklama = txtAciklama.Text,
                    GrupluUrunMu = chkGrupluUrun.Checked,
                    UrunBoyu = (!chkGrupluUrun.Checked && lazerTipi == "Boru") ? (decimal?)numUrunBoyu.Value : null,
                    ProfilEbati = profilEbati,
                    ProfilUzunlugu = profilUzunlugu,
                    SacKalinligi = lazerTipi == "Plaka" ? (decimal?)numSacKalinligi.Value : null
                };

                foreach (AltUrun au in altUrunler)
                {
                    talep.AltUrunler.Add(new LazerAltUrunDetay
                    {
                        ParcaAdi = au.ParcaAdi,
                        Adet = au.Adet,
                        UrunBoyu = au.UrunBoyu,
                        ProfilEbati = au.ProfilEbati,
                        ProfilUzunlugu = au.ProfilUzunlugu
                    });
                }

                _lazerUrunFormService.KaydetUrun(connectionString, talep);

                MessageBox.Show(
                    duzenlemeModunda ? "Ürün başarıyla güncellendi!" : "Ürün başarıyla eklendi!",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem sırasında hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    // ══════════════════════════════════════════════════════════════════
    // AltUrunEkleDialog - değişmedi, aynen korunuyor
    // ══════════════════════════════════════════════════════════════════
    public class AltUrunEkleDialog : Form
    {
        public int? MevcutUrunID { get; private set; }
        public string ParcaAdi { get; private set; }
        public int Adet { get; private set; }
        public decimal UrunBoyu { get; private set; }
        public string ProfilEbati { get; private set; }
        public decimal ProfilUzunlugu { get; private set; }

        private ComboBox cmbMevcutUrun;
        private TextBox txtParcaAdi;
        private NumericUpDown numAdet;
        private NumericUpDown numUrunBoyu;
        private ComboBox cmbProfilEbati;
        private NumericUpDown numProfilUzunlugu;
        private Button btnTamam;
        private Button btnIptal;
        private Label lblBilgi;
        private string connectionString;
        private readonly ILazerUrunFormService _lazerUrunFormService;

        public AltUrunEkleDialog(string connString)
        {
            this.connectionString = connString;
            _lazerUrunFormService = InstanceFactory.GetInstance<ILazerUrunFormService>();
            InitializeComponent();
            MevcutUrunleriYukle();
        }

        private void InitializeComponent()
        {
            this.cmbMevcutUrun = new ComboBox();
            this.txtParcaAdi = new TextBox();
            this.numAdet = new NumericUpDown();
            this.numUrunBoyu = new NumericUpDown();
            this.cmbProfilEbati = new ComboBox();
            this.numProfilUzunlugu = new NumericUpDown();
            this.btnTamam = new Button();
            this.btnIptal = new Button();
            this.lblBilgi = new Label();

            this.SuspendLayout();

            this.lblBilgi.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblBilgi.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblBilgi.Location = new Point(20, 15);
            this.lblBilgi.Size = new Size(460, 40);
            this.lblBilgi.Text = "💡 Mevcut bir ürünü seçebilir veya yeni bir alt ürün oluşturabilirsiniz.\nMevcut ürün seçerseniz bilgileri otomatik yüklenir.";

            this.cmbMevcutUrun.Font = new Font("Segoe UI", 10F);
            this.cmbMevcutUrun.Location = new Point(180, 65);
            this.cmbMevcutUrun.Size = new Size(300, 28);
            this.cmbMevcutUrun.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMevcutUrun.SelectedIndexChanged += CmbMevcutUrun_SelectedIndexChanged;

            this.txtParcaAdi.Font = new Font("Segoe UI", 10F);
            this.txtParcaAdi.Location = new Point(180, 105);
            this.txtParcaAdi.Size = new Size(300, 28);

            this.numAdet.Font = new Font("Segoe UI", 10F);
            this.numAdet.Location = new Point(180, 145);
            this.numAdet.Minimum = 1;
            this.numAdet.Maximum = 1000;
            this.numAdet.Value = 1;
            this.numAdet.Size = new Size(300, 28);

            this.numUrunBoyu.Font = new Font("Segoe UI", 10F);
            this.numUrunBoyu.Location = new Point(180, 185);
            this.numUrunBoyu.Maximum = 100000;
            this.numUrunBoyu.DecimalPlaces = 2;
            this.numUrunBoyu.Size = new Size(300, 28);

            this.cmbProfilEbati.Font = new Font("Segoe UI", 10F);
            this.cmbProfilEbati.Location = new Point(180, 225);
            this.cmbProfilEbati.Size = new Size(300, 28);
            this.cmbProfilEbati.Items.AddRange(new string[] {
                "10X20","20X20","20X30","25X25","30X30","40X40","50X50","60X60","CAP16","CAP25","CAP30","CAP40"
            });

            this.numProfilUzunlugu.Font = new Font("Segoe UI", 10F);
            this.numProfilUzunlugu.Location = new Point(180, 265);
            this.numProfilUzunlugu.Maximum = 100000;
            this.numProfilUzunlugu.Value = 6000;
            this.numProfilUzunlugu.Size = new Size(300, 28);

            this.btnTamam.BackColor = Color.FromArgb(46, 204, 113);
            this.btnTamam.FlatStyle = FlatStyle.Flat;
            this.btnTamam.FlatAppearance.BorderSize = 0;
            this.btnTamam.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnTamam.ForeColor = Color.White;
            this.btnTamam.Location = new Point(180, 315);
            this.btnTamam.Size = new Size(145, 40);
            this.btnTamam.Text = "✅ Ekle";
            this.btnTamam.Cursor = Cursors.Hand;
            this.btnTamam.Click += BtnTamam_Click;

            this.btnIptal.BackColor = Color.FromArgb(231, 76, 60);
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(335, 315);
            this.btnIptal.Size = new Size(145, 40);
            this.btnIptal.Text = "❌ İptal";
            this.btnIptal.Cursor = Cursors.Hand;
            this.btnIptal.Click += (s, ev) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            Label[] etiketler = {
                new Label { Text="Mevcut Ürün:", Location=new Point(20,68), AutoSize=true, Font=new Font("Segoe UI",10F,FontStyle.Bold), ForeColor=Color.FromArgb(52,73,94) },
                new Label { Text="Parça Adı:", Location=new Point(20,108), AutoSize=true, Font=new Font("Segoe UI",10F,FontStyle.Bold), ForeColor=Color.FromArgb(52,73,94) },
                new Label { Text="Adet:", Location=new Point(20,148), AutoSize=true, Font=new Font("Segoe UI",10F,FontStyle.Bold), ForeColor=Color.FromArgb(52,73,94) },
                new Label { Text="Ürün Boyu (mm):", Location=new Point(20,188), AutoSize=true, Font=new Font("Segoe UI",10F,FontStyle.Bold), ForeColor=Color.FromArgb(52,73,94) },
                new Label { Text="Profil Ebatı:", Location=new Point(20,228), AutoSize=true, Font=new Font("Segoe UI",10F,FontStyle.Bold), ForeColor=Color.FromArgb(52,73,94) },
                new Label { Text="Profil Uzunluğu:", Location=new Point(20,268), AutoSize=true, Font=new Font("Segoe UI",10F,FontStyle.Bold), ForeColor=Color.FromArgb(52,73,94) },
            };

            this.BackColor = Color.FromArgb(236, 240, 245);
            this.ClientSize = new Size(510, 380);
            this.Controls.Add(this.lblBilgi);
            foreach (var lbl in etiketler) this.Controls.Add(lbl);
            this.Controls.Add(this.cmbMevcutUrun);
            this.Controls.Add(this.txtParcaAdi);
            this.Controls.Add(this.numAdet);
            this.Controls.Add(this.numUrunBoyu);
            this.Controls.Add(this.cmbProfilEbati);
            this.Controls.Add(this.numProfilUzunlugu);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Alt Ürün Ekle";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void MevcutUrunleriYukle()
        {
            try
            {
                List<LazerAltUrunSecimItem> liste = _lazerUrunFormService.GetAltUrunSecenekleri(connectionString);
                liste.Insert(0, new LazerAltUrunSecimItem { DetayId = null, UrunBilgi = "-- Yeni Alt Ürün Oluştur --" });

                cmbMevcutUrun.DisplayMember = "UrunBilgi";
                cmbMevcutUrun.ValueMember = "DetayId";
                cmbMevcutUrun.DataSource = liste;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mevcut ürünler yüklenirken hata: " + ex.Message);
            }
        }

        private void CmbMevcutUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMevcutUrun.SelectedValue == null || cmbMevcutUrun.SelectedValue == DBNull.Value)
            {
                txtParcaAdi.Text = "";
                txtParcaAdi.ReadOnly = false;
                numUrunBoyu.Value = 0;
                numUrunBoyu.ReadOnly = false;
                cmbProfilEbati.SelectedIndex = -1;
                cmbProfilEbati.Enabled = true;
                numProfilUzunlugu.Value = 6000;
                numProfilUzunlugu.ReadOnly = false;
                MevcutUrunID = null;
                return;
            }

            try
            {
                LazerAltUrunSecimItem selectedItem = cmbMevcutUrun.SelectedItem as LazerAltUrunSecimItem;
                if (selectedItem == null) return;

                LazerAltUrunDetay detay = _lazerUrunFormService.GetAltUrunDetayi(connectionString, selectedItem.UrunBilgi);
                if (detay == null)
                {
                    return;
                }

                txtParcaAdi.Text = detay.ParcaAdi;
                txtParcaAdi.ReadOnly = false;
                numUrunBoyu.Value = detay.UrunBoyu;
                numUrunBoyu.ReadOnly = false;
                cmbProfilEbati.Text = detay.ProfilEbati;
                cmbProfilEbati.Enabled = true;
                numProfilUzunlugu.Value = detay.ProfilUzunlugu;
                numProfilUzunlugu.ReadOnly = false;
                MevcutUrunID = null;
                numAdet.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün bilgileri yüklenirken hata: " + ex.Message);
            }
        }

        private void BtnTamam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtParcaAdi.Text))
            {
                MessageBox.Show("Parça adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numUrunBoyu.Value <= 0)
            {
                MessageBox.Show("Ürün boyu sıfırdan büyük olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbProfilEbati.Text))
            {
                MessageBox.Show("Profil ebatı seçilmelidir!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ParcaAdi = txtParcaAdi.Text.Trim();
            Adet = (int)numAdet.Value;
            UrunBoyu = numUrunBoyu.Value;
            ProfilEbati = cmbProfilEbati.Text;
            ProfilUzunlugu = numProfilUzunlugu.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
