namespace ÜretimTakipSistemi.Lazer
{
    partial class SiparisDetayForm
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
            this.pnlBaslik = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.grpSiparisBilgi = new System.Windows.Forms.GroupBox();
            this.lblAciklamaDeger = new System.Windows.Forms.Label();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.lblDurumDeger = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.lblTeslimTarihiDeger = new System.Windows.Forms.Label();
            this.lblTeslimTarihi = new System.Windows.Forms.Label();
            this.lblSiparisTarihiDeger = new System.Windows.Forms.Label();
            this.lblSiparisTarihi = new System.Windows.Forms.Label();
            this.lblMusteriDeger = new System.Windows.Forms.Label();
            this.lblMusteri = new System.Windows.Forms.Label();
            this.lblSiparisNoDeger = new System.Windows.Forms.Label();
            this.lblSiparisNo = new System.Windows.Forms.Label();
            this.grpDetaylar = new System.Windows.Forms.GroupBox();
            this.dgvDetaylar = new System.Windows.Forms.DataGridView();
            this.pnlIstatistikler = new System.Windows.Forms.Panel();
            this.lblGenelTamamlanma = new System.Windows.Forms.Label();
            this.lblToplamKalan = new System.Windows.Forms.Label();
            this.lblToplamUretilen = new System.Windows.Forms.Label();
            this.lblToplamSiparis = new System.Windows.Forms.Label();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnProfilOptimizasyonu = new System.Windows.Forms.Button();
            this.btnIsciRaporu = new System.Windows.Forms.Button();
            this.btnUretimGuncelle = new System.Windows.Forms.Button();
            this.pnlBaslik.SuspendLayout();
            this.grpSiparisBilgi.SuspendLayout();
            this.grpDetaylar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetaylar)).BeginInit();
            this.pnlIstatistikler.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBaslik
            // 
            this.pnlBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlBaslik.Controls.Add(this.lblBaslik);
            this.pnlBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBaslik.Location = new System.Drawing.Point(0, 0);
            this.pnlBaslik.Name = "pnlBaslik";
            this.pnlBaslik.Size = new System.Drawing.Size(884, 60);
            this.pnlBaslik.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(15, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(351, 30);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "📋 Sipariş Detay ve Üretim Takip";
            // 
            // grpSiparisBilgi
            // 
            this.grpSiparisBilgi.BackColor = System.Drawing.Color.White;
            this.grpSiparisBilgi.Controls.Add(this.lblAciklamaDeger);
            this.grpSiparisBilgi.Controls.Add(this.lblAciklama);
            this.grpSiparisBilgi.Controls.Add(this.lblDurumDeger);
            this.grpSiparisBilgi.Controls.Add(this.lblDurum);
            this.grpSiparisBilgi.Controls.Add(this.lblTeslimTarihiDeger);
            this.grpSiparisBilgi.Controls.Add(this.lblTeslimTarihi);
            this.grpSiparisBilgi.Controls.Add(this.lblSiparisTarihiDeger);
            this.grpSiparisBilgi.Controls.Add(this.lblSiparisTarihi);
            this.grpSiparisBilgi.Controls.Add(this.lblMusteriDeger);
            this.grpSiparisBilgi.Controls.Add(this.lblMusteri);
            this.grpSiparisBilgi.Controls.Add(this.lblSiparisNoDeger);
            this.grpSiparisBilgi.Controls.Add(this.lblSiparisNo);
            this.grpSiparisBilgi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpSiparisBilgi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpSiparisBilgi.Location = new System.Drawing.Point(12, 73);
            this.grpSiparisBilgi.Name = "grpSiparisBilgi";
            this.grpSiparisBilgi.Padding = new System.Windows.Forms.Padding(15);
            this.grpSiparisBilgi.Size = new System.Drawing.Size(860, 170);
            this.grpSiparisBilgi.TabIndex = 1;
            this.grpSiparisBilgi.TabStop = false;
            this.grpSiparisBilgi.Text = "Sipariş Bilgileri";
            // 
            // lblAciklamaDeger
            // 
            this.lblAciklamaDeger.AutoSize = true;
            this.lblAciklamaDeger.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAciklamaDeger.Location = new System.Drawing.Point(165, 125);
            this.lblAciklamaDeger.Name = "lblAciklamaDeger";
            this.lblAciklamaDeger.Size = new System.Drawing.Size(13, 17);
            this.lblAciklamaDeger.TabIndex = 11;
            this.lblAciklamaDeger.Text = "-";
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAciklama.Location = new System.Drawing.Point(18, 125);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(68, 17);
            this.lblAciklama.TabIndex = 10;
            this.lblAciklama.Text = "Açıklama:";
            // 
            // lblDurumDeger
            // 
            this.lblDurumDeger.AutoSize = true;
            this.lblDurumDeger.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDurumDeger.Location = new System.Drawing.Point(600, 75);
            this.lblDurumDeger.Name = "lblDurumDeger";
            this.lblDurumDeger.Size = new System.Drawing.Size(13, 17);
            this.lblDurumDeger.TabIndex = 9;
            this.lblDurumDeger.Text = "-";
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDurum.Location = new System.Drawing.Point(453, 75);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(55, 17);
            this.lblDurum.TabIndex = 8;
            this.lblDurum.Text = "Durum:";
            // 
            // lblTeslimTarihiDeger
            // 
            this.lblTeslimTarihiDeger.AutoSize = true;
            this.lblTeslimTarihiDeger.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTeslimTarihiDeger.Location = new System.Drawing.Point(165, 75);
            this.lblTeslimTarihiDeger.Name = "lblTeslimTarihiDeger";
            this.lblTeslimTarihiDeger.Size = new System.Drawing.Size(13, 17);
            this.lblTeslimTarihiDeger.TabIndex = 7;
            this.lblTeslimTarihiDeger.Text = "-";
            // 
            // lblTeslimTarihi
            // 
            this.lblTeslimTarihi.AutoSize = true;
            this.lblTeslimTarihi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTeslimTarihi.Location = new System.Drawing.Point(18, 75);
            this.lblTeslimTarihi.Name = "lblTeslimTarihi";
            this.lblTeslimTarihi.Size = new System.Drawing.Size(91, 17);
            this.lblTeslimTarihi.TabIndex = 6;
            this.lblTeslimTarihi.Text = "Teslim Tarihi:";
            // 
            // lblSiparisTarihiDeger
            // 
            this.lblSiparisTarihiDeger.AutoSize = true;
            this.lblSiparisTarihiDeger.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSiparisTarihiDeger.Location = new System.Drawing.Point(600, 40);
            this.lblSiparisTarihiDeger.Name = "lblSiparisTarihiDeger";
            this.lblSiparisTarihiDeger.Size = new System.Drawing.Size(13, 17);
            this.lblSiparisTarihiDeger.TabIndex = 5;
            this.lblSiparisTarihiDeger.Text = "-";
            // 
            // lblSiparisTarihi
            // 
            this.lblSiparisTarihi.AutoSize = true;
            this.lblSiparisTarihi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSiparisTarihi.Location = new System.Drawing.Point(453, 40);
            this.lblSiparisTarihi.Name = "lblSiparisTarihi";
            this.lblSiparisTarihi.Size = new System.Drawing.Size(92, 17);
            this.lblSiparisTarihi.TabIndex = 4;
            this.lblSiparisTarihi.Text = "Sipariş Tarihi:";
            // 
            // lblMusteriDeger
            // 
            this.lblMusteriDeger.AutoSize = true;
            this.lblMusteriDeger.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMusteriDeger.Location = new System.Drawing.Point(165, 40);
            this.lblMusteriDeger.Name = "lblMusteriDeger";
            this.lblMusteriDeger.Size = new System.Drawing.Size(13, 17);
            this.lblMusteriDeger.TabIndex = 3;
            this.lblMusteriDeger.Text = "-";
            // 
            // lblMusteri
            // 
            this.lblMusteri.AutoSize = true;
            this.lblMusteri.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMusteri.Location = new System.Drawing.Point(18, 40);
            this.lblMusteri.Name = "lblMusteri";
            this.lblMusteri.Size = new System.Drawing.Size(59, 17);
            this.lblMusteri.TabIndex = 2;
            this.lblMusteri.Text = "Müşteri:";
            // 
            // lblSiparisNoDeger
            // 
            this.lblSiparisNoDeger.AutoSize = true;
            this.lblSiparisNoDeger.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSiparisNoDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblSiparisNoDeger.Location = new System.Drawing.Point(600, 105);
            this.lblSiparisNoDeger.Name = "lblSiparisNoDeger";
            this.lblSiparisNoDeger.Size = new System.Drawing.Size(15, 20);
            this.lblSiparisNoDeger.TabIndex = 1;
            this.lblSiparisNoDeger.Text = "-";
            // 
            // lblSiparisNo
            // 
            this.lblSiparisNo.AutoSize = true;
            this.lblSiparisNo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSiparisNo.Location = new System.Drawing.Point(453, 105);
            this.lblSiparisNo.Name = "lblSiparisNo";
            this.lblSiparisNo.Size = new System.Drawing.Size(84, 20);
            this.lblSiparisNo.TabIndex = 0;
            this.lblSiparisNo.Text = "Sipariş No:";
            // 
            // grpDetaylar
            // 
            this.grpDetaylar.BackColor = System.Drawing.Color.White;
            this.grpDetaylar.Controls.Add(this.dgvDetaylar);
            this.grpDetaylar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDetaylar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpDetaylar.Location = new System.Drawing.Point(12, 255);
            this.grpDetaylar.Name = "grpDetaylar";
            this.grpDetaylar.Padding = new System.Windows.Forms.Padding(15);
            this.grpDetaylar.Size = new System.Drawing.Size(860, 280);
            this.grpDetaylar.TabIndex = 2;
            this.grpDetaylar.TabStop = false;
            this.grpDetaylar.Text = "Sipariş Ürünleri ve Üretim Durumu";
            // 
            // dgvDetaylar
            // 
            this.dgvDetaylar.AllowUserToAddRows = false;
            this.dgvDetaylar.AllowUserToDeleteRows = false;
            this.dgvDetaylar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetaylar.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetaylar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetaylar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetaylar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetaylar.Location = new System.Drawing.Point(15, 33);
            this.dgvDetaylar.Name = "dgvDetaylar";
            this.dgvDetaylar.ReadOnly = true;
            this.dgvDetaylar.RowHeadersVisible = false;
            this.dgvDetaylar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetaylar.Size = new System.Drawing.Size(830, 232);
            this.dgvDetaylar.TabIndex = 0;
            this.dgvDetaylar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetaylar_CellDoubleClick);
            // 
            // pnlIstatistikler
            // 
            this.pnlIstatistikler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlIstatistikler.Controls.Add(this.lblGenelTamamlanma);
            this.pnlIstatistikler.Controls.Add(this.lblToplamKalan);
            this.pnlIstatistikler.Controls.Add(this.lblToplamUretilen);
            this.pnlIstatistikler.Controls.Add(this.lblToplamSiparis);
            this.pnlIstatistikler.Location = new System.Drawing.Point(12, 545);
            this.pnlIstatistikler.Name = "pnlIstatistikler";
            this.pnlIstatistikler.Padding = new System.Windows.Forms.Padding(15);
            this.pnlIstatistikler.Size = new System.Drawing.Size(860, 80);
            this.pnlIstatistikler.TabIndex = 3;
            // 
            // lblGenelTamamlanma
            // 
            this.lblGenelTamamlanma.AutoSize = true;
            this.lblGenelTamamlanma.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblGenelTamamlanma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblGenelTamamlanma.Location = new System.Drawing.Point(18, 45);
            this.lblGenelTamamlanma.Name = "lblGenelTamamlanma";
            this.lblGenelTamamlanma.Size = new System.Drawing.Size(238, 25);
            this.lblGenelTamamlanma.TabIndex = 3;
            this.lblGenelTamamlanma.Text = "Genel Tamamlanma: %0.0";
            // 
            // lblToplamKalan
            // 
            this.lblToplamKalan.AutoSize = true;
            this.lblToplamKalan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblToplamKalan.ForeColor = System.Drawing.Color.Red;
            this.lblToplamKalan.Location = new System.Drawing.Point(653, 15);
            this.lblToplamKalan.Name = "lblToplamKalan";
            this.lblToplamKalan.Size = new System.Drawing.Size(156, 20);
            this.lblToplamKalan.TabIndex = 2;
            this.lblToplamKalan.Text = "Toplam Kalan: 0 adet";
            // 
            // lblToplamUretilen
            // 
            this.lblToplamUretilen.AutoSize = true;
            this.lblToplamUretilen.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblToplamUretilen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblToplamUretilen.Location = new System.Drawing.Point(410, 15);
            this.lblToplamUretilen.Name = "lblToplamUretilen";
            this.lblToplamUretilen.Size = new System.Drawing.Size(173, 20);
            this.lblToplamUretilen.TabIndex = 1;
            this.lblToplamUretilen.Text = "Toplam Üretilen: 0 adet";
            // 
            // lblToplamSiparis
            // 
            this.lblToplamSiparis.AutoSize = true;
            this.lblToplamSiparis.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblToplamSiparis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblToplamSiparis.Location = new System.Drawing.Point(18, 15);
            this.lblToplamSiparis.Name = "lblToplamSiparis";
            this.lblToplamSiparis.Size = new System.Drawing.Size(163, 20);
            this.lblToplamSiparis.TabIndex = 0;
            this.lblToplamSiparis.Text = "Toplam Sipariş: 0 adet";
            // 
            // btnKapat
            // 
            this.btnKapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Location = new System.Drawing.Point(727, 640);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(145, 40);
            this.btnKapat.TabIndex = 4;
            this.btnKapat.Text = "✗ Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnProfilOptimizasyonu
            // 
            this.btnProfilOptimizasyonu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnProfilOptimizasyonu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfilOptimizasyonu.FlatAppearance.BorderSize = 0;
            this.btnProfilOptimizasyonu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfilOptimizasyonu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProfilOptimizasyonu.ForeColor = System.Drawing.Color.White;
            this.btnProfilOptimizasyonu.Location = new System.Drawing.Point(200, 640);
            this.btnProfilOptimizasyonu.Name = "btnProfilOptimizasyonu";
            this.btnProfilOptimizasyonu.Size = new System.Drawing.Size(182, 40);
            this.btnProfilOptimizasyonu.TabIndex = 5;
            this.btnProfilOptimizasyonu.Text = "🔧 Profil Optimizasyonu";
            this.btnProfilOptimizasyonu.UseVisualStyleBackColor = false;
            this.btnProfilOptimizasyonu.Click += new System.EventHandler(this.btnProfilOptimizasyonu_Click);
            // 
            // btnIsciRaporu
            // 
            this.btnIsciRaporu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnIsciRaporu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIsciRaporu.FlatAppearance.BorderSize = 0;
            this.btnIsciRaporu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIsciRaporu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIsciRaporu.ForeColor = System.Drawing.Color.White;
            this.btnIsciRaporu.Location = new System.Drawing.Point(388, 640);
            this.btnIsciRaporu.Name = "btnIsciRaporu";
            this.btnIsciRaporu.Size = new System.Drawing.Size(182, 40);
            this.btnIsciRaporu.TabIndex = 7;
            this.btnIsciRaporu.Text = "📄 İşçi Üretim Raporu";
            this.btnIsciRaporu.UseVisualStyleBackColor = false;
            this.btnIsciRaporu.Click += new System.EventHandler(this.btnIsciRaporu_Click);
            // 
            // btnUretimGuncelle
            // 
            this.btnUretimGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnUretimGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUretimGuncelle.FlatAppearance.BorderSize = 0;
            this.btnUretimGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUretimGuncelle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUretimGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnUretimGuncelle.Location = new System.Drawing.Point(12, 640);
            this.btnUretimGuncelle.Name = "btnUretimGuncelle";
            this.btnUretimGuncelle.Size = new System.Drawing.Size(182, 40);
            this.btnUretimGuncelle.TabIndex = 6;
            this.btnUretimGuncelle.Text = "✏️ Üretim Güncelle";
            this.btnUretimGuncelle.UseVisualStyleBackColor = false;
            this.btnUretimGuncelle.Click += new System.EventHandler(this.btnUretimGuncelle_Click);
            // 
            // SiparisDetayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(884, 695);
            this.Controls.Add(this.btnUretimGuncelle);
            this.Controls.Add(this.btnProfilOptimizasyonu);
            this.Controls.Add(this.btnIsciRaporu);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.pnlIstatistikler);
            this.Controls.Add(this.grpDetaylar);
            this.Controls.Add(this.grpSiparisBilgi);
            this.Controls.Add(this.pnlBaslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SiparisDetayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sipariş Detayları ve Üretim Takip";
            this.Load += new System.EventHandler(this.SiparisDetayForm_Load);
            this.pnlBaslik.ResumeLayout(false);
            this.pnlBaslik.PerformLayout();
            this.grpSiparisBilgi.ResumeLayout(false);
            this.grpSiparisBilgi.PerformLayout();
            this.grpDetaylar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetaylar)).EndInit();
            this.pnlIstatistikler.ResumeLayout(false);
            this.pnlIstatistikler.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlBaslik;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.GroupBox grpSiparisBilgi;
        private System.Windows.Forms.Label lblSiparisNo;
        private System.Windows.Forms.Label lblSiparisNoDeger;
        private System.Windows.Forms.Label lblMusteri;
        private System.Windows.Forms.Label lblMusteriDeger;
        private System.Windows.Forms.Label lblSiparisTarihi;
        private System.Windows.Forms.Label lblSiparisTarihiDeger;
        private System.Windows.Forms.Label lblTeslimTarihi;
        private System.Windows.Forms.Label lblTeslimTarihiDeger;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Label lblDurumDeger;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.Label lblAciklamaDeger;
        private System.Windows.Forms.GroupBox grpDetaylar;
        private System.Windows.Forms.DataGridView dgvDetaylar;
        private System.Windows.Forms.Panel pnlIstatistikler;
        private System.Windows.Forms.Label lblToplamSiparis;
        private System.Windows.Forms.Label lblToplamUretilen;
        private System.Windows.Forms.Label lblToplamKalan;
        private System.Windows.Forms.Label lblGenelTamamlanma;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnProfilOptimizasyonu;
        private System.Windows.Forms.Button btnIsciRaporu;
        private System.Windows.Forms.Button btnUretimGuncelle;
    }
}