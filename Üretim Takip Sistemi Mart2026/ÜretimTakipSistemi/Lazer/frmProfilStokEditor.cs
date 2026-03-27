using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ÜretimTakipSistemi.Lazer
{
    public partial class frmProfilStokEditor : Form
    {
        private readonly string connectionString = "Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Lazer; User Id=ADMIN; Password=1;";
        private readonly int? initialProfilId;
        private readonly string initialProfilEbati;

        private SqlDataAdapter da;
        private SqlCommandBuilder cb;
        private DataTable dt;

        public frmProfilStokEditor()
            : this(null, null)
        {
        }

        public frmProfilStokEditor(int? profilId, string profilEbati)
        {
            InitializeComponent();
            initialProfilId = profilId;
            initialProfilEbati = profilEbati;
            ConfigureFormAppearance();
            Load += frmProfilStokEditor_Load;
        }

        private void frmProfilStokEditor_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ConfigureFormAppearance()
        {
            BackColor = Color.FromArgb(240, 244, 248);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);

            pnlTop.BackColor = Color.White;
            pnlBottom.BackColor = Color.White;

            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);

            ConfigureButton(btnAdd, Color.FromArgb(41, 128, 185));
            ConfigureButton(btnDelete, Color.FromArgb(192, 57, 43));
            ConfigureButton(btnSave, Color.FromArgb(39, 174, 96));

            dgvStok.BackgroundColor = BackColor;
            dgvStok.BorderStyle = BorderStyle.None;
            dgvStok.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStok.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvStok.EnableHeadersVisualStyles = false;
            dgvStok.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvStok.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStok.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvStok.ColumnHeadersHeight = 42;
            dgvStok.DefaultCellStyle.BackColor = Color.White;
            dgvStok.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            dgvStok.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
            dgvStok.DefaultCellStyle.SelectionForeColor = Color.FromArgb(44, 62, 80);
            dgvStok.DefaultCellStyle.Padding = new Padding(4);
            dgvStok.RowTemplate.Height = 34;
        }

        private void ConfigureButton(Button button, Color backColor)
        {
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    const string query = "SELECT * FROM ProfilStok ORDER BY ProfilEbati";
                    da = new SqlDataAdapter(query, conn);
                    cb = new SqlCommandBuilder(da);

                    dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Columns.Contains("KayitTarihi"))
                    {
                        dt.Columns["KayitTarihi"].DefaultValue = DateTime.Now;
                    }

                    if (dt.Columns.Contains("GuncellemeTarihi"))
                    {
                        dt.Columns["GuncellemeTarihi"].DefaultValue = DateTime.Now;
                    }

                    if (dt.Columns.Contains("StokAdedi"))
                    {
                        dt.Columns["StokAdedi"].DefaultValue = 0;
                    }

                    if (dt.Columns.Contains("MinimumStok"))
                    {
                        dt.Columns["MinimumStok"].DefaultValue = 10;
                    }

                    dgvStok.DataSource = dt.DefaultView;
                    ConfigureGridColumns();
                    ApplyInitialFocus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGridColumns()
        {
            if (dgvStok.Columns.Count == 0)
            {
                return;
            }

            if (dgvStok.Columns.Contains("ProfilID"))
            {
                dgvStok.Columns["ProfilID"].Visible = false;
            }

            SetColumn("ProfilEbati", "Profil Ebatı (mm)", false);
            SetColumn("ProfilUzunlugu", "Boy (mm)", false);
            SetColumn("StokAdedi", "Stok Adedi", false);
            SetColumn("MinimumStok", "Min. Stok", false);
            SetColumn("BirimFiyat", "Birim Fiyat (TL)", false);
            SetColumn("KayitTarihi", "Kayıt Tarihi", true);
            SetColumn("GuncellemeTarihi", "Son Güncelleme", true);
        }

        private void SetColumn(string columnName, string headerText, bool readOnly)
        {
            if (!dgvStok.Columns.Contains(columnName))
            {
                return;
            }

            DataGridViewColumn column = dgvStok.Columns[columnName];
            column.HeaderText = headerText;
            column.ReadOnly = readOnly;

            if (columnName.Contains("Tarihi"))
            {
                column.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
        }

        private void ApplyInitialFocus()
        {
            if (!string.IsNullOrWhiteSpace(initialProfilEbati))
            {
                txtSearch.Text = initialProfilEbati;
            }

            if (!initialProfilId.HasValue)
            {
                return;
            }

            foreach (DataGridViewRow row in dgvStok.Rows)
            {
                if (row.IsNewRow || row.Cells["ProfilID"].Value == null)
                {
                    continue;
                }

                if (Convert.ToInt32(row.Cells["ProfilID"].Value) == initialProfilId.Value)
                {
                    row.Selected = true;
                    dgvStok.CurrentCell = row.Cells["ProfilEbati"];
                    dgvStok.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (dt == null)
            {
                return;
            }

            DataRow newRow = dt.NewRow();
            if (dt.Columns.Contains("KayitTarihi"))
            {
                newRow["KayitTarihi"] = DateTime.Now;
            }

            if (dt.Columns.Contains("GuncellemeTarihi"))
            {
                newRow["GuncellemeTarihi"] = DateTime.Now;
            }

            if (dt.Columns.Contains("StokAdedi"))
            {
                newRow["StokAdedi"] = 0;
            }

            if (dt.Columns.Contains("MinimumStok"))
            {
                newRow["MinimumStok"] = 10;
            }

            dt.Rows.Add(newRow);
            txtSearch.Clear();
            dgvStok.ClearSelection();

            int lastIndex = dgvStok.Rows.Count - 1;
            if (lastIndex >= 0)
            {
                dgvStok.CurrentCell = dgvStok.Rows[lastIndex].Cells["ProfilEbati"];
                dgvStok.BeginEdit(true);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStok.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Seçili profilleri silmek istediğinize emin misiniz?\nİşlem kaydet butonuna bastığınızda veritabanına yansıyacaktır.",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            foreach (DataGridViewRow row in dgvStok.SelectedRows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                DataRowView rowView = row.DataBoundItem as DataRowView;
                rowView?.Row.Delete();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (dt == null || da == null)
            {
                return;
            }

            dgvStok.EndEdit();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    if (da.SelectCommand == null)
                    {
                        da.SelectCommand = new SqlCommand("SELECT * FROM ProfilStok", conn);
                    }
                    else
                    {
                        da.SelectCommand.Connection = conn;
                    }

                    cb = new SqlCommandBuilder(da);

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row.RowState == DataRowState.Modified && dt.Columns.Contains("GuncellemeTarihi"))
                        {
                            row["GuncellemeTarihi"] = DateTime.Now;
                        }
                    }

                    da.Update(dt);

                    MessageBox.Show("Tüm değişiklikler başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydetme sırasında hata:\n" + ex.Message, "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dt == null)
            {
                return;
            }

            try
            {
                string filter = txtSearch.Text.Trim().Replace("'", "''");
                DataView view = dt.DefaultView;
                view.RowFilter = string.IsNullOrWhiteSpace(filter)
                    ? string.Empty
                    : string.Format("ProfilEbati LIKE '%{0}%'", filter);
                dgvStok.DataSource = view;
                ConfigureGridColumns();
            }
            catch
            {
            }
        }

        private void DgvStok_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
