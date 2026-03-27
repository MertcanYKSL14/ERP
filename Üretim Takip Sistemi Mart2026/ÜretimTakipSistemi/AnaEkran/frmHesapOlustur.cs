using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ÜretimTakipSistemi
{
    public partial class frmHesapOlustur : Form
    {
        // Bağlantı dizesi
        private readonly string connectionString = "Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Sac_Ambarı; User Id=ADMIN; Password=1;";

        public frmHesapOlustur()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. ADIM: Zorunlu Alan Kontrolü
            if (tbxKullaniciAdi.Text == "Kullanıcı Adı" || tbxKullaniciSifresi.Text == "Şifre" ||
                string.IsNullOrWhiteSpace(tbxKullaniciAdi.Text) || string.IsNullOrWhiteSpace(tbxKullaniciSifresi.Text))
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre alanları boş bırakılamaz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 2. ADIM: Kullanıcı Adı Kontrolü (Aynısından var mı?)
                    string checkSql = "SELECT COUNT(*) FROM [Users] WHERE [UserName] = @user";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@user", tbxKullaniciAdi.Text.Trim());
                        int userCount = (int)checkCmd.ExecuteScalar();
                        if (userCount > 0)
                        {
                            MessageBox.Show("Bu Kullanıcı Adı zaten kullanımda!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    // 3. ADIM: Kayıt İşlemi (Tüm parametreler dahil)
                    string insertSql = @"INSERT INTO [Users] ([UserName], [Password], [KullaniciAdi], [KullaniciSoyadi], [Departman], [Bolum]) 
                                        VALUES (@UserName, @Pass, @K_Adi, @K_Soyadi, @Dep, @Bol)";

                    using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", tbxKullaniciAdi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Pass", tbxKullaniciSifresi.Text);

                        // Placeholder kontrolü: Eğer kutuda varsayılan metin duruyorsa boş ("") kaydet
                        cmd.Parameters.AddWithValue("@K_Adi", tbxKisiAdi.Text == "Ad" ? "" : tbxKisiAdi.Text.Trim());
                        cmd.Parameters.AddWithValue("@K_Soyadi", tbxKisiSoyadi.Text == "Soyad" ? "" : tbxKisiSoyadi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Dep", tbxDepartman.Text == "Departman" ? "" : tbxDepartman.Text.Trim());
                        cmd.Parameters.AddWithValue("@Bol", tbxBolum.Text == "Bölüm" ? "" : tbxBolum.Text.Trim());

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Hesap başarıyla oluşturuldu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Başarılıysa formu kapat
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tbxTemizle();
        }

        // --- Yeni Eklenen tbxDepartman Placeholder Olayları ---

        private void tbxDepartman_Enter(object sender, EventArgs e)
        {
            if (tbxDepartman.Text == "Departman")
            {
                tbxDepartman.Text = "";
            }
        }

        private void tbxDepartman_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxDepartman.Text))
            {
                tbxDepartman.Text = "Departman";
            }
        }

        // --- Diğer Placeholder Olayları ---

        private void tbxKisiAdi_Enter(object sender, EventArgs e) { if (tbxKisiAdi.Text == "Ad") tbxKisiAdi.Text = ""; }
        private void tbxKisiAdi_Leave(object sender, EventArgs e) { if (string.IsNullOrWhiteSpace(tbxKisiAdi.Text)) tbxKisiAdi.Text = "Ad"; }

        private void tbxKisiSoyadi_Enter(object sender, EventArgs e) { if (tbxKisiSoyadi.Text == "Soyad") tbxKisiSoyadi.Text = ""; }
        private void tbxKisiSoyadi_Leave(object sender, EventArgs e) { if (string.IsNullOrWhiteSpace(tbxKisiSoyadi.Text)) tbxKisiSoyadi.Text = "Soyad"; }

        private void tbxKullaniciAdi_Enter(object sender, EventArgs e) { if (tbxKullaniciAdi.Text == "Kullanıcı Adı") tbxKullaniciAdi.Text = ""; }
        private void tbxKullaniciAdi_Leave(object sender, EventArgs e) { if (string.IsNullOrWhiteSpace(tbxKullaniciAdi.Text)) tbxKullaniciAdi.Text = "Kullanıcı Adı"; }

        private void tbxKullaniciSifresi_Enter(object sender, EventArgs e)
        {
            if (tbxKullaniciSifresi.Text == "Şifre") { tbxKullaniciSifresi.Text = ""; tbxKullaniciSifresi.UseSystemPasswordChar = true; }
        }
        private void tbxKullaniciSifresi_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxKullaniciSifresi.Text)) { tbxKullaniciSifresi.Text = "Şifre"; tbxKullaniciSifresi.UseSystemPasswordChar = false; }
        }

        private void tbxBolum_Enter(object sender, EventArgs e) { if (tbxBolum.Text == "Bölüm") tbxBolum.Text = ""; }
        private void tbxBolum_Leave(object sender, EventArgs e) { if (string.IsNullOrWhiteSpace(tbxBolum.Text)) tbxBolum.Text = "Bölüm"; }

        public void tbxTemizle()
        {
            tbxKullaniciAdi.Text = "Kullanıcı Adı";
            tbxKullaniciSifresi.Text = "Şifre";
            tbxKisiAdi.Text = "Ad";
            tbxKisiSoyadi.Text = "Soyad";
            tbxDepartman.Text = "Departman";
            tbxBolum.Text = "Bölüm";
        }

        private void frmHesapOlustur_Load(object sender, EventArgs e)
        {
            tbxKullaniciAdi.Focus();
        }
    }
}
