using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using ExcelDataReader;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;
using ÜretimTakipSistemi.Siparis;
using System.ComponentModel;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using SiparisEntity = ÜretimTakipSistemi.Entities.Concrete.Siparis;
using SiparisExcelSatirEntity = ÜretimTakipSistemi.Entities.Concrete.SiparisExcelSatir;
using SiparisIhtiyacSonucEntity = ÜretimTakipSistemi.Entities.Concrete.SiparisIhtiyacSonuc;
using SiparisIhtiyacTalepEntity = ÜretimTakipSistemi.Entities.Concrete.SiparisIhtiyacTalep;
using SiparisImportSonucEntity = ÜretimTakipSistemi.Entities.Concrete.SiparisImportSonuc;
using SiparisKpiOzetEntity = ÜretimTakipSistemi.Entities.Concrete.SiparisKpiOzet;

namespace ÜretimTakipSistemi.Siparis
{
    public partial class SiparisAnaForm : Form
    {
        private static readonly Dictionary<string, string> SiparisGridBasliklari = new Dictionary<string, string>
        {
            { "StokNo", "Stok Kodu" },
            { "MusteriAdi", "Müşteri" },
            { "ParcaAdi", "Parça Adı" },
            { "Bolum", "Bölüm" },
            { "SiparisAdeti", "Adet" },
            { "Durum", "Durum" },
            { "KayitTarihi", "Tarih" }
        };

        DataTable tablo = new DataTable();
        DataView dv;
        private readonly ISiparisService _siparisService;

        public SiparisAnaForm()
        {
            InitializeComponent();
            _siparisService = InstanceFactory.GetInstance<ISiparisService>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void SiparisAnaForm_Load(object sender, EventArgs e)
        {
            // Tarih filtrelerini ayarla (Son 30 gün)
            dtBaslangic.Value = DateTime.Now.AddDays(-30);
            dtBitis.Value = DateTime.Now;

            // Grid ayarları
            dgvSiparisler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSiparisler.MultiSelect = true;

            VerileriGetir();
            KPIGuncelle();
        }

        // --- VERİ TABANI İŞLEMLERİ ---

        void VerileriGetir()
        {
            try
            {
                DateTime baslangic = dtBaslangic.Value.Date;
                DateTime bitis = dtBitis.Value.Date.AddDays(1).AddSeconds(-1);

                var siparisler = _siparisService.GetByDateRange(baslangic, bitis);

                tablo = SiparisGridTableHelper.SiparisleriDataTableaDonustur(siparisler);
                dv = new DataView(tablo);
                dgvSiparisler.DataSource = dv;

                GridKolonAyarla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri hatası: " + ex.Message);
            }
        }

        void GridKolonAyarla()
        {
            SiparisGridColumnHelper.Uygula(dgvSiparisler, SiparisGridBasliklari);
        }

        void KPIGuncelle()
        {
            try
            {
                SiparisKpiOzetEntity kpiOzet = _siparisService.GetKpiOzet();

                lblKPITotalVal.Text = kpiOzet.ToplamSiparisSayisi.ToString();
                lblKPIPendingVal.Text = kpiOzet.BekleyenSiparisSayisi.ToString();
                lblKPITodayVal.Text = kpiOzet.BugunIhtiyacSayisi.ToString();
            }
            catch
            {
                lblKPITotalVal.Text = "-";
                lblKPIPendingVal.Text = "-";
                lblKPITodayVal.Text = "-";
            }
        }

        // --- EXCEL YÜKLEME ---

        private void btnExcelYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Dosyası |*.xlsx; *.xls";
            ofd.Title = "Sipariş Excel Dosyasını Seçin";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });

                    if (!result.Tables.Contains("Sayfa1"))
                    {
                        MessageBox.Show("Hata: Excel dosyasında 'Sayfa1' isimli sayfa bulunamadı!", "Format Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataTable excelTablosu = result.Tables["Sayfa1"];
                    ExceliVeritabaninaAktar(excelTablosu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel Okuma Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExceliVeritabaninaAktar(DataTable dt)
        {
            try
            {
                List<SiparisExcelSatirEntity> satirlar = new List<SiparisExcelSatirEntity>();

                foreach (DataRow row in dt.Rows)
                {
                    if (row["STOK NO"] == DBNull.Value || string.IsNullOrWhiteSpace(row["STOK NO"].ToString()))
                    {
                        continue;
                    }

                    satirlar.Add(new SiparisExcelSatirEntity
                    {
                        StokNo = row["STOK NO"].ToString().Trim(),
                        ParcaAdi = row["MALZEME TANIMI"]?.ToString().Trim(),
                        Bolum = row["BÖLÜM"]?.ToString().Trim(),
                        Adet = ParseAdet(row["TOPLAM"])
                    });
                }

                SiparisImportSonucEntity sonuc = _siparisService.ImportSiparisler(satirlar);

                MessageBox.Show($"İşlem Tamamlandı!\nEklenen: {sonuc.Eklenen}\nGüncellenen: {sonuc.Guncellenen}\nSilinen: {sonuc.Silinen}",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerileriGetir();
                KPIGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel aktarım hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ParseAdet(object val)
        {
            if (val == DBNull.Value) return 0;
            string deger = val.ToString().Replace(".", "").Replace(",", ".");
            if (double.TryParse(deger, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double adetRaw))
            {
                return Convert.ToInt32(Math.Round(adetRaw));
            }
            return 0;
        }

        // --- ÇOKLU SEÇİM İHTİYAÇ HESAPLAMA ---

        private void dgvSiparisler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSiparisler.SelectedRows.Count > 0)
            {
                // Seçilen ürünleri topla (aynı ürünleri birleştir)
                Dictionary<string, int> urunAdetleri = new Dictionary<string, int>();

                foreach (DataGridViewRow row in dgvSiparisler.SelectedRows)
                {
                    string stokNo = row.Cells["StokNo"].Value?.ToString();
                    string adetStr = row.Cells["SiparisAdeti"].Value?.ToString();
                    string parcaAdi = row.Cells["ParcaAdi"].Value?.ToString();

                    if (!string.IsNullOrEmpty(stokNo) && !string.IsNullOrEmpty(adetStr))
                    {
                        int adet = Convert.ToInt32(adetStr);
                        if (urunAdetleri.ContainsKey(stokNo))
                        {
                            urunAdetleri[stokNo] += adet;
                        }
                        else
                        {
                            urunAdetleri.Add(stokNo, adet);
                        }
                    }
                }

                // Başlığı güncelle
                if (urunAdetleri.Count == 1)
                {
                    var urun = urunAdetleri.First();
                    lblIhtiyacAnalizi.Text = $"📋 Stok Analizi: {urun.Key} ({urun.Value} Adet)";
                }
                else
                {
                    lblIhtiyacAnalizi.Text = $"📋 Stok Analizi: {urunAdetleri.Count} ürün seçildi";
                }

                IhtiyacListesiniGetir(urunAdetleri);
            }
            else
            {
                dgvIhtiyaclar.DataSource = null;
                lblIhtiyacAnalizi.Text = "📋 Stok Analizi: Ürün seçiniz";
                lblKPITodayVal.Text = "0";
            }
        }

        private void IhtiyacListesiniGetir(Dictionary<string, int> urunAdetleri)
        {
            try
            {
                List<SiparisIhtiyacTalepEntity> talepler = urunAdetleri
                    .Select(x => new SiparisIhtiyacTalepEntity
                    {
                        StokNo = x.Key,
                        Adet = x.Value
                    })
                    .ToList();

                var ihtiyaclar = _siparisService.GetIhtiyacListesi(talepler);
                DataTable dtTumIhtiyaclar = IhtiyaclariDataTableaDonustur(ihtiyaclar);

                dgvIhtiyaclar.DataSource = dtTumIhtiyaclar;
                lblKPITodayVal.Text = dtTumIhtiyaclar.Rows.Count.ToString();
                lblKPIToday.Text = "IHTIYAC LISTESI";

                RenklendirGereksinimler();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesaplama hatası: " + ex.Message);
            }
        }

        private DataTable IhtiyaclariDataTableaDonustur(IEnumerable<SiparisIhtiyacSonucEntity> ihtiyaclar)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("UrunKodu", typeof(string));
            dataTable.Columns.Add("UrunAdi", typeof(string));
            dataTable.Columns.Add("BirimSarfiyat", typeof(decimal));
            dataTable.Columns.Add("ToplamIhtiyac", typeof(decimal));
            dataTable.Columns.Add("MevcutStok", typeof(decimal));
            dataTable.Columns.Add("KalanStok", typeof(decimal));
            dataTable.Columns.Add("Durum", typeof(string));
            dataTable.Columns.Add("Aciliyet", typeof(string));

            foreach (SiparisIhtiyacSonucEntity ihtiyac in ihtiyaclar)
            {
                dataTable.Rows.Add(
                    ihtiyac.UrunKodu,
                    ihtiyac.UrunAdi,
                    ihtiyac.BirimSarfiyat,
                    ihtiyac.ToplamIhtiyac,
                    ihtiyac.MevcutStok,
                    ihtiyac.KalanStok,
                    ihtiyac.Durum,
                    ihtiyac.Aciliyet);
            }

            return dataTable;
        }

        private void RenklendirGereksinimler()
        {
            foreach (DataGridViewRow row in dgvIhtiyaclar.Rows)
            {
                if (row.Cells["KalanStok"].Value != null && row.Cells["KalanStok"].Value != DBNull.Value)
                {
                    decimal kalan = Convert.ToDecimal(row.Cells["KalanStok"].Value);
                    string durum = row.Cells["Durum"].Value?.ToString();

                    switch (durum)
                    {
                        case "EKSIK":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 99, 71); // Kırmızı
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        case "AZ":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 215, 0); // Sarı/Altın
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case "ORTA":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 165, 0); // Turuncu
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        case "YETERLI":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(60, 179, 113); // Yeşil
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                    }
                }
            }
        }

        // --- FİLTRE VE ARAMA ---

        private void btnListele_Click(object sender, EventArgs e)
        {
            VerileriGetir();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (dv != null)
            {
                SiparisGridFilterHelper.Uygula(dv, txtArama.Text, "StokNo", "MusteriAdi", "ParcaAdi");
            }
        }

        // --- EXCEL'E AKTARIM ---

        private void btnDisaAktar_Click(object sender, EventArgs e)
        {
            if (dgvIhtiyaclar.Rows.Count == 0) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyası|*.xlsx";
            sfd.FileName = $"Ihtiyac_Analizi_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("İhtiyaç Analizi");

                        // Başlık
                        worksheet.Cells[1, 1].Value = "İHTİYAÇ ANALİZİ RAPORU";
                        worksheet.Cells[1, 1, 1, 8].Merge = true;
                        worksheet.Cells[1, 1].Style.Font.Bold = true;
                        worksheet.Cells[1, 1].Style.Font.Size = 16;
                        worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        // Alt başlık
                        worksheet.Cells[2, 1].Value = $"Oluşturulma Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}";
                        worksheet.Cells[2, 1, 2, 8].Merge = true;
                        worksheet.Cells[2, 1].Style.Font.Italic = true;

                        // Kolon başlıkları
                        string[] headers = { "Ürün Kodu", "Ürün Adı", "Birim Sarfiyat", "Toplam İhtiyaç", "Mevcut Stok", "Kalan Stok", "Durum", "Aciliyet" };
                        for (int i = 0; i < headers.Length; i++)
                        {
                            worksheet.Cells[4, i + 1].Value = headers[i];
                            worksheet.Cells[4, i + 1].Style.Font.Bold = true;
                            worksheet.Cells[4, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            worksheet.Cells[4, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                            worksheet.Cells[4, i + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }

                        // Veriler
                        int rowIndex = 5;
                        foreach (DataGridViewRow gridRow in dgvIhtiyaclar.Rows)
                        {
                            for (int colIndex = 0; colIndex < headers.Length; colIndex++)
                            {
                                worksheet.Cells[rowIndex, colIndex + 1].Value = gridRow.Cells[colIndex].Value;
                                worksheet.Cells[rowIndex, colIndex + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            }

                            // Renklendirme
                            string durum = gridRow.Cells["Durum"].Value?.ToString();
                            var cellRange = worksheet.Cells[rowIndex, 1, rowIndex, headers.Length];

                            switch (durum)
                            {
                                case "EKSIK":
                                    cellRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    cellRange.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 99, 71));
                                    cellRange.Style.Font.Color.SetColor(Color.White);
                                    break;
                                case "AZ":
                                    cellRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    cellRange.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 215, 0));
                                    break;
                                case "ORTA":
                                    cellRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    cellRange.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 165, 0));
                                    cellRange.Style.Font.Color.SetColor(Color.White);
                                    break;
                                case "YETERLI":
                                    cellRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    cellRange.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(60, 179, 113));
                                    cellRange.Style.Font.Color.SetColor(Color.White);
                                    break;
                            }

                            rowIndex++;
                        }

                        // Sütun genişliklerini otomatik ayarla
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        // Özet satırı
                        worksheet.Cells[rowIndex + 2, 1].Value = "ÖZET";
                        worksheet.Cells[rowIndex + 2, 1].Style.Font.Bold = true;

                        int eksikSayisi = dgvIhtiyaclar.Rows.Cast<DataGridViewRow>()
                            .Count(r => r.Cells["Durum"].Value?.ToString() == "EKSIK");
                        int azSayisi = dgvIhtiyaclar.Rows.Cast<DataGridViewRow>()
                            .Count(r => r.Cells["Durum"].Value?.ToString() == "AZ");

                        worksheet.Cells[rowIndex + 3, 1].Value = "Kritik Ürünler:";
                        worksheet.Cells[rowIndex + 3, 2].Value = eksikSayisi;
                        worksheet.Cells[rowIndex + 4, 1].Value = "Az Stoklu Ürünler:";
                        worksheet.Cells[rowIndex + 4, 2].Value = azSayisi;

                        package.SaveAs(new FileInfo(sfd.FileName));
                    }

                    MessageBox.Show("Excel dosyası başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excel oluşturma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- DİĞER FORMLARA GEÇİŞ ---

        private void btnSiparisAkisi_Click(object sender, EventArgs e)
        {
            SiparisDurumAnaForm form = new SiparisDurumAnaForm();
            form.ShowDialog();
            VerileriGetir();
            KPIGuncelle();
        }

        private void btnStokGuncelle_Click(object sender, EventArgs e)
        {
            StokGuncelleForm form = new StokGuncelleForm();
            form.ShowDialog();
        }

        private void btnBitenSiparis_Click(object sender, EventArgs e)
        {
            BitenSiparisForm form = new BitenSiparisForm();
            form.ShowDialog();
            VerileriGetir();
            KPIGuncelle();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SiparisChat yeni = new SiparisChat();
            yeni.Show();
        }
    }
}
