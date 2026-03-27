namespace ÜretimTakipSistemi.Lazer
{
    partial class YeniSiparisForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpUrunListesi = new System.Windows.Forms.GroupBox();
            this.btnUrunDuzenle = new System.Windows.Forms.Button();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.dgvSiparisUrunler = new System.Windows.Forms.DataGridView();
            this.grpSiparisBilgi = new System.Windows.Forms.GroupBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSiparisNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpSiparisTarihi = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpUrunListesi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisUrunler)).BeginInit();
            this.grpSiparisBilgi.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(980, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(185, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "➕ YENİ SİPARİŞ";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpUrunListesi);
            this.pnlMain.Controls.Add(this.grpSiparisBilgi);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMain.Size = new System.Drawing.Size(980, 590);
            this.pnlMain.TabIndex = 1;
            // 
            // grpUrunListesi
            // 
            this.grpUrunListesi.Controls.Add(this.btnUrunDuzenle);
            this.grpUrunListesi.Controls.Add(this.btnUrunSil);
            this.grpUrunListesi.Controls.Add(this.btnUrunEkle);
            this.grpUrunListesi.Controls.Add(this.dgvSiparisUrunler);
            this.grpUrunListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUrunListesi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpUrunListesi.Location = new System.Drawing.Point(15, 215);
            this.grpUrunListesi.Name = "grpUrunListesi";
            this.grpUrunListesi.Padding = new System.Windows.Forms.Padding(10);
            this.grpUrunListesi.Size = new System.Drawing.Size(950, 360);
            this.grpUrunListesi.TabIndex = 1;
            this.grpUrunListesi.TabStop = false;
            this.grpUrunListesi.Text = "SİPARİŞ ÜRÜN LİSTESİ  (Teslim tarihini listede çift tıklayarak düzenleyebilirsiniz)";
            // 
            // btnUrunDuzenle
            // 
            this.btnUrunDuzenle.BackColor = System.Drawing.Color.FromArgb(240, 196, 15);
            this.btnUrunDuzenle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUrunDuzenle.FlatAppearance.BorderSize = 0;
            this.btnUrunDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunDuzenle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUrunDuzenle.ForeColor = System.Drawing.Color.White;
            this.btnUrunDuzenle.Location = new System.Drawing.Point(207, 305);
            this.btnUrunDuzenle.Name = "btnUrunDuzenle";
            this.btnUrunDuzenle.Size = new System.Drawing.Size(186, 45);
            this.btnUrunDuzenle.TabIndex = 3;
            this.btnUrunDuzenle.Text = "✏️ Seçili Ürünü Düzenle";
            this.btnUrunDuzenle.UseVisualStyleBackColor = false;
            this.btnUrunDuzenle.Click += new System.EventHandler(this.btnUrunDuzenle_Click);
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.BackColor = System.Drawing.Color.Red;
            this.btnUrunSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUrunSil.FlatAppearance.BorderSize = 0;
            this.btnUrunSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunSil.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUrunSil.ForeColor = System.Drawing.Color.White;
            this.btnUrunSil.Location = new System.Drawing.Point(399, 305);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(186, 45);
            this.btnUrunSil.TabIndex = 2;
            this.btnUrunSil.Text = "🗑️ Seçili Ürünü Sil";
            this.btnUrunSil.UseVisualStyleBackColor = false;
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnUrunEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUrunEkle.FlatAppearance.BorderSize = 0;
            this.btnUrunEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunEkle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUrunEkle.ForeColor = System.Drawing.Color.White;
            this.btnUrunEkle.Location = new System.Drawing.Point(15, 305);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(186, 45);
            this.btnUrunEkle.TabIndex = 1;
            this.btnUrunEkle.Text = "➕ Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = false;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // dgvSiparisUrunler
            // 
            this.dgvSiparisUrunler.AllowUserToAddRows = false;
            this.dgvSiparisUrunler.AllowUserToDeleteRows = false;
            this.dgvSiparisUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSiparisUrunler.BackgroundColor = System.Drawing.Color.White;
            this.dgvSiparisUrunler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSiparisUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiparisUrunler.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSiparisUrunler.Location = new System.Drawing.Point(10, 28);
            this.dgvSiparisUrunler.Name = "dgvSiparisUrunler";
            this.dgvSiparisUrunler.ReadOnly = false;
            this.dgvSiparisUrunler.RowHeadersVisible = false;
            this.dgvSiparisUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSiparisUrunler.Size = new System.Drawing.Size(930, 270);
            this.dgvSiparisUrunler.TabIndex = 0;
            // 
            // grpSiparisBilgi
            // 
            this.grpSiparisBilgi.Controls.Add(this.txtAciklama);
            this.grpSiparisBilgi.Controls.Add(this.label5);
            this.grpSiparisBilgi.Controls.Add(this.cmbMusteri);
            this.grpSiparisBilgi.Controls.Add(this.label3);
            this.grpSiparisBilgi.Controls.Add(this.txtSiparisNo);
            this.grpSiparisBilgi.Controls.Add(this.label2);
            this.grpSiparisBilgi.Controls.Add(this.dtpSiparisTarihi);
            this.grpSiparisBilgi.Controls.Add(this.label1);
            this.grpSiparisBilgi.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSiparisBilgi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpSiparisBilgi.Location = new System.Drawing.Point(15, 15);
            this.grpSiparisBilgi.Name = "grpSiparisBilgi";
            this.grpSiparisBilgi.Padding = new System.Windows.Forms.Padding(10);
            this.grpSiparisBilgi.Size = new System.Drawing.Size(950, 200);
            this.grpSiparisBilgi.TabIndex = 0;
            this.grpSiparisBilgi.TabStop = false;
            this.grpSiparisBilgi.Text = "SİPARİŞ BİLGİLERİ";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAciklama.Location = new System.Drawing.Point(450, 55);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(480, 120);
            this.txtAciklama.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(450, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Açıklama:";
            // 
            // cmbMusteri
            // 
            this.cmbMusteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusteri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMusteri.FormattingEnabled = true;
            this.cmbMusteri.Items.AddRange(new object[] { "KELEBEK", "AYD" });
            this.cmbMusteri.Location = new System.Drawing.Point(20, 105);
            this.cmbMusteri.Name = "cmbMusteri";
            this.cmbMusteri.Size = new System.Drawing.Size(373, 25);
            this.cmbMusteri.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(20, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Müşteri:";
            // 
            // txtSiparisNo
            // 
            this.txtSiparisNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSiparisNo.Location = new System.Drawing.Point(20, 55);
            this.txtSiparisNo.Name = "txtSiparisNo";
            this.txtSiparisNo.ReadOnly = true;
            this.txtSiparisNo.Size = new System.Drawing.Size(200, 25);
            this.txtSiparisNo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(20, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sipariş No:";
            // 
            // dtpSiparisTarihi
            // 
            this.dtpSiparisTarihi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpSiparisTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSiparisTarihi.Location = new System.Drawing.Point(20, 150);
            this.dtpSiparisTarihi.Name = "dtpSiparisTarihi";
            this.dtpSiparisTarihi.Size = new System.Drawing.Size(200, 25);
            this.dtpSiparisTarihi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(20, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sipariş Tarihi:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnIptal);
            this.pnlButtons.Controls.Add(this.btnKaydet);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 650);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.pnlButtons.Size = new System.Drawing.Size(980, 70);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(795, 13);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(170, 45);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "✗ İPTAL";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(619, 13);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(170, 45);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "💾 KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // YeniSiparisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(980, 720);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YeniSiparisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Sipariş Ekle";
            this.Load += new System.EventHandler(this.YeniSiparisForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.grpUrunListesi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisUrunler)).EndInit();
            this.grpSiparisBilgi.ResumeLayout(false);
            this.grpSiparisBilgi.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpSiparisBilgi;
        private System.Windows.Forms.TextBox txtSiparisNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpSiparisTarihi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpUrunListesi;
        private System.Windows.Forms.DataGridView dgvSiparisUrunler;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.ComboBox cmbMusteri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.Button btnUrunDuzenle;
    }
}