namespace ÜretimTakipSistemi
{
    partial class SacAmbari_Gecmis_TümList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Tum_Liste = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Detaylı_Arama = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SacAmbari_Urun_Giris_Cikis_Tablosu = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SacAmbari_Urun_Giris_Cikis_Tablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // Tum_Liste
            // 
            this.Tum_Liste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Tum_Liste.FlatAppearance.BorderSize = 0;
            this.Tum_Liste.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Tum_Liste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tum_Liste.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Tum_Liste.ForeColor = System.Drawing.Color.White;
            this.Tum_Liste.Location = new System.Drawing.Point(348, 2);
            this.Tum_Liste.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Tum_Liste.Name = "Tum_Liste";
            this.Tum_Liste.Size = new System.Drawing.Size(100, 25);
            this.Tum_Liste.TabIndex = 100;
            this.Tum_Liste.Text = "Tüm Liste";
            this.Tum_Liste.UseVisualStyleBackColor = false;
            this.Tum_Liste.Click += new System.EventHandler(this.Tum_Liste_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(492, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(372, 30);
            this.label3.TabIndex = 99;
            this.label3.Text = "(Not: Ekranda sadece son 500 ürün hareketi görülmektedir.\r\nTüm hareketleri aramak" +
    " isterseniz \"Detaylı Arama\" butonuna basınız.)\r\n";
            // 
            // Detaylı_Arama
            // 
            this.Detaylı_Arama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Detaylı_Arama.FlatAppearance.BorderSize = 0;
            this.Detaylı_Arama.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Detaylı_Arama.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Detaylı_Arama.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Detaylı_Arama.ForeColor = System.Drawing.Color.White;
            this.Detaylı_Arama.Location = new System.Drawing.Point(231, 2);
            this.Detaylı_Arama.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Detaylı_Arama.Name = "Detaylı_Arama";
            this.Detaylı_Arama.Size = new System.Drawing.Size(100, 25);
            this.Detaylı_Arama.TabIndex = 98;
            this.Detaylı_Arama.Text = "Stok Kodu Ara";
            this.Detaylı_Arama.UseVisualStyleBackColor = false;
            this.Detaylı_Arama.Click += new System.EventHandler(this.Detaylı_Arama_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.textBox1.Location = new System.Drawing.Point(75, 3);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 21);
            this.textBox1.TabIndex = 96;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 97;
            this.label1.Text = "Stok Kodu:";
            // 
            // SacAmbari_Urun_Giris_Cikis_Tablosu
            // 
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.AllowUserToAddRows = false;
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.AllowUserToDeleteRows = false;
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.EnableHeadersVisualStyles = false;
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.GridColor = System.Drawing.Color.DarkGray;
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.Location = new System.Drawing.Point(5, 69);
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.Margin = new System.Windows.Forms.Padding(5);
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.Name = "SacAmbari_Urun_Giris_Cikis_Tablosu";
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.ReadOnly = true;
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.Size = new System.Drawing.Size(1086, 626);
            this.SacAmbari_Urun_Giris_Cikis_Tablosu.TabIndex = 95;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.textBox2.Location = new System.Drawing.Point(75, 34);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(150, 21);
            this.textBox2.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(20, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 102;
            this.label2.Text = "Stok Adı:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(231, 32);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 103;
            this.button1.Text = "Stok Adı Ara";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SacAmbari_Gecmis_TümList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 729);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tum_Liste);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Detaylı_Arama);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SacAmbari_Urun_Giris_Cikis_Tablosu);
            this.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SacAmbari_Gecmis_TümList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SacAmbari_Gecmis_TümList";
            this.Load += new System.EventHandler(this.SacAmbari_Gecmis_TümList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SacAmbari_Urun_Giris_Cikis_Tablosu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Tum_Liste;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Detaylı_Arama;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView SacAmbari_Urun_Giris_Cikis_Tablosu;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}