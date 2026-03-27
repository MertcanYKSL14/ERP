namespace ÜretimTakipSistemi.Lazer
{
    partial class LazerSistemi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.txtOrderQty = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.lblP = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();

            // Panel Tasarımı
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 100;

            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Text = "Lazer Bölümü Üretim Takip";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(20, 10);

            // Giriş Elemanları
            this.cmbProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProducts.Location = new System.Drawing.Point(25, 60);
            this.cmbProducts.Size = new System.Drawing.Size(200, 25);

            this.txtOrderQty.Location = new System.Drawing.Point(250, 60);
            this.txtOrderQty.Size = new System.Drawing.Size(80, 25);

            this.btnCalculate.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Text = "HESAPLA";
            this.btnCalculate.Location = new System.Drawing.Point(350, 58);
            this.btnCalculate.Size = new System.Drawing.Size(120, 30);
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            // Grid
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.dgvResults.ForeColor = System.Drawing.Color.Black;

            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.pnlTop);
            this.pnlTop.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblHeader, this.cmbProducts, this.txtOrderQty, this.btnCalculate });
            this.Text = "Lazer Üretim v2026";
            this.Size = new System.Drawing.Size(900, 600);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.TextBox txtOrderQty;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label lblP, lblA;
    }
}

