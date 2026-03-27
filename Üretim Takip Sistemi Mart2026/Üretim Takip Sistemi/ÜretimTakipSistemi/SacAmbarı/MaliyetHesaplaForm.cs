using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ÜretimTakipSistemi.SacAmbarı
{
    public partial class MaliyetHesaplaForm : Form
    {
        private string connectionString = @"Data Source=192.168.1.144,1433;Initial Catalog=UrunAgaciDB;User ID=ADMIN;Password=1;MultipleActiveResultSets=True;";
        private DataTable dtMaliyet;

        public MaliyetHesaplaForm()
        {
            InitializeComponent();
            SetupDataTable();
        }

        private void SetupDataTable()
        {
            dtMaliyet = new DataTable();
            dtMaliyet.Columns.Add("Parça Adı");
            dtMaliyet.Columns.Add("Miktar", typeof(decimal));
            dtMaliyet.Columns.Add("Birim Fiyat", typeof(decimal));
            dtMaliyet.Columns.Add("Toplam", typeof(decimal));
            dgvMaliyet.DataSource = dtMaliyet;
        }

        // --- TEK BUTON: HEM BULUR HEM HESAPLAR ---
        private void btnMaliyetHesapla_Click(object sender, EventArgs e)
        {
            string arananKod = txtUrunKodu.Text.Trim();

            if (string.IsNullOrEmpty(arananKod))
            {
                MessageBox.Show("Lütfen bir ürün kodu girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // 1. Ürünü koduna göre ara
                    string query = "SELECT UrunID, UrunAdi FROM Urunler WHERE UrunKodu = @Kod";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Kod", arananKod);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        int urunID = (int)dr["UrunID"];
                        string urunAdi = dr["UrunAdi"].ToString();
                        dr.Close();

                        // 2. Tabloyu temizle ve hesaplamayı başlat
                        dtMaliyet.Rows.Clear();
                        decimal toplamMaliyet = HesaplaRecursive(urunID, 1);

                        // 3. İSTEDİĞİNİZ FORMATTA YAZDIRMA
                        lblToplamMaliyet.Text = $"{urunAdi} ({arananKod}) - Toplam Maliyet: {toplamMaliyet:N2} TL";
                    }
                    else
                    {
                        lblToplamMaliyet.Text = "Ürün bulunamadı!";
                        MessageBox.Show("Girdiğiniz kodda bir ürün sistemde kayıtlı değil.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private decimal HesaplaRecursive(int parentID, decimal parentMiktar)
        {
            decimal altToplam = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT u.UrunID, u.UrunAdi, u.BirimFiyat, ua.Miktar 
                                FROM UrunAgaci ua 
                                INNER JOIN Urunler u ON ua.AltUrunID = u.UrunID 
                                WHERE ua.AnaUrunID = @ParentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ParentID", parentID);
                    List<dynamic> children = new List<dynamic>();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            children.Add(new
                            {
                                ID = (int)dr["UrunID"],
                                Ad = dr["UrunAdi"].ToString(),
                                Fiyat = (decimal)dr["BirimFiyat"],
                                Miktar = (decimal)dr["Miktar"]
                            });
                        }
                    }

                    foreach (var item in children)
                    {
                        decimal gercekMiktar = item.Miktar * parentMiktar;
                        decimal maliyet = gercekMiktar * item.Fiyat;

                        dtMaliyet.Rows.Add(item.Ad, gercekMiktar, item.Fiyat, maliyet);

                        // Özyinelemeli maliyet toplama
                        altToplam += maliyet + HesaplaRecursive(item.ID, gercekMiktar);
                    }
                }
            }
            return altToplam;
        }
    }
}
   