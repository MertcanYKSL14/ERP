using System.Windows.Forms;

namespace ÜretimTakipSistemi.Siparis
{
    partial class SiparisChat
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
            this.components = new System.ComponentModel.Container();
            this.pnlUst = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.tlpAlt = new System.Windows.Forms.TableLayoutPanel();
            this.btnDosyaEkle = new System.Windows.Forms.Button();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.pnlSohbetAkisi = new System.Windows.Forms.FlowLayoutPanel();
            this.yenilemeZamanlayicisi = new System.Windows.Forms.Timer(this.components);
            this.pnlUst.SuspendLayout();
            this.pnlAlt.SuspendLayout();
            this.tlpAlt.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.pnlUst.Controls.Add(this.lblBaslik);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Padding = new System.Windows.Forms.Padding(15);
            this.pnlUst.Size = new System.Drawing.Size(484, 60);
            this.pnlUst.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(15, 18);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(199, 21);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "🏭 Fabrika Genel Sohbet";
            // 
            // pnlAlt
            // 
            this.pnlAlt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.pnlAlt.Controls.Add(this.tlpAlt);
            this.pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlt.Location = new System.Drawing.Point(0, 591);
            this.pnlAlt.Name = "pnlAlt";
            this.pnlAlt.Padding = new System.Windows.Forms.Padding(10);
            this.pnlAlt.Size = new System.Drawing.Size(484, 70);
            this.pnlAlt.TabIndex = 1;
            // 
            // tlpAlt
            // 
            this.tlpAlt.ColumnCount = 3;
            this.tlpAlt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tlpAlt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpAlt.Controls.Add(this.btnDosyaEkle, 0, 0);
            this.tlpAlt.Controls.Add(this.txtMesaj, 1, 0);
            this.tlpAlt.Controls.Add(this.btnGonder, 2, 0);
            this.tlpAlt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAlt.Location = new System.Drawing.Point(10, 10);
            this.tlpAlt.Name = "tlpAlt";
            this.tlpAlt.Padding = new System.Windows.Forms.Padding(5);
            this.tlpAlt.RowCount = 1;
            this.tlpAlt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlt.Size = new System.Drawing.Size(464, 50);
            this.tlpAlt.TabIndex = 0;
            // 
            // btnDosyaEkle
            // 
            this.btnDosyaEkle.BackColor = System.Drawing.Color.Transparent;
            this.btnDosyaEkle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDosyaEkle.FlatAppearance.BorderSize = 0;
            this.btnDosyaEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDosyaEkle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.btnDosyaEkle.ForeColor = System.Drawing.Color.White;
            this.btnDosyaEkle.Location = new System.Drawing.Point(8, 8);
            this.btnDosyaEkle.Name = "btnDosyaEkle";
            this.btnDosyaEkle.Size = new System.Drawing.Size(43, 34);
            this.btnDosyaEkle.TabIndex = 0;
            this.btnDosyaEkle.Text = "📎";
            this.btnDosyaEkle.UseVisualStyleBackColor = false;
            this.btnDosyaEkle.Click += new System.EventHandler(this.btnDosyaEkle_Click);
            // 
            // txtMesaj
            // 
            this.txtMesaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.txtMesaj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMesaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMesaj.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMesaj.ForeColor = System.Drawing.Color.White;
            this.txtMesaj.Location = new System.Drawing.Point(59, 10);
            this.txtMesaj.Margin = new System.Windows.Forms.Padding(5);
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(340, 30);
            this.txtMesaj.TabIndex = 2;
            this.txtMesaj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMesaj_KeyDown);
            // 
            // btnGonder
            // 
            this.btnGonder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(132)))));
            this.btnGonder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGonder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGonder.FlatAppearance.BorderSize = 0;
            this.btnGonder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGonder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonder.ForeColor = System.Drawing.Color.White;
            this.btnGonder.Location = new System.Drawing.Point(407, 8);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(49, 34);
            this.btnGonder.TabIndex = 0;
            this.btnGonder.Text = "➤";
            this.btnGonder.UseVisualStyleBackColor = false;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // pnlSohbetAkisi
            // 
            this.pnlSohbetAkisi.AutoScroll = true;
            this.pnlSohbetAkisi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(20)))), ((int)(((byte)(26)))));
            this.pnlSohbetAkisi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSohbetAkisi.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlSohbetAkisi.Location = new System.Drawing.Point(0, 60);
            this.pnlSohbetAkisi.Name = "pnlSohbetAkisi";
            this.pnlSohbetAkisi.Padding = new System.Windows.Forms.Padding(10, 20, 0, 20);
            this.pnlSohbetAkisi.Size = new System.Drawing.Size(484, 531);
            this.pnlSohbetAkisi.TabIndex = 2;
            this.pnlSohbetAkisi.WrapContents = false;
            this.pnlSohbetAkisi.SizeChanged += new System.EventHandler(this.pnlSohbetAkisi_SizeChanged);
            // 
            // yenilemeZamanlayicisi
            // 
            this.yenilemeZamanlayicisi.Interval = 2000;
            this.yenilemeZamanlayicisi.Tick += new System.EventHandler(this.yenilemeZamanlayicisi_Tick);
            // 
            // SiparisChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.pnlSohbetAkisi);
            this.Controls.Add(this.pnlAlt);
            this.Controls.Add(this.pnlUst);
            this.DoubleBuffered = true;
            this.Name = "SiparisChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fabrika Chat";
            this.pnlUst.ResumeLayout(false);
            this.pnlUst.PerformLayout();
            this.pnlAlt.ResumeLayout(false);
            this.tlpAlt.ResumeLayout(false);
            this.tlpAlt.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Panel pnlAlt;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.FlowLayoutPanel pnlSohbetAkisi;
        private System.Windows.Forms.Timer yenilemeZamanlayicisi;
        private System.Windows.Forms.Button btnDosyaEkle;
        private System.Windows.Forms.TableLayoutPanel tlpAlt;
    }
}