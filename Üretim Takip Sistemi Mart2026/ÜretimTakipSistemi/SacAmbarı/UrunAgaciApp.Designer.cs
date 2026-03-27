using System.Drawing;
using System.Windows.Forms;

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
        private System.Windows.Forms.Button btnTumunuAc;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Button btnCikis;

        // DİĞER KONTROLLER
        private System.Windows.Forms.Label lblStatus;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrunAgaciApp));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnExcelAktar = new System.Windows.Forms.Button();
            this.UrunSil_Btn = new System.Windows.Forms.Button();
            this.btnYenile = new System.Windows.Forms.Button();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.btnTumunuAc = new System.Windows.Forms.Button();
            this.Gecis_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUrunDetay = new System.Windows.Forms.TextBox();
            this.panelTop.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.treeView1.FullRowSelect = true;
            this.treeView1.HotTracking = true;
            this.treeView1.Indent = 12;
            this.treeView1.ItemHeight = 28;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(572, 630);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.panel11);
            this.panelTop.Controls.Add(this.panel9);
            this.panelTop.Controls.Add(this.panel7);
            this.panelTop.Controls.Add(this.panel5);
            this.panelTop.Controls.Add(this.panel3);
            this.panelTop.Controls.Add(this.panel1);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.btnCikis);
            this.panelTop.Controls.Add(this.btnExcelAktar);
            this.panelTop.Controls.Add(this.UrunSil_Btn);
            this.panelTop.Controls.Add(this.btnYenile);
            this.panelTop.Controls.Add(this.btnUrunEkle);
            this.panelTop.Controls.Add(this.btnTumunuAc);
            this.panelTop.Controls.Add(this.Gecis_Btn);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTop.Location = new System.Drawing.Point(3, 24);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.panelTop.Size = new System.Drawing.Size(220, 630);
            this.panelTop.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Black;
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Controls.Add(this.button6);
            this.panel11.Location = new System.Drawing.Point(3, 385);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(4, 25);
            this.panel11.TabIndex = 114;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Black;
            this.panel12.Location = new System.Drawing.Point(-73, -1);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(4, 37);
            this.panel12.TabIndex = 107;
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 9.5F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button6.Location = new System.Drawing.Point(-81, 723);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(166, 45);
            this.button6.TabIndex = 106;
            this.button6.Text = " Ürün Ağacı";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Black;
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.button5);
            this.panel9.Location = new System.Drawing.Point(3, 66);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(4, 63);
            this.panel9.TabIndex = 113;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Black;
            this.panel10.Location = new System.Drawing.Point(-73, -1);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(4, 37);
            this.panel10.TabIndex = 107;
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 9.5F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.Location = new System.Drawing.Point(-81, 723);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 45);
            this.button5.TabIndex = 106;
            this.button5.Text = " Ürün Ağacı";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.button4);
            this.panel7.Location = new System.Drawing.Point(3, 129);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(4, 50);
            this.panel7.TabIndex = 112;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Black;
            this.panel8.Location = new System.Drawing.Point(-73, -1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(4, 37);
            this.panel8.TabIndex = 107;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 9.5F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(-81, 723);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(166, 45);
            this.button4.TabIndex = 106;
            this.button4.Text = " Ürün Ağacı";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.button3);
            this.panel5.Location = new System.Drawing.Point(3, 179);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(4, 50);
            this.panel5.TabIndex = 111;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(-73, -1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(4, 37);
            this.panel6.TabIndex = 107;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9.5F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(-81, 723);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 45);
            this.button3.TabIndex = 106;
            this.button3.Text = " Ürün Ağacı";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(3, 229);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(4, 50);
            this.panel3.TabIndex = 110;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(-73, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(4, 37);
            this.panel4.TabIndex = 107;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9.5F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(-81, 723);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 45);
            this.button2.TabIndex = 106;
            this.button2.Text = " Ürün Ağacı";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(4, 50);
            this.panel1.TabIndex = 109;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(-73, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 37);
            this.panel2.TabIndex = 107;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.5F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(-81, 723);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 45);
            this.button1.TabIndex = 106;
            this.button1.Text = " Ürün Ağacı";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(6, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Ürün Bul:";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(106, 385);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(104, 25);
            this.txtSearch.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.Red;
            this.btnCikis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)), true);
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(10, 570);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(200, 50);
            this.btnCikis.TabIndex = 6;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnExcelAktar
            // 
            this.btnExcelAktar.BackColor = System.Drawing.Color.Transparent;
            this.btnExcelAktar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExcelAktar.FlatAppearance.BorderSize = 0;
            this.btnExcelAktar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnExcelAktar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcelAktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcelAktar.ForeColor = System.Drawing.Color.White;
            this.btnExcelAktar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelAktar.Location = new System.Drawing.Point(10, 329);
            this.btnExcelAktar.Name = "btnExcelAktar";
            this.btnExcelAktar.Size = new System.Drawing.Size(200, 50);
            this.btnExcelAktar.TabIndex = 12;
            this.btnExcelAktar.Text = "📊 Excele Aktar";
            this.btnExcelAktar.UseVisualStyleBackColor = false;
            this.btnExcelAktar.Click += new System.EventHandler(this.btnExcelAktar_Click);
            // 
            // UrunSil_Btn
            // 
            this.UrunSil_Btn.BackColor = System.Drawing.Color.Transparent;
            this.UrunSil_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.UrunSil_Btn.FlatAppearance.BorderSize = 0;
            this.UrunSil_Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.UrunSil_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UrunSil_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UrunSil_Btn.ForeColor = System.Drawing.Color.White;
            this.UrunSil_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UrunSil_Btn.Location = new System.Drawing.Point(10, 279);
            this.UrunSil_Btn.Name = "UrunSil_Btn";
            this.UrunSil_Btn.Size = new System.Drawing.Size(200, 50);
            this.UrunSil_Btn.TabIndex = 9;
            this.UrunSil_Btn.Text = "🗑️ Ürün Sil";
            this.UrunSil_Btn.UseVisualStyleBackColor = false;
            this.UrunSil_Btn.Click += new System.EventHandler(this.UrunSil_Btn_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.BackColor = System.Drawing.Color.Transparent;
            this.btnYenile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnYenile.FlatAppearance.BorderSize = 0;
            this.btnYenile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYenile.ForeColor = System.Drawing.Color.White;
            this.btnYenile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(10, 229);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(200, 50);
            this.btnYenile.TabIndex = 1;
            this.btnYenile.Text = "🔄 Yenile";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.BackColor = System.Drawing.Color.Transparent;
            this.btnUrunEkle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUrunEkle.FlatAppearance.BorderSize = 0;
            this.btnUrunEkle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnUrunEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrunEkle.ForeColor = System.Drawing.Color.White;
            this.btnUrunEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUrunEkle.Location = new System.Drawing.Point(10, 179);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(200, 50);
            this.btnUrunEkle.TabIndex = 5;
            this.btnUrunEkle.Text = "➕ Yeni Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = false;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // btnTumunuAc
            // 
            this.btnTumunuAc.BackColor = System.Drawing.Color.Transparent;
            this.btnTumunuAc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTumunuAc.FlatAppearance.BorderSize = 0;
            this.btnTumunuAc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnTumunuAc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTumunuAc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTumunuAc.ForeColor = System.Drawing.Color.White;
            this.btnTumunuAc.Location = new System.Drawing.Point(10, 129);
            this.btnTumunuAc.Name = "btnTumunuAc";
            this.btnTumunuAc.Size = new System.Drawing.Size(200, 50);
            this.btnTumunuAc.TabIndex = 3;
            this.btnTumunuAc.Text = "▼ Tümünü Genişlet ";
            this.btnTumunuAc.UseVisualStyleBackColor = false;
            this.btnTumunuAc.Click += new System.EventHandler(this.btnToggleTree_Click);
            // 
            // Gecis_Btn
            // 
            this.Gecis_Btn.BackColor = System.Drawing.Color.Transparent;
            this.Gecis_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Gecis_Btn.FlatAppearance.BorderSize = 0;
            this.Gecis_Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Gecis_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gecis_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Gecis_Btn.ForeColor = System.Drawing.Color.White;
            this.Gecis_Btn.Location = new System.Drawing.Point(10, 66);
            this.Gecis_Btn.Name = "Gecis_Btn";
            this.Gecis_Btn.Size = new System.Drawing.Size(200, 63);
            this.Gecis_Btn.TabIndex = 11;
            this.Gecis_Btn.Text = "📋 Tüm Ürünleri Göster";
            this.Gecis_Btn.UseVisualStyleBackColor = false;
            this.Gecis_Btn.Click += new System.EventHandler(this.Gecis_Btn_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(200, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serdar Makina";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(13, 42);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(67, 24);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Durum";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(223, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelRight);
            this.splitContainer1.Size = new System.Drawing.Size(1045, 630);
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
            this.panelLeft.Size = new System.Drawing.Size(575, 630);
            this.panelLeft.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.label2);
            this.panelRight.Controls.Add(this.txtUrunDetay);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(460, 630);
            this.panelRight.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Ink Free", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(460, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ürün Detayları";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUrunDetay
            // 
            this.txtUrunDetay.Location = new System.Drawing.Point(3, 33);
            this.txtUrunDetay.Multiline = true;
            this.txtUrunDetay.Name = "txtUrunDetay";
            this.txtUrunDetay.Size = new System.Drawing.Size(455, 597);
            this.txtUrunDetay.TabIndex = 1;
            // 
            // UrunAgaciApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1271, 657);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "UrunAgaciApp";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Ağacı Yönetim Sistemi ";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button Gecis_Btn;
        private System.Windows.Forms.Button btnExcelAktar;
        private TextBox txtUrunDetay;
        private PictureBox pictureBox1;
        private TextBox txtSearch;
        private Label label3;
        private Panel panel9;
        private Panel panel10;
        private Button button5;
        private Panel panel7;
        private Panel panel8;
        private Button button4;
        private Panel panel5;
        private Panel panel6;
        private Button button3;
        private Panel panel3;
        private Panel panel4;
        private Button button2;
        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private Panel panel11;
        private Panel panel12;
        private Button button6;
    }
}

