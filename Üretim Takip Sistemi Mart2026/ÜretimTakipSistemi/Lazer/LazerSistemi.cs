using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ÜretimTakipSistemi.Lazer
{
    public partial class LazerSistemi : Form
    {
        // SQL Server Bağlantı Bilgileri (Kendi sunucuna göre düzenle)
        string connStr = "Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=SiparisDB; User Id=ADMIN; Password=1;";

        public LazerSistemi()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT ProductCode FROM Products", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) cmbProducts.Items.Add(dr["ProductCode"].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("Bağlantı Hatası: " + ex.Message); }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem == null || !int.TryParse(txtOrderQty.Text, out int orderQty)) return;

            string selectedProduct = cmbProducts.SelectedItem.ToString();
            DataTable dt = new DataTable();
            dt.Columns.Add("Bileşen");
            dt.Columns.Add("Profil Tipi");
            dt.Columns.Add("Birim Uzunluk (mm)");
            dt.Columns.Add("Toplam İhtiyaç (mm)");
            dt.Columns.Add("Gereken Boy (6m)");
            dt.Columns.Add("Stok (Boy)");
            dt.Columns.Add("Durum");

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM BillOfMaterials WHERE ParentProductCode = @code";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code", selectedProduct);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string component = dr["PartCode"].ToString();
                    string profile = dr["ProfileType"].ToString();
                    double len = Convert.ToDouble(dr["LengthMM"]);
                    int qtyPer = Convert.ToInt32(dr["Quantity"]);

                    double totalLen = len * qtyPer * orderQty;
                    int reqSticks = (int)Math.Ceiling(totalLen / 6000);

                    // Stok bilgisini alt sorguyla alalım
                    int stockSticks = GetCurrentStock(profile);

                    string status = (stockSticks >= reqSticks) ? "TAMAM" : "STOK YETERSİZ";
                    dt.Rows.Add(component, profile, len, totalLen, reqSticks, stockSticks, status);
                }
            }
            dgvResults.DataSource = dt;
            FormatGridRows();
        }

        private int GetCurrentStock(string profileType)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT StockCount FROM Stocks WHERE ProfileType = @pt", conn);
                cmd.Parameters.AddWithValue("@pt", profileType);
                object res = cmd.ExecuteScalar();
                return res != null ? Convert.ToInt32(res) : 0;
            }
        }

        private void FormatGridRows()
        {
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                if (row.Cells["Durum"].Value.ToString() == "STOK YETERSİZ")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200); // Açık Kırmızı
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200); // Açık Yeşil
                }
            }
        }
    }
}
