using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.Lazer
{
    public partial class YeniSiparisForm : Form
    {
        private string connectionString = "Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Lazer; User Id=ADMIN; Password=1;";
        private readonly ILazerSiparisFormService _lazerSiparisFormService;
        private DataTable dtSiparisUrunler;
        private int? duzenlemeSiparisID = null;

        // Teslim tarihi düzenleme için inline DateTimePicker
        private DateTimePicker dtpInline;
        private int _editRow = -1;

        public YeniSiparisForm(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            _lazerSiparisFormService = InstanceFactory.GetInstance<ILazerSiparisFormService>();
            this.duzenlemeSiparisID = null;
        }

        public YeniSiparisForm(string connectionString, int siparisID)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            _lazerSiparisFormService = InstanceFactory.GetInstance<ILazerSiparisFormService>();
            this.duzenlemeSiparisID = siparisID;
        }

        private void YeniSiparisForm_Load(object sender, EventArgs e)
        {
            // DataTable hazırla - TeslimTarihi sütunu eklendi
            dtSiparisUrunler = new DataTable();
            dtSiparisUrunler.Columns.Add("UrunID", typeof(int));
            dtSiparisUrunler.Columns.Add("Ürün Kodu", typeof(string));
            dtSiparisUrunler.Columns.Add("Ürün Adı", typeof(string));
            dtSiparisUrunler.Columns.Add("Lazer Tipi", typeof(string));
            dtSiparisUrunler.Columns.Add("Sipariş Adedi", typeof(int));
            dtSiparisUrunler.Columns.Add("Teslim Tarihi", typeof(DateTime));

            dgvSiparisUrunler.DataSource = dtSiparisUrunler;
            dgvSiparisUrunler.Columns["UrunID"].Visible = false;

            // Teslim Tarihi sütununu daha geniş yap
            if (dgvSiparisUrunler.Columns.Contains("Teslim Tarihi"))
            {
                dgvSiparisUrunler.Columns["Teslim Tarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvSiparisUrunler.Columns["Teslim Tarihi"].FillWeight = 80;
            }

            // Inline DateTimePicker oluştur
            dtpInline = new DateTimePicker();
            dtpInline.Format = DateTimePickerFormat.Short;
            dtpInline.Visible = false;
            dtpInline.CloseUp += DtpInline_CloseUp;
            dgvSiparisUrunler.Controls.Add(dtpInline);

            // Grid olayları
            dgvSiparisUrunler.CellClick += DgvSiparisUrunler_CellClick;
            dgvSiparisUrunler.CellFormatting += DgvSiparisUrunler_CellFormatting;
            dgvSiparisUrunler.Scroll += (s, ev) => { if (dtpInline.Visible) dtpInline.Visible = false; };

            if (duzenlemeSiparisID.HasValue)
            {
                this.Text = "Sipariş Düzenle";
                SiparisBilgileriniYukle(duzenlemeSiparisID.Value);
            }
            else
            {
                this.Text = "Yeni Sipariş";
                txtSiparisNo.Text = "SIP-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                dtpSiparisTarihi.Value = DateTime.Now;
                cmbMusteri.SelectedIndex = 0;
            }
        }

        // ──────────────────────────────────────────────────────────────
        // Teslim Tarihi hücresine tıklandığında inline DTP göster
        // ──────────────────────────────────────────────────────────────
        private void DgvSiparisUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvSiparisUrunler.Columns[e.ColumnIndex].Name != "Teslim Tarihi") return;

            _editRow = e.RowIndex;
            Rectangle cellRect = dgvSiparisUrunler.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

            object cellVal = dgvSiparisUrunler.Rows[e.RowIndex].Cells["Teslim Tarihi"].Value;
            dtpInline.Value = (cellVal != null && cellVal != DBNull.Value)
                ? Convert.ToDateTime(cellVal)
                : DateTime.Today.AddDays(7);

            dtpInline.Location = cellRect.Location;
            dtpInline.Size = cellRect.Size;
            dtpInline.Visible = true;
            dtpInline.BringToFront();
            dtpInline.Focus();
        }

        private void DtpInline_CloseUp(object sender, EventArgs e)
        {
            if (_editRow >= 0 && _editRow < dtSiparisUrunler.Rows.Count)
            {
                dtSiparisUrunler.Rows[_editRow]["Teslim Tarihi"] = dtpInline.Value;
            }
            dtpInline.Visible = false;
            _editRow = -1;
        }

        // Teslim tarihi renklendirmesi (yaklaşan = sarı, geçmiş = kırmızı)
        private void DgvSiparisUrunler_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvSiparisUrunler.Columns[e.ColumnIndex].Name != "Teslim Tarihi") return;
            if (e.Value == null || e.Value == DBNull.Value) return;

            DateTime teslim = Convert.ToDateTime(e.Value);
            int kalanGun = (teslim - DateTime.Today).Days;

            if (kalanGun < 0)
                e.CellStyle.BackColor = Color.FromArgb(255, 180, 180); // geçmiş - kırmızı
            else if (kalanGun <= 3)
                e.CellStyle.BackColor = Color.FromArgb(255, 220, 130); // 3 gün - turuncu
            else if (kalanGun <= 7)
                e.CellStyle.BackColor = Color.FromArgb(255, 255, 180); // 7 gün - sarı
        }

        // ──────────────────────────────────────────────────────────────
        // Sipariş yükleme (düzenleme modu)
        // ──────────────────────────────────────────────────────────────
        private void SiparisBilgileriniYukle(int siparisID)
        {
            try
            {
                LazerSiparisDuzenlemeModel model = _lazerSiparisFormService.GetSiparisDuzenlemeModel(connectionString, siparisID);

                if (model == null)
                {
                    throw new InvalidOperationException("Siparis kaydi bulunamadi.");
                }

                txtSiparisNo.Text = model.SiparisNo;
                cmbMusteri.Text = model.Musteri;
                dtpSiparisTarihi.Value = model.SiparisTarihi;
                txtAciklama.Text = model.Aciklama ?? string.Empty;

                dtSiparisUrunler.Rows.Clear();
                foreach (LazerSiparisDetaySatiri detay in model.Detaylar)
                {
                    dtSiparisUrunler.Rows.Add(
                        detay.UrunID,
                        detay.UrunKodu,
                        detay.UrunAdi,
                        detay.LazerTipi,
                        detay.SiparisAdedi,
                        detay.TeslimTarihi.HasValue ? (object)detay.TeslimTarihi.Value : DBNull.Value
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş bilgileri yüklenirken hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────────
        // Ürün ekleme
        // ──────────────────────────────────────────────────────────────
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            using (UrunSecimForm frmUrunSec = new UrunSecimForm(connectionString))
            {
                if (frmUrunSec.ShowDialog() == DialogResult.OK)
                {
                    int urunID = frmUrunSec.SecilenUrunID;
                    int adet = frmUrunSec.SecilenAdet;
                    DateTime teslimTarihi = frmUrunSec.SecilenTeslimTarihi;
                    LazerSiparisUrunSecimItem urun = _lazerSiparisFormService.GetUrunById(connectionString, urunID);

                    if (urun == null)
                    {
                        MessageBox.Show("Secilen urun bulunamadi.", "Uyari",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool bulundu = false;
                    foreach (DataRow row in dtSiparisUrunler.Rows)
                    {
                        if ((int)row["UrunID"] == urunID)
                        {
                            row["Sipariş Adedi"] = (int)row["Sipariş Adedi"] + adet;
                            row["Teslim Tarihi"] = teslimTarihi;
                            bulundu = true;
                            break;
                        }
                    }

                    if (!bulundu)
                    {
                        dtSiparisUrunler.Rows.Add(
                            urunID,
                            urun.UrunKodu,
                            urun.UrunAdi,
                            urun.LazerTipi,
                            adet,
                            teslimTarihi
                        );
                    }
                }
            }
        }

        private void btnUrunDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvSiparisUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek için bir ürün seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgvSiparisUrunler.SelectedRows[0];
            int mevcutAdet = Convert.ToInt32(selectedRow.Cells["Sipariş Adedi"].Value);

            using (AdetDuzenleForm frmAdet = new AdetDuzenleForm(mevcutAdet))
            {
                if (frmAdet.ShowDialog() == DialogResult.OK)
                {
                    int rowIndex = selectedRow.Index;
                    dtSiparisUrunler.Rows[rowIndex]["Sipariş Adedi"] = frmAdet.YeniAdet;
                }
            }
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (dgvSiparisUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir ürün seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvSiparisUrunler.Rows.Remove(dgvSiparisUrunler.SelectedRows[0]);
        }

        // ──────────────────────────────────────────────────────────────
        // Kaydet
        // ──────────────────────────────────────────────────────────────
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Açık inline DTP varsa kapat
            if (dtpInline.Visible)
            {
                if (_editRow >= 0 && _editRow < dtSiparisUrunler.Rows.Count)
                    dtSiparisUrunler.Rows[_editRow]["Teslim Tarihi"] = dtpInline.Value;
                dtpInline.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txtSiparisNo.Text))
            {
                MessageBox.Show("Sipariş No boş bırakılamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMusteri.SelectedItem == null)
            {
                MessageBox.Show("Müşteri seçmelisiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtSiparisUrunler.Rows.Count == 0)
            {
                MessageBox.Show("En az bir ürün eklemelisiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LazerSiparisKaydetTalep talep = new LazerSiparisKaydetTalep
                {
                    SiparisId = duzenlemeSiparisID,
                    SiparisNo = txtSiparisNo.Text.Trim(),
                    Musteri = cmbMusteri.SelectedItem.ToString(),
                    SiparisTarihi = dtpSiparisTarihi.Value,
                    Aciklama = txtAciklama.Text
                };

                foreach (DataRow row in dtSiparisUrunler.Rows)
                {
                    talep.Detaylar.Add(new LazerSiparisDetaySatiri
                    {
                        UrunID = Convert.ToInt32(row["UrunID"]),
                        UrunKodu = row["Ürün Kodu"]?.ToString(),
                        UrunAdi = row["Ürün Adı"]?.ToString(),
                        LazerTipi = row["Lazer Tipi"]?.ToString(),
                        SiparisAdedi = Convert.ToInt32(row["Sipariş Adedi"]),
                        TeslimTarihi = row["Teslim Tarihi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["Teslim Tarihi"])
                    });
                }

                _lazerSiparisFormService.KaydetSiparis(connectionString, talep);

                MessageBox.Show(
                    duzenlemeSiparisID.HasValue ? "Sipariş başarıyla güncellendi!" : "Sipariş başarıyla kaydedildi!",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş kaydedilirken hata: " + ex.Message, "Hata",
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
    // UrunSecimForm - TeslimTarihi alanı eklendi
    // ══════════════════════════════════════════════════════════════════
    public class UrunSecimForm : Form
    {
        private ComboBox cmbUrunler;
        private NumericUpDown numAdet;
        private DateTimePicker dtpTeslim;
        private Button btnTamam;
        private Button btnIptal;
        private string connectionString;
        private readonly ILazerSiparisFormService _lazerSiparisFormService;

        public int SecilenUrunID { get; private set; }
        public int SecilenAdet { get; private set; }
        public DateTime SecilenTeslimTarihi { get; private set; }

        public UrunSecimForm(string connectionString)
        {
            this.connectionString = connectionString;
            _lazerSiparisFormService = InstanceFactory.GetInstance<ILazerSiparisFormService>();
            InitializeComponent();
            UrunleriYukle();
        }

        private void InitializeComponent()
        {
            this.cmbUrunler = new ComboBox();
            this.numAdet = new NumericUpDown();
            this.dtpTeslim = new DateTimePicker();
            this.btnTamam = new Button();
            this.btnIptal = new Button();

            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAdet)).BeginInit();

            // cmbUrunler
            this.cmbUrunler.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbUrunler.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbUrunler.FormattingEnabled = true;
            this.cmbUrunler.Location = new System.Drawing.Point(20, 50);
            this.cmbUrunler.Size = new System.Drawing.Size(360, 25);

            // numAdet
            this.numAdet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numAdet.Location = new System.Drawing.Point(20, 105);
            this.numAdet.Maximum = 100000;
            this.numAdet.Minimum = 1;
            this.numAdet.Size = new System.Drawing.Size(360, 25);
            this.numAdet.Value = 1;

            // dtpTeslim
            this.dtpTeslim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTeslim.Format = DateTimePickerFormat.Short;
            this.dtpTeslim.Location = new System.Drawing.Point(20, 160);
            this.dtpTeslim.Size = new System.Drawing.Size(360, 25);
            this.dtpTeslim.Value = DateTime.Today.AddDays(7);

            // btnTamam
            this.btnTamam.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnTamam.FlatStyle = FlatStyle.Flat;
            this.btnTamam.FlatAppearance.BorderSize = 0;
            this.btnTamam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTamam.ForeColor = System.Drawing.Color.White;
            this.btnTamam.Location = new System.Drawing.Point(20, 210);
            this.btnTamam.Size = new System.Drawing.Size(170, 40);
            this.btnTamam.Text = "✓ Tamam";
            this.btnTamam.Click += new EventHandler(this.btnTamam_Click);

            // btnIptal
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(210, 210);
            this.btnIptal.Size = new System.Drawing.Size(170, 40);
            this.btnIptal.Text = "✗ İptal";
            this.btnIptal.Click += new EventHandler(this.btnIptal_Click);

            // Etiketler
            Label lblUrun = new Label { Text = "Ürün Seçin:", Location = new System.Drawing.Point(20, 30), Font = new System.Drawing.Font("Segoe UI", 9F), AutoSize = true };
            Label lblAdet = new Label { Text = "Adet:", Location = new System.Drawing.Point(20, 85), Font = new System.Drawing.Font("Segoe UI", 9F), AutoSize = true };
            Label lblTeslim = new Label { Text = "Teslim Tarihi:", Location = new System.Drawing.Point(20, 140), Font = new System.Drawing.Font("Segoe UI", 9F), AutoSize = true };

            // Form
            this.ClientSize = new System.Drawing.Size(400, 270);
            this.Controls.Add(lblUrun);
            this.Controls.Add(this.cmbUrunler);
            this.Controls.Add(lblAdet);
            this.Controls.Add(this.numAdet);
            this.Controls.Add(lblTeslim);
            this.Controls.Add(this.dtpTeslim);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Ürün Seç";
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            ((System.ComponentModel.ISupportInitialize)(this.numAdet)).EndInit();
            this.ResumeLayout(false);
        }

        private void UrunleriYukle()
        {
            try
            {
                cmbUrunler.DisplayMember = "UrunBilgi";
                cmbUrunler.ValueMember = "UrunID";
                cmbUrunler.DataSource = _lazerSiparisFormService.GetAktifUrunler(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata: " + ex.Message);
            }
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (cmbUrunler.SelectedValue != null)
            {
                SecilenUrunID = Convert.ToInt32(cmbUrunler.SelectedValue);
                SecilenAdet = (int)numAdet.Value;
                SecilenTeslimTarihi = dtpTeslim.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    // ══════════════════════════════════════════════════════════════════
    // AdetDuzenleForm 
    // ══════════════════════════════════════════════════════════════════
    public class AdetDuzenleForm : Form
    {
        private NumericUpDown numAdet;
        private Button btnTamam;
        private Button btnIptal;

        public int YeniAdet { get; private set; }

        public AdetDuzenleForm(int mevcutAdet)
        {
            InitializeComponent();
            numAdet.Value = mevcutAdet;
        }

        private void InitializeComponent()
        {
            this.numAdet = new NumericUpDown();
            this.btnTamam = new Button();
            this.btnIptal = new Button();

            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAdet)).BeginInit();

            this.numAdet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.numAdet.Location = new System.Drawing.Point(20, 50);
            this.numAdet.Maximum = 100000;
            this.numAdet.Minimum = 1;
            this.numAdet.Size = new System.Drawing.Size(260, 29);
            this.numAdet.Value = 1;

            this.btnTamam.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnTamam.FlatStyle = FlatStyle.Flat;
            this.btnTamam.FlatAppearance.BorderSize = 0;
            this.btnTamam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTamam.ForeColor = System.Drawing.Color.White;
            this.btnTamam.Location = new System.Drawing.Point(20, 100);
            this.btnTamam.Size = new System.Drawing.Size(120, 40);
            this.btnTamam.Text = "✓ Tamam";
            this.btnTamam.Click += new EventHandler(this.btnTamam_Click);

            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(160, 100);
            this.btnIptal.Size = new System.Drawing.Size(120, 40);
            this.btnIptal.Text = "✗ İptal";
            this.btnIptal.Click += new EventHandler(this.btnIptal_Click);

            Label lblAdet = new Label
            {
                Text = "Yeni Adet:",
                Location = new System.Drawing.Point(20, 25),
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                AutoSize = true
            };

            this.ClientSize = new System.Drawing.Size(300, 160);
            this.Controls.Add(lblAdet);
            this.Controls.Add(this.numAdet);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Adet Düzenle";
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            ((System.ComponentModel.ISupportInitialize)(this.numAdet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            YeniAdet = (int)numAdet.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
