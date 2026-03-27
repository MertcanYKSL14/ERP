namespace ÜretimTakipSistemi.Siparis
{
    partial class SiparisAnaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiparisAnaForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnsiparis = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnStokGuncelle = new System.Windows.Forms.Button();
            this.btnBitenSiparis = new System.Windows.Forms.Button();
            this.btnSiparisDurum = new System.Windows.Forms.Button();
            this.btnExcelYukle = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.panelKPI = new System.Windows.Forms.Panel();
            this.cardToday = new System.Windows.Forms.Panel();
            this.lblKPITodayVal = new System.Windows.Forms.Label();
            this.lblKPIToday = new System.Windows.Forms.Label();
            this.cardPending = new System.Windows.Forms.Panel();
            this.lblKPIPendingVal = new System.Windows.Forms.Label();
            this.lblKPIPending = new System.Windows.Forms.Label();
            this.cardTotal = new System.Windows.Forms.Panel();
            this.lblKPITotalVal = new System.Windows.Forms.Label();
            this.lblKPITotal = new System.Windows.Forms.Label();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.panelGridTop = new System.Windows.Forms.Panel();
            this.dgvSiparisler = new System.Windows.Forms.DataGridView();
            this.panelSiparisFilter = new System.Windows.Forms.Panel();
            this.btnListele = new System.Windows.Forms.Button();
            this.dtBitis = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.lblSiparisListesi = new System.Windows.Forms.Label();
            this.panelGridBottom = new System.Windows.Forms.Panel();
            this.dgvIhtiyaclar = new System.Windows.Forms.DataGridView();
            this.panelIhtiyacHeader = new System.Windows.Forms.Panel();
            this.btnDisaAktar = new System.Windows.Forms.Button();
            this.lblIhtiyacAnalizi = new System.Windows.Forms.Label();
            this.panelSideMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelKPI.SuspendLayout();
            this.cardToday.SuspendLayout();
            this.cardPending.SuspendLayout();
            this.cardTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelGridTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).BeginInit();
            this.panelSiparisFilter.SuspendLayout();
            this.panelGridBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhtiyaclar)).BeginInit();
            this.panelIhtiyacHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(33)))), ((int)(((byte)(62)))));
            this.panelSideMenu.Controls.Add(this.btnsiparis);
            this.panelSideMenu.Controls.Add(this.btnCikis);
            this.panelSideMenu.Controls.Add(this.btnStokGuncelle);
            this.panelSideMenu.Controls.Add(this.btnBitenSiparis);
            this.panelSideMenu.Controls.Add(this.btnSiparisDurum);
            this.panelSideMenu.Controls.Add(this.btnExcelYukle);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(220, 761);
            this.panelSideMenu.TabIndex = 3;
            // 
            // btnsiparis
            // 
            this.btnsiparis.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnsiparis.FlatAppearance.BorderSize = 0;
            this.btnsiparis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsiparis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnsiparis.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnsiparis.Location = new System.Drawing.Point(0, 300);
            this.btnsiparis.Name = "btnsiparis";
            this.btnsiparis.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnsiparis.Size = new System.Drawing.Size(220, 55);
            this.btnsiparis.TabIndex = 5;
            this.btnsiparis.Text = "🗨️ Sohbet";
            this.btnsiparis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsiparis.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnCikis.ForeColor = System.Drawing.Color.IndianRed;
            this.btnCikis.Location = new System.Drawing.Point(0, 711);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(220, 50);
            this.btnCikis.TabIndex = 0;
            this.btnCikis.Text = "🚪 Çıkış";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnStokGuncelle
            // 
            this.btnStokGuncelle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStokGuncelle.FlatAppearance.BorderSize = 0;
            this.btnStokGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStokGuncelle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnStokGuncelle.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStokGuncelle.Location = new System.Drawing.Point(0, 245);
            this.btnStokGuncelle.Name = "btnStokGuncelle";
            this.btnStokGuncelle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnStokGuncelle.Size = new System.Drawing.Size(220, 55);
            this.btnStokGuncelle.TabIndex = 1;
            this.btnStokGuncelle.Text = "📦  Stok Yönetimi";
            this.btnStokGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStokGuncelle.Click += new System.EventHandler(this.btnStokGuncelle_Click);
            // 
            // btnBitenSiparis
            // 
            this.btnBitenSiparis.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBitenSiparis.FlatAppearance.BorderSize = 0;
            this.btnBitenSiparis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBitenSiparis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBitenSiparis.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBitenSiparis.Location = new System.Drawing.Point(0, 190);
            this.btnBitenSiparis.Name = "btnBitenSiparis";
            this.btnBitenSiparis.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnBitenSiparis.Size = new System.Drawing.Size(220, 55);
            this.btnBitenSiparis.TabIndex = 2;
            this.btnBitenSiparis.Text = "✅  Tamamlananlar";
            this.btnBitenSiparis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBitenSiparis.Click += new System.EventHandler(this.btnBitenSiparis_Click);
            // 
            // btnSiparisDurum
            // 
            this.btnSiparisDurum.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSiparisDurum.FlatAppearance.BorderSize = 0;
            this.btnSiparisDurum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiparisDurum.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSiparisDurum.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSiparisDurum.Location = new System.Drawing.Point(0, 135);
            this.btnSiparisDurum.Name = "btnSiparisDurum";
            this.btnSiparisDurum.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSiparisDurum.Size = new System.Drawing.Size(220, 55);
            this.btnSiparisDurum.TabIndex = 2;
            this.btnSiparisDurum.Text = "📊  Sipariş Akışı";
            this.btnSiparisDurum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSiparisDurum.Click += new System.EventHandler(this.btnSiparisAkisi_Click);
            // 
            // btnExcelYukle
            // 
            this.btnExcelYukle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExcelYukle.FlatAppearance.BorderSize = 0;
            this.btnExcelYukle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcelYukle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExcelYukle.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExcelYukle.Location = new System.Drawing.Point(0, 80);
            this.btnExcelYukle.Name = "btnExcelYukle";
            this.btnExcelYukle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnExcelYukle.Size = new System.Drawing.Size(220, 55);
            this.btnExcelYukle.TabIndex = 3;
            this.btnExcelYukle.Text = "📥  Yeni Sipariş (Excel)";
            this.btnExcelYukle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelYukle.Click += new System.EventHandler(this.btnExcelYukle_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(220, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(964, 60);
            this.panelHeader.TabIndex = 2;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(341, 30);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Sipariş ve Üretim Kontrol Paneli";
            // 
            // panelKPI
            // 
            this.panelKPI.Controls.Add(this.cardToday);
            this.panelKPI.Controls.Add(this.cardPending);
            this.panelKPI.Controls.Add(this.cardTotal);
            this.panelKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPI.Location = new System.Drawing.Point(220, 60);
            this.panelKPI.Name = "panelKPI";
            this.panelKPI.Padding = new System.Windows.Forms.Padding(20);
            this.panelKPI.Size = new System.Drawing.Size(964, 120);
            this.panelKPI.TabIndex = 1;
            // 
            // cardToday
            // 
            this.cardToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.cardToday.Controls.Add(this.lblKPITodayVal);
            this.cardToday.Controls.Add(this.lblKPIToday);
            this.cardToday.Location = new System.Drawing.Point(460, 20);
            this.cardToday.Name = "cardToday";
            this.cardToday.Size = new System.Drawing.Size(200, 80);
            this.cardToday.TabIndex = 0;
            // 
            // lblKPITodayVal
            // 
            this.lblKPITodayVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblKPITodayVal.ForeColor = System.Drawing.Color.White;
            this.lblKPITodayVal.Location = new System.Drawing.Point(10, 30);
            this.lblKPITodayVal.Name = "lblKPITodayVal";
            this.lblKPITodayVal.Size = new System.Drawing.Size(100, 41);
            this.lblKPITodayVal.TabIndex = 0;
            this.lblKPITodayVal.Text = "0";
            // 
            // lblKPIToday
            // 
            this.lblKPIToday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKPIToday.ForeColor = System.Drawing.Color.White;
            this.lblKPIToday.Location = new System.Drawing.Point(10, 10);
            this.lblKPIToday.Name = "lblKPIToday";
            this.lblKPIToday.Size = new System.Drawing.Size(100, 23);
            this.lblKPIToday.TabIndex = 1;
            this.lblKPIToday.Text = "İHTİYAC LİSTESİ";
            // 
            // cardPending
            // 
            this.cardPending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.cardPending.Controls.Add(this.lblKPIPendingVal);
            this.cardPending.Controls.Add(this.lblKPIPending);
            this.cardPending.Location = new System.Drawing.Point(240, 20);
            this.cardPending.Name = "cardPending";
            this.cardPending.Size = new System.Drawing.Size(200, 80);
            this.cardPending.TabIndex = 1;
            // 
            // lblKPIPendingVal
            // 
            this.lblKPIPendingVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblKPIPendingVal.ForeColor = System.Drawing.Color.White;
            this.lblKPIPendingVal.Location = new System.Drawing.Point(10, 30);
            this.lblKPIPendingVal.Name = "lblKPIPendingVal";
            this.lblKPIPendingVal.Size = new System.Drawing.Size(100, 41);
            this.lblKPIPendingVal.TabIndex = 0;
            this.lblKPIPendingVal.Text = "0";
            // 
            // lblKPIPending
            // 
            this.lblKPIPending.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKPIPending.ForeColor = System.Drawing.Color.White;
            this.lblKPIPending.Location = new System.Drawing.Point(10, 10);
            this.lblKPIPending.Name = "lblKPIPending";
            this.lblKPIPending.Size = new System.Drawing.Size(100, 23);
            this.lblKPIPending.TabIndex = 1;
            this.lblKPIPending.Text = "BEKLEYEN";
            // 
            // cardTotal
            // 
            this.cardTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.cardTotal.Controls.Add(this.lblKPITotalVal);
            this.cardTotal.Controls.Add(this.lblKPITotal);
            this.cardTotal.Location = new System.Drawing.Point(20, 20);
            this.cardTotal.Name = "cardTotal";
            this.cardTotal.Size = new System.Drawing.Size(200, 80);
            this.cardTotal.TabIndex = 2;
            // 
            // lblKPITotalVal
            // 
            this.lblKPITotalVal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblKPITotalVal.ForeColor = System.Drawing.Color.White;
            this.lblKPITotalVal.Location = new System.Drawing.Point(10, 30);
            this.lblKPITotalVal.Name = "lblKPITotalVal";
            this.lblKPITotalVal.Size = new System.Drawing.Size(100, 41);
            this.lblKPITotalVal.TabIndex = 0;
            this.lblKPITotalVal.Text = "0";
            // 
            // lblKPITotal
            // 
            this.lblKPITotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKPITotal.ForeColor = System.Drawing.Color.White;
            this.lblKPITotal.Location = new System.Drawing.Point(10, 10);
            this.lblKPITotal.Name = "lblKPITotal";
            this.lblKPITotal.Size = new System.Drawing.Size(100, 23);
            this.lblKPITotal.TabIndex = 1;
            this.lblKPITotal.Text = "TOPLAM";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(220, 180);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.panelGridTop);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.panelGridBottom);
            this.splitContainerMain.Size = new System.Drawing.Size(964, 581);
            this.splitContainerMain.SplitterDistance = 300;
            this.splitContainerMain.SplitterWidth = 10;
            this.splitContainerMain.TabIndex = 0;
            // 
            // panelGridTop
            // 
            this.panelGridTop.BackColor = System.Drawing.Color.White;
            this.panelGridTop.Controls.Add(this.dgvSiparisler);
            this.panelGridTop.Controls.Add(this.panelSiparisFilter);
            this.panelGridTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridTop.Location = new System.Drawing.Point(0, 0);
            this.panelGridTop.Name = "panelGridTop";
            this.panelGridTop.Padding = new System.Windows.Forms.Padding(10);
            this.panelGridTop.Size = new System.Drawing.Size(964, 300);
            this.panelGridTop.TabIndex = 0;
            // 
            // dgvSiparisler
            // 
            this.dgvSiparisler.AllowUserToAddRows = false;
            this.dgvSiparisler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSiparisler.BackgroundColor = System.Drawing.Color.White;
            this.dgvSiparisler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dgvSiparisler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSiparisler.ColumnHeadersHeight = 35;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSiparisler.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSiparisler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSiparisler.Location = new System.Drawing.Point(10, 60);
            this.dgvSiparisler.Name = "dgvSiparisler";
            this.dgvSiparisler.ReadOnly = true;
            this.dgvSiparisler.RowHeadersVisible = false;
            this.dgvSiparisler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSiparisler.Size = new System.Drawing.Size(944, 230);
            this.dgvSiparisler.TabIndex = 0;
            this.dgvSiparisler.SelectionChanged += new System.EventHandler(this.dgvSiparisler_SelectionChanged);
            // 
            // panelSiparisFilter
            // 
            this.panelSiparisFilter.Controls.Add(this.btnListele);
            this.panelSiparisFilter.Controls.Add(this.dtBitis);
            this.panelSiparisFilter.Controls.Add(this.label2);
            this.panelSiparisFilter.Controls.Add(this.dtBaslangic);
            this.panelSiparisFilter.Controls.Add(this.label1);
            this.panelSiparisFilter.Controls.Add(this.txtArama);
            this.panelSiparisFilter.Controls.Add(this.lblSiparisListesi);
            this.panelSiparisFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSiparisFilter.Location = new System.Drawing.Point(10, 10);
            this.panelSiparisFilter.Name = "panelSiparisFilter";
            this.panelSiparisFilter.Size = new System.Drawing.Size(944, 50);
            this.panelSiparisFilter.TabIndex = 1;
            // 
            // btnListele
            // 
            this.btnListele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListele.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnListele.ForeColor = System.Drawing.Color.White;
            this.btnListele.Location = new System.Drawing.Point(625, 7);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(84, 37);
            this.btnListele.TabIndex = 0;
            this.btnListele.Text = "Filtrele";
            this.btnListele.UseVisualStyleBackColor = false;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // dtBitis
            // 
            this.dtBitis.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBitis.Location = new System.Drawing.Point(519, 12);
            this.dtBitis.Name = "dtBitis";
            this.dtBitis.Size = new System.Drawing.Size(100, 29);
            this.dtBitis.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(504, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // dtBaslangic
            // 
            this.dtBaslangic.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBaslangic.Location = new System.Drawing.Point(399, 12);
            this.dtBaslangic.Name = "dtBaslangic";
            this.dtBaslangic.Size = new System.Drawing.Size(100, 29);
            this.dtBaslangic.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(333, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tarih:";
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(135, 12);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(150, 25);
            this.txtArama.TabIndex = 5;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // lblSiparisListesi
            // 
            this.lblSiparisListesi.AutoSize = true;
            this.lblSiparisListesi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSiparisListesi.ForeColor = System.Drawing.Color.Black;
            this.lblSiparisListesi.Location = new System.Drawing.Point(0, 12);
            this.lblSiparisListesi.Name = "lblSiparisListesi";
            this.lblSiparisListesi.Size = new System.Drawing.Size(129, 20);
            this.lblSiparisListesi.TabIndex = 6;
            this.lblSiparisListesi.Text = "📦 Sipariş Listesi";
            // 
            // panelGridBottom
            // 
            this.panelGridBottom.BackColor = System.Drawing.Color.White;
            this.panelGridBottom.Controls.Add(this.dgvIhtiyaclar);
            this.panelGridBottom.Controls.Add(this.panelIhtiyacHeader);
            this.panelGridBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridBottom.Location = new System.Drawing.Point(0, 0);
            this.panelGridBottom.Name = "panelGridBottom";
            this.panelGridBottom.Padding = new System.Windows.Forms.Padding(10);
            this.panelGridBottom.Size = new System.Drawing.Size(964, 271);
            this.panelGridBottom.TabIndex = 0;
            // 
            // dgvIhtiyaclar
            // 
            this.dgvIhtiyaclar.AllowUserToAddRows = false;
            this.dgvIhtiyaclar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIhtiyaclar.BackgroundColor = System.Drawing.Color.White;
            this.dgvIhtiyaclar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dgvIhtiyaclar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvIhtiyaclar.ColumnHeadersHeight = 30;
            this.dgvIhtiyaclar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIhtiyaclar.Location = new System.Drawing.Point(10, 50);
            this.dgvIhtiyaclar.Name = "dgvIhtiyaclar";
            this.dgvIhtiyaclar.ReadOnly = true;
            this.dgvIhtiyaclar.RowHeadersVisible = false;
            this.dgvIhtiyaclar.Size = new System.Drawing.Size(944, 211);
            this.dgvIhtiyaclar.TabIndex = 0;
            // 
            // panelIhtiyacHeader
            // 
            this.panelIhtiyacHeader.Controls.Add(this.btnDisaAktar);
            this.panelIhtiyacHeader.Controls.Add(this.lblIhtiyacAnalizi);
            this.panelIhtiyacHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelIhtiyacHeader.Location = new System.Drawing.Point(10, 10);
            this.panelIhtiyacHeader.Name = "panelIhtiyacHeader";
            this.panelIhtiyacHeader.Size = new System.Drawing.Size(944, 40);
            this.panelIhtiyacHeader.TabIndex = 1;
            // 
            // btnDisaAktar
            // 
            this.btnDisaAktar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnDisaAktar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisaAktar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDisaAktar.ForeColor = System.Drawing.Color.White;
            this.btnDisaAktar.Location = new System.Drawing.Point(562, 3);
            this.btnDisaAktar.Name = "btnDisaAktar";
            this.btnDisaAktar.Size = new System.Drawing.Size(147, 31);
            this.btnDisaAktar.TabIndex = 0;
            this.btnDisaAktar.Text = "📊 Excel\'e Aktar";
            this.btnDisaAktar.UseVisualStyleBackColor = false;
            this.btnDisaAktar.Click += new System.EventHandler(this.btnDisaAktar_Click);
            // 
            // lblIhtiyacAnalizi
            // 
            this.lblIhtiyacAnalizi.AutoSize = true;
            this.lblIhtiyacAnalizi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblIhtiyacAnalizi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblIhtiyacAnalizi.Location = new System.Drawing.Point(0, 8);
            this.lblIhtiyacAnalizi.Name = "lblIhtiyacAnalizi";
            this.lblIhtiyacAnalizi.Size = new System.Drawing.Size(334, 20);
            this.lblIhtiyacAnalizi.TabIndex = 1;
            this.lblIhtiyacAnalizi.Text = "📋 Seçili Sipariş İçin Stok Analizi & İhtiyaç Listesi";
            // 
            // SiparisAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.panelKPI);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "SiparisAnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üretim Takip Sistemi v2.0";
            this.Load += new System.EventHandler(this.SiparisAnaForm_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelKPI.ResumeLayout(false);
            this.cardToday.ResumeLayout(false);
            this.cardPending.ResumeLayout(false);
            this.cardTotal.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panelGridTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).EndInit();
            this.panelSiparisFilter.ResumeLayout(false);
            this.panelSiparisFilter.PerformLayout();
            this.panelGridBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhtiyaclar)).EndInit();
            this.panelIhtiyacHeader.ResumeLayout(false);
            this.panelIhtiyacHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnExcelYukle;
        private System.Windows.Forms.Button btnSiparisDurum;
        private System.Windows.Forms.Button btnStokGuncelle;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel panelKPI;
        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Label lblKPITotal;
        private System.Windows.Forms.Label lblKPITotalVal;
        private System.Windows.Forms.Panel cardPending;
        private System.Windows.Forms.Label lblKPIPending;
        private System.Windows.Forms.Label lblKPIPendingVal;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panelGridTop;
        private System.Windows.Forms.DataGridView dgvSiparisler;
        private System.Windows.Forms.Panel panelSiparisFilter;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Label lblSiparisListesi;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.DateTimePicker dtBitis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtBaslangic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelGridBottom;
        private System.Windows.Forms.DataGridView dgvIhtiyaclar;
        private System.Windows.Forms.Panel panelIhtiyacHeader;
        private System.Windows.Forms.Label lblIhtiyacAnalizi;
        private System.Windows.Forms.Button btnDisaAktar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBitenSiparis;
        private System.Windows.Forms.Panel cardToday;
        private System.Windows.Forms.Label lblKPIToday;
        private System.Windows.Forms.Label lblKPITodayVal;
        private System.Windows.Forms.Button btnsiparis;
    }
}