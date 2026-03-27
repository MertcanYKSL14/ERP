namespace ÜretimTakipSistemi
{
    partial class Rezistans_Stok_Listesi
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
            this.Rezistans_Gruplama_StokList_Tablosu = new System.Windows.Forms.DataGridView();
            this.Mesaj_Gönder = new System.Windows.Forms.Button();
            this.Mesaj_Sil = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.Rezistans_Gruplama_StokList_Tablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // Rezistans_Gruplama_StokList_Tablosu
            // 
            this.Rezistans_Gruplama_StokList_Tablosu.AllowUserToAddRows = false;
            this.Rezistans_Gruplama_StokList_Tablosu.AllowUserToDeleteRows = false;
            this.Rezistans_Gruplama_StokList_Tablosu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Rezistans_Gruplama_StokList_Tablosu.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.Rezistans_Gruplama_StokList_Tablosu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Rezistans_Gruplama_StokList_Tablosu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Rezistans_Gruplama_StokList_Tablosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Rezistans_Gruplama_StokList_Tablosu.EnableHeadersVisualStyles = false;
            this.Rezistans_Gruplama_StokList_Tablosu.GridColor = System.Drawing.Color.DarkGray;
            this.Rezistans_Gruplama_StokList_Tablosu.Location = new System.Drawing.Point(3, 4);
            this.Rezistans_Gruplama_StokList_Tablosu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Rezistans_Gruplama_StokList_Tablosu.Name = "Rezistans_Gruplama_StokList_Tablosu";
            this.Rezistans_Gruplama_StokList_Tablosu.ReadOnly = true;
            this.Rezistans_Gruplama_StokList_Tablosu.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.Rezistans_Gruplama_StokList_Tablosu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Rezistans_Gruplama_StokList_Tablosu.Size = new System.Drawing.Size(1014, 479);
            this.Rezistans_Gruplama_StokList_Tablosu.TabIndex = 30;
            // 
            // Mesaj_Gönder
            // 
            this.Mesaj_Gönder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Mesaj_Gönder.FlatAppearance.BorderSize = 0;
            this.Mesaj_Gönder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Mesaj_Gönder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Mesaj_Gönder.ForeColor = System.Drawing.Color.White;
            this.Mesaj_Gönder.Location = new System.Drawing.Point(833, 614);
            this.Mesaj_Gönder.Name = "Mesaj_Gönder";
            this.Mesaj_Gönder.Size = new System.Drawing.Size(84, 30);
            this.Mesaj_Gönder.TabIndex = 60;
            this.Mesaj_Gönder.Text = "Gönder";
            this.Mesaj_Gönder.UseVisualStyleBackColor = false;
            this.Mesaj_Gönder.Click += new System.EventHandler(this.Mesaj_Gönder_Click);
            // 
            // Mesaj_Sil
            // 
            this.Mesaj_Sil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Mesaj_Sil.FlatAppearance.BorderSize = 0;
            this.Mesaj_Sil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Mesaj_Sil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Mesaj_Sil.ForeColor = System.Drawing.Color.White;
            this.Mesaj_Sil.Location = new System.Drawing.Point(932, 614);
            this.Mesaj_Sil.Name = "Mesaj_Sil";
            this.Mesaj_Sil.Size = new System.Drawing.Size(85, 30);
            this.Mesaj_Sil.TabIndex = 59;
            this.Mesaj_Sil.Text = "Sil";
            this.Mesaj_Sil.UseVisualStyleBackColor = false;
            this.Mesaj_Sil.Click += new System.EventHandler(this.Mesaj_Sil_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox3.Location = new System.Drawing.Point(3, 607);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(819, 43);
            this.textBox3.TabIndex = 58;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(3, 484);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(1014, 121);
            this.listBox1.TabIndex = 57;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Rezistans_Stok_Listesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 651);
            this.Controls.Add(this.Mesaj_Gönder);
            this.Controls.Add(this.Mesaj_Sil);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Rezistans_Gruplama_StokList_Tablosu);
            this.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Rezistans_Stok_Listesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rezistans_Stok_Listesi";
            this.Load += new System.EventHandler(this.Rezistans_Stok_Listesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Rezistans_Gruplama_StokList_Tablosu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Rezistans_Gruplama_StokList_Tablosu;
        private System.Windows.Forms.Button Mesaj_Gönder;
        private System.Windows.Forms.Button Mesaj_Sil;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ListBox listBox1;
    }
}