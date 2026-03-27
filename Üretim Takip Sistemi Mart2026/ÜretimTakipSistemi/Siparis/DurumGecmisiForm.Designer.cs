// =====================================================
// DURUM GEÇMİŞİ GÖRÜNTÜLEME SİSTEMİ
// =====================================================

// ============== 1. YENİ FORM OLUŞTUR ==============
// Projenize yeni bir form ekleyin: DurumGecmisiForm.cs

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using SiparisDurumGecmisiEntity = ÜretimTakipSistemi.Entities.Concrete.SiparisDurumGecmisi;

namespace ÜretimTakipSistemi.Siparis
{
    public partial class DurumGecmisiForm : Form
    {
        private readonly ISiparisService _siparisService;
        private int siparisID;
        private string stokNo;
        private string urunAdi;

        public DurumGecmisiForm(int sipID, string stok, string urun)
        {
            InitializeComponent();
            _siparisService = InstanceFactory.GetInstance<ISiparisService>();
            siparisID = sipID;
            stokNo = stok;
            urunAdi = urun;
        }

        private void DurumGecmisiForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Durum Geçmişi - {stokNo}";
            lblBaslik.Text = $"Ürün: {urunAdi}\nStok No: {stokNo}";

            DurumGecmisiniYukle();
            DataGridStiliniAyarla();
        }

        private void DurumGecmisiniYukle()
        {
            try
            {
                List<SiparisDurumGecmisiEntity> gecmisKayitlari = _siparisService.GetDurumGecmisi(siparisID);

                if (gecmisKayitlari.Count == 0)
                {
                    MessageBox.Show("Bu sipariş için henüz durum geçmişi bulunmuyor.",
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                DataTable dt = DurumGecmisiniDataTableaDonustur(gecmisKayitlari);
                dgvGecmis.DataSource = dt;
                lblToplamKayit.Text = $"Toplam {dt.Rows.Count} durum değişikliği";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Geçmiş yükleme hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable DurumGecmisiniDataTableaDonustur(List<SiparisDurumGecmisiEntity> gecmisKayitlari)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("EskiDurum", typeof(string));
            dataTable.Columns.Add("YeniDurum", typeof(string));
            dataTable.Columns.Add("DegistirenKullanici", typeof(string));
            dataTable.Columns.Add("DegisiklikTarihi", typeof(DateTime));
            dataTable.Columns.Add("UretilenMiktar", typeof(int));
            dataTable.Columns.Add("Aciklama", typeof(string));

            foreach (SiparisDurumGecmisiEntity kayit in gecmisKayitlari)
            {
                dataTable.Rows.Add(
                    kayit.EskiDurum,
                    kayit.YeniDurum,
                    kayit.DegistirenKullanici,
                    kayit.DegisiklikTarihi,
                    kayit.UretilenMiktar.HasValue ? (object)kayit.UretilenMiktar.Value : DBNull.Value,
                    kayit.Aciklama);
            }

            return dataTable;
        }

        private void DataGridStiliniAyarla()
        {
            dgvGecmis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGecmis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGecmis.MultiSelect = false;
            dgvGecmis.ReadOnly = true;
            dgvGecmis.AllowUserToAddRows = false;
            dgvGecmis.RowHeadersVisible = false;
            dgvGecmis.BackgroundColor = Color.White;
            dgvGecmis.BorderStyle = BorderStyle.None;
            dgvGecmis.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvGecmis.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvGecmis.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvGecmis.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvGecmis.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvGecmis.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvGecmis.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);
            dgvGecmis.ColumnHeadersHeight = 40;
            dgvGecmis.EnableHeadersVisualStyles = false;
            dgvGecmis.RowTemplate.Height = 35;

            // Kolon başlıklarını Türkçeleştir
            if (dgvGecmis.Columns.Count > 0)
            {
                dgvGecmis.Columns["EskiDurum"].HeaderText = "Eski Durum";
                dgvGecmis.Columns["YeniDurum"].HeaderText = "Yeni Durum";
                dgvGecmis.Columns["DegistirenKullanici"].HeaderText = "Kullanıcı";
                dgvGecmis.Columns["DegisiklikTarihi"].HeaderText = "Tarih/Saat";
                dgvGecmis.Columns["UretilenMiktar"].HeaderText = "Miktar";
                dgvGecmis.Columns["Aciklama"].HeaderText = "Açıklama";

                // Tarih formatı
                dgvGecmis.Columns["DegisiklikTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

                // Kolon genişlikleri
                dgvGecmis.Columns["EskiDurum"].FillWeight = 80;
                dgvGecmis.Columns["YeniDurum"].FillWeight = 80;
                dgvGecmis.Columns["DegistirenKullanici"].FillWeight = 70;
                dgvGecmis.Columns["DegisiklikTarihi"].FillWeight = 90;
                dgvGecmis.Columns["UretilenMiktar"].FillWeight = 60;
                dgvGecmis.Columns["Aciklama"].FillWeight = 120;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.dgvGecmis = new System.Windows.Forms.DataGridView();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblToplamKayit = new System.Windows.Forms.Label();
            this.btnKapat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmis)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGecmis
            // 
            this.dgvGecmis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGecmis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGecmis.Location = new System.Drawing.Point(10, 80);
            this.dgvGecmis.Name = "dgvGecmis";
            this.dgvGecmis.Size = new System.Drawing.Size(880, 490);
            this.dgvGecmis.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblBaslik.Location = new System.Drawing.Point(15, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(83, 42);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "Ürün: -\nStok No: -";
            // 
            // lblToplamKayit
            // 
            this.lblToplamKayit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToplamKayit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblToplamKayit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblToplamKayit.Location = new System.Drawing.Point(718, 15);
            this.lblToplamKayit.Name = "lblToplamKayit";
            this.lblToplamKayit.Size = new System.Drawing.Size(136, 21);
            this.lblToplamKayit.TabIndex = 2;
            this.lblToplamKayit.Text = "Toplam 0 kayıt";
            this.lblToplamKayit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Location = new System.Drawing.Point(761, 527);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(115, 40);
            this.btnKapat.TabIndex = 3;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.lblToplamKayit);
            this.panel1.Controls.Add(this.lblBaslik);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 70);
            this.panel1.TabIndex = 4;
            // 
            // DurumGecmisiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.dgvGecmis);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DurumGecmisiForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Durum Geçmişi";
            this.Load += new System.EventHandler(this.DurumGecmisiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmis)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dgvGecmis;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblToplamKayit;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Panel panel1;
    }
}
