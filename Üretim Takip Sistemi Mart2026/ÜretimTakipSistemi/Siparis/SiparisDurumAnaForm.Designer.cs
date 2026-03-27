namespace ÜretimTakipSistemi.Siparis
{
    partial class SiparisDurumAnaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnAramayiTemizle = new System.Windows.Forms.Button();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.lblArama = new System.Windows.Forms.Label();
            this.btnYenile = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelBeklemede = new System.Windows.Forms.Panel();
            this.lblBeklemedeAdet = new System.Windows.Forms.Label();
            this.lblBeklemedeBaslik = new System.Windows.Forms.Label();
            this.panelUretimde = new System.Windows.Forms.Panel();
            this.lblUretimdeAdet = new System.Windows.Forms.Label();
            this.lblUretimdeBaslik = new System.Windows.Forms.Label();
            this.panelTamamlanan = new System.Windows.Forms.Panel();
            this.lblTamamlananAdet = new System.Windows.Forms.Label();
            this.lblTamamlananBaslik = new System.Windows.Forms.Label();
            this.panelToplam = new System.Windows.Forms.Panel();
            this.lblToplamAdet = new System.Windows.Forms.Label();
            this.lblToplamBaslik = new System.Windows.Forms.Label();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.dgvSiparisler = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.flowSteps = new System.Windows.Forms.FlowLayoutPanel();
            this.chartDurum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelRight = new System.Windows.Forms.Panel();
            this.gbIslemler = new System.Windows.Forms.GroupBox();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.btnNotEkle = new System.Windows.Forms.Button();
            this.btnDurumGuncelle = new System.Windows.Forms.Button();
            this.cmbYeniDurum = new System.Windows.Forms.ComboBox();
            this.lblYeniDurum = new System.Windows.Forms.Label();
            this.gbDetay = new System.Windows.Forms.GroupBox();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblMevcutDurum = new System.Windows.Forms.Label();
            this.lblAdet = new System.Windows.Forms.Label();
            this.lblParcaAdi = new System.Windows.Forms.Label();
            this.lblMusteriAdi = new System.Windows.Forms.Label();
            this.lblSiparisNo = new System.Windows.Forms.Label();
            this.btndrmgecmis = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelBeklemede.SuspendLayout();
            this.panelUretimde.SuspendLayout();
            this.panelTamamlanan.SuspendLayout();
            this.panelToplam.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDurum)).BeginInit();
            this.panelRight.SuspendLayout();
            this.gbIslemler.SuspendLayout();
            this.gbDetay.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.btnAramayiTemizle);
            this.panelHeader.Controls.Add(this.txtArama);
            this.panelHeader.Controls.Add(this.lblArama);
            this.panelHeader.Controls.Add(this.btnYenile);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1400, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // btnAramayiTemizle
            // 
            this.btnAramayiTemizle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAramayiTemizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnAramayiTemizle.FlatAppearance.BorderSize = 0;
            this.btnAramayiTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAramayiTemizle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAramayiTemizle.ForeColor = System.Drawing.Color.White;
            this.btnAramayiTemizle.Location = new System.Drawing.Point(1080, 22);
            this.btnAramayiTemizle.Name = "btnAramayiTemizle";
            this.btnAramayiTemizle.Size = new System.Drawing.Size(50, 27);
            this.btnAramayiTemizle.TabIndex = 4;
            this.btnAramayiTemizle.Text = "✕";
            this.btnAramayiTemizle.UseVisualStyleBackColor = false;
            this.btnAramayiTemizle.Click += new System.EventHandler(this.btnAramayiTemizle_Click);
            this.btnAramayiTemizle.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnAramayiTemizle.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // txtArama
            // 
            this.txtArama.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArama.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtArama.Location = new System.Drawing.Point(820, 22);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(250, 27);
            this.txtArama.TabIndex = 3;
            // 
            // lblArama
            // 
            this.lblArama.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArama.AutoSize = true;
            this.lblArama.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblArama.ForeColor = System.Drawing.Color.White;
            this.lblArama.Location = new System.Drawing.Point(700, 27);
            this.lblArama.Name = "lblArama";
            this.lblArama.Size = new System.Drawing.Size(119, 19);
            this.lblArama.TabIndex = 2;
            this.lblArama.Text = "🔍 Stok No Ara:";
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnYenile.FlatAppearance.BorderSize = 0;
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYenile.ForeColor = System.Drawing.Color.White;
            this.btnYenile.Location = new System.Drawing.Point(1250, 18);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(130, 35);
            this.btnYenile.TabIndex = 1;
            this.btnYenile.Text = "🔄 Yenile";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            this.btnYenile.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnYenile.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(403, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ÜRETİM VE SİPARİŞ TAKİP PANELİ";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelStats.Controls.Add(this.panelBeklemede);
            this.panelStats.Controls.Add(this.panelUretimde);
            this.panelStats.Controls.Add(this.panelTamamlanan);
            this.panelStats.Controls.Add(this.panelToplam);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 70);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelStats.Size = new System.Drawing.Size(1400, 110);
            this.panelStats.TabIndex = 1;
            // 
            // panelBeklemede
            // 
            this.panelBeklemede.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.panelBeklemede.Controls.Add(this.lblBeklemedeAdet);
            this.panelBeklemede.Controls.Add(this.lblBeklemedeBaslik);
            this.panelBeklemede.Location = new System.Drawing.Point(30, 20);
            this.panelBeklemede.Name = "panelBeklemede";
            this.panelBeklemede.Size = new System.Drawing.Size(200, 70);
            this.panelBeklemede.TabIndex = 0;
            // 
            // lblBeklemedeAdet
            // 
            this.lblBeklemedeAdet.AutoSize = true;
            this.lblBeklemedeAdet.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBeklemedeAdet.ForeColor = System.Drawing.Color.White;
            this.lblBeklemedeAdet.Location = new System.Drawing.Point(15, 35);
            this.lblBeklemedeAdet.Name = "lblBeklemedeAdet";
            this.lblBeklemedeAdet.Size = new System.Drawing.Size(29, 32);
            this.lblBeklemedeAdet.TabIndex = 1;
            this.lblBeklemedeAdet.Text = "0";
            // 
            // lblBeklemedeBaslik
            // 
            this.lblBeklemedeBaslik.AutoSize = true;
            this.lblBeklemedeBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBeklemedeBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBeklemedeBaslik.Location = new System.Drawing.Point(15, 12);
            this.lblBeklemedeBaslik.Name = "lblBeklemedeBaslik";
            this.lblBeklemedeBaslik.Size = new System.Drawing.Size(84, 19);
            this.lblBeklemedeBaslik.TabIndex = 0;
            this.lblBeklemedeBaslik.Text = "Beklemede";
            // 
            // panelUretimde
            // 
            this.panelUretimde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelUretimde.Controls.Add(this.lblUretimdeAdet);
            this.panelUretimde.Controls.Add(this.lblUretimdeBaslik);
            this.panelUretimde.Location = new System.Drawing.Point(280, 20);
            this.panelUretimde.Name = "panelUretimde";
            this.panelUretimde.Size = new System.Drawing.Size(200, 70);
            this.panelUretimde.TabIndex = 1;
            // 
            // lblUretimdeAdet
            // 
            this.lblUretimdeAdet.AutoSize = true;
            this.lblUretimdeAdet.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblUretimdeAdet.ForeColor = System.Drawing.Color.White;
            this.lblUretimdeAdet.Location = new System.Drawing.Point(15, 35);
            this.lblUretimdeAdet.Name = "lblUretimdeAdet";
            this.lblUretimdeAdet.Size = new System.Drawing.Size(29, 32);
            this.lblUretimdeAdet.TabIndex = 1;
            this.lblUretimdeAdet.Text = "0";
            // 
            // lblUretimdeBaslik
            // 
            this.lblUretimdeBaslik.AutoSize = true;
            this.lblUretimdeBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUretimdeBaslik.ForeColor = System.Drawing.Color.White;
            this.lblUretimdeBaslik.Location = new System.Drawing.Point(15, 12);
            this.lblUretimdeBaslik.Name = "lblUretimdeBaslik";
            this.lblUretimdeBaslik.Size = new System.Drawing.Size(72, 19);
            this.lblUretimdeBaslik.TabIndex = 0;
            this.lblUretimdeBaslik.Text = "Üretimde";
            // 
            // panelTamamlanan
            // 
            this.panelTamamlanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelTamamlanan.Controls.Add(this.lblTamamlananAdet);
            this.panelTamamlanan.Controls.Add(this.lblTamamlananBaslik);
            this.panelTamamlanan.Location = new System.Drawing.Point(530, 20);
            this.panelTamamlanan.Name = "panelTamamlanan";
            this.panelTamamlanan.Size = new System.Drawing.Size(200, 70);
            this.panelTamamlanan.TabIndex = 2;
            // 
            // lblTamamlananAdet
            // 
            this.lblTamamlananAdet.AutoSize = true;
            this.lblTamamlananAdet.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTamamlananAdet.ForeColor = System.Drawing.Color.White;
            this.lblTamamlananAdet.Location = new System.Drawing.Point(15, 35);
            this.lblTamamlananAdet.Name = "lblTamamlananAdet";
            this.lblTamamlananAdet.Size = new System.Drawing.Size(29, 32);
            this.lblTamamlananAdet.TabIndex = 1;
            this.lblTamamlananAdet.Text = "0";
            // 
            // lblTamamlananBaslik
            // 
            this.lblTamamlananBaslik.AutoSize = true;
            this.lblTamamlananBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTamamlananBaslik.ForeColor = System.Drawing.Color.White;
            this.lblTamamlananBaslik.Location = new System.Drawing.Point(15, 12);
            this.lblTamamlananBaslik.Name = "lblTamamlananBaslik";
            this.lblTamamlananBaslik.Size = new System.Drawing.Size(94, 19);
            this.lblTamamlananBaslik.TabIndex = 0;
            this.lblTamamlananBaslik.Text = "Tamamlanan";
            // 
            // panelToplam
            // 
            this.panelToplam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelToplam.Controls.Add(this.lblToplamAdet);
            this.panelToplam.Controls.Add(this.lblToplamBaslik);
            this.panelToplam.Location = new System.Drawing.Point(780, 20);
            this.panelToplam.Name = "panelToplam";
            this.panelToplam.Size = new System.Drawing.Size(200, 70);
            this.panelToplam.TabIndex = 3;
            // 
            // lblToplamAdet
            // 
            this.lblToplamAdet.AutoSize = true;
            this.lblToplamAdet.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblToplamAdet.ForeColor = System.Drawing.Color.White;
            this.lblToplamAdet.Location = new System.Drawing.Point(15, 35);
            this.lblToplamAdet.Name = "lblToplamAdet";
            this.lblToplamAdet.Size = new System.Drawing.Size(29, 32);
            this.lblToplamAdet.TabIndex = 1;
            this.lblToplamAdet.Text = "0";
            // 
            // lblToplamBaslik
            // 
            this.lblToplamBaslik.AutoSize = true;
            this.lblToplamBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblToplamBaslik.ForeColor = System.Drawing.Color.White;
            this.lblToplamBaslik.Location = new System.Drawing.Point(15, 12);
            this.lblToplamBaslik.Name = "lblToplamBaslik";
            this.lblToplamBaslik.Size = new System.Drawing.Size(108, 19);
            this.lblToplamBaslik.TabIndex = 0;
            this.lblToplamBaslik.Text = "Toplam Sipariş";
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.dgvSiparisler);
            this.panelCenter.Controls.Add(this.panelTop);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 180);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Padding = new System.Windows.Forms.Padding(20);
            this.panelCenter.Size = new System.Drawing.Size(1070, 620);
            this.panelCenter.TabIndex = 2;
            // 
            // dgvSiparisler
            // 
            this.dgvSiparisler.BackgroundColor = System.Drawing.Color.White;
            this.dgvSiparisler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSiparisler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiparisler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSiparisler.Location = new System.Drawing.Point(20, 220);
            this.dgvSiparisler.Name = "dgvSiparisler";
            this.dgvSiparisler.RowHeadersWidth = 51;
            this.dgvSiparisler.Size = new System.Drawing.Size(1030, 380);
            this.dgvSiparisler.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.flowSteps);
            this.panelTop.Controls.Add(this.chartDurum);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(20, 20);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1030, 200);
            this.panelTop.TabIndex = 0;
            // 
            // flowSteps
            // 
            this.flowSteps.BackColor = System.Drawing.Color.White;
            this.flowSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSteps.Location = new System.Drawing.Point(400, 0);
            this.flowSteps.Name = "flowSteps";
            this.flowSteps.Padding = new System.Windows.Forms.Padding(10);
            this.flowSteps.Size = new System.Drawing.Size(630, 200);
            this.flowSteps.TabIndex = 1;
            // 
            // chartDurum
            // 
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.Name = "ChartArea1";
            this.chartDurum.ChartAreas.Add(chartArea3);
            this.chartDurum.Dock = System.Windows.Forms.DockStyle.Left;
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend3.Name = "Legend1";
            this.chartDurum.Legends.Add(legend3);
            this.chartDurum.Location = new System.Drawing.Point(0, 0);
            this.chartDurum.Name = "chartDurum";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Legend = "Legend1";
            series3.Name = "Durumlar";
            this.chartDurum.Series.Add(series3);
            this.chartDurum.Size = new System.Drawing.Size(400, 200);
            this.chartDurum.TabIndex = 0;
            this.chartDurum.Text = "chartDurum";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelRight.Controls.Add(this.gbIslemler);
            this.panelRight.Controls.Add(this.gbDetay);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(1070, 180);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(10);
            this.panelRight.Size = new System.Drawing.Size(330, 620);
            this.panelRight.TabIndex = 3;
            // 
            // gbIslemler
            // 
            this.gbIslemler.BackColor = System.Drawing.Color.White;
            this.gbIslemler.Controls.Add(this.btndrmgecmis);
            this.gbIslemler.Controls.Add(this.btnYazdir);
            this.gbIslemler.Controls.Add(this.btnNotEkle);
            this.gbIslemler.Controls.Add(this.btnDurumGuncelle);
            this.gbIslemler.Controls.Add(this.cmbYeniDurum);
            this.gbIslemler.Controls.Add(this.lblYeniDurum);
            this.gbIslemler.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbIslemler.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbIslemler.Location = new System.Drawing.Point(10, 286);
            this.gbIslemler.Name = "gbIslemler";
            this.gbIslemler.Size = new System.Drawing.Size(310, 315);
            this.gbIslemler.TabIndex = 1;
            this.gbIslemler.TabStop = false;
            this.gbIslemler.Text = "⚙️ İşlemler";
            // 
            // btnYazdir
            // 
            this.btnYazdir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnYazdir.FlatAppearance.BorderSize = 0;
            this.btnYazdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYazdir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYazdir.ForeColor = System.Drawing.Color.White;
            this.btnYazdir.Location = new System.Drawing.Point(15, 264);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(280, 45);
            this.btnYazdir.TabIndex = 4;
            this.btnYazdir.Text = "🖨️ YAZDIR";
            this.btnYazdir.UseVisualStyleBackColor = false;
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            this.btnYazdir.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnYazdir.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // btnNotEkle
            // 
            this.btnNotEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnNotEkle.FlatAppearance.BorderSize = 0;
            this.btnNotEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotEkle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNotEkle.ForeColor = System.Drawing.Color.White;
            this.btnNotEkle.Location = new System.Drawing.Point(15, 160);
            this.btnNotEkle.Name = "btnNotEkle";
            this.btnNotEkle.Size = new System.Drawing.Size(280, 45);
            this.btnNotEkle.TabIndex = 3;
            this.btnNotEkle.Text = "📝 NOT EKLE";
            this.btnNotEkle.UseVisualStyleBackColor = false;
            this.btnNotEkle.Click += new System.EventHandler(this.btnNotEkle_Click);
            this.btnNotEkle.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnNotEkle.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // btnDurumGuncelle
            // 
            this.btnDurumGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnDurumGuncelle.FlatAppearance.BorderSize = 0;
            this.btnDurumGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDurumGuncelle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDurumGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnDurumGuncelle.Location = new System.Drawing.Point(15, 100);
            this.btnDurumGuncelle.Name = "btnDurumGuncelle";
            this.btnDurumGuncelle.Size = new System.Drawing.Size(280, 45);
            this.btnDurumGuncelle.TabIndex = 2;
            this.btnDurumGuncelle.Text = "✓ DURUMU GÜNCELLE";
            this.btnDurumGuncelle.UseVisualStyleBackColor = false;
            this.btnDurumGuncelle.Click += new System.EventHandler(this.btnDurumGuncelle_Click);
            this.btnDurumGuncelle.MouseEnter += new System.EventHandler(this.Btn_MouseEnter);
            this.btnDurumGuncelle.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            // 
            // cmbYeniDurum
            // 
            this.cmbYeniDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYeniDurum.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbYeniDurum.FormattingEnabled = true;
            this.cmbYeniDurum.Location = new System.Drawing.Point(15, 60);
            this.cmbYeniDurum.Name = "cmbYeniDurum";
            this.cmbYeniDurum.Size = new System.Drawing.Size(280, 23);
            this.cmbYeniDurum.TabIndex = 1;
            // 
            // lblYeniDurum
            // 
            this.lblYeniDurum.AutoSize = true;
            this.lblYeniDurum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblYeniDurum.Location = new System.Drawing.Point(15, 35);
            this.lblYeniDurum.Name = "lblYeniDurum";
            this.lblYeniDurum.Size = new System.Drawing.Size(98, 15);
            this.lblYeniDurum.TabIndex = 0;
            this.lblYeniDurum.Text = "Yeni Durum Seç:";
            // 
            // gbDetay
            // 
            this.gbDetay.BackColor = System.Drawing.Color.White;
            this.gbDetay.Controls.Add(this.lblTarih);
            this.gbDetay.Controls.Add(this.lblMevcutDurum);
            this.gbDetay.Controls.Add(this.lblAdet);
            this.gbDetay.Controls.Add(this.lblParcaAdi);
            this.gbDetay.Controls.Add(this.lblMusteriAdi);
            this.gbDetay.Controls.Add(this.lblSiparisNo);
            this.gbDetay.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDetay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbDetay.Location = new System.Drawing.Point(10, 10);
            this.gbDetay.Name = "gbDetay";
            this.gbDetay.Size = new System.Drawing.Size(310, 276);
            this.gbDetay.TabIndex = 0;
            this.gbDetay.TabStop = false;
            this.gbDetay.Text = "📋 Sipariş Detayları";
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTarih.ForeColor = System.Drawing.Color.Gray;
            this.lblTarih.Location = new System.Drawing.Point(15, 205);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(41, 13);
            this.lblTarih.TabIndex = 5;
            this.lblTarih.Text = "Kayıt: -";
            // 
            // lblMevcutDurum
            // 
            this.lblMevcutDurum.AutoSize = true;
            this.lblMevcutDurum.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMevcutDurum.Location = new System.Drawing.Point(15, 165);
            this.lblMevcutDurum.Name = "lblMevcutDurum";
            this.lblMevcutDurum.Size = new System.Drawing.Size(68, 19);
            this.lblMevcutDurum.TabIndex = 4;
            this.lblMevcutDurum.Text = "Durum: -";
            // 
            // lblAdet
            // 
            this.lblAdet.AutoSize = true;
            this.lblAdet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAdet.Location = new System.Drawing.Point(15, 135);
            this.lblAdet.Name = "lblAdet";
            this.lblAdet.Size = new System.Drawing.Size(43, 15);
            this.lblAdet.TabIndex = 3;
            this.lblAdet.Text = "Adet: -";
            // 
            // lblParcaAdi
            // 
            this.lblParcaAdi.AutoSize = true;
            this.lblParcaAdi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblParcaAdi.Location = new System.Drawing.Point(15, 95);
            this.lblParcaAdi.MaximumSize = new System.Drawing.Size(280, 0);
            this.lblParcaAdi.Name = "lblParcaAdi";
            this.lblParcaAdi.Size = new System.Drawing.Size(68, 15);
            this.lblParcaAdi.TabIndex = 2;
            this.lblParcaAdi.Text = "Parça Adı: -";
            // 
            // lblMusteriAdi
            // 
            this.lblMusteriAdi.AutoSize = true;
            this.lblMusteriAdi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMusteriAdi.Location = new System.Drawing.Point(15, 65);
            this.lblMusteriAdi.Name = "lblMusteriAdi";
            this.lblMusteriAdi.Size = new System.Drawing.Size(58, 15);
            this.lblMusteriAdi.TabIndex = 1;
            this.lblMusteriAdi.Text = "Müşteri: -";
            // 
            // lblSiparisNo
            // 
            this.lblSiparisNo.AutoSize = true;
            this.lblSiparisNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSiparisNo.Location = new System.Drawing.Point(15, 35);
            this.lblSiparisNo.Name = "lblSiparisNo";
            this.lblSiparisNo.Size = new System.Drawing.Size(71, 15);
            this.lblSiparisNo.TabIndex = 0;
            this.lblSiparisNo.Text = "Sipariş No: -";
            // 
            // btndrmgecmis
            // 
            this.btndrmgecmis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btndrmgecmis.FlatAppearance.BorderSize = 0;
            this.btndrmgecmis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndrmgecmis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btndrmgecmis.ForeColor = System.Drawing.Color.White;
            this.btndrmgecmis.Location = new System.Drawing.Point(15, 213);
            this.btndrmgecmis.Name = "btndrmgecmis";
            this.btndrmgecmis.Size = new System.Drawing.Size(280, 45);
            this.btndrmgecmis.TabIndex = 5;
            this.btndrmgecmis.Text = "📋 DURUM GEÇMİŞİ";
            this.btndrmgecmis.UseVisualStyleBackColor = false;
            this.btndrmgecmis.Click += new System.EventHandler(this.btndrmgecmis_Click);
            // 
            // SiparisDurumAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "SiparisDurumAnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üretim Takip Sistemi - Sipariş Durum Paneli";
            this.Load += new System.EventHandler(this.SiparisDurumAnaForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.panelBeklemede.ResumeLayout(false);
            this.panelBeklemede.PerformLayout();
            this.panelUretimde.ResumeLayout(false);
            this.panelUretimde.PerformLayout();
            this.panelTamamlanan.ResumeLayout(false);
            this.panelTamamlanan.PerformLayout();
            this.panelToplam.ResumeLayout(false);
            this.panelToplam.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDurum)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.gbIslemler.ResumeLayout(false);
            this.gbIslemler.PerformLayout();
            this.gbDetay.ResumeLayout(false);
            this.gbDetay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Label lblArama;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Button btnAramayiTemizle;

        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelBeklemede;
        private System.Windows.Forms.Label lblBeklemedeAdet;
        private System.Windows.Forms.Label lblBeklemedeBaslik;
        private System.Windows.Forms.Panel panelUretimde;
        private System.Windows.Forms.Label lblUretimdeAdet;
        private System.Windows.Forms.Label lblUretimdeBaslik;
        private System.Windows.Forms.Panel panelTamamlanan;
        private System.Windows.Forms.Label lblTamamlananAdet;
        private System.Windows.Forms.Label lblTamamlananBaslik;
        private System.Windows.Forms.Panel panelToplam;
        private System.Windows.Forms.Label lblToplamAdet;
        private System.Windows.Forms.Label lblToplamBaslik;

        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.FlowLayoutPanel flowSteps;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDurum;
        private System.Windows.Forms.DataGridView dgvSiparisler;

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox gbDetay;
        private System.Windows.Forms.Label lblSiparisNo;
        private System.Windows.Forms.Label lblMusteriAdi;
        private System.Windows.Forms.Label lblParcaAdi;
        private System.Windows.Forms.Label lblAdet;
        private System.Windows.Forms.Label lblMevcutDurum;
        private System.Windows.Forms.Label lblTarih;

        private System.Windows.Forms.GroupBox gbIslemler;
        private System.Windows.Forms.Label lblYeniDurum;
        private System.Windows.Forms.ComboBox cmbYeniDurum;
        private System.Windows.Forms.Button btnDurumGuncelle;
        private System.Windows.Forms.Button btnNotEkle;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.Button btndrmgecmis;
    }
}