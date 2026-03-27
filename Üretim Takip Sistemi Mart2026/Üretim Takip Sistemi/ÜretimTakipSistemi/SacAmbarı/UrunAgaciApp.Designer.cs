namespace ÜretimTakipSistemi.SacAmbarı
{
    partial class UrunAgaciApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // TREEVIEW ve PANEL
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.SplitContainer splitContainer1;

        // BUTONLAR
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Button btnTestVerisiEkle;
        private System.Windows.Forms.Button btnTumunuAc;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button Bul_Btn;

        // DİĞER KONTROLLER
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtUrunDetay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTop;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.Gecis_Btn = new System.Windows.Forms.Button();
            this.btnMaliyetAc = new System.Windows.Forms.Button();
            this.UrunSil_Btn = new System.Windows.Forms.Button();
            this.Bul_Btn = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.btnTumunuAc = new System.Windows.Forms.Button();
            this.btnTestVerisiEkle = new System.Windows.Forms.Button();
            this.btnYenile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.txtUrunDetay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExcelAktar = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.treeView1.FullRowSelect = true;
            this.treeView1.HotTracking = true;
            this.treeView1.Indent = 20;
            this.treeView1.ItemHeight = 28;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(575, 685);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelTop.Controls.Add(this.btnExcelAktar);
            this.panelTop.Controls.Add(this.Gecis_Btn);
            this.panelTop.Controls.Add(this.btnMaliyetAc);
            this.panelTop.Controls.Add(this.UrunSil_Btn);
            this.panelTop.Controls.Add(this.Bul_Btn);
            this.panelTop.Controls.Add(this.lblStatus);
            this.panelTop.Controls.Add(this.btnCikis);
            this.panelTop.Controls.Add(this.btnUrunEkle);
            this.panelTop.Controls.Add(this.btnTumunuAc);
            this.panelTop.Controls.Add(this.btnTestVerisiEkle);
            this.panelTop.Controls.Add(this.btnYenile);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1236, 60);
            this.panelTop.TabIndex = 1;
            // 
            // Gecis_Btn
            // 
            this.Gecis_Btn.BackColor = System.Drawing.Color.CadetBlue;
            this.Gecis_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gecis_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)), true);
            this.Gecis_Btn.ForeColor = System.Drawing.Color.White;
            this.Gecis_Btn.Location = new System.Drawing.Point(137, 7);
            this.Gecis_Btn.Name = "Gecis_Btn";
            this.Gecis_Btn.Size = new System.Drawing.Size(196, 34);
            this.Gecis_Btn.TabIndex = 11;
            this.Gecis_Btn.Text = "Tüm Ürünleri Göster";
            this.Gecis_Btn.UseVisualStyleBackColor = false;
            this.Gecis_Btn.Click += new System.EventHandler(this.Gecis_Btn_Click);
            // 
            // btnMaliyetAc
            // 
            this.btnMaliyetAc.BackColor = System.Drawing.Color.CadetBlue;
            this.btnMaliyetAc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaliyetAc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)), true);
            this.btnMaliyetAc.ForeColor = System.Drawing.Color.White;
            this.btnMaliyetAc.Location = new System.Drawing.Point(982, 7);
            this.btnMaliyetAc.Name = "btnMaliyetAc";
            this.btnMaliyetAc.Size = new System.Drawing.Size(83, 34);
            this.btnMaliyetAc.TabIndex = 10;
            this.btnMaliyetAc.Text = "Maliyet Hesapla";
            this.btnMaliyetAc.UseVisualStyleBackColor = false;
            this.btnMaliyetAc.Click += new System.EventHandler(this.btnMaliyetAc_Click);
            // 
            // UrunSil_Btn
            // 
            this.UrunSil_Btn.BackColor = System.Drawing.Color.CadetBlue;
            this.UrunSil_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UrunSil_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UrunSil_Btn.ForeColor = System.Drawing.Color.White;
            this.UrunSil_Btn.Location = new System.Drawing.Point(704, 7);
            this.UrunSil_Btn.Name = "UrunSil_Btn";
            this.UrunSil_Btn.Size = new System.Drawing.Size(91, 34);
            this.UrunSil_Btn.TabIndex = 9;
            this.UrunSil_Btn.Text = "Ürün Sil";
            this.UrunSil_Btn.UseVisualStyleBackColor = false;
            this.UrunSil_Btn.Click += new System.EventHandler(this.UrunSil_Btn_Click);
            // 
            // Bul_Btn
            // 
            this.Bul_Btn.BackColor = System.Drawing.Color.CadetBlue;
            this.Bul_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bul_Btn.FlatAppearance.BorderSize = 0;
            this.Bul_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bul_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Bul_Btn.ForeColor = System.Drawing.Color.White;
            this.Bul_Btn.Location = new System.Drawing.Point(493, 7);
            this.Bul_Btn.Name = "Bul_Btn";
            this.Bul_Btn.Size = new System.Drawing.Size(88, 34);
            this.Bul_Btn.TabIndex = 8;
            this.Bul_Btn.Text = "Ürün Bul";
            this.Bul_Btn.UseVisualStyleBackColor = false;
            this.Bul_Btn.Click += new System.EventHandler(this.Bul_Btn_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(13, 42);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 18);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Durum";
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.Red;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)), true);
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(907, 7);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(69, 34);
            this.btnCikis.TabIndex = 6;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.BackColor = System.Drawing.Color.CadetBlue;
            this.btnUrunEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrunEkle.ForeColor = System.Drawing.Color.White;
            this.btnUrunEkle.Location = new System.Drawing.Point(588, 7);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(110, 34);
            this.btnUrunEkle.TabIndex = 5;
            this.btnUrunEkle.Text = "Yeni Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = false;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // btnTumunuAc
            // 
            this.btnTumunuAc.BackColor = System.Drawing.Color.CadetBlue;
            this.btnTumunuAc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTumunuAc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTumunuAc.ForeColor = System.Drawing.Color.White;
            this.btnTumunuAc.Location = new System.Drawing.Point(339, 7);
            this.btnTumunuAc.Name = "btnTumunuAc";
            this.btnTumunuAc.Size = new System.Drawing.Size(148, 34);
            this.btnTumunuAc.TabIndex = 3;
            this.btnTumunuAc.Text = "Tümünü Genişlet ▼";
            this.btnTumunuAc.UseVisualStyleBackColor = false;
            this.btnTumunuAc.Click += new System.EventHandler(this.btnToggleTree_Click);
            // 
            // btnTestVerisiEkle
            // 
            this.btnTestVerisiEkle.BackColor = System.Drawing.Color.CadetBlue;
            this.btnTestVerisiEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestVerisiEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTestVerisiEkle.ForeColor = System.Drawing.Color.White;
            this.btnTestVerisiEkle.Location = new System.Drawing.Point(1159, 6);
            this.btnTestVerisiEkle.Name = "btnTestVerisiEkle";
            this.btnTestVerisiEkle.Size = new System.Drawing.Size(65, 34);
            this.btnTestVerisiEkle.TabIndex = 2;
            this.btnTestVerisiEkle.Text = "Test Verisi Ekle";
            this.btnTestVerisiEkle.UseVisualStyleBackColor = false;
            this.btnTestVerisiEkle.Click += new System.EventHandler(this.btnTestVerisiEkle_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.BackColor = System.Drawing.Color.CadetBlue;
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYenile.ForeColor = System.Drawing.Color.White;
            this.btnYenile.Location = new System.Drawing.Point(801, 7);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(100, 34);
            this.btnYenile.TabIndex = 1;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürün Ağacı";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelRight);
            this.splitContainer1.Size = new System.Drawing.Size(1236, 685);
            this.splitContainer1.SplitterDistance = 575;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.treeView1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(575, 685);
            this.panelLeft.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.txtUrunDetay);
            this.panelRight.Controls.Add(this.label2);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(651, 685);
            this.panelRight.TabIndex = 0;
            // 
            // txtUrunDetay
            // 
            this.txtUrunDetay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUrunDetay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrunDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUrunDetay.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtUrunDetay.Location = new System.Drawing.Point(0, 30);
            this.txtUrunDetay.Multiline = true;
            this.txtUrunDetay.Name = "txtUrunDetay";
            this.txtUrunDetay.ReadOnly = true;
            this.txtUrunDetay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUrunDetay.Size = new System.Drawing.Size(651, 655);
            this.txtUrunDetay.TabIndex = 1;
            this.txtUrunDetay.Text = "Bir ürün seçin...";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(651, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ürün Detayları";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExcelAktar
            // 
            this.btnExcelAktar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnExcelAktar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcelAktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)), true);
            this.btnExcelAktar.ForeColor = System.Drawing.Color.White;
            this.btnExcelAktar.Location = new System.Drawing.Point(1071, 6);
            this.btnExcelAktar.Name = "btnExcelAktar";
            this.btnExcelAktar.Size = new System.Drawing.Size(83, 34);
            this.btnExcelAktar.TabIndex = 12;
            this.btnExcelAktar.Text = "Excele Aktar";
            this.btnExcelAktar.UseVisualStyleBackColor = false;
            this.btnExcelAktar.Click += new System.EventHandler(this.btnExcelAktar_Click);
            // 
            // UrunAgaciApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 745);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "UrunAgaciApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Ağacı Yönetim Sistemi Serdar Makina";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Button UrunSil_Btn;
        private System.Windows.Forms.Button btnMaliyetAc;
        private System.Windows.Forms.Button Gecis_Btn;
        private System.Windows.Forms.Button btnExcelAktar;


    }
}


