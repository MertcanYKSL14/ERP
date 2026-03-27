namespace ÜretimTakipSistemi.SacAmbarı
{
    partial class MaliyetHesaplaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvMaliyet;
        private System.Windows.Forms.Button btnMaliyetHesapla; // Tek buton
        private System.Windows.Forms.Label lblToplamMaliyet;
        private System.Windows.Forms.TextBox txtUrunKodu;
        private System.Windows.Forms.Label lblBilgi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvMaliyet = new System.Windows.Forms.DataGridView();
            this.btnMaliyetHesapla = new System.Windows.Forms.Button();
            this.lblToplamMaliyet = new System.Windows.Forms.Label();
            this.txtUrunKodu = new System.Windows.Forms.TextBox();
            this.lblBilgi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaliyet)).BeginInit();
            this.SuspendLayout();

            // lblBilgi
            this.lblBilgi.Text = "Ürün Kodu:";
            this.lblBilgi.Location = new System.Drawing.Point(12, 15);
            this.lblBilgi.AutoSize = true;

            // txtUrunKodu (Arama kutusu)
            this.txtUrunKodu.Location = new System.Drawing.Point(90, 12);
            this.txtUrunKodu.Size = new System.Drawing.Size(180, 24);

            // btnMaliyetHesapla (Bul ve Hesapla Birleşik)
            this.btnMaliyetHesapla.Location = new System.Drawing.Point(280, 10);
            this.btnMaliyetHesapla.Size = new System.Drawing.Size(150, 30);
            this.btnMaliyetHesapla.Text = "Bul ve Hesapla";
            this.btnMaliyetHesapla.BackColor = System.Drawing.Color.LightGreen;
            this.btnMaliyetHesapla.Click += new System.EventHandler(this.btnMaliyetHesapla_Click);

            // dgvMaliyet
            this.dgvMaliyet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaliyet.Location = new System.Drawing.Point(12, 50);
            this.dgvMaliyet.Size = new System.Drawing.Size(760, 350);

            // lblToplamMaliyet (Sonucun Yazılacağı Yer)
            this.lblToplamMaliyet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblToplamMaliyet.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblToplamMaliyet.Location = new System.Drawing.Point(12, 410);
            this.lblToplamMaliyet.Size = new System.Drawing.Size(760, 40);
            this.lblToplamMaliyet.Text = "Hesaplama için ürün kodu giriniz...";

            // Form
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblBilgi, this.txtUrunKodu, this.btnMaliyetHesapla,
                this.dgvMaliyet, this.lblToplamMaliyet
            });
            this.Text = "Ürün Ağacı - Otomatik Maliyet Hesaplama";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaliyet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}