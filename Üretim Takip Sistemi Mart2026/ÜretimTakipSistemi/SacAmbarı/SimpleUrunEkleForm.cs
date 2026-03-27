using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ÜretimTakipSistemi.SacAmbarı
{
    // Alt ürün veri modeli
    public class AltUrunBilgi
    {
        public string Kod { get; set; }
        public string Ad { get; set; }
        public decimal Miktar { get; set; }
    }

    public class SimpleUrunEkleForm : Form
    {
        // ── Dışarıdan erişilen property'ler ──────────────────────
        public string UrunKodu => txtKod.Text.Trim();
        public string UrunAdi => txtAd.Text.Trim();

        // Geriye dönük uyumluluk (tek alt ürün)
        public string AltUrunKodu => AltUrunler.Count > 0 ? AltUrunler[0].Kod : "";
        public string AltUrunAdi => AltUrunler.Count > 0 ? AltUrunler[0].Ad : "";
        public decimal Miktar => AltUrunler.Count > 0 ? AltUrunler[0].Miktar : 1;
        public bool AltUrunEklenecek => AltUrunler.Count > 0;

        // Tüm alt ürünler listesi
        public List<AltUrunBilgi> AltUrunler { get; } = new List<AltUrunBilgi>();

        // ── İç kontroller ─────────────────────────────────────────
        private TextBox txtKod, txtAd;
        private Button btnAltUrunEkle, btnKaydet, btnIptal;
        private Panel panelAnaUrun, panelAltUrunGiris, panelButonlar;
        private DataGridView dgvAltUrunler;
        private Label lblAltUrunBaslik, lblAltUrunSayac;
        private TextBox txtAltKod, txtAltAd;
        private NumericUpDown numMiktar;
        private Button btnAltEkle, btnAltIptal;

        private int _toplamAltUrunSayisi = 0;
        private int _eklenenSayisi = 0;

        // ── Sabit ölçüler ─────────────────────────────────────────
        private const int FW = 500;   // form iç genişliği
        private const int PAD = 20;    // sol/sağ kenar boşluğu
        private const int LBL_W = 125;   // etiket genişliği
        private const int TXT_X = 150;   // textbox başlangıç X
        private const int TXT_W = FW - TXT_X - PAD;  // 330

        // ── Renkler ───────────────────────────────────────────────
        private readonly Color AccentBlue = Color.FromArgb(0, 122, 204);
        private readonly Color LightBg = Color.FromArgb(245, 248, 252);
        private readonly Color GreenBtn = Color.FromArgb(39, 174, 96);
        private readonly Color OrangeBtn = Color.FromArgb(230, 126, 34);
        private readonly Color RedBtn = Color.FromArgb(192, 57, 43);

        private void SimpleUrunEkleForm_Load(object sender, EventArgs e) { }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(FW, 210);
            this.Name = "SimpleUrunEkleForm";
            this.Load += new EventHandler(this.SimpleUrunEkleForm_Load);
            this.ResumeLayout(false);
        }

        public SimpleUrunEkleForm()
        {
            InitializeComponent();
            BuildForm();
        }

        // ═══════════════════════════════════════════════════════════
        //  FORM İNŞASI
        // ═══════════════════════════════════════════════════════════
        private void BuildForm()
        {
            this.Text = "🏭 Ürün Kayıt Paneli";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = LightBg;
            this.Font = new Font("Segoe UI", 9.5f);

            // ── 1. Başlık şeridi ────────────────────────────────
            var header = new Panel { Dock = DockStyle.Top, Height = 46, BackColor = AccentBlue };
            header.Controls.Add(new Label
            {
                Text = "ÜRÜN KAYIT PANELİ",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });

            // ── 2. Ana ürün paneli ──────────────────────────────
            panelAnaUrun = new Panel
            {
                Location = new Point(0, 46),
                Size = new Size(FW, 108),
                BackColor = Color.White
            };
            panelAnaUrun.Controls.Add(new Label
            {
                Text = "ANA ÜRÜN BİLGİLERİ",
                ForeColor = AccentBlue,
                Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold),
                Location = new Point(PAD, 10),
                Size = new Size(200, 18),
                AutoSize = false
            });
            panelAnaUrun.Controls.Add(MakeLabel("Ürün Kodu *", new Point(PAD, 36)));
            txtKod = MakeTextBox(new Point(TXT_X, 33), TXT_W);
            panelAnaUrun.Controls.Add(txtKod);

            panelAnaUrun.Controls.Add(MakeLabel("Ürün Adı *", new Point(PAD, 70)));
            txtAd = MakeTextBox(new Point(TXT_X, 67), TXT_W);
            panelAnaUrun.Controls.Add(txtAd);

            // ── 3. Alt ürün giriş paneli (başta gizli) ──────────
            panelAltUrunGiris = new Panel
            {
                Location = new Point(0, 154),
                Size = new Size(FW, 0),
                BackColor = Color.FromArgb(237, 245, 255),
                Visible = false
            };
            panelAltUrunGiris.Controls.Add(new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(FW, 4),
                BackColor = Color.FromArgb(0, 100, 180)
            });

            lblAltUrunBaslik = new Label
            {
                Text = "",
                ForeColor = AccentBlue,
                Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold),
                Location = new Point(PAD, 12),
                Size = new Size(FW - PAD * 2, 18),
                AutoSize = false
            };
            panelAltUrunGiris.Controls.Add(lblAltUrunBaslik);

            panelAltUrunGiris.Controls.Add(MakeLabel("Alt Ürün Kodu *", new Point(PAD, 40)));
            txtAltKod = MakeTextBox(new Point(TXT_X, 37), TXT_W);
            panelAltUrunGiris.Controls.Add(txtAltKod);

            panelAltUrunGiris.Controls.Add(MakeLabel("Alt Ürün Adı *", new Point(PAD, 74)));
            txtAltAd = MakeTextBox(new Point(TXT_X, 71), TXT_W);
            panelAltUrunGiris.Controls.Add(txtAltAd);

            panelAltUrunGiris.Controls.Add(MakeLabel("Miktar", new Point(PAD, 108)));
            numMiktar = new NumericUpDown
            {
                Location = new Point(TXT_X, 105),
                Size = new Size(100, 26),
                Minimum = 1,
                Maximum = 100000,
                Value = 1,
                Font = this.Font,
                BackColor = Color.White
            };
            panelAltUrunGiris.Controls.Add(numMiktar);

            lblAltUrunSayac = new Label
            {
                ForeColor = Color.FromArgb(160, 80, 0),
                Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold),
                Location = new Point(TXT_X + 110, 108),
                Size = new Size(200, 22),
                AutoSize = false
            };
            panelAltUrunGiris.Controls.Add(lblAltUrunSayac);

            btnAltEkle = MakeButton("✔ Kaydet", GreenBtn, new Point(PAD, 140), new Size(120, 32));
            btnAltEkle.Click += BtnAltEkle_Click;
            panelAltUrunGiris.Controls.Add(btnAltEkle);

            btnAltIptal = MakeButton("✖ Atla", OrangeBtn, new Point(PAD + 130, 140), new Size(100, 32));
            btnAltIptal.Click += BtnAltIptal_Click;
            panelAltUrunGiris.Controls.Add(btnAltIptal);

            // ── 4. Tablo (başta gizli) ───────────────────────────
            dgvAltUrunler = new DataGridView
            {
                Location = new Point(0, 154),
                Size = new Size(FW, 0),
                Visible = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 9f),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeight = 30,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                EnableHeadersVisualStyles = false
            };
            dgvAltUrunler.RowTemplate.Height = 26;
            dgvAltUrunler.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = AccentBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvAltUrunler.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "#", Name = "sira", FillWeight = 8 });
            dgvAltUrunler.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Alt Ürün Kodu", Name = "kod", FillWeight = 25 });
            dgvAltUrunler.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Alt Ürün Adı", Name = "ad", FillWeight = 45 });
            dgvAltUrunler.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Miktar", Name = "mik", FillWeight = 12 });
            dgvAltUrunler.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Sil",
                Name = "sil",
                Text = "🗑",
                UseColumnTextForButtonValue = true,
                FillWeight = 10
            });
            dgvAltUrunler.CellClick += DgvAltUrunler_CellClick;
            dgvAltUrunler.RowsDefaultCellStyle.BackColor = Color.White;
            dgvAltUrunler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 247, 255);

            // ── 5. Alt buton çubuğu ─────────────────────────────
            panelButonlar = new Panel
            {
                Location = new Point(0, 154),
                Size = new Size(FW, 56),
                BackColor = Color.White
            };
            panelButonlar.Controls.Add(new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(FW, 1),
                BackColor = Color.FromArgb(210, 225, 245)
            });

            btnAltUrunEkle = MakeButton("➕ Alt Ürün Ekle", AccentBlue, new Point(PAD, 11), new Size(150, 34));
            btnAltUrunEkle.Click += BtnAltUrunEkle_Click;
            panelButonlar.Controls.Add(btnAltUrunEkle);

            btnKaydet = MakeButton("💾 Kaydet", GreenBtn, new Point(FW - 225, 11), new Size(100, 34));
            btnKaydet.DialogResult = DialogResult.OK;
            btnKaydet.Click += BtnKaydet_Click;
            panelButonlar.Controls.Add(btnKaydet);

            btnIptal = MakeButton("✖ İptal", RedBtn, new Point(FW - 115, 11), new Size(100, 34));
            btnIptal.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            panelButonlar.Controls.Add(btnIptal);

            // ── Forma ekle ──────────────────────────────────────
            this.Controls.AddRange(new Control[]
                { header, panelAnaUrun, panelAltUrunGiris, dgvAltUrunler, panelButonlar });

            this.ClientSize = new Size(FW, 1);
            RearrangeLayout();
        }

        // ═══════════════════════════════════════════════════════════
        //  LAYOUT YÖNETİMİ
        // ═══════════════════════════════════════════════════════════
        private void RearrangeLayout()
        {
            int y = 46 + panelAnaUrun.Height + 2;

            panelAltUrunGiris.Location = new Point(0, y);
            if (panelAltUrunGiris.Visible) y += panelAltUrunGiris.Height + 2;

            dgvAltUrunler.Location = new Point(0, y);
            if (dgvAltUrunler.Visible && dgvAltUrunler.Height > 0) y += dgvAltUrunler.Height + 2;

            panelButonlar.Location = new Point(0, y);
            y += panelButonlar.Height;

            this.ClientSize = new Size(FW, y + 2);
        }

        // ═══════════════════════════════════════════════════════════
        //  OLAY İŞLEYİCİLER
        // ═══════════════════════════════════════════════════════════
        private void BtnAltUrunEkle_Click(object sender, EventArgs e)
        {
            using (var dlg = new AltUrunSayisiForm())
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                _toplamAltUrunSayisi = dlg.Sayi;
                _eklenenSayisi = 0;
            }
            btnAltUrunEkle.Enabled = false;
            AcGirisFormunu();
        }

        private void AcGirisFormunu()
        {
            int kalan = _toplamAltUrunSayisi - _eklenenSayisi;
            if (kalan <= 0) { KapatGirisFormunu(); return; }

            lblAltUrunBaslik.Text = $"ALT ÜRÜN  {_eklenenSayisi + 1} / {_toplamAltUrunSayisi}   —   ({kalan} kaldı)";
            lblAltUrunSayac.Text = $"Eklenen: {_eklenenSayisi}";
            btnAltIptal.Text = (_eklenenSayisi == 0) ? "✖ Vazgeç" : "✖ Atla";
            panelAltUrunGiris.Height = 182;
            panelAltUrunGiris.Visible = true;

            txtAltKod.Clear();
            txtAltAd.Clear();
            numMiktar.Value = 1;
            txtAltKod.Focus();

            RefreshTable();
            RearrangeLayout();
        }

        private void BtnAltEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAltKod.Text))
            { MessageBox.Show("Alt ürün kodu boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrWhiteSpace(txtAltAd.Text))
            { MessageBox.Show("Alt ürün adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            AltUrunler.Add(new AltUrunBilgi
            {
                Kod = txtAltKod.Text.Trim(),
                Ad = txtAltAd.Text.Trim(),
                Miktar = numMiktar.Value
            });
            _eklenenSayisi++;

            if (_eklenenSayisi >= _toplamAltUrunSayisi)
                KapatGirisFormunu();
            else
                AcGirisFormunu();
        }

        private void BtnAltIptal_Click(object sender, EventArgs e)
        {
            if (_eklenenSayisi == 0)
            {
                KapatGirisFormunu();
                btnAltUrunEkle.Enabled = true;
            }
            else
            {
                _toplamAltUrunSayisi = _eklenenSayisi;
                KapatGirisFormunu();
            }
        }

        private void KapatGirisFormunu()
        {
            panelAltUrunGiris.Visible = false;
            panelAltUrunGiris.Height = 0;
            btnAltUrunEkle.Enabled = true;
            RefreshTable();
            RearrangeLayout();
        }

        private void RefreshTable()
        {
            dgvAltUrunler.Rows.Clear();
            foreach (var a in AltUrunler)
                dgvAltUrunler.Rows.Add(dgvAltUrunler.Rows.Count + 1, a.Kod, a.Ad, a.Miktar);

            if (AltUrunler.Count == 0)
            {
                dgvAltUrunler.Visible = false;
                dgvAltUrunler.Height = 0;
            }
            else
            {
                int h = dgvAltUrunler.ColumnHeadersHeight
                      + AltUrunler.Count * dgvAltUrunler.RowTemplate.Height + 4;
                dgvAltUrunler.Height = Math.Min(h, 200);
                dgvAltUrunler.Visible = true;
            }
        }

        private void DgvAltUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != dgvAltUrunler.Columns["sil"].Index) return;

            var onay = MessageBox.Show(
                $"'{AltUrunler[e.RowIndex].Ad}' silinsin mi?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay != DialogResult.Yes) return;

            AltUrunler.RemoveAt(e.RowIndex);
            RefreshTable();
            RearrangeLayout();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKod.Text))
            {
                MessageBox.Show("Ürün kodu boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None; return;
            }
            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                MessageBox.Show("Ürün adı boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None; return;
            }
            this.Close();
        }

        // ═══════════════════════════════════════════════════════════
        //  YARDIMCI METOTLAR
        // ═══════════════════════════════════════════════════════════
        private Label MakeLabel(string text, Point loc)
        {
            return new Label
            {
                Text = text,
                Location = loc,
                Size = new Size(LBL_W, 24),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(60, 80, 100),
                Font = this.Font,
                AutoSize = false
            };
        }

        private TextBox MakeTextBox(Point loc, int width)
        {
            return new TextBox
            {
                Location = loc,
                Size = new Size(width, 26),
                Font = this.Font,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        private Button MakeButton(string text, Color back, Point loc, Size size)
        {
            var btn = new Button
            {
                Text = text,
                Location = loc,
                Size = size,
                BackColor = back,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9.5f),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, ev) => btn.BackColor = ControlPaint.Light(back, 0.2f);
            btn.MouseLeave += (s, ev) => btn.BackColor = back;
            return btn;
        }
    }

    // ═══════════════════════════════════════════════════════════════
    //  KAÇ ALT ÜRÜN EKLENECEĞİNİ SORAN MİNİK DİYALOG
    // ═══════════════════════════════════════════════════════════════
    public class AltUrunSayisiForm : Form
    {
        public int Sayi => (int)numSayi.Value;
        private NumericUpDown numSayi;

        public AltUrunSayisiForm()
        {
            this.Text = "Alt Ürün Sayısı";
            this.ClientSize = new Size(320, 120);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 248, 252);
            this.Font = new Font("Segoe UI", 10f);

            this.Controls.Add(new Label
            {
                Text = "Kaç adet alt ürün eklemek istiyorsunuz?",
                Location = new Point(20, 18),
                Size = new Size(280, 22),
                ForeColor = Color.FromArgb(40, 60, 90),
                AutoSize = false
            });

            numSayi = new NumericUpDown
            {
                Location = new Point(20, 48),
                Size = new Size(80, 28),
                Minimum = 1,
                Maximum = 50,
                Value = 1,
                Font = new Font("Segoe UI Semibold", 11f),
                TextAlign = HorizontalAlignment.Center
            };
            this.Controls.Add(numSayi);

            var btnOk = new Button
            {
                Text = "Tamam",
                Location = new Point(120, 46),
                Size = new Size(84, 32),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9.5f),
                DialogResult = DialogResult.OK,
                Cursor = Cursors.Hand
            };
            btnOk.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnOk);

            var btnCancel = new Button
            {
                Text = "İptal",
                Location = new Point(214, 46),
                Size = new Size(84, 32),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9.5f),
                DialogResult = DialogResult.Cancel,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }
    }
}