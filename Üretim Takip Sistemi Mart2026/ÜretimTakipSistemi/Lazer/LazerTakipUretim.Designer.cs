namespace ÜretimTakipSistemi.Lazer
{
    partial class LazerTakipUretim
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabSiparisler = new System.Windows.Forms.TabPage();
            this.pnlSiparisButtons = new System.Windows.Forms.Panel();
            this.btnTumUrunler = new System.Windows.Forms.Button();
            this.btnSiparisSil = new System.Windows.Forms.Button();
            this.btnExclYkl = new System.Windows.Forms.Button();
            this.btnSiparisDuzenle = new System.Windows.Forms.Button();
            this.btnSiparisTamamla = new System.Windows.Forms.Button();
            this.btnYeniSiparis = new System.Windows.Forms.Button();
            this.dgvSiparisler = new System.Windows.Forms.DataGridView();
            this.tabUrunYonetim = new System.Windows.Forms.TabPage();
            this.pnlUrunButtons = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txturunara = new System.Windows.Forms.TextBox();
            this.lblara = new System.Windows.Forms.Label();
            // ── YENİ: Ürün tipi filtre ComboBox ──
            this.cmbUrunTipiFiltre = new System.Windows.Forms.ComboBox();
            this.lblUrunTipiFiltre = new System.Windows.Forms.Label();
            // ─────────────────────────────────────
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.btnUrunDuzenle = new System.Windows.Forms.Button();
            this.btnYeniUrun = new System.Windows.Forms.Button();
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.tabPlakaLazer = new System.Windows.Forms.TabPage();
            this.pnlPlakaRight = new System.Windows.Forms.Panel();
            this.grpPlakaHesaplama = new System.Windows.Forms.GroupBox();
            this.lblPlakaSonuc = new System.Windows.Forms.Label();
            this.grpPlakaSiparis = new System.Windows.Forms.GroupBox();
            this.btnPlakaHesapla = new System.Windows.Forms.Button();
            this.numPlakaSiparisAdet = new System.Windows.Forms.NumericUpDown();
            this.cmbPlakaUrun = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlPlakaLeft = new System.Windows.Forms.Panel();
            this.dgvPlakaDetay = new System.Windows.Forms.DataGridView();
            this.grpPlakaSacStok = new System.Windows.Forms.GroupBox();
            this.btnStokDuzenlePlaka = new System.Windows.Forms.Button();
            this.btnSacStokGuncelle = new System.Windows.Forms.Button();
            // ── YENİ: Sac stok ekleme butonu ──
            this.btnSacStokEkle = new System.Windows.Forms.Button();
            // ──────────────────────────────────
            this.dgvSacStok = new System.Windows.Forms.DataGridView();
            this.tabBoruLazer = new System.Windows.Forms.TabPage();
            this.pnlBoruRight = new System.Windows.Forms.Panel();
            this.grpBoruHesaplama = new System.Windows.Forms.GroupBox();
            this.rtxtBoruSonuc = new System.Windows.Forms.RichTextBox();
            this.grpBoruSiparis = new System.Windows.Forms.GroupBox();
            this.btnBoruHesapla = new System.Windows.Forms.Button();
            this.numBoruSiparisAdet = new System.Windows.Forms.NumericUpDown();
            this.cmbBoruUrun = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBoruLeft = new System.Windows.Forms.Panel();
            this.dgvBoruDetay = new System.Windows.Forms.DataGridView();
            this.grpBoruProfilStok = new System.Windows.Forms.GroupBox();
            this.btnStokDuzenle = new System.Windows.Forms.Button();
            this.btnProfilStokGuncelle = new System.Windows.Forms.Button();
            this.dgvProfilStok = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pnlHeader.SuspendLayout();
            this.tabSiparisler.SuspendLayout();
            this.pnlSiparisButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).BeginInit();
            this.tabUrunYonetim.SuspendLayout();
            this.pnlUrunButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.tabPlakaLazer.SuspendLayout();
            this.pnlPlakaRight.SuspendLayout();
            this.grpPlakaHesaplama.SuspendLayout();
            this.grpPlakaSiparis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPlakaSiparisAdet)).BeginInit();
            this.pnlPlakaLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlakaDetay)).BeginInit();
            this.grpPlakaSacStok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSacStok)).BeginInit();
            this.tabBoruLazer.SuspendLayout();
            this.pnlBoruRight.SuspendLayout();
            this.grpBoruHesaplama.SuspendLayout();
            this.grpBoruSiparis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoruSiparisAdet)).BeginInit();
            this.pnlBoruLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoruDetay)).BeginInit();
            this.grpBoruProfilStok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfilStok)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1600, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(376, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔷 LAZER TAKİP SİSTEMİ";
            // 
            // tabSiparisler
            // 
            this.tabSiparisler.BackColor = System.Drawing.Color.FromArgb(236, 240, 245);
            this.tabSiparisler.Controls.Add(this.pnlSiparisButtons);
            this.tabSiparisler.Controls.Add(this.dgvSiparisler);
            this.tabSiparisler.Location = new System.Drawing.Point(4, 28);
            this.tabSiparisler.Name = "tabSiparisler";
            this.tabSiparisler.Padding = new System.Windows.Forms.Padding(10);
            this.tabSiparisler.Size = new System.Drawing.Size(1592, 788);
            this.tabSiparisler.TabIndex = 3;
            this.tabSiparisler.Text = "📦 SİPARİŞLER";
            // 
            // pnlSiparisButtons
            // 
            this.pnlSiparisButtons.BackColor = System.Drawing.Color.White;
            this.pnlSiparisButtons.Controls.Add(this.btnTumUrunler);
            this.pnlSiparisButtons.Controls.Add(this.btnSiparisSil);
            this.pnlSiparisButtons.Controls.Add(this.btnExclYkl);
            this.pnlSiparisButtons.Controls.Add(this.btnSiparisDuzenle);
            this.pnlSiparisButtons.Controls.Add(this.btnSiparisTamamla);
            this.pnlSiparisButtons.Controls.Add(this.btnYeniSiparis);
            this.pnlSiparisButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSiparisButtons.Location = new System.Drawing.Point(10, 718);
            this.pnlSiparisButtons.Name = "pnlSiparisButtons";
            this.pnlSiparisButtons.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSiparisButtons.Size = new System.Drawing.Size(1572, 60);
            this.pnlSiparisButtons.TabIndex = 1;
            // 
            // btnTumUrunler
            // 
            this.btnTumUrunler.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.btnTumUrunler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTumUrunler.FlatAppearance.BorderSize = 0;
            this.btnTumUrunler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTumUrunler.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTumUrunler.ForeColor = System.Drawing.Color.White;
            this.btnTumUrunler.Location = new System.Drawing.Point(360, 13);
            this.btnTumUrunler.Name = "btnTumUrunler";
            this.btnTumUrunler.Size = new System.Drawing.Size(198, 40);
            this.btnTumUrunler.TabIndex = 5;
            this.btnTumUrunler.Text = "📋 Tüm Siparişleri Göster";
            this.btnTumUrunler.UseVisualStyleBackColor = false;
            this.btnTumUrunler.Click += new System.EventHandler(this.btnTumUrunler_Click);
            // 
            // btnSiparisSil
            // 
            this.btnSiparisSil.BackColor = System.Drawing.Color.Red;
            this.btnSiparisSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiparisSil.FlatAppearance.BorderSize = 0;
            this.btnSiparisSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiparisSil.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSiparisSil.ForeColor = System.Drawing.Color.White;
            this.btnSiparisSil.Location = new System.Drawing.Point(723, 13);
            this.btnSiparisSil.Name = "btnSiparisSil";
            this.btnSiparisSil.Size = new System.Drawing.Size(153, 40);
            this.btnSiparisSil.TabIndex = 4;
            this.btnSiparisSil.Text = "🗑️ Siparişi Sil";
            this.btnSiparisSil.UseVisualStyleBackColor = false;
            this.btnSiparisSil.Click += new System.EventHandler(this.btnSiparisSil_Click);
            // 
            // btnExclYkl
            // 
            this.btnExclYkl.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnExclYkl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExclYkl.FlatAppearance.BorderSize = 0;
            this.btnExclYkl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExclYkl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExclYkl.ForeColor = System.Drawing.Color.White;
            this.btnExclYkl.Location = new System.Drawing.Point(172, 13);
            this.btnExclYkl.Name = "btnExclYkl";
            this.btnExclYkl.Size = new System.Drawing.Size(182, 40);
            this.btnExclYkl.TabIndex = 3;
            this.btnExclYkl.Text = "📊 Excel Dosyası Yükle";
            this.btnExclYkl.UseVisualStyleBackColor = false;
            this.btnExclYkl.Click += new System.EventHandler(this.btnExclYkl_Click);
            // 
            // btnSiparisDuzenle
            // 
            this.btnSiparisDuzenle.BackColor = System.Drawing.Color.FromArgb(240, 196, 15);
            this.btnSiparisDuzenle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiparisDuzenle.FlatAppearance.BorderSize = 0;
            this.btnSiparisDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiparisDuzenle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSiparisDuzenle.ForeColor = System.Drawing.Color.White;
            this.btnSiparisDuzenle.Location = new System.Drawing.Point(564, 13);
            this.btnSiparisDuzenle.Name = "btnSiparisDuzenle";
            this.btnSiparisDuzenle.Size = new System.Drawing.Size(153, 40);
            this.btnSiparisDuzenle.TabIndex = 2;
            this.btnSiparisDuzenle.Text = "✏️ Siparişi Düzenle";
            this.btnSiparisDuzenle.UseVisualStyleBackColor = false;
            this.btnSiparisDuzenle.Click += new System.EventHandler(this.btnSiparisDuzenle_Click);
            // 
            // btnSiparisTamamla
            // 
            this.btnSiparisTamamla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSiparisTamamla.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSiparisTamamla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiparisTamamla.FlatAppearance.BorderSize = 0;
            this.btnSiparisTamamla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiparisTamamla.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSiparisTamamla.ForeColor = System.Drawing.Color.White;
            this.btnSiparisTamamla.Location = new System.Drawing.Point(1396, 13);
            this.btnSiparisTamamla.Name = "btnSiparisTamamla";
            this.btnSiparisTamamla.Size = new System.Drawing.Size(163, 40);
            this.btnSiparisTamamla.TabIndex = 1;
            this.btnSiparisTamamla.Text = "✔️ Sipariş Tamamla";
            this.btnSiparisTamamla.UseVisualStyleBackColor = false;
            this.btnSiparisTamamla.Click += new System.EventHandler(this.btnSiparisTamamla_Click);
            // 
            // btnYeniSiparis
            // 
            this.btnYeniSiparis.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnYeniSiparis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYeniSiparis.FlatAppearance.BorderSize = 0;
            this.btnYeniSiparis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniSiparis.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnYeniSiparis.ForeColor = System.Drawing.Color.White;
            this.btnYeniSiparis.Location = new System.Drawing.Point(13, 13);
            this.btnYeniSiparis.Name = "btnYeniSiparis";
            this.btnYeniSiparis.Size = new System.Drawing.Size(153, 40);
            this.btnYeniSiparis.TabIndex = 0;
            this.btnYeniSiparis.Text = "➕ Yeni Sipariş";
            this.btnYeniSiparis.UseVisualStyleBackColor = false;
            this.btnYeniSiparis.Click += new System.EventHandler(this.btnYeniSiparis_Click);
            // 
            // dgvSiparisler
            // 
            this.dgvSiparisler.AllowUserToAddRows = false;
            this.dgvSiparisler.AllowUserToDeleteRows = false;
            this.dgvSiparisler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSiparisler.BackgroundColor = System.Drawing.Color.White;
            this.dgvSiparisler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSiparisler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiparisler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSiparisler.Location = new System.Drawing.Point(10, 10);
            this.dgvSiparisler.Name = "dgvSiparisler";
            this.dgvSiparisler.ReadOnly = true;
            this.dgvSiparisler.RowHeadersVisible = false;
            this.dgvSiparisler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSiparisler.Size = new System.Drawing.Size(1572, 768);
            this.dgvSiparisler.TabIndex = 0;
            this.dgvSiparisler.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSiparisler_CellDoubleClick);
            // 
            // tabUrunYonetim
            // 
            this.tabUrunYonetim.BackColor = System.Drawing.Color.FromArgb(236, 240, 245);
            this.tabUrunYonetim.Controls.Add(this.pnlUrunButtons);
            this.tabUrunYonetim.Controls.Add(this.dgvUrunler);
            this.tabUrunYonetim.Location = new System.Drawing.Point(4, 28);
            this.tabUrunYonetim.Name = "tabUrunYonetim";
            this.tabUrunYonetim.Padding = new System.Windows.Forms.Padding(10);
            this.tabUrunYonetim.Size = new System.Drawing.Size(1592, 788);
            this.tabUrunYonetim.TabIndex = 2;
            this.tabUrunYonetim.Text = "🔧 ÜRÜN YÖNETİMİ";
            // 
            // pnlUrunButtons
            // 
            this.pnlUrunButtons.BackColor = System.Drawing.Color.White;
            this.pnlUrunButtons.Controls.Add(this.panel1);
            // ── YENİ: cmbUrunTipiFiltre ve lblUrunTipiFiltre ──
            this.pnlUrunButtons.Controls.Add(this.cmbUrunTipiFiltre);
            this.pnlUrunButtons.Controls.Add(this.lblUrunTipiFiltre);
            // ──────────────────────────────────────────────────
            this.pnlUrunButtons.Controls.Add(this.btnUrunSil);
            this.pnlUrunButtons.Controls.Add(this.btnUrunDuzenle);
            this.pnlUrunButtons.Controls.Add(this.btnYeniUrun);
            this.pnlUrunButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUrunButtons.Location = new System.Drawing.Point(10, 718);
            this.pnlUrunButtons.Name = "pnlUrunButtons";
            this.pnlUrunButtons.Padding = new System.Windows.Forms.Padding(10);
            this.pnlUrunButtons.Size = new System.Drawing.Size(1572, 60);
            this.pnlUrunButtons.TabIndex = 1;
            // 
            // panel1  (arama kutusu)
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.panel1.Controls.Add(this.lblara);
            this.panel1.Controls.Add(this.txturunara);
            this.panel1.Location = new System.Drawing.Point(546, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 40);
            this.panel1.TabIndex = 4;
            // 
            // txturunara
            // 
            this.txturunara.Location = new System.Drawing.Point(0, 14);
            this.txturunara.Name = "txturunara";
            this.txturunara.Size = new System.Drawing.Size(182, 26);
            this.txturunara.TabIndex = 3;
            this.txturunara.TextChanged += new System.EventHandler(this.txturunara_TextChanged);
            // 
            // lblara
            // 
            this.lblara.AutoSize = true;
            this.lblara.Location = new System.Drawing.Point(0, 0);
            this.lblara.Name = "lblara";
            this.lblara.Size = new System.Drawing.Size(183, 19);
            this.lblara.TabIndex = 4;
            this.lblara.Text = "Ürün Kodu Veya Adı Ara...";
            // 
            // ── YENİ: cmbUrunTipiFiltre ──────────────────────────────
            // Arama kutusunun (panel1) hemen sağına yerleştirildi: X=740
            // 
            // lblUrunTipiFiltre
            // 
            this.lblUrunTipiFiltre.AutoSize = true;
            this.lblUrunTipiFiltre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUrunTipiFiltre.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblUrunTipiFiltre.Location = new System.Drawing.Point(740, 20);
            this.lblUrunTipiFiltre.Name = "lblUrunTipiFiltre";
            this.lblUrunTipiFiltre.Size = new System.Drawing.Size(65, 15);
            this.lblUrunTipiFiltre.TabIndex = 10;
            this.lblUrunTipiFiltre.Text = "Lazer Tipi:";
            // 
            // cmbUrunTipiFiltre
            // 
            this.cmbUrunTipiFiltre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrunTipiFiltre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbUrunTipiFiltre.FormattingEnabled = true;
            this.cmbUrunTipiFiltre.Location = new System.Drawing.Point(810, 14);
            this.cmbUrunTipiFiltre.Name = "cmbUrunTipiFiltre";
            this.cmbUrunTipiFiltre.Size = new System.Drawing.Size(130, 25);
            this.cmbUrunTipiFiltre.TabIndex = 11;
            // (SelectedIndexChanged olayı LazerTakipUretim_Load'da bağlanıyor)
            // ─────────────────────────────────────────────────────────
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.BackColor = System.Drawing.Color.Red;
            this.btnUrunSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUrunSil.FlatAppearance.BorderSize = 0;
            this.btnUrunSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunSil.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUrunSil.ForeColor = System.Drawing.Color.White;
            this.btnUrunSil.Location = new System.Drawing.Point(370, 10);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(170, 40);
            this.btnUrunSil.TabIndex = 2;
            this.btnUrunSil.Text = "🗑️ Ürün Sil";
            this.btnUrunSil.UseVisualStyleBackColor = false;
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);
            // 
            // btnUrunDuzenle
            // 
            this.btnUrunDuzenle.BackColor = System.Drawing.Color.FromArgb(240, 196, 15);
            this.btnUrunDuzenle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUrunDuzenle.FlatAppearance.BorderSize = 0;
            this.btnUrunDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunDuzenle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUrunDuzenle.ForeColor = System.Drawing.Color.White;
            this.btnUrunDuzenle.Location = new System.Drawing.Point(194, 10);
            this.btnUrunDuzenle.Name = "btnUrunDuzenle";
            this.btnUrunDuzenle.Size = new System.Drawing.Size(170, 40);
            this.btnUrunDuzenle.TabIndex = 1;
            this.btnUrunDuzenle.Text = "✏️ Ürün Düzenle";
            this.btnUrunDuzenle.UseVisualStyleBackColor = false;
            this.btnUrunDuzenle.Click += new System.EventHandler(this.btnUrunDuzenle_Click);
            // 
            // btnYeniUrun
            // 
            this.btnYeniUrun.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnYeniUrun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYeniUrun.FlatAppearance.BorderSize = 0;
            this.btnYeniUrun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniUrun.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYeniUrun.ForeColor = System.Drawing.Color.White;
            this.btnYeniUrun.Location = new System.Drawing.Point(18, 10);
            this.btnYeniUrun.Name = "btnYeniUrun";
            this.btnYeniUrun.Size = new System.Drawing.Size(170, 40);
            this.btnYeniUrun.TabIndex = 0;
            this.btnYeniUrun.Text = "➕ Yeni Ürün Ekle";
            this.btnYeniUrun.UseVisualStyleBackColor = false;
            this.btnYeniUrun.Click += new System.EventHandler(this.btnYeniUrun_Click);
            // 
            // dgvUrunler
            // 
            this.dgvUrunler.AllowUserToAddRows = false;
            this.dgvUrunler.AllowUserToDeleteRows = false;
            this.dgvUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUrunler.BackgroundColor = System.Drawing.Color.White;
            this.dgvUrunler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUrunler.Location = new System.Drawing.Point(10, 10);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.ReadOnly = true;
            this.dgvUrunler.RowHeadersVisible = false;
            this.dgvUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUrunler.Size = new System.Drawing.Size(1572, 768);
            this.dgvUrunler.TabIndex = 0;
            // 
            // tabPlakaLazer
            // 
            this.tabPlakaLazer.BackColor = System.Drawing.Color.FromArgb(236, 240, 245);
            this.tabPlakaLazer.Controls.Add(this.pnlPlakaRight);
            this.tabPlakaLazer.Controls.Add(this.pnlPlakaLeft);
            this.tabPlakaLazer.Location = new System.Drawing.Point(4, 28);
            this.tabPlakaLazer.Name = "tabPlakaLazer";
            this.tabPlakaLazer.Padding = new System.Windows.Forms.Padding(10);
            this.tabPlakaLazer.Size = new System.Drawing.Size(1592, 788);
            this.tabPlakaLazer.TabIndex = 1;
            this.tabPlakaLazer.Text = "🔷 PLAKA LAZER";
            // 
            // pnlPlakaRight
            // 
            this.pnlPlakaRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlakaRight.Controls.Add(this.grpPlakaHesaplama);
            this.pnlPlakaRight.Controls.Add(this.grpPlakaSiparis);
            this.pnlPlakaRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlakaRight.Location = new System.Drawing.Point(810, 10);
            this.pnlPlakaRight.Name = "pnlPlakaRight";
            this.pnlPlakaRight.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnlPlakaRight.Size = new System.Drawing.Size(772, 768);
            this.pnlPlakaRight.TabIndex = 1;
            // 
            // grpPlakaHesaplama
            // 
            this.grpPlakaHesaplama.BackColor = System.Drawing.Color.White;
            this.grpPlakaHesaplama.Controls.Add(this.lblPlakaSonuc);
            this.grpPlakaHesaplama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPlakaHesaplama.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpPlakaHesaplama.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.grpPlakaHesaplama.Location = new System.Drawing.Point(5, 200);
            this.grpPlakaHesaplama.Name = "grpPlakaHesaplama";
            this.grpPlakaHesaplama.Padding = new System.Windows.Forms.Padding(15);
            this.grpPlakaHesaplama.Size = new System.Drawing.Size(767, 568);
            this.grpPlakaHesaplama.TabIndex = 1;
            this.grpPlakaHesaplama.TabStop = false;
            this.grpPlakaHesaplama.Text = "📊 Hesaplama Sonuçları";
            // 
            // lblPlakaSonuc
            // 
            this.lblPlakaSonuc.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.lblPlakaSonuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlakaSonuc.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblPlakaSonuc.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblPlakaSonuc.Location = new System.Drawing.Point(15, 35);
            this.lblPlakaSonuc.Name = "lblPlakaSonuc";
            this.lblPlakaSonuc.Padding = new System.Windows.Forms.Padding(10);
            this.lblPlakaSonuc.Size = new System.Drawing.Size(737, 518);
            this.lblPlakaSonuc.TabIndex = 0;
            // 
            // grpPlakaSiparis
            // 
            this.grpPlakaSiparis.BackColor = System.Drawing.Color.White;
            this.grpPlakaSiparis.Controls.Add(this.btnPlakaHesapla);
            this.grpPlakaSiparis.Controls.Add(this.numPlakaSiparisAdet);
            this.grpPlakaSiparis.Controls.Add(this.cmbPlakaUrun);
            this.grpPlakaSiparis.Controls.Add(this.label4);
            this.grpPlakaSiparis.Controls.Add(this.label5);
            this.grpPlakaSiparis.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPlakaSiparis.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpPlakaSiparis.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.grpPlakaSiparis.Location = new System.Drawing.Point(5, 0);
            this.grpPlakaSiparis.Name = "grpPlakaSiparis";
            this.grpPlakaSiparis.Padding = new System.Windows.Forms.Padding(15);
            this.grpPlakaSiparis.Size = new System.Drawing.Size(767, 200);
            this.grpPlakaSiparis.TabIndex = 0;
            this.grpPlakaSiparis.TabStop = false;
            this.grpPlakaSiparis.Text = "📋 Sipariş Bilgileri";
            // 
            // btnPlakaHesapla
            // 
            this.btnPlakaHesapla.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnPlakaHesapla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlakaHesapla.FlatAppearance.BorderSize = 0;
            this.btnPlakaHesapla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlakaHesapla.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPlakaHesapla.ForeColor = System.Drawing.Color.White;
            this.btnPlakaHesapla.Location = new System.Drawing.Point(18, 140);
            this.btnPlakaHesapla.Name = "btnPlakaHesapla";
            this.btnPlakaHesapla.Size = new System.Drawing.Size(730, 45);
            this.btnPlakaHesapla.TabIndex = 4;
            this.btnPlakaHesapla.Text = "✅ HESAPLA";
            this.btnPlakaHesapla.UseVisualStyleBackColor = false;
            this.btnPlakaHesapla.Click += new System.EventHandler(this.btnPlakaHesapla_Click);
            // 
            // numPlakaSiparisAdet
            // 
            this.numPlakaSiparisAdet.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numPlakaSiparisAdet.Location = new System.Drawing.Point(18, 102);
            this.numPlakaSiparisAdet.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numPlakaSiparisAdet.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numPlakaSiparisAdet.Name = "numPlakaSiparisAdet";
            this.numPlakaSiparisAdet.Size = new System.Drawing.Size(730, 27);
            this.numPlakaSiparisAdet.TabIndex = 3;
            this.numPlakaSiparisAdet.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbPlakaUrun
            // 
            this.cmbPlakaUrun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlakaUrun.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbPlakaUrun.FormattingEnabled = true;
            this.cmbPlakaUrun.Location = new System.Drawing.Point(18, 48);
            this.cmbPlakaUrun.Name = "cmbPlakaUrun";
            this.cmbPlakaUrun.Size = new System.Drawing.Size(730, 28);
            this.cmbPlakaUrun.TabIndex = 1;
            this.cmbPlakaUrun.SelectedIndexChanged += new System.EventHandler(this.cmbPlakaUrun_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(15, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Sipariş Adedi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(15, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ürün Seçin:";
            // 
            // pnlPlakaLeft
            // 
            this.pnlPlakaLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlakaLeft.Controls.Add(this.dgvPlakaDetay);
            this.pnlPlakaLeft.Controls.Add(this.grpPlakaSacStok);
            this.pnlPlakaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPlakaLeft.Location = new System.Drawing.Point(10, 10);
            this.pnlPlakaLeft.Name = "pnlPlakaLeft";
            this.pnlPlakaLeft.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlPlakaLeft.Size = new System.Drawing.Size(800, 768);
            this.pnlPlakaLeft.TabIndex = 0;
            // 
            // dgvPlakaDetay
            // 
            this.dgvPlakaDetay.AllowUserToAddRows = false;
            this.dgvPlakaDetay.AllowUserToDeleteRows = false;
            this.dgvPlakaDetay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlakaDetay.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlakaDetay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlakaDetay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlakaDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlakaDetay.Location = new System.Drawing.Point(0, 370);
            this.dgvPlakaDetay.Name = "dgvPlakaDetay";
            this.dgvPlakaDetay.ReadOnly = true;
            this.dgvPlakaDetay.RowHeadersVisible = false;
            this.dgvPlakaDetay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlakaDetay.Size = new System.Drawing.Size(795, 398);
            this.dgvPlakaDetay.TabIndex = 1;
            // 
            // grpPlakaSacStok
            // 
            this.grpPlakaSacStok.BackColor = System.Drawing.Color.White;
            // ── YENİ: btnSacStokEkle gruba eklendi ──
            this.grpPlakaSacStok.Controls.Add(this.btnSacStokEkle);
            // ────────────────────────────────────────
            this.grpPlakaSacStok.Controls.Add(this.btnStokDuzenlePlaka);
            this.grpPlakaSacStok.Controls.Add(this.btnSacStokGuncelle);
            this.grpPlakaSacStok.Controls.Add(this.dgvSacStok);
            this.grpPlakaSacStok.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPlakaSacStok.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpPlakaSacStok.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.grpPlakaSacStok.Location = new System.Drawing.Point(0, 0);
            this.grpPlakaSacStok.Name = "grpPlakaSacStok";
            this.grpPlakaSacStok.Padding = new System.Windows.Forms.Padding(15);
            // Yüksekliği 370 → 420 yapıldı (btnSacStokEkle için alt sıra eklendi)
            this.grpPlakaSacStok.Size = new System.Drawing.Size(795, 420);
            this.grpPlakaSacStok.TabIndex = 0;
            this.grpPlakaSacStok.TabStop = false;
            this.grpPlakaSacStok.Text = "📦 Sac Stok Durumu";
            // 
            // btnStokDuzenlePlaka  (orta buton — konumu 317→367 kayacak)
            // 
            this.btnStokDuzenlePlaka.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnStokDuzenlePlaka.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStokDuzenlePlaka.FlatAppearance.BorderSize = 0;
            this.btnStokDuzenlePlaka.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStokDuzenlePlaka.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStokDuzenlePlaka.ForeColor = System.Drawing.Color.White;
            this.btnStokDuzenlePlaka.Location = new System.Drawing.Point(398, 367);
            this.btnStokDuzenlePlaka.Name = "btnStokDuzenlePlaka";
            this.btnStokDuzenlePlaka.Size = new System.Drawing.Size(374, 40);
            this.btnStokDuzenlePlaka.TabIndex = 3;
            this.btnStokDuzenlePlaka.Text = "✏️ Stok Düzenle";
            this.btnStokDuzenlePlaka.UseVisualStyleBackColor = false;
            this.btnStokDuzenlePlaka.Click += new System.EventHandler(this.btnStokDuzenlePlaka_Click);
            // 
            // btnSacStokGuncelle  (sol buton — konumu 317→367)
            // 
            this.btnSacStokGuncelle.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSacStokGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSacStokGuncelle.FlatAppearance.BorderSize = 0;
            this.btnSacStokGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSacStokGuncelle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSacStokGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnSacStokGuncelle.Location = new System.Drawing.Point(18, 367);
            this.btnSacStokGuncelle.Name = "btnSacStokGuncelle";
            this.btnSacStokGuncelle.Size = new System.Drawing.Size(374, 40);
            this.btnSacStokGuncelle.TabIndex = 1;
            this.btnSacStokGuncelle.Text = "🔄 Stokları Yenile";
            this.btnSacStokGuncelle.UseVisualStyleBackColor = false;
            this.btnSacStokGuncelle.Click += new System.EventHandler(this.btnSacStokGuncelle_Click);
            // 
            // ── YENİ: btnSacStokEkle ─────────────────────────────────
            // İki mevcut butonun üstüne, 317 konumuna yerleştirildi
            // 
            this.btnSacStokEkle.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnSacStokEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSacStokEkle.FlatAppearance.BorderSize = 0;
            this.btnSacStokEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSacStokEkle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSacStokEkle.ForeColor = System.Drawing.Color.White;
            this.btnSacStokEkle.Location = new System.Drawing.Point(18, 317);
            this.btnSacStokEkle.Name = "btnSacStokEkle";
            this.btnSacStokEkle.Size = new System.Drawing.Size(757, 40);
            this.btnSacStokEkle.TabIndex = 4;
            this.btnSacStokEkle.Text = "➕ Yeni Sac / Plaka Ekle";
            this.btnSacStokEkle.UseVisualStyleBackColor = false;
            this.btnSacStokEkle.Click += new System.EventHandler(this.btnSacStokEkle_Click);
            // ─────────────────────────────────────────────────────────
            // 
            // dgvSacStok
            // 
            this.dgvSacStok.AllowUserToAddRows = false;
            this.dgvSacStok.AllowUserToDeleteRows = false;
            this.dgvSacStok.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSacStok.BackgroundColor = System.Drawing.Color.White;
            this.dgvSacStok.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSacStok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSacStok.Location = new System.Drawing.Point(18, 29);
            this.dgvSacStok.Name = "dgvSacStok";
            this.dgvSacStok.ReadOnly = true;
            this.dgvSacStok.RowHeadersVisible = false;
            this.dgvSacStok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSacStok.Size = new System.Drawing.Size(757, 282);
            this.dgvSacStok.TabIndex = 0;
            // 
            // tabBoruLazer
            // 
            this.tabBoruLazer.BackColor = System.Drawing.Color.FromArgb(236, 240, 245);
            this.tabBoruLazer.Controls.Add(this.pnlBoruRight);
            this.tabBoruLazer.Controls.Add(this.pnlBoruLeft);
            this.tabBoruLazer.Location = new System.Drawing.Point(4, 28);
            this.tabBoruLazer.Name = "tabBoruLazer";
            this.tabBoruLazer.Padding = new System.Windows.Forms.Padding(10);
            this.tabBoruLazer.Size = new System.Drawing.Size(1592, 788);
            this.tabBoruLazer.TabIndex = 0;
            this.tabBoruLazer.Text = "🔶 BORU LAZER";
            // 
            // pnlBoruRight
            // 
            this.pnlBoruRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlBoruRight.Controls.Add(this.grpBoruHesaplama);
            this.pnlBoruRight.Controls.Add(this.grpBoruSiparis);
            this.pnlBoruRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBoruRight.Location = new System.Drawing.Point(810, 10);
            this.pnlBoruRight.Name = "pnlBoruRight";
            this.pnlBoruRight.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnlBoruRight.Size = new System.Drawing.Size(772, 768);
            this.pnlBoruRight.TabIndex = 1;
            // 
            // grpBoruHesaplama
            // 
            this.grpBoruHesaplama.BackColor = System.Drawing.Color.White;
            this.grpBoruHesaplama.Controls.Add(this.rtxtBoruSonuc);
            this.grpBoruHesaplama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoruHesaplama.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpBoruHesaplama.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.grpBoruHesaplama.Location = new System.Drawing.Point(5, 200);
            this.grpBoruHesaplama.Name = "grpBoruHesaplama";
            this.grpBoruHesaplama.Padding = new System.Windows.Forms.Padding(15);
            this.grpBoruHesaplama.Size = new System.Drawing.Size(767, 568);
            this.grpBoruHesaplama.TabIndex = 1;
            this.grpBoruHesaplama.TabStop = false;
            this.grpBoruHesaplama.Text = "📊 Hesaplama Sonuçları";
            // 
            // rtxtBoruSonuc
            // 
            this.rtxtBoruSonuc.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.rtxtBoruSonuc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtBoruSonuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtBoruSonuc.Font = new System.Drawing.Font("Consolas", 10F);
            this.rtxtBoruSonuc.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.rtxtBoruSonuc.Location = new System.Drawing.Point(15, 35);
            this.rtxtBoruSonuc.Name = "rtxtBoruSonuc";
            this.rtxtBoruSonuc.ReadOnly = true;
            this.rtxtBoruSonuc.Size = new System.Drawing.Size(737, 518);
            this.rtxtBoruSonuc.TabIndex = 0;
            this.rtxtBoruSonuc.Text = "";
            // 
            // grpBoruSiparis
            // 
            this.grpBoruSiparis.BackColor = System.Drawing.Color.White;
            this.grpBoruSiparis.Controls.Add(this.btnBoruHesapla);
            this.grpBoruSiparis.Controls.Add(this.numBoruSiparisAdet);
            this.grpBoruSiparis.Controls.Add(this.cmbBoruUrun);
            this.grpBoruSiparis.Controls.Add(this.label3);
            this.grpBoruSiparis.Controls.Add(this.label2);
            this.grpBoruSiparis.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoruSiparis.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpBoruSiparis.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.grpBoruSiparis.Location = new System.Drawing.Point(5, 0);
            this.grpBoruSiparis.Name = "grpBoruSiparis";
            this.grpBoruSiparis.Padding = new System.Windows.Forms.Padding(15);
            this.grpBoruSiparis.Size = new System.Drawing.Size(767, 200);
            this.grpBoruSiparis.TabIndex = 0;
            this.grpBoruSiparis.TabStop = false;
            this.grpBoruSiparis.Text = "📋 Sipariş Bilgileri";
            // 
            // btnBoruHesapla
            // 
            this.btnBoruHesapla.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnBoruHesapla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBoruHesapla.FlatAppearance.BorderSize = 0;
            this.btnBoruHesapla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoruHesapla.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBoruHesapla.ForeColor = System.Drawing.Color.White;
            this.btnBoruHesapla.Location = new System.Drawing.Point(18, 140);
            this.btnBoruHesapla.Name = "btnBoruHesapla";
            this.btnBoruHesapla.Size = new System.Drawing.Size(730, 45);
            this.btnBoruHesapla.TabIndex = 4;
            this.btnBoruHesapla.Text = "✅ HESAPLA";
            this.btnBoruHesapla.UseVisualStyleBackColor = false;
            this.btnBoruHesapla.Click += new System.EventHandler(this.btnBoruHesapla_Click);
            // 
            // numBoruSiparisAdet
            // 
            this.numBoruSiparisAdet.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numBoruSiparisAdet.Location = new System.Drawing.Point(18, 102);
            this.numBoruSiparisAdet.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numBoruSiparisAdet.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numBoruSiparisAdet.Name = "numBoruSiparisAdet";
            this.numBoruSiparisAdet.Size = new System.Drawing.Size(730, 27);
            this.numBoruSiparisAdet.TabIndex = 3;
            this.numBoruSiparisAdet.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbBoruUrun
            // 
            this.cmbBoruUrun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoruUrun.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbBoruUrun.FormattingEnabled = true;
            this.cmbBoruUrun.Location = new System.Drawing.Point(18, 48);
            this.cmbBoruUrun.Name = "cmbBoruUrun";
            this.cmbBoruUrun.Size = new System.Drawing.Size(730, 28);
            this.cmbBoruUrun.TabIndex = 1;
            this.cmbBoruUrun.SelectedIndexChanged += new System.EventHandler(this.cmbBoruUrun_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sipariş Adedi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(15, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ürün Seçin:";
            // 
            // pnlBoruLeft
            // 
            this.pnlBoruLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlBoruLeft.Controls.Add(this.dgvBoruDetay);
            this.pnlBoruLeft.Controls.Add(this.grpBoruProfilStok);
            this.pnlBoruLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBoruLeft.Location = new System.Drawing.Point(10, 10);
            this.pnlBoruLeft.Name = "pnlBoruLeft";
            this.pnlBoruLeft.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlBoruLeft.Size = new System.Drawing.Size(800, 768);
            this.pnlBoruLeft.TabIndex = 0;
            // 
            // dgvBoruDetay
            // 
            this.dgvBoruDetay.AllowUserToAddRows = false;
            this.dgvBoruDetay.AllowUserToDeleteRows = false;
            this.dgvBoruDetay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBoruDetay.BackgroundColor = System.Drawing.Color.White;
            this.dgvBoruDetay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBoruDetay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBoruDetay.ColumnHeadersHeight = 40;
            this.dgvBoruDetay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBoruDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBoruDetay.EnableHeadersVisualStyles = false;
            this.dgvBoruDetay.Location = new System.Drawing.Point(0, 370);
            this.dgvBoruDetay.Name = "dgvBoruDetay";
            this.dgvBoruDetay.ReadOnly = true;
            this.dgvBoruDetay.RowHeadersVisible = false;
            this.dgvBoruDetay.RowTemplate.Height = 30;
            this.dgvBoruDetay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBoruDetay.Size = new System.Drawing.Size(795, 398);
            this.dgvBoruDetay.TabIndex = 1;
            // 
            // grpBoruProfilStok
            // 
            this.grpBoruProfilStok.BackColor = System.Drawing.Color.White;
            this.grpBoruProfilStok.Controls.Add(this.btnStokDuzenle);
            this.grpBoruProfilStok.Controls.Add(this.btnProfilStokGuncelle);
            this.grpBoruProfilStok.Controls.Add(this.dgvProfilStok);
            this.grpBoruProfilStok.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoruProfilStok.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpBoruProfilStok.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.grpBoruProfilStok.Location = new System.Drawing.Point(0, 0);
            this.grpBoruProfilStok.Name = "grpBoruProfilStok";
            this.grpBoruProfilStok.Padding = new System.Windows.Forms.Padding(15);
            this.grpBoruProfilStok.Size = new System.Drawing.Size(795, 370);
            this.grpBoruProfilStok.TabIndex = 0;
            this.grpBoruProfilStok.TabStop = false;
            this.grpBoruProfilStok.Text = "📦 Profil Stok Durumu";
            // 
            // btnStokDuzenle
            // 
            this.btnStokDuzenle.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnStokDuzenle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStokDuzenle.FlatAppearance.BorderSize = 0;
            this.btnStokDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStokDuzenle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStokDuzenle.ForeColor = System.Drawing.Color.White;
            this.btnStokDuzenle.Location = new System.Drawing.Point(398, 317);
            this.btnStokDuzenle.Name = "btnStokDuzenle";
            this.btnStokDuzenle.Size = new System.Drawing.Size(374, 40);
            this.btnStokDuzenle.TabIndex = 2;
            this.btnStokDuzenle.Text = "✏️ Stok Düzenle";
            this.btnStokDuzenle.UseVisualStyleBackColor = false;
            this.btnStokDuzenle.Click += new System.EventHandler(this.btnStokDuzenle_Click);
            // 
            // btnProfilStokGuncelle
            // 
            this.btnProfilStokGuncelle.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnProfilStokGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfilStokGuncelle.FlatAppearance.BorderSize = 0;
            this.btnProfilStokGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfilStokGuncelle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProfilStokGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnProfilStokGuncelle.Location = new System.Drawing.Point(18, 317);
            this.btnProfilStokGuncelle.Name = "btnProfilStokGuncelle";
            this.btnProfilStokGuncelle.Size = new System.Drawing.Size(374, 40);
            this.btnProfilStokGuncelle.TabIndex = 1;
            this.btnProfilStokGuncelle.Text = "🔄 Stokları Yenile";
            this.btnProfilStokGuncelle.UseVisualStyleBackColor = false;
            this.btnProfilStokGuncelle.Click += new System.EventHandler(this.btnProfilStokGuncelle_Click);
            // 
            // dgvProfilStok
            // 
            this.dgvProfilStok.AllowUserToAddRows = false;
            this.dgvProfilStok.AllowUserToDeleteRows = false;
            this.dgvProfilStok.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProfilStok.BackgroundColor = System.Drawing.Color.White;
            this.dgvProfilStok.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProfilStok.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProfilStok.ColumnHeadersHeight = 40;
            this.dgvProfilStok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProfilStok.EnableHeadersVisualStyles = false;
            this.dgvProfilStok.Location = new System.Drawing.Point(18, 29);
            this.dgvProfilStok.Name = "dgvProfilStok";
            this.dgvProfilStok.ReadOnly = true;
            this.dgvProfilStok.RowHeadersVisible = false;
            this.dgvProfilStok.RowTemplate.Height = 30;
            this.dgvProfilStok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfilStok.Size = new System.Drawing.Size(760, 282);
            this.dgvProfilStok.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBoruLazer);
            this.tabControl.Controls.Add(this.tabPlakaLazer);
            this.tabControl.Controls.Add(this.tabUrunYonetim);
            this.tabControl.Controls.Add(this.tabSiparisler);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControl.Location = new System.Drawing.Point(0, 80);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1600, 820);
            this.tabControl.TabIndex = 1;
            // 
            // LazerTakipUretim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlHeader);
            this.Name = "LazerTakipUretim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lazer Takip ve Üretim Sistemi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LazerTakipUretim_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabSiparisler.ResumeLayout(false);
            this.pnlSiparisButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).EndInit();
            this.tabUrunYonetim.ResumeLayout(false);
            this.pnlUrunButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.tabPlakaLazer.ResumeLayout(false);
            this.pnlPlakaRight.ResumeLayout(false);
            this.grpPlakaHesaplama.ResumeLayout(false);
            this.grpPlakaSiparis.ResumeLayout(false);
            this.grpPlakaSiparis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPlakaSiparisAdet)).EndInit();
            this.pnlPlakaLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlakaDetay)).EndInit();
            this.grpPlakaSacStok.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSacStok)).EndInit();
            this.tabBoruLazer.ResumeLayout(false);
            this.pnlBoruRight.ResumeLayout(false);
            this.grpBoruHesaplama.ResumeLayout(false);
            this.grpBoruSiparis.ResumeLayout(false);
            this.grpBoruSiparis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoruSiparisAdet)).EndInit();
            this.pnlBoruLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoruDetay)).EndInit();
            this.grpBoruProfilStok.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfilStok)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabPage tabSiparisler;
        private System.Windows.Forms.Panel pnlSiparisButtons;
        private System.Windows.Forms.Button btnSiparisDuzenle;
        private System.Windows.Forms.Button btnSiparisTamamla;
        private System.Windows.Forms.Button btnYeniSiparis;
        private System.Windows.Forms.DataGridView dgvSiparisler;
        private System.Windows.Forms.TabPage tabUrunYonetim;
        private System.Windows.Forms.Panel pnlUrunButtons;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.Button btnUrunDuzenle;
        private System.Windows.Forms.Button btnYeniUrun;
        private System.Windows.Forms.DataGridView dgvUrunler;
        private System.Windows.Forms.TabPage tabPlakaLazer;
        private System.Windows.Forms.Panel pnlPlakaRight;
        private System.Windows.Forms.GroupBox grpPlakaHesaplama;
        private System.Windows.Forms.Label lblPlakaSonuc;
        private System.Windows.Forms.GroupBox grpPlakaSiparis;
        private System.Windows.Forms.Button btnPlakaHesapla;
        private System.Windows.Forms.NumericUpDown numPlakaSiparisAdet;
        private System.Windows.Forms.ComboBox cmbPlakaUrun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlPlakaLeft;
        private System.Windows.Forms.DataGridView dgvPlakaDetay;
        private System.Windows.Forms.GroupBox grpPlakaSacStok;
        private System.Windows.Forms.Button btnSacStokGuncelle;
        private System.Windows.Forms.DataGridView dgvSacStok;
        private System.Windows.Forms.TabPage tabBoruLazer;
        private System.Windows.Forms.Panel pnlBoruRight;
        private System.Windows.Forms.GroupBox grpBoruHesaplama;
        private System.Windows.Forms.RichTextBox rtxtBoruSonuc;
        private System.Windows.Forms.GroupBox grpBoruSiparis;
        private System.Windows.Forms.Button btnBoruHesapla;
        private System.Windows.Forms.NumericUpDown numBoruSiparisAdet;
        private System.Windows.Forms.ComboBox cmbBoruUrun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBoruLeft;
        private System.Windows.Forms.DataGridView dgvBoruDetay;
        private System.Windows.Forms.GroupBox grpBoruProfilStok;
        private System.Windows.Forms.Button btnStokDuzenle;
        private System.Windows.Forms.Button btnProfilStokGuncelle;
        private System.Windows.Forms.DataGridView dgvProfilStok;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btnStokDuzenlePlaka;
        private System.Windows.Forms.Button btnExclYkl;
        private System.Windows.Forms.Button btnSiparisSil;
        private System.Windows.Forms.Button btnTumUrunler;
        private System.Windows.Forms.TextBox txturunara;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblara;
        // ── YENİ field tanımları ──
        private System.Windows.Forms.ComboBox cmbUrunTipiFiltre;
        private System.Windows.Forms.Label lblUrunTipiFiltre;
        private System.Windows.Forms.Button btnSacStokEkle;
    }
}