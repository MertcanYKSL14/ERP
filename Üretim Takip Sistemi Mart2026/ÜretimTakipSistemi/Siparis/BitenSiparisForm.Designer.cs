using System.Windows.Forms;

namespace ÜretimTakipSistemi.Siparis
{
    partial class BitenSiparisForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.panelUst = new System.Windows.Forms.Panel();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.dtBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dtBitis = new System.Windows.Forms.DateTimePicker();
            this.btnListele = new System.Windows.Forms.Button();
            this.btnGeriAl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBitenler = new System.Windows.Forms.DataGridView();
            this.panelAlt = new System.Windows.Forms.Panel();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitenler)).BeginInit();
            this.panelAlt.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(950, 50);
            this.panelHeader.TabIndex = 3;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(10, 10);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(331, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "TAMAMLANAN SİPARİŞLER (ARŞİV)";
            // 
            // panelUst
            // 
            this.panelUst.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelUst.Controls.Add(this.txtArama);
            this.panelUst.Controls.Add(this.dtBaslangic);
            this.panelUst.Controls.Add(this.dtBitis);
            this.panelUst.Controls.Add(this.btnListele);
            this.panelUst.Controls.Add(this.btnGeriAl);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 50);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(950, 60);
            this.panelUst.TabIndex = 2;
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(15, 18);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(180, 20);
            this.txtArama.TabIndex = 0;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // dtBaslangic
            // 
            this.dtBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBaslangic.Location = new System.Drawing.Point(210, 18);
            this.dtBaslangic.Name = "dtBaslangic";
            this.dtBaslangic.Size = new System.Drawing.Size(100, 20);
            this.dtBaslangic.TabIndex = 1;
            // 
            // dtBitis
            // 
            this.dtBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBitis.Location = new System.Drawing.Point(320, 18);
            this.dtBitis.Name = "dtBitis";
            this.dtBitis.Size = new System.Drawing.Size(100, 20);
            this.dtBitis.TabIndex = 2;
            // 
            // btnListele
            // 
            this.btnListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnListele.Location = new System.Drawing.Point(430, 16);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(80, 30);
            this.btnListele.TabIndex = 3;
            this.btnListele.Text = "Filtrele";
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // btnGeriAl
            // 
            this.btnGeriAl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnGeriAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeriAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeriAl.Location = new System.Drawing.Point(520, 16);
            this.btnGeriAl.Name = "btnGeriAl";
            this.btnGeriAl.Size = new System.Drawing.Size(120, 30);
            this.btnGeriAl.TabIndex = 4;
            this.btnGeriAl.Text = "↩ Aktife Geri Al";
            this.btnGeriAl.UseVisualStyleBackColor = false;
            this.btnGeriAl.Click += new System.EventHandler(this.btnGeriAl_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // dgvBitenler
            // 
            this.dgvBitenler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBitenler.BackgroundColor = System.Drawing.Color.White;
            this.dgvBitenler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBitenler.Location = new System.Drawing.Point(0, 110);
            this.dgvBitenler.Name = "dgvBitenler";
            this.dgvBitenler.ReadOnly = true;
            this.dgvBitenler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBitenler.Size = new System.Drawing.Size(950, 410);
            this.dgvBitenler.TabIndex = 0;
            // 
            // panelAlt
            // 
            this.panelAlt.Controls.Add(this.lblBilgi);
            this.panelAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAlt.Location = new System.Drawing.Point(0, 520);
            this.panelAlt.Name = "panelAlt";
            this.panelAlt.Size = new System.Drawing.Size(950, 30);
            this.panelAlt.TabIndex = 1;
            // 
            // lblBilgi
            // 
            this.lblBilgi.Location = new System.Drawing.Point(10, 7);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(174, 23);
            this.lblBilgi.TabIndex = 0;
            this.lblBilgi.Text = "Toplam Tamamlanan: 0";
            // 
            // BitenSiparisForm
            // 
            this.ClientSize = new System.Drawing.Size(950, 550);
            this.Controls.Add(this.dgvBitenler);
            this.Controls.Add(this.panelAlt);
            this.Controls.Add(this.panelUst);
            this.Controls.Add(this.panelHeader);
            this.Name = "BitenSiparisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sipariş Arşivi";
            this.Load += new System.EventHandler(this.BitenSiparisForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelUst.ResumeLayout(false);
            this.panelUst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitenler)).EndInit();
            this.panelAlt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Panel panelUst;
        private System.Windows.Forms.DataGridView dgvBitenler;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.DateTimePicker dtBaslangic;
        private Label label1;
        private System.Windows.Forms.DateTimePicker dtBitis;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.Button btnGeriAl;
        private System.Windows.Forms.Panel panelAlt;
        private Label lblBilgi;
    }

}