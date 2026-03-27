namespace ÜretimTakipSistemi
{
    partial class Stok_Listesi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Stok_Kodu_Text = new System.Windows.Forms.TextBox();
            this.Stok_Adı_Text = new System.Windows.Forms.TextBox();
            this.Barkod_Text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SacAmbarı_Giris_Cikis_TümList = new System.Windows.Forms.Button();
            this.Kalinlik_Text = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.P_Birim = new System.Windows.Forms.Label();
            this.P_Toplam = new System.Windows.Forms.Label();
            this.Birim = new System.Windows.Forms.Label();
            this.R_Toplam = new System.Windows.Forms.Label();
            this.R_P_Text = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Cikan_Listesi_Btn = new System.Windows.Forms.Button();
            this.Tüm_Listesi_Btn = new System.Windows.Forms.Button();
            this.Kalite_Text = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Stok_Listesi_Tablosu = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Stok_Listesi_Tablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // Stok_Kodu_Text
            // 
            this.Stok_Kodu_Text.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Stok_Kodu_Text.Location = new System.Drawing.Point(75, 1);
            this.Stok_Kodu_Text.Name = "Stok_Kodu_Text";
            this.Stok_Kodu_Text.Size = new System.Drawing.Size(150, 21);
            this.Stok_Kodu_Text.TabIndex = 1;
            this.Stok_Kodu_Text.TextChanged += new System.EventHandler(this.Stok_Kodu_Text_TextChanged);
            // 
            // Stok_Adı_Text
            // 
            this.Stok_Adı_Text.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Stok_Adı_Text.Location = new System.Drawing.Point(75, 25);
            this.Stok_Adı_Text.Name = "Stok_Adı_Text";
            this.Stok_Adı_Text.Size = new System.Drawing.Size(150, 21);
            this.Stok_Adı_Text.TabIndex = 2;
            this.Stok_Adı_Text.TextChanged += new System.EventHandler(this.Stok_Adı_Text_TextChanged);
            // 
            // Barkod_Text
            // 
            this.Barkod_Text.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Barkod_Text.Location = new System.Drawing.Point(296, 1);
            this.Barkod_Text.Name = "Barkod_Text";
            this.Barkod_Text.Size = new System.Drawing.Size(150, 21);
            this.Barkod_Text.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(10, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Stok Kodu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(20, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stok Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(246, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Barkod:";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.SacAmbarı_Giris_Cikis_TümList);
            this.panel1.Controls.Add(this.Kalinlik_Text);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.P_Birim);
            this.panel1.Controls.Add(this.P_Toplam);
            this.panel1.Controls.Add(this.Birim);
            this.panel1.Controls.Add(this.R_Toplam);
            this.panel1.Controls.Add(this.R_P_Text);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Cikan_Listesi_Btn);
            this.panel1.Controls.Add(this.Tüm_Listesi_Btn);
            this.panel1.Controls.Add(this.Kalite_Text);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Barkod_Text);
            this.panel1.Controls.Add(this.Stok_Adı_Text);
            this.panel1.Controls.Add(this.Stok_Kodu_Text);
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1206, 57);
            this.panel1.TabIndex = 14;
            // 
            // SacAmbarı_Giris_Cikis_TümList
            // 
            this.SacAmbarı_Giris_Cikis_TümList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.SacAmbarı_Giris_Cikis_TümList.FlatAppearance.BorderSize = 0;
            this.SacAmbarı_Giris_Cikis_TümList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.SacAmbarı_Giris_Cikis_TümList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SacAmbarı_Giris_Cikis_TümList.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.SacAmbarı_Giris_Cikis_TümList.ForeColor = System.Drawing.Color.White;
            this.SacAmbarı_Giris_Cikis_TümList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SacAmbarı_Giris_Cikis_TümList.ImageKey = "(none)";
            this.SacAmbarı_Giris_Cikis_TümList.Location = new System.Drawing.Point(797, 1);
            this.SacAmbarı_Giris_Cikis_TümList.Name = "SacAmbarı_Giris_Cikis_TümList";
            this.SacAmbarı_Giris_Cikis_TümList.Size = new System.Drawing.Size(110, 25);
            this.SacAmbarı_Giris_Cikis_TümList.TabIndex = 99;
            this.SacAmbarı_Giris_Cikis_TümList.Text = "Tüm Geçmiş ";
            this.SacAmbarı_Giris_Cikis_TümList.UseVisualStyleBackColor = false;
            this.SacAmbarı_Giris_Cikis_TümList.Click += new System.EventHandler(this.SacAmbarı_Giris_Cikis_TümList_Click);
            // 
            // Kalinlik_Text
            // 
            this.Kalinlik_Text.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Kalinlik_Text.Location = new System.Drawing.Point(296, 25);
            this.Kalinlik_Text.Name = "Kalinlik_Text";
            this.Kalinlik_Text.Size = new System.Drawing.Size(150, 21);
            this.Kalinlik_Text.TabIndex = 97;
            this.Kalinlik_Text.TextChanged += new System.EventHandler(this.Kalinlik_Text_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.label10.Location = new System.Drawing.Point(245, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 16);
            this.label10.TabIndex = 98;
            this.label10.Text = "Kalınlık:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.label9.Location = new System.Drawing.Point(932, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "Toplam=";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.label8.Location = new System.Drawing.Point(931, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Toplam=";
            // 
            // P_Birim
            // 
            this.P_Birim.AutoSize = true;
            this.P_Birim.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.P_Birim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.P_Birim.Location = new System.Drawing.Point(1032, 26);
            this.P_Birim.Name = "P_Birim";
            this.P_Birim.Size = new System.Drawing.Size(34, 16);
            this.P_Birim.TabIndex = 22;
            this.P_Birim.Text = "Adet";
            this.P_Birim.Click += new System.EventHandler(this.P_Birim_Click);
            // 
            // P_Toplam
            // 
            this.P_Toplam.AutoSize = true;
            this.P_Toplam.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.P_Toplam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.P_Toplam.Location = new System.Drawing.Point(990, 26);
            this.P_Toplam.Name = "P_Toplam";
            this.P_Toplam.Size = new System.Drawing.Size(38, 16);
            this.P_Toplam.TabIndex = 21;
            this.P_Toplam.Text = "Plaka";
            // 
            // Birim
            // 
            this.Birim.AutoSize = true;
            this.Birim.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Birim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Birim.Location = new System.Drawing.Point(1032, 5);
            this.Birim.Name = "Birim";
            this.Birim.Size = new System.Drawing.Size(22, 16);
            this.Birim.TabIndex = 20;
            this.Birim.Text = "Kg";
            // 
            // R_Toplam
            // 
            this.R_Toplam.AutoSize = true;
            this.R_Toplam.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.R_Toplam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.R_Toplam.Location = new System.Drawing.Point(990, 5);
            this.R_Toplam.Name = "R_Toplam";
            this.R_Toplam.Size = new System.Drawing.Size(31, 16);
            this.R_Toplam.TabIndex = 19;
            this.R_Toplam.Text = "Rulo";
            // 
            // R_P_Text
            // 
            this.R_P_Text.Font = new System.Drawing.Font("Century Gothic", 7F);
            this.R_P_Text.FormattingEnabled = true;
            this.R_P_Text.Items.AddRange(new object[] {
            "R",
            "P"});
            this.R_P_Text.Location = new System.Drawing.Point(503, 25);
            this.R_P_Text.Name = "R_P_Text";
            this.R_P_Text.Size = new System.Drawing.Size(150, 21);
            this.R_P_Text.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(472, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "R/P:";
            // 
            // Cikan_Listesi_Btn
            // 
            this.Cikan_Listesi_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Cikan_Listesi_Btn.FlatAppearance.BorderSize = 0;
            this.Cikan_Listesi_Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Cikan_Listesi_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cikan_Listesi_Btn.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.Cikan_Listesi_Btn.ForeColor = System.Drawing.Color.White;
            this.Cikan_Listesi_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cikan_Listesi_Btn.ImageKey = "(none)";
            this.Cikan_Listesi_Btn.Location = new System.Drawing.Point(672, 29);
            this.Cikan_Listesi_Btn.Name = "Cikan_Listesi_Btn";
            this.Cikan_Listesi_Btn.Size = new System.Drawing.Size(110, 25);
            this.Cikan_Listesi_Btn.TabIndex = 15;
            this.Cikan_Listesi_Btn.Text = "Çıkan Listesi";
            this.Cikan_Listesi_Btn.UseVisualStyleBackColor = false;
            this.Cikan_Listesi_Btn.Click += new System.EventHandler(this.Cikan_Listesi_Btn_Click);
            // 
            // Tüm_Listesi_Btn
            // 
            this.Tüm_Listesi_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Tüm_Listesi_Btn.FlatAppearance.BorderSize = 0;
            this.Tüm_Listesi_Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Tüm_Listesi_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tüm_Listesi_Btn.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.Tüm_Listesi_Btn.ForeColor = System.Drawing.Color.White;
            this.Tüm_Listesi_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Tüm_Listesi_Btn.ImageKey = "(none)";
            this.Tüm_Listesi_Btn.Location = new System.Drawing.Point(672, 1);
            this.Tüm_Listesi_Btn.Name = "Tüm_Listesi_Btn";
            this.Tüm_Listesi_Btn.Size = new System.Drawing.Size(110, 25);
            this.Tüm_Listesi_Btn.TabIndex = 14;
            this.Tüm_Listesi_Btn.Text = "Tüm Liste";
            this.Tüm_Listesi_Btn.UseVisualStyleBackColor = false;
            this.Tüm_Listesi_Btn.Click += new System.EventHandler(this.Tüm_Listesi_Btn_Click);
            // 
            // Kalite_Text
            // 
            this.Kalite_Text.Font = new System.Drawing.Font("Century Gothic", 7F);
            this.Kalite_Text.FormattingEnabled = true;
            this.Kalite_Text.Items.AddRange(new object[] {
            "ALUSİ",
            "DEC",
            "DKP",
            "EK",
            "GLZ",
            "İNOX",
            ""});
            this.Kalite_Text.Location = new System.Drawing.Point(503, 1);
            this.Kalite_Text.Name = "Kalite_Text";
            this.Kalite_Text.Size = new System.Drawing.Size(150, 21);
            this.Kalite_Text.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.label7.Location = new System.Drawing.Point(461, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Kalite:";
            // 
            // Stok_Listesi_Tablosu
            // 
            this.Stok_Listesi_Tablosu.AllowUserToAddRows = false;
            this.Stok_Listesi_Tablosu.AllowUserToDeleteRows = false;
            this.Stok_Listesi_Tablosu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Stok_Listesi_Tablosu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Stok_Listesi_Tablosu.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.Stok_Listesi_Tablosu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Stok_Listesi_Tablosu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Stok_Listesi_Tablosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Stok_Listesi_Tablosu.EnableHeadersVisualStyles = false;
            this.Stok_Listesi_Tablosu.GridColor = System.Drawing.Color.DarkGray;
            this.Stok_Listesi_Tablosu.Location = new System.Drawing.Point(0, 72);
            this.Stok_Listesi_Tablosu.Name = "Stok_Listesi_Tablosu";
            this.Stok_Listesi_Tablosu.ReadOnly = true;
            this.Stok_Listesi_Tablosu.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.Stok_Listesi_Tablosu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Stok_Listesi_Tablosu.Size = new System.Drawing.Size(1206, 669);
            this.Stok_Listesi_Tablosu.TabIndex = 3;
            this.Stok_Listesi_Tablosu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Stok_Listesi_Tablosu_CellClick);
            // 
            // Stok_Listesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1206, 738);
            this.Controls.Add(this.Stok_Listesi_Tablosu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stok_Listesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok_Listesi";
            this.Load += new System.EventHandler(this.Stok_Listesi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Stok_Listesi_Tablosu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Stok_Kodu_Text;
        private System.Windows.Forms.TextBox Stok_Adı_Text;
        private System.Windows.Forms.TextBox Barkod_Text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox Kalite_Text;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Tüm_Listesi_Btn;
        private System.Windows.Forms.Button Cikan_Listesi_Btn;
        private System.Windows.Forms.ComboBox R_P_Text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Birim;
        private System.Windows.Forms.Label R_Toplam;
        private System.Windows.Forms.Label P_Birim;
        private System.Windows.Forms.Label P_Toplam;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Kalinlik_Text;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SacAmbarı_Giris_Cikis_TümList;
        private System.Windows.Forms.DataGridView Stok_Listesi_Tablosu;
    }
}