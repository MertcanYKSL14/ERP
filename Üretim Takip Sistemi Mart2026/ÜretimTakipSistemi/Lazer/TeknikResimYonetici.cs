using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ÜretimTakipSistemi.Lazer
{

    public static class TeknikResimYonetici
    {


        /// <summary>
        /// dgvUrunler'e sağ tık menüsü bağlar.
        /// </summary>
        /// <param name="dgvUrunler">Ürün listesi DataGridView</param>
        /// <param name="connectionString">SQL bağlantı dizesi</param>
        public static void Baslat(DataGridView dgvUrunler, string connectionString)
        {
            // ContextMenuStrip oluştur
            var ctxMenu = new ContextMenuStrip();

            var menuTeknikResimGor = new ToolStripMenuItem("📄 Teknik Resmi Gör");
            var menuTeknikResimEkle = new ToolStripMenuItem("➕ Teknik Resim Ekle / Güncelle");

            ctxMenu.Items.Add(menuTeknikResimGor);
            ctxMenu.Items.Add(menuTeknikResimEkle);

            // Menü açılmadan önce: seçili satır var mı kontrol et
            ctxMenu.Opening += (s, e) =>
            {
                bool satirSecili = dgvUrunler.SelectedRows.Count > 0;
                menuTeknikResimGor.Enabled = satirSecili;
                menuTeknikResimEkle.Enabled = satirSecili;

                if (satirSecili)
                {
                    // Teknik resim var mı? → menü başlığını güncelle
                    int urunID = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["UrunID"].Value);
                    bool pdfVar = TeknikResimVarMi(urunID, connectionString);
                    menuTeknikResimGor.Enabled = pdfVar;
                    menuTeknikResimGor.Text = pdfVar
                        ? "📄 Teknik Resmi Gör"
                        : "📄 Teknik Resmi Gör  (Henüz Eklenmedi)";
                    menuTeknikResimEkle.Text = pdfVar
                        ? "🔄 Teknik Resim Güncelle"
                        : "➕ Teknik Resim Ekle";
                }
            };

            // Menü olayları
            menuTeknikResimGor.Click += (s, e) =>
                TeknikResimGoster(dgvUrunler, connectionString);

            menuTeknikResimEkle.Click += (s, e) =>
                TeknikResimEkleGuncelle(dgvUrunler, connectionString);

            // dgvUrunler'e bağla — sadece sağ tıkta seçili satırı belirle
            dgvUrunler.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hitTest = dgvUrunler.HitTest(e.X, e.Y);
                    if (hitTest.RowIndex >= 0)
                    {
                        dgvUrunler.ClearSelection();
                        dgvUrunler.Rows[hitTest.RowIndex].Selected = true;
                    }
                }
            };

            dgvUrunler.ContextMenuStrip = ctxMenu;
        }

        /// <summary>
        /// Seçili ürünün PDF'ini geçici klasöre yazar ve varsayılan PDF okuyucuda açar.
        /// </summary>
        private static void TeknikResimGoster(DataGridView dgvUrunler, string connectionString)
        {
            if (dgvUrunler.SelectedRows.Count == 0) return;

            int urunID = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["UrunID"].Value);
            string urunAdi = dgvUrunler.SelectedRows[0].Cells["Ürün Adı"].Value?.ToString() ?? "Urun";

            try
            {
                byte[] pdfBytes = TeknikResimOku(urunID, connectionString);

                if (pdfBytes == null || pdfBytes.Length == 0)
                {
                    MessageBox.Show("Bu ürüne ait teknik resim bulunamadı.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Geçici dosyaya yaz
                string guvenliUrunAdi = string.Concat(urunAdi.Split(Path.GetInvalidFileNameChars()))
                              .Replace(" ", "_");
                string geciciDosya = Path.Combine(
                    Path.GetTempPath(),
                    $"TeknikResim_{guvenliUrunAdi}_{urunID}.pdf");

                File.WriteAllBytes(geciciDosya, pdfBytes);

                // Varsayılan PDF okuyucuyla aç
                Process.Start(new ProcessStartInfo
                {
                    FileName = geciciDosya,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Teknik resim açılırken hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Kullanıcıdan PDF seçmesini ister ve veritabanına kaydeder.
        /// </summary>
        private static void TeknikResimEkleGuncelle(DataGridView dgvUrunler, string connectionString)
        {
            if (dgvUrunler.SelectedRows.Count == 0) return;

            int urunID = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["UrunID"].Value);
            string urunAdi = dgvUrunler.SelectedRows[0].Cells["Ürün Adı"].Value?.ToString() ?? "";

            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = $"{urunAdi} — Teknik Resim (PDF) Seç";
                ofd.Filter = "PDF Dosyaları (*.pdf)|*.pdf";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    byte[] pdfBytes = File.ReadAllBytes(ofd.FileName);
                    string dosyaAdi = Path.GetFileName(ofd.FileName);

                    TeknikResimKaydet(urunID, pdfBytes, dosyaAdi, connectionString);

                    MessageBox.Show(
                        $"✅ Teknik resim başarıyla kaydedildi!\n\nDosya: {dosyaAdi}",
                        "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Teknik resim kaydedilirken hata: " + ex.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private static bool TeknikResimVarMi(int urunID, string connectionString)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {


                    conn.Open();
                    var cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Urunler WHERE UrunID = @ID AND TeknikResim IS NOT NULL",
                        conn);
                    cmd.Parameters.AddWithValue("@ID", urunID);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch { return false; }
        }

        private static byte[] TeknikResimOku(int urunID, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT TeknikResim FROM Urunler WHERE UrunID = @ID",
                    conn);
                cmd.Parameters.AddWithValue("@ID", urunID);

                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return null;
                return (byte[])result;
            }
        }

        private static void TeknikResimKaydet(int urunID, byte[] pdfBytes, string dosyaAdi, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"UPDATE Urunler 
                      SET TeknikResim = @PDF, 
                          TeknikResimDosyaAdi = @DosyaAdi,
                          GuncellemeTarihi = GETDATE()
                      WHERE UrunID = @ID",
                    conn);
                cmd.Parameters.AddWithValue("@PDF", pdfBytes);
                cmd.Parameters.AddWithValue("@DosyaAdi", dosyaAdi);
                cmd.Parameters.AddWithValue("@ID", urunID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}