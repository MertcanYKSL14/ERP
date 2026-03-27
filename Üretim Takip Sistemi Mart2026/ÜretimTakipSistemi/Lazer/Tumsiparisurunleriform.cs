using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;

namespace ÜretimTakipSistemi.Lazer
{
    public class TumSiparisUrunleriForm : Form
    {
        private string connectionString;
        private readonly ITumSiparisUrunleriService _tumSiparisUrunleriService;
        private DataGridView dgvTumUrunler;
        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlFilter;
        private ComboBox cmbDurumFiltre;
        private TextBox txtAra;
        private Label lblAra;
        private Label lblDurum;
        private Panel pnlButtons;
        private Button btnYenile;
        private Button btnKapat;
        private Label lblAciklama;

        public TumSiparisUrunleriForm(string connStr)
        {
            connectionString = connStr;
            _tumSiparisUrunleriService = InstanceFactory.GetInstance<ITumSiparisUrunleriService>();
            UIKurulum();
            this.Load += TumSiparisUrunleriForm_Load;

        }

        private void UIKurulum()
        {
            this.Text = "Tüm Sipariş Ürünleri";
            this.ClientSize = new Size(1200, 700);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(236, 240, 245);

            // Header
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(0, 122, 204)
            };
            lblTitle = new Label
            {
                Text = "📋 TÜM SİPARİŞ ÜRÜNLERİ",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(15, 15)
            };
            pnlHeader.Controls.Add(lblTitle);

            // Filtre paneli
            pnlFilter = new Panel
            {
                Dock = DockStyle.Top,
                Height = 55,
                BackColor = Color.White,
                Padding = new Padding(10, 8, 10, 8)
            };

            lblAra = new Label { Text = "Ara:", Location = new Point(15, 18), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };
            txtAra = new TextBox { Location = new Point(50, 15), Size = new Size(200, 25), Font = new Font("Segoe UI", 10F) };
            txtAra.TextChanged += (s, e) => UygulaTumFiltreler();

            lblDurum = new Label { Text = "Durum:", Location = new Point(270, 18), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };
            cmbDurumFiltre = new ComboBox { Location = new Point(330, 15), Size = new Size(150, 25), Font = new Font("Segoe UI", 10F), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbDurumFiltre.Items.AddRange(new object[] { "Tümü", "Beklemede", "Üretiliyor", "Tamamlandı" });
            cmbDurumFiltre.SelectedIndex = 0;
            cmbDurumFiltre.SelectedIndexChanged += (s, e) => UygulaTumFiltreler();

            // Renk açıklaması
            lblAciklama = new Label
            {
                Text = "🔴 Tarihi Geçmiş  🟠 3 Gün İçinde  🟡 7 Gün İçinde  🟢 Normal",
                Location = new Point(500, 18),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F)
            };

            pnlFilter.Controls.AddRange(new Control[] { lblAra, txtAra, lblDurum, cmbDurumFiltre, lblAciklama });

            // DataGridView
            dgvTumUrunler = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                AlternatingRowsDefaultCellStyle = { BackColor = Color.FromArgb(245, 247, 250) },
                GridColor = Color.LightGray,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            };
            dgvTumUrunler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvTumUrunler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTumUrunler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTumUrunler.EnableHeadersVisualStyles = false;
            dgvTumUrunler.RowTemplate.Height = 35;
            dgvTumUrunler.CellFormatting += DgvTumUrunler_CellFormatting;
            dgvTumUrunler.CellDoubleClick += DgvTumUrunler_CellDoubleClick;
            dgvTumUrunler.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

            // Alt butonlar
            pnlButtons = new Panel { Dock = DockStyle.Bottom, Height = 60, Padding = new Padding(15, 10, 15, 10) };
            btnYenile = new Button
            {
                Text = "🔄 Yenile",
                Location = new Point(15, 12),
                Size = new Size(150, 38),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnYenile.FlatAppearance.BorderSize = 0;
            btnYenile.Click += (s, e) => VerileriYukle();

            btnKapat = new Button
            {
                Text = "✗ Kapat",
                Location = new Point(175, 12),
                Size = new Size(150, 38),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnKapat.FlatAppearance.BorderSize = 0;
            btnKapat.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };

            pnlButtons.Controls.Add(btnYenile);
            pnlButtons.Controls.Add(btnKapat);

            // Kontrolleri forma ekle
            this.Controls.Add(dgvTumUrunler);
            this.Controls.Add(pnlFilter);
            this.Controls.Add(pnlButtons);
            this.Controls.Add(pnlHeader);
        }

        private void TumSiparisUrunleriForm_Load(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        private void VerileriYukle()
        {
            try
            {
                DataTable tablo = _tumSiparisUrunleriService.GetTumSiparisUrunleri(connectionString);

                dgvTumUrunler.DataSource = tablo;
                if (dgvTumUrunler.Columns.Contains("SiparisDetayID"))
                    dgvTumUrunler.Columns["SiparisDetayID"].Visible = false;
                if (dgvTumUrunler.Columns.Contains("SiparisID"))
                    dgvTumUrunler.Columns["SiparisID"].Visible = false;

                if (dgvTumUrunler.Columns.Contains("Teslim Tarihi"))
                {
                    dgvTumUrunler.Columns["Teslim Tarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UygulaTumFiltreler()
        {
            if (!(dgvTumUrunler.DataSource is DataTable dt)) return;

            string aranan = txtAra.Text.Trim().Replace("'", "''");
            string durum = cmbDurumFiltre.SelectedItem?.ToString() ?? "Tümü";

            var filtreler = new System.Collections.Generic.List<string>();

            if (!string.IsNullOrEmpty(aranan))
                filtreler.Add($"([Ürün Kodu] LIKE '%{aranan}%' OR [Ürün Adı] LIKE '%{aranan}%' OR [Sipariş No] LIKE '%{aranan}%' OR [Müşteri] LIKE '%{aranan}%')");

            if (durum != "Tümü")
                filtreler.Add($"[Durum] = '{durum}'");

            dt.DefaultView.RowFilter = filtreler.Count > 0 ? string.Join(" AND ", filtreler) : string.Empty;
        }

        /// <summary>
        /// Teslim tarihi renklendirmesi:
        /// - Geçmiş tarih → kırmızı
        /// - 3 gün kalan → turuncu
        /// - 7 gün kalan → sarı
        /// - Normal → yeşil
        /// - Durum renklendirmesi de korundu
        /// </summary>
        private void DgvTumUrunler_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string kolonAdi = dgvTumUrunler.Columns[e.ColumnIndex].Name;

            if (kolonAdi == "Teslim Tarihi")
            {
                if (e.Value == null || e.Value == DBNull.Value || string.IsNullOrWhiteSpace(e.Value.ToString()))
                    return;

                bool tarihGecerli = e.Value is DateTime
                    ? true
                    : DateTime.TryParse(e.Value.ToString(), out _);

                DateTime teslim = e.Value is DateTime
                    ? (DateTime)e.Value
                    : DateTime.Parse(e.Value.ToString());

                int kalanGun = (teslim - DateTime.Today).Days;

                if (kalanGun < 0)
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 80, 80);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.Font = new Font(dgvTumUrunler.Font, FontStyle.Bold);
                    e.Value = teslim.ToString("dd.MM.yyyy") + $"  ({-kalanGun}g geçti)";
                    e.FormattingApplied = true;
                }
                else if (kalanGun <= 3)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 140, 0);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.Font = new Font(dgvTumUrunler.Font, FontStyle.Bold);
                    e.Value = teslim.ToString("dd.MM.yyyy") + $"  ({kalanGun}g kaldı)";
                    e.FormattingApplied = true;
                }
                else if (kalanGun <= 7)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 230, 80);
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.Font = new Font(dgvTumUrunler.Font, FontStyle.Bold);
                    e.Value = teslim.ToString("dd.MM.yyyy") + $"  ({kalanGun}g kaldı)";
                    e.FormattingApplied = true;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(200, 240, 200);
                    e.CellStyle.ForeColor = Color.FromArgb(0, 100, 0);
                }
            }
            else if (kolonAdi == "Durum")
            {
                string deger = e.Value.ToString();
                switch (deger)
                {
                    case "Beklemede":
                        e.CellStyle.BackColor = Color.FromArgb(255, 220, 150);
                        e.CellStyle.ForeColor = Color.FromArgb(100, 60, 0);
                        break;
                    case "Üretiliyor":
                        e.CellStyle.BackColor = Color.FromArgb(180, 220, 255);
                        e.CellStyle.ForeColor = Color.FromArgb(0, 50, 120);
                        break;
                    case "Tamamlandı":
                        e.CellStyle.BackColor = Color.FromArgb(180, 240, 180);
                        e.CellStyle.ForeColor = Color.FromArgb(0, 100, 0);
                        break;
                }
            }
        }
        private void DgvTumUrunler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int seciliSiparisID = Convert.ToInt32(dgvTumUrunler.Rows[e.RowIndex].Cells["SiparisID"].Value);
                SiparisDetayForm detayForm = new SiparisDetayForm(connectionString, seciliSiparisID);
                detayForm.ShowDialog();
                VerileriYukle();
            }
        }


    }
}
