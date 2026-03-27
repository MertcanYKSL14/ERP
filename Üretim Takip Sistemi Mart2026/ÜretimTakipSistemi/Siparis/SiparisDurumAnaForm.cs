using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Text;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using ÜretimTakipSistemi.Siparis;
using SiparisEntity = ÜretimTakipSistemi.Entities.Concrete.Siparis;
using SiparisDurumGecmisiEntity = ÜretimTakipSistemi.Entities.Concrete.SiparisDurumGecmisi;
using SiparisDurumGecmisiKayitTalepEntity = ÜretimTakipSistemi.Entities.Concrete.SiparisDurumGecmisiKayitTalep;
using SiparisTamamlamaSonucEntity = ÜretimTakipSistemi.Entities.Concrete.SiparisTamamlamaSonuc;
using SiparisTamamlamaTalepEntity = ÜretimTakipSistemi.Entities.Concrete.SiparisTamamlamaTalep;

namespace ÜretimTakipSistemi.Siparis
{
    public partial class SiparisDurumAnaForm : Form
    {
        private static readonly Dictionary<string, string> SiparisGridBasliklari = new Dictionary<string, string>
        {
            { "StokNo", "Stok No" },
            { "MusteriAdi", "Müşteri Adı" },
            { "ParcaAdi", "Parça Adı" },
            { "Bolum", "Bölüm" },
            { "SiparisAdeti", "Sipariş Adeti" },
            { "Durum", "Durum" },
            { "KayitTarihi", "Kayıt Tarihi" },
            { "SiparisNotu", "Sipariş Notu" }
        };

        private DataTable siparislerTablosu;
        private readonly ISiparisService _siparisService;
        private int secilenSiparisID = -1;
        private string kullaniciAdi = Environment.UserName; // veya giriş yapan kullanıcı
        // Sipariş Durumları 
        private readonly string[] durumlar = new string[]
        {
            "Beklemede",
            "Üretimde",
            "Paketleme",
            "Sevkiyat",
            "Tamamlandı"
        };

        public SiparisDurumAnaForm()
        {
            InitializeComponent();
            _siparisService = InstanceFactory.GetInstance<ISiparisService>();

            // ComboBox'ı doldur
            cmbYeniDurum.Items.AddRange(durumlar);

            // Arama TextBox için event handler
            txtArama.TextChanged += txtArama_TextChanged;

            // ÖNEMLİ: DataGridView CellClick event'ini manuel bağla
            dgvSiparisler.CellClick += dgvSiparisler_CellClick;

            // SelectionChanged event'i de ekleyelim (daha güvenilir)
            dgvSiparisler.SelectionChanged += dgvSiparisler_SelectionChanged;
        }

        private void SiparisDurumAnaForm_Load(object sender, EventArgs e)
        {
            VerileriYukle();
            DurumAdimlariniOlustur();
            DataGridStiliniAyarla();
        }

        #region Veri İşlemleri

        private void VerileriYukle()
        {
            try
            {
                List<SiparisEntity> siparisler = _siparisService.GetAktifSiparisler();
                siparislerTablosu = SiparisGridTableHelper.SiparisleriDataTableaDonustur(siparisler);

                dgvSiparisler.DataSource = siparislerTablosu;

                IstatistikleriGuncelle();
                GrafikleriGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yükleme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IstatistikleriGuncelle()
        {
            if (siparislerTablosu == null || siparislerTablosu.Rows.Count == 0)
            {
                lblBeklemedeAdet.Text = "0";
                lblUretimdeAdet.Text = "0";
                lblTamamlananAdet.Text = "0";
                lblToplamAdet.Text = "0";
                return;
            }

            int beklemede = siparislerTablosu.Select("Durum = 'Beklemede'").Length;
            int uretimde = siparislerTablosu.Select("Durum = 'Üretimde' OR Durum = 'Paketleme' OR Durum = 'Sevkiyat'").Length;
            int tamamlanan = siparislerTablosu.Select("Durum = 'Tamamlandı'").Length;
            int toplam = siparislerTablosu.Rows.Count;

            lblBeklemedeAdet.Text = beklemede.ToString();
            lblUretimdeAdet.Text = uretimde.ToString();
            lblTamamlananAdet.Text = tamamlanan.ToString();
            lblToplamAdet.Text = toplam.ToString();
        }

        #endregion

        #region Arama Fonksiyonu

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            string aramaMetni = txtArama.Text.Trim();

            if (string.IsNullOrEmpty(aramaMetni))
            {
                // Arama boşsa tüm verileri göster
                dgvSiparisler.DataSource = siparislerTablosu;
                return;
            }

            try
            {
                // StokNo'ya göre filtrele
                DataView dv = siparislerTablosu.DefaultView;
                SiparisGridFilterHelper.Uygula(dv, aramaMetni, "StokNo");
                dgvSiparisler.DataSource = dv.ToTable();

                // Eğer tek bir sonuç varsa otomatik seç
                if (dgvSiparisler.Rows.Count == 1)
                {
                    dgvSiparisler.Rows[0].Selected = true;
                    dgvSiparisler_CellClick(dgvSiparisler, new DataGridViewCellEventArgs(0, 0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Arama hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAramayiTemizle_Click(object sender, EventArgs e)
        {
            txtArama.Clear();
            dgvSiparisler.DataSource = siparislerTablosu;
            txtArama.Focus();
        }

        #endregion

        #region Grafik ve Görsel Öğeler

        private void GrafikleriGuncelle()
        {
            try
            {
                chartDurum.Series["Durumlar"].Points.Clear();

                if (siparislerTablosu == null || siparislerTablosu.Rows.Count == 0)
                    return;

                // Her durum için sayıları hesapla
                foreach (string durum in durumlar)
                {
                    int adet = siparislerTablosu.Select($"Durum = '{durum}'").Length;

                    if (adet > 0)
                    {
                        DataPoint point = new DataPoint();
                        point.SetValueY(adet);
                        point.Label = $"{durum}\n({adet})";
                        point.LegendText = durum;

                        // Renk ataması
                        point.Color = DurumRengiGetir(durum);

                        chartDurum.Series["Durumlar"].Points.Add(point);
                    }
                }

                chartDurum.Series["Durumlar"]["PieLabelStyle"] = "Disabled";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Grafik güncelleme hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DurumAdimlariniOlustur()
        {
            flowSteps.Controls.Clear();

            Color[] renkler = new Color[]
            {
                Color.FromArgb(241, 196, 15),   // Beklemede - Sarı
                Color.FromArgb(52, 152, 219),   // Üretimde - Mavi
                Color.FromArgb(230, 126, 34),   // Paketleme - Turuncu
                Color.FromArgb(52, 73, 94),     // Sevkiyat - Lacivert
                Color.FromArgb(46, 204, 113)    // Tamamlandı - Yeşil
            };

            string[] ikonlar = new string[] { "⏳", "⚙️", "📦", "🚚", "✅" };

            for (int i = 0; i < durumlar.Length; i++)
            {
                Panel adimPanel = new Panel
                {
                    Width = 180,
                    Height = 80,
                    BackColor = renkler[i],
                    Margin = new Padding(5)
                };

                Label lblIkon = new Label
                {
                    Text = ikonlar[i],
                    Font = new Font("Segoe UI", 20F),
                    ForeColor = Color.White,
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblDurum = new Label
                {
                    Text = durumlar[i],
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(60, 15),
                    AutoSize = true
                };

                
                int adet = 0;
                if (siparislerTablosu != null)
                {
                    adet = siparislerTablosu.Select($"Durum = '{durumlar[i]}'").Length;
                }

                Label lblAdet = new Label
                {
                    Text = $"{adet} Sipariş",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.White,
                    Location = new Point(60, 45),
                    AutoSize = true
                };

                adimPanel.Controls.Add(lblIkon);
                adimPanel.Controls.Add(lblDurum);
                adimPanel.Controls.Add(lblAdet);

                flowSteps.Controls.Add(adimPanel);
            }
        }

        private void DataGridStiliniAyarla()
        {
            if (dgvSiparisler.Columns.Count == 0)
                return;

            dgvSiparisler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSiparisler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSiparisler.MultiSelect = false;
            dgvSiparisler.ReadOnly = true;
            dgvSiparisler.AllowUserToAddRows = false;

            // Başlık stilleri
            dgvSiparisler.EnableHeadersVisualStyles = false;
            dgvSiparisler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvSiparisler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSiparisler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSiparisler.ColumnHeadersHeight = 40;

            // Satır stilleri
            dgvSiparisler.RowTemplate.Height = 35;
            dgvSiparisler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvSiparisler.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dgvSiparisler.DefaultCellStyle.SelectionForeColor = Color.White;

            SiparisGridColumnHelper.Uygula(dgvSiparisler, SiparisGridBasliklari);
        }

        private Color DurumRengiGetir(string durum)
        {
            switch (durum)
            {
                case "Beklemede": return Color.FromArgb(241, 196, 15);
                case "Üretimde": return Color.FromArgb(52, 152, 219);
                case "Paketleme": return Color.FromArgb(230, 126, 34);
                case "Sevkiyat": return Color.FromArgb(52, 73, 94);
                case "Tamamlandı": return Color.FromArgb(46, 204, 113);
                default: return Color.Gray;
            }
        }

        #endregion

        #region Event Handler'lar

        // SelectionChanged - Daha güvenilir bir alternatif
        private void dgvSiparisler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSiparisler.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvSiparisler.SelectedRows[0];
                    SiparisDetaylariniGoster(row);
                }
                catch (Exception ex)
                {
                    // Hata ayıklama için (isteğe bağlı)
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
            if (secilenSiparisID != -1)
                DurumGecmisiniYukle(secilenSiparisID);
        }
        private void DurumGecmisiniYukle(int siparisID)
        {
            try
            {
                List<SiparisDurumGecmisiEntity> gecmisKayitlari = _siparisService.GetDurumGecmisi(siparisID);

                if (gecmisKayitlari.Count == 0)
                {
                    return;
                }

                string gecmisMetni = DurumGecmisiMetniniOlustur(gecmisKayitlari);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Durum Geçmişi Yüklenirken Hata: " + ex.Message);
            }
        }

        private string DurumGecmisiMetniniOlustur(List<SiparisDurumGecmisiEntity> gecmisKayitlari)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("DURUM GEÇMİŞİ");
            builder.AppendLine(new string('═', 50));
            builder.AppendLine();

            for (int i = 0; i < gecmisKayitlari.Count; i++)
            {
                SiparisDurumGecmisiEntity kayit = gecmisKayitlari[i];

                builder.AppendLine($"{i + 1}. {kayit.EskiDurum ?? "-"} → {kayit.YeniDurum ?? ""}");
                builder.AppendLine($"   Tarih: {kayit.DegisiklikTarihi:dd.MM.yyyy HH:mm}");
                builder.AppendLine($"   Kullanıcı: {kayit.DegistirenKullanici ?? ""}");

                if (kayit.UretilenMiktar.HasValue)
                {
                    builder.AppendLine($"   Üretilen Miktar: {kayit.UretilenMiktar.Value}");
                }

                if (!string.IsNullOrWhiteSpace(kayit.Aciklama))
                {
                    builder.AppendLine($"   Açıklama: {kayit.Aciklama}");
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
        private void dgvSiparisler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row = dgvSiparisler.Rows[e.RowIndex];
                SiparisDetaylariniGoster(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Detay yükleme hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DurumGecmisiniYukle(secilenSiparisID);
        }

        private void SiparisDetaylariniGoster(DataGridViewRow row)
        {
            secilenSiparisID = Convert.ToInt32(row.Cells["SiparisID"].Value);
            string siparisNo = row.Cells["StokNo"].Value?.ToString() ?? "-";
            string musteriAdi = row.Cells["MusteriAdi"].Value?.ToString() ?? "-";
            string parcaAdi = row.Cells["ParcaAdi"].Value?.ToString() ?? "-";
            string adet = row.Cells["SiparisAdeti"].Value?.ToString() ?? "-";
            string durum = row.Cells["Durum"].Value?.ToString() ?? "-";
            string tarih = "-";

            if (row.Cells["KayitTarihi"].Value != null && row.Cells["KayitTarihi"].Value != DBNull.Value)
            {
                DateTime kayitTarihi = Convert.ToDateTime(row.Cells["KayitTarihi"].Value);
                tarih = kayitTarihi.ToString("dd.MM.yyyy HH:mm");
            }

            // Detay panelini güncelle
            lblSiparisNo.Text = $"Sipariş No: {siparisNo}";
            lblMusteriAdi.Text = $"Müşteri: {musteriAdi}";
            lblParcaAdi.Text = $"Parça Adı: {parcaAdi}";
            lblAdet.Text = $"Adet: {adet}";
            lblMevcutDurum.Text = $"Durum: {durum}";
            lblMevcutDurum.ForeColor = DurumRengiGetir(durum);
            lblTarih.Text = $"Kayıt: {tarih}";


            int durumIndex = Array.IndexOf(durumlar, durum);
            if (durumIndex >= 0)
            {
                cmbYeniDurum.SelectedIndex = durumIndex;
            }
            else
            {
                cmbYeniDurum.SelectedIndex = -1;
            }
        }
        private void DurumGecmisiKaydet(int siparisID, string stokNo, string urunAdi,
                                 string eskiDurum, string yeniDurum,
                                 int? uretilenMiktar = null, string aciklama = null)
        {
            try
            {
                _siparisService.KaydetDurumGecmisi(new SiparisDurumGecmisiKayitTalepEntity
                {
                    SiparisID = siparisID,
                    StokNo = stokNo,
                    UrunAdi = urunAdi,
                    EskiDurum = eskiDurum,
                    YeniDurum = yeniDurum,
                    DegistirenKullanici = kullaniciAdi,
                    UretilenMiktar = uretilenMiktar,
                    Aciklama = aciklama
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Durum geçmişi kaydetme hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDurumGuncelle_Click(object sender, EventArgs e)
        {
            if (secilenSiparisID == -1)
            {
                MessageBox.Show("Lütfen güncellenecek siparişi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbYeniDurum.SelectedItem == null)
            {
                MessageBox.Show("Lütfen yeni durumu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Verileri Al
            string yeniDurum = cmbYeniDurum.SelectedItem.ToString();
            DataGridViewRow row = dgvSiparisler.SelectedRows[0];
            string eskiDurum = row.Cells["Durum"].Value?.ToString() ?? "";
            string stokNo = row.Cells["StokNo"].Value?.ToString() ?? "";
            string urunAdi = row.Cells["ParcaAdi"].Value?.ToString() ?? "";
            int siparisAdeti = Convert.ToInt32(row.Cells["SiparisAdeti"].Value);

            if (eskiDurum == yeniDurum)
            {
                MessageBox.Show("Durum değişikliği yapılmadı (Eski ve Yeni durum aynı).", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Durum Kontrolü ve Yönlendirme
            if (yeniDurum == "Tamamlandı")
            {
                // Önceki cevaptaki (veya aşağıda tekrar verdiğim) gelişmiş tamamlama metodu
                TamamlandıDurumuIslemi(stokNo, urunAdi, siparisAdeti, eskiDurum);
            }
            else
            {
                // --- NORMAL DURUM GÜNCELLEMESİ (Beklemede, Üretimde, Sevkiyat vb.) ---

                DialogResult onay = MessageBox.Show(
                    $"Sipariş durumu '{eskiDurum}' → '{yeniDurum}' olarak güncellenecek.\nOnaylıyor musunuz?",
                    "Durum Güncelleme",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (onay != DialogResult.Yes) return;

                try
                {
                    _siparisService.SiparisDurumunuGuncelle(secilenSiparisID, yeniDurum);

                    // B) KRİTİK NOKTA: Durum Geçmişine Kayıt (Artık burada kesinlikle çalışacak)
                    DurumGecmisiKaydet(
                        secilenSiparisID,
                        stokNo,
                        urunAdi,
                        eskiDurum,
                        yeniDurum,
                        null, // Normal geçişte üretilen miktar yok
                        "Durum güncellemesi yapıldı." // Açıklama
                    );

                    MessageBox.Show("Durum güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Listeyi yenile
                    VerileriYukle();
                    DurumAdimlariniOlustur();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Güncelleme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TamamlandıDurumuIslemi(string stokNo, string urunAdi, int siparisAdeti, string eskiDurum)
        {
            try
            {
                // 1. KULLANICIDAN VERİ ALMA
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Sipariş: {stokNo} - {urunAdi}\n" +
                    $"Toplam Sipariş Adeti: {siparisAdeti}\n\n" +
                    $"Kaç adet üretildi?",
                    "Üretim Miktarı Girişi",
                    siparisAdeti.ToString(), // Varsayılan olarak tamamını getir
                    -1, -1);

                if (string.IsNullOrWhiteSpace(input)) return; // İptal edilirse çık

                if (!int.TryParse(input, out int uretilenAdet) || uretilenAdet <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir sayı giriniz (0'dan büyük).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (uretilenAdet > siparisAdeti)
                {
                    MessageBox.Show($"Hata: Üretilen miktar ({uretilenAdet}), sipariş adetinden ({siparisAdeti}) fazla olamaz!",
                        "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. STOK İŞLEMLERİ (Stok veritabanı farklı olduğu için transaction dışı tuttum, isterseniz birleştirebilirsiniz)
                bool stokSonuc = StokIslemleriniGerceklestir(stokNo, uretilenAdet);
                if (!stokSonuc)
                {
                    MessageBox.Show("Stok düşme işlemi başarısız olduğu için sipariş güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. SIPARIS VERITABANI GUNCELLEME
                try
                {
                    SiparisTamamlamaSonucEntity sonuc = _siparisService.SiparisiTamamla(new SiparisTamamlamaTalepEntity
                    {
                        SiparisID = secilenSiparisID,
                        StokNo = stokNo,
                        UrunAdi = urunAdi,
                        EskiDurum = eskiDurum,
                        DegistirenKullanici = kullaniciAdi,
                        SiparisAdeti = siparisAdeti,
                        UretilenAdet = uretilenAdet
                    });

                    string mesaj = sonuc.KalanAdet > 0
                        ? $"Kısmi üretim kaydedildi.\nÜretilen: {uretilenAdet}\nKalan: {sonuc.KalanAdet}\nSipariş 'Beklemede' durumuna döndü."
                        : "Sipariş tamamen tamamlandı, stoklar güncellendi ve arşive taşındı.";

                    MessageBox.Show(mesaj, "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı güncelleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                // Arayüzü yenile
                VerileriYukle();
                DurumAdimlariniOlustur();
            }
        }

        private bool StokIslemleriniGerceklestir(string stokNo, int uretilenAdet)
        {
            try
            {
                _siparisService.UretimStoklariniGuncelle(stokNo, uretilenAdet);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok güncelleme hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnNotEkle_Click(object sender, EventArgs e)
        {
            if (secilenSiparisID == -1)
            {
                MessageBox.Show("Lütfen bir sipariş seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Not ekleme formu
            string not = Microsoft.VisualBasic.Interaction.InputBox(
                "Sipariş notu girin:",
                "Not Ekle",
                "",
                -1, -1);

            if (string.IsNullOrWhiteSpace(not))
                return;

            try
            {
                _siparisService.SiparisNotunuGuncelle(secilenSiparisID, not);

                MessageBox.Show("Not başarıyla kaydedildi.", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                VerileriYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Not ekleme hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (secilenSiparisID == -1)
            {
                MessageBox.Show("Lütfen bir sipariş seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Yazdırma özelliği yapım aşamasında.", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            VerileriYukle();
            DurumAdimlariniOlustur();
            MessageBox.Show("Veriler yenilendi.", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Hover Efektleri

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = ControlPaint.Light(btn.BackColor, 0.2f);
                btn.Cursor = Cursors.Hand;
            }
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Orijinal rengine geri dön
                if (btn == btnDurumGuncelle)
                    btn.BackColor = Color.FromArgb(46, 204, 113);
                else if (btn == btnNotEkle)
                    btn.BackColor = Color.FromArgb(52, 152, 219);
                else if (btn == btnYazdir)
                    btn.BackColor = Color.FromArgb(149, 165, 166);
                else if (btn == btnYenile)
                    btn.BackColor = Color.FromArgb(52, 152, 219);
                else if (btn == btnAramayiTemizle)
                    btn.BackColor = Color.FromArgb(231, 76, 60);
            }
        }

        #endregion

        private void btndrmgecmis_Click(object sender, EventArgs e)
        {
            {
                if (secilenSiparisID == -1)
                {
                    MessageBox.Show("Lütfen durum geçmişini görmek istediğiniz siparişi seçin.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // Seçili sipariş bilgilerini al
                    DataGridViewRow row = dgvSiparisler.SelectedRows[0];
                    string stokNo = row.Cells["StokNo"].Value?.ToString() ?? "";
                    string urunAdi = row.Cells["ParcaAdi"].Value?.ToString() ?? "";

                    // Durum geçmişi formunu aç
                    DurumGecmisiForm gecmisForm = new DurumGecmisiForm(
                        secilenSiparisID,
                        stokNo,
                        urunAdi
                    );
                    gecmisForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Form açma hatası: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
