namespace ÜretimTakipSistemi
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblArma = new System.Windows.Forms.Panel();
            this.pcbxArma = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGiris = new System.Windows.Forms.TextBox();
            this.lblParola = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.btnSifreUnutma = new System.Windows.Forms.LinkLabel();
            this.btnCikis = new System.Windows.Forms.PictureBox();
            this.btnAlt = new System.Windows.Forms.PictureBox();
            this.btnHesapOlstur = new System.Windows.Forms.LinkLabel();
            this.lblArma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxArma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCikis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAlt)).BeginInit();
            this.SuspendLayout();
            // 
            // lblArma
            // 
            this.lblArma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblArma.Controls.Add(this.pcbxArma);
            this.lblArma.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblArma.Location = new System.Drawing.Point(0, 0);
            this.lblArma.Name = "lblArma";
            this.lblArma.Size = new System.Drawing.Size(200, 260);
            this.lblArma.TabIndex = 0;
            this.lblArma.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pcbxArma
            // 
            this.pcbxArma.Image = ((System.Drawing.Image)(resources.GetObject("pcbxArma.Image")));
            this.pcbxArma.Location = new System.Drawing.Point(30, 67);
            this.pcbxArma.Name = "pcbxArma";
            this.pcbxArma.Size = new System.Drawing.Size(124, 125);
            this.pcbxArma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbxArma.TabIndex = 0;
            this.pcbxArma.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(233, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 1);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(233, 148);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 1);
            this.panel3.TabIndex = 2;
            // 
            // lblGiris
            // 
            this.lblGiris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblGiris.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblGiris.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblGiris.ForeColor = System.Drawing.Color.White;
            this.lblGiris.Location = new System.Drawing.Point(233, 85);
            this.lblGiris.Name = "lblGiris";
            this.lblGiris.Size = new System.Drawing.Size(350, 17);
            this.lblGiris.TabIndex = 1;
            this.lblGiris.Text = "GİRİŞ";
            this.lblGiris.Enter += new System.EventHandler(this.Giris_Enter);
            this.lblGiris.Leave += new System.EventHandler(this.Giris_Leave);
            // 
            // lblParola
            // 
            this.lblParola.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblParola.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblParola.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblParola.ForeColor = System.Drawing.Color.White;
            this.lblParola.Location = new System.Drawing.Point(233, 125);
            this.lblParola.Name = "lblParola";
            this.lblParola.Size = new System.Drawing.Size(350, 17);
            this.lblParola.TabIndex = 2;
            this.lblParola.Text = "PAROLA";
            this.lblParola.Enter += new System.EventHandler(this.Parola_Enter);
            this.lblParola.Leave += new System.EventHandler(this.Parola_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(376, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "GİRİŞ";
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.FlatAppearance.BorderSize = 0;
            this.btnGirisYap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnGirisYap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGirisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGirisYap.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGirisYap.ForeColor = System.Drawing.Color.White;
            this.btnGirisYap.Location = new System.Drawing.Point(233, 176);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(350, 29);
            this.btnGirisYap.TabIndex = 3;
            this.btnGirisYap.Text = "GİRİŞ YAP";
            this.btnGirisYap.UseVisualStyleBackColor = true;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            // 
            // btnSifreUnutma
            // 
            this.btnSifreUnutma.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(204)))));
            this.btnSifreUnutma.AutoSize = true;
            this.btnSifreUnutma.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSifreUnutma.LinkColor = System.Drawing.Color.Gray;
            this.btnSifreUnutma.Location = new System.Drawing.Point(243, 233);
            this.btnSifreUnutma.Name = "btnSifreUnutma";
            this.btnSifreUnutma.Size = new System.Drawing.Size(120, 18);
            this.btnSifreUnutma.TabIndex = 4;
            this.btnSifreUnutma.TabStop = true;
            this.btnSifreUnutma.Text = "Şifremi unuttum ?";
            this.btnSifreUnutma.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSifreUnutma_LinkClicked);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.White;
            this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCikis.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.Image")));
            this.btnCikis.Location = new System.Drawing.Point(612, 0);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(15, 15);
            this.btnCikis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCikis.TabIndex = 8;
            this.btnCikis.TabStop = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnAlt
            // 
            this.btnAlt.BackColor = System.Drawing.Color.White;
            this.btnAlt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlt.Image = ((System.Drawing.Image)(resources.GetObject("btnAlt.Image")));
            this.btnAlt.Location = new System.Drawing.Point(593, 0);
            this.btnAlt.Name = "btnAlt";
            this.btnAlt.Size = new System.Drawing.Size(15, 15);
            this.btnAlt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAlt.TabIndex = 9;
            this.btnAlt.TabStop = false;
            this.btnAlt.Click += new System.EventHandler(this.btnAlt_Click);
            // 
            // btnHesapOlstur
            // 
            this.btnHesapOlstur.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(204)))));
            this.btnHesapOlstur.AutoSize = true;
            this.btnHesapOlstur.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHesapOlstur.LinkColor = System.Drawing.Color.Gray;
            this.btnHesapOlstur.Location = new System.Drawing.Point(429, 233);
            this.btnHesapOlstur.Name = "btnHesapOlstur";
            this.btnHesapOlstur.Size = new System.Drawing.Size(117, 18);
            this.btnHesapOlstur.TabIndex = 10;
            this.btnHesapOlstur.TabStop = true;
            this.btnHesapOlstur.Text = "Hesap Oluşturma ";
            this.btnHesapOlstur.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnHesapOlstur_LinkClicked);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(630, 260);
            this.Controls.Add(this.btnHesapOlstur);
            this.Controls.Add(this.btnAlt);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnSifreUnutma);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblParola);
            this.Controls.Add(this.lblGiris);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblArma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_MouseDown);
            this.lblArma.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbxArma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCikis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAlt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel lblArma;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox lblGiris;
        private System.Windows.Forms.TextBox lblParola;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.LinkLabel btnSifreUnutma;
        private System.Windows.Forms.PictureBox btnCikis;
        private System.Windows.Forms.PictureBox btnAlt;
        private System.Windows.Forms.PictureBox pcbxArma;
        private System.Windows.Forms.LinkLabel btnHesapOlstur;
    }
}