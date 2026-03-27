namespace ÜretimTakipSistemi.Siparis
{
    partial class StokGuncelleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.panelIslemler = new System.Windows.Forms.Panel();
            this.groupBoxIslem = new System.Windows.Forms.GroupBox();
            this.numMiktar = new System.Windows.Forms.NumericUpDown();
            this.lblSeciliUrun = new System.Windows.Forms.Label();
            this.btnStokCikar = new System.Windows.Forms.Button();
            this.btnStokEkle = new System.Windows.Forms.Button();
            this.lblKritikUyari = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.panelIslemler.SuspendLayout();
            this.groupBoxIslem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMiktar)).BeginInit();
            this.SuspendLayout();

            // 
            // panelHeader (Üst Başlık Çubuğu)
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 60);
            this.panelHeader.TabIndex = 0;

            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(266, 30);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "STOK YÖNETİM EKRANI";

            // 
            // panelSearch (Arama Paneli)
            // 
            this.panelSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelSearch.Controls.Add(this.txtArama);
            this.panelSearch.Controls.Add(this.label1);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 60);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(900, 50);
            this.panelSearch.TabIndex = 1;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürün Ara : ";

            // 
            // txtArama
            // 
            this.txtArama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtArama.Location = new System.Drawing.Point(111, 12);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(300, 25);
            this.txtArama.TabIndex = 1;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);

            // 
            // panelIslemler (Sağ Taraf - İşlem Paneli)
            // 
            this.panelIslemler.BackColor = System.Drawing.Color.White;
            this.panelIslemler.Controls.Add(this.lblKritikUyari);
            this.panelIslemler.Controls.Add(this.groupBoxIslem);
            this.panelIslemler.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelIslemler.Location = new System.Drawing.Point(620, 110);
            this.panelIslemler.Name = "panelIslemler";
            this.panelIslemler.Padding = new System.Windows.Forms.Padding(10);
            this.panelIslemler.Size = new System.Drawing.Size(280, 490);
            this.panelIslemler.TabIndex = 3;

            // 
            // groupBoxIslem
            // 
            this.groupBoxIslem.Controls.Add(this.btnStokEkle);
            this.groupBoxIslem.Controls.Add(this.btnStokCikar);
            this.groupBoxIslem.Controls.Add(this.numMiktar);
            this.groupBoxIslem.Controls.Add(this.lblSeciliUrun);
            this.groupBoxIslem.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxIslem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxIslem.Location = new System.Drawing.Point(10, 10);
            this.groupBoxIslem.Name = "groupBoxIslem";
            this.groupBoxIslem.Size = new System.Drawing.Size(260, 250);
            this.groupBoxIslem.TabIndex = 0;
            this.groupBoxIslem.TabStop = false;
            this.groupBoxIslem.Text = "Hızlı Stok İşlemi";

            // 
            // lblSeciliUrun
            // 
            this.lblSeciliUrun.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSeciliUrun.ForeColor = System.Drawing.Color.DimGray;
            this.lblSeciliUrun.Location = new System.Drawing.Point(15, 30);
            this.lblSeciliUrun.Name = "lblSeciliUrun";
            this.lblSeciliUrun.Size = new System.Drawing.Size(230, 40);
            this.lblSeciliUrun.TabIndex = 0;
            this.lblSeciliUrun.Text = "Lütfen listeden bir ürün seçin...";

            // 
            // numMiktar
            // 
            this.numMiktar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.numMiktar.Location = new System.Drawing.Point(18, 80);
            this.numMiktar.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numMiktar.Name = "numMiktar";
            this.numMiktar.Size = new System.Drawing.Size(225, 32);
            this.numMiktar.TabIndex = 1;
            this.numMiktar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // btnStokEkle
            // 
            this.btnStokEkle.BackColor = System.Drawing.Color.SeaGreen;
            this.btnStokEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStokEkle.ForeColor = System.Drawing.Color.White;
            this.btnStokEkle.Location = new System.Drawing.Point(18, 130);
            this.btnStokEkle.Name = "btnStokEkle";
            this.btnStokEkle.Size = new System.Drawing.Size(225, 45);
            this.btnStokEkle.TabIndex = 2;
            this.btnStokEkle.Text = "+ STOK EKLE";
            this.btnStokEkle.UseVisualStyleBackColor = false;
            this.btnStokEkle.Click += new System.EventHandler(this.btnStokEkle_Click);

            // 
            // btnStokCikar
            // 
            this.btnStokCikar.BackColor = System.Drawing.Color.Firebrick;
            this.btnStokCikar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStokCikar.ForeColor = System.Drawing.Color.White;
            this.btnStokCikar.Location = new System.Drawing.Point(18, 185);
            this.btnStokCikar.Name = "btnStokCikar";
            this.btnStokCikar.Size = new System.Drawing.Size(225, 45);
            this.btnStokCikar.TabIndex = 3;
            this.btnStokCikar.Text = "- STOK DÜŞ";
            this.btnStokCikar.UseVisualStyleBackColor = false;
            this.btnStokCikar.Click += new System.EventHandler(this.btnStokCikar_Click);

            // 
            // lblKritikUyari
            // 
            this.lblKritikUyari.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKritikUyari.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblKritikUyari.ForeColor = System.Drawing.Color.Red;
            this.lblKritikUyari.Location = new System.Drawing.Point(10, 440);
            this.lblKritikUyari.Name = "lblKritikUyari";
            this.lblKritikUyari.Size = new System.Drawing.Size(260, 40);
            this.lblKritikUyari.TabIndex = 1;
            this.lblKritikUyari.Text = "* Kırmızı satırlar kritik stok seviyesini gösterir.";
            this.lblKritikUyari.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // dgvUrunler
            // 
            this.dgvUrunler.AllowUserToAddRows = false;
            this.dgvUrunler.AllowUserToDeleteRows = false;
            this.dgvUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUrunler.BackgroundColor = System.Drawing.Color.White;
            this.dgvUrunler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUrunler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUrunler.ColumnHeadersHeight = 40;
            this.dgvUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUrunler.EnableHeadersVisualStyles = false;
            this.dgvUrunler.GridColor = System.Drawing.Color.LightGray;
            this.dgvUrunler.Location = new System.Drawing.Point(0, 110);
            this.dgvUrunler.MultiSelect = false;
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.ReadOnly = true;
            this.dgvUrunler.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvUrunler.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUrunler.RowTemplate.Height = 35;
            this.dgvUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUrunler.Size = new System.Drawing.Size(620, 490);
            this.dgvUrunler.TabIndex = 2;
            this.dgvUrunler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUrunler_CellClick);
            this.dgvUrunler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvUrunler_DataBindingComplete);

            // 
            // StokGuncelleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.dgvUrunler);
            this.Controls.Add(this.panelIslemler);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelHeader);
            this.Name = "StokGuncelleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Yönetim Sistemi";
            this.Load += new System.EventHandler(this.StokGuncelleForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.panelIslemler.ResumeLayout(false);
            this.groupBoxIslem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMiktar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvUrunler;
        private System.Windows.Forms.Panel panelIslemler;
        private System.Windows.Forms.GroupBox groupBoxIslem;
        private System.Windows.Forms.Button btnStokEkle;
        private System.Windows.Forms.Button btnStokCikar;
        private System.Windows.Forms.NumericUpDown numMiktar;
        private System.Windows.Forms.Label lblSeciliUrun;
        private System.Windows.Forms.Label lblKritikUyari;
    }
}
