namespace ÜretimTakipSistemi.Lazer
{
    partial class YeniUrunForm
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

        private void InitializeComponent()
        {
            this.lblUrunKodu = new System.Windows.Forms.Label();
            this.txtUrunKodu = new System.Windows.Forms.TextBox();
            this.lblUrunAdi = new System.Windows.Forms.Label();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.lblLazerTipi = new System.Windows.Forms.Label();
            this.cmbLazerTipi = new System.Windows.Forms.ComboBox();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.chkGrupluUrun = new System.Windows.Forms.CheckBox();
            this.pnlAnaUrun = new System.Windows.Forms.Panel();
            this.cmbProfilEbati = new System.Windows.Forms.ComboBox();
            this.lblProfilEbati = new System.Windows.Forms.Label();
            this.numUrunBoyu = new System.Windows.Forms.NumericUpDown();
            this.lblUrunBoyu = new System.Windows.Forms.Label();
            this.pnlAltUrunler = new System.Windows.Forms.Panel();
            this.btnAltUrunSil = new System.Windows.Forms.Button();
            this.btnAltUrunEkle = new System.Windows.Forms.Button();
            this.dgvAltUrunler = new System.Windows.Forms.DataGridView();
            // --- YENİ: Plaka Kalınlık Paneli ---
            this.pnlPlakaKalinlik = new System.Windows.Forms.Panel();
            this.numSacKalinligi = new System.Windows.Forms.NumericUpDown();
            this.lblSacKalinligi = new System.Windows.Forms.Label();
            // ------------------------------------
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.pnlAnaUrun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUrunBoyu)).BeginInit();
            this.pnlAltUrunler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAltUrunler)).BeginInit();
            this.pnlPlakaKalinlik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSacKalinligi)).BeginInit();
            this.SuspendLayout();

            // lblUrunKodu
            this.lblUrunKodu.AutoSize = true;
            this.lblUrunKodu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUrunKodu.Location = new System.Drawing.Point(20, 20);
            this.lblUrunKodu.Name = "lblUrunKodu";
            this.lblUrunKodu.Size = new System.Drawing.Size(84, 19);
            this.lblUrunKodu.TabIndex = 0;
            this.lblUrunKodu.Text = "Ürün Kodu:";

            // txtUrunKodu
            this.txtUrunKodu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUrunKodu.Location = new System.Drawing.Point(160, 17);
            this.txtUrunKodu.Name = "txtUrunKodu";
            this.txtUrunKodu.Size = new System.Drawing.Size(450, 25);
            this.txtUrunKodu.TabIndex = 1;

            // lblUrunAdi
            this.lblUrunAdi.AutoSize = true;
            this.lblUrunAdi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUrunAdi.Location = new System.Drawing.Point(20, 55);
            this.lblUrunAdi.Name = "lblUrunAdi";
            this.lblUrunAdi.Size = new System.Drawing.Size(72, 19);
            this.lblUrunAdi.TabIndex = 2;
            this.lblUrunAdi.Text = "Ürün Adı:";

            // txtUrunAdi
            this.txtUrunAdi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUrunAdi.Location = new System.Drawing.Point(160, 52);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(450, 25);
            this.txtUrunAdi.TabIndex = 3;

            // lblLazerTipi
            this.lblLazerTipi.AutoSize = true;
            this.lblLazerTipi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLazerTipi.Location = new System.Drawing.Point(20, 90);
            this.lblLazerTipi.Name = "lblLazerTipi";
            this.lblLazerTipi.Size = new System.Drawing.Size(78, 19);
            this.lblLazerTipi.TabIndex = 4;
            this.lblLazerTipi.Text = "Lazer Tipi:";

            // cmbLazerTipi
            this.cmbLazerTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLazerTipi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbLazerTipi.FormattingEnabled = true;
            this.cmbLazerTipi.Location = new System.Drawing.Point(160, 87);
            this.cmbLazerTipi.Name = "cmbLazerTipi";
            this.cmbLazerTipi.Size = new System.Drawing.Size(450, 25);
            this.cmbLazerTipi.TabIndex = 5;
            this.cmbLazerTipi.SelectedIndexChanged += new System.EventHandler(this.cmbLazerTipi_SelectedIndexChanged);

            // lblAciklama
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAciklama.Location = new System.Drawing.Point(20, 125);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(75, 19);
            this.lblAciklama.TabIndex = 6;
            this.lblAciklama.Text = "Açıklama:";

            // txtAciklama
            this.txtAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAciklama.Location = new System.Drawing.Point(160, 122);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(450, 60);
            this.txtAciklama.TabIndex = 7;

            // chkGrupluUrun
            this.chkGrupluUrun.AutoSize = true;
            this.chkGrupluUrun.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkGrupluUrun.Location = new System.Drawing.Point(160, 195);
            this.chkGrupluUrun.Name = "chkGrupluUrun";
            this.chkGrupluUrun.Size = new System.Drawing.Size(264, 23);
            this.chkGrupluUrun.TabIndex = 8;
            this.chkGrupluUrun.Text = "Gruplu Ürün (Alt ürünlerden oluşur)";
            this.chkGrupluUrun.UseVisualStyleBackColor = true;
            this.chkGrupluUrun.CheckedChanged += new System.EventHandler(this.chkGrupluUrun_CheckedChanged);

            // ── pnlAnaUrun (Boru - tek parça) ──
            this.pnlAnaUrun.BackColor = System.Drawing.Color.White;
            this.pnlAnaUrun.Controls.Add(this.cmbProfilEbati);
            this.pnlAnaUrun.Controls.Add(this.lblProfilEbati);
            this.pnlAnaUrun.Controls.Add(this.numUrunBoyu);
            this.pnlAnaUrun.Controls.Add(this.lblUrunBoyu);
            this.pnlAnaUrun.Location = new System.Drawing.Point(24, 230);
            this.pnlAnaUrun.Name = "pnlAnaUrun";
            this.pnlAnaUrun.Padding = new System.Windows.Forms.Padding(10);
            this.pnlAnaUrun.Size = new System.Drawing.Size(586, 90);
            this.pnlAnaUrun.TabIndex = 9;
            this.pnlAnaUrun.Visible = false;

            this.cmbProfilEbati.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProfilEbati.FormattingEnabled = true;
            this.cmbProfilEbati.Location = new System.Drawing.Point(136, 47);
            this.cmbProfilEbati.Name = "cmbProfilEbati";
            this.cmbProfilEbati.Size = new System.Drawing.Size(427, 25);
            this.cmbProfilEbati.TabIndex = 3;

            this.lblProfilEbati.AutoSize = true;
            this.lblProfilEbati.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProfilEbati.Location = new System.Drawing.Point(13, 50);
            this.lblProfilEbati.Name = "lblProfilEbati";
            this.lblProfilEbati.Size = new System.Drawing.Size(81, 17);
            this.lblProfilEbati.TabIndex = 2;
            this.lblProfilEbati.Text = "Profil Ebatı:";

            this.numUrunBoyu.DecimalPlaces = 2;
            this.numUrunBoyu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numUrunBoyu.Location = new System.Drawing.Point(136, 12);
            this.numUrunBoyu.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numUrunBoyu.Name = "numUrunBoyu";
            this.numUrunBoyu.Size = new System.Drawing.Size(427, 25);
            this.numUrunBoyu.TabIndex = 1;

            this.lblUrunBoyu.AutoSize = true;
            this.lblUrunBoyu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUrunBoyu.Location = new System.Drawing.Point(13, 15);
            this.lblUrunBoyu.Name = "lblUrunBoyu";
            this.lblUrunBoyu.Size = new System.Drawing.Size(115, 17);
            this.lblUrunBoyu.TabIndex = 0;
            this.lblUrunBoyu.Text = "Ürün Boyu (mm):";

            // ── pnlAltUrunler (Boru - gruplu) ──
            this.pnlAltUrunler.BackColor = System.Drawing.Color.White;
            this.pnlAltUrunler.Controls.Add(this.btnAltUrunSil);
            this.pnlAltUrunler.Controls.Add(this.btnAltUrunEkle);
            this.pnlAltUrunler.Controls.Add(this.dgvAltUrunler);
            this.pnlAltUrunler.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.pnlAltUrunler.Location = new System.Drawing.Point(24, 230);
            this.pnlAltUrunler.Name = "pnlAltUrunler";
            this.pnlAltUrunler.Padding = new System.Windows.Forms.Padding(10);
            this.pnlAltUrunler.Size = new System.Drawing.Size(586, 330);
            this.pnlAltUrunler.TabIndex = 10;
            this.pnlAltUrunler.Visible = false;

            this.btnAltUrunSil.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnAltUrunSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAltUrunSil.FlatAppearance.BorderSize = 0;
            this.btnAltUrunSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltUrunSil.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAltUrunSil.ForeColor = System.Drawing.Color.White;
            this.btnAltUrunSil.Location = new System.Drawing.Point(298, 279);
            this.btnAltUrunSil.Name = "btnAltUrunSil";
            this.btnAltUrunSil.Size = new System.Drawing.Size(275, 35);
            this.btnAltUrunSil.TabIndex = 2;
            this.btnAltUrunSil.Text = "🗑️ Seçili Alt Ürünü Sil";
            this.btnAltUrunSil.UseVisualStyleBackColor = false;
            this.btnAltUrunSil.Click += new System.EventHandler(this.btnAltUrunSil_Click);

            this.btnAltUrunEkle.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAltUrunEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAltUrunEkle.FlatAppearance.BorderSize = 0;
            this.btnAltUrunEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltUrunEkle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAltUrunEkle.ForeColor = System.Drawing.Color.White;
            this.btnAltUrunEkle.Location = new System.Drawing.Point(13, 279);
            this.btnAltUrunEkle.Name = "btnAltUrunEkle";
            this.btnAltUrunEkle.Size = new System.Drawing.Size(275, 35);
            this.btnAltUrunEkle.TabIndex = 1;
            this.btnAltUrunEkle.Text = "➕ Alt Ürün Ekle";
            this.btnAltUrunEkle.UseVisualStyleBackColor = false;
            this.btnAltUrunEkle.Click += new System.EventHandler(this.btnAltUrunEkle_Click);

            this.dgvAltUrunler.AllowUserToAddRows = false;
            this.dgvAltUrunler.BackgroundColor = System.Drawing.Color.White;
            this.dgvAltUrunler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAltUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAltUrunler.Location = new System.Drawing.Point(13, 13);
            this.dgvAltUrunler.Name = "dgvAltUrunler";
            this.dgvAltUrunler.ReadOnly = true;
            this.dgvAltUrunler.RowHeadersVisible = false;
            this.dgvAltUrunler.Size = new System.Drawing.Size(560, 260);
            this.dgvAltUrunler.TabIndex = 0;

            // ── pnlPlakaKalinlik (YENİ - Plaka seçilince görünür) ──
            this.pnlPlakaKalinlik.BackColor = System.Drawing.Color.White;
            this.pnlPlakaKalinlik.Controls.Add(this.numSacKalinligi);
            this.pnlPlakaKalinlik.Controls.Add(this.lblSacKalinligi);
            this.pnlPlakaKalinlik.Location = new System.Drawing.Point(24, 230);
            this.pnlPlakaKalinlik.Name = "pnlPlakaKalinlik";
            this.pnlPlakaKalinlik.Padding = new System.Windows.Forms.Padding(10);
            this.pnlPlakaKalinlik.Size = new System.Drawing.Size(586, 70);
            this.pnlPlakaKalinlik.TabIndex = 11;
            this.pnlPlakaKalinlik.Visible = false;

            this.lblSacKalinligi.AutoSize = true;
            this.lblSacKalinligi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSacKalinligi.Location = new System.Drawing.Point(13, 20);
            this.lblSacKalinligi.Name = "lblSacKalinligi";
            this.lblSacKalinligi.Text = "Sac Kalınlığı (mm):";
            this.lblSacKalinligi.TabIndex = 0;

            this.numSacKalinligi.DecimalPlaces = 1;
            this.numSacKalinligi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numSacKalinligi.Location = new System.Drawing.Point(170, 16);
            this.numSacKalinligi.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numSacKalinligi.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numSacKalinligi.Name = "numSacKalinligi";
            this.numSacKalinligi.Size = new System.Drawing.Size(200, 25);
            this.numSacKalinligi.TabIndex = 1;
            this.numSacKalinligi.Value = new decimal(new int[] { 3, 0, 0, 0 });
            this.numSacKalinligi.Increment = new decimal(new int[] { 5, 0, 0, 65536 }); // 0.5 artış

            // ── Kaydet / İptal ──
            this.btnKaydet.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(160, 580);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(220, 40);
            this.btnKaydet.TabIndex = 12;
            this.btnKaydet.Text = "✅ Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            this.btnIptal.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(390, 580);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(220, 40);
            this.btnIptal.TabIndex = 13;
            this.btnIptal.Text = "✗ İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);

            // ── YeniUrunForm ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 245);
            this.ClientSize = new System.Drawing.Size(634, 640);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.pnlAltUrunler);
            this.Controls.Add(this.pnlAnaUrun);
            this.Controls.Add(this.pnlPlakaKalinlik);  // YENİ
            this.Controls.Add(this.chkGrupluUrun);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.cmbLazerTipi);
            this.Controls.Add(this.lblLazerTipi);
            this.Controls.Add(this.txtUrunAdi);
            this.Controls.Add(this.lblUrunAdi);
            this.Controls.Add(this.txtUrunKodu);
            this.Controls.Add(this.lblUrunKodu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YeniUrunForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Ürün";
            this.Load += new System.EventHandler(this.YeniUrunForm_Load);
            this.pnlAnaUrun.ResumeLayout(false);
            this.pnlAnaUrun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUrunBoyu)).EndInit();
            this.pnlAltUrunler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAltUrunler)).EndInit();
            this.pnlPlakaKalinlik.ResumeLayout(false);
            this.pnlPlakaKalinlik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSacKalinligi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblUrunKodu;
        private System.Windows.Forms.TextBox txtUrunKodu;
        private System.Windows.Forms.Label lblUrunAdi;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.Label lblLazerTipi;
        private System.Windows.Forms.ComboBox cmbLazerTipi;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.CheckBox chkGrupluUrun;
        private System.Windows.Forms.Panel pnlAnaUrun;
        private System.Windows.Forms.Label lblUrunBoyu;
        private System.Windows.Forms.NumericUpDown numUrunBoyu;
        private System.Windows.Forms.Label lblProfilEbati;
        private System.Windows.Forms.ComboBox cmbProfilEbati;
        private System.Windows.Forms.Panel pnlAltUrunler;
        private System.Windows.Forms.DataGridView dgvAltUrunler;
        private System.Windows.Forms.Button btnAltUrunEkle;
        private System.Windows.Forms.Button btnAltUrunSil;
        // YENİ alanlar
        private System.Windows.Forms.Panel pnlPlakaKalinlik;
        private System.Windows.Forms.NumericUpDown numSacKalinligi;
        private System.Windows.Forms.Label lblSacKalinligi;
        // ---------
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
    }
}