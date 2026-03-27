using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.Lazer
{
    public partial class SiparisDetayForm : Form
    {
        private string connectionString;
        private int siparisID;
        private readonly ILazerSiparisDetayService _lazerSiparisDetayService;

        public SiparisDetayForm(string connString, int siparisID)
        {
            InitializeComponent();
            this.connectionString = connString;
            this.siparisID = siparisID;
            _lazerSiparisDetayService = InstanceFactory.GetInstance<ILazerSiparisDetayService>();
        }

        private void SiparisDetayForm_Load(object sender, EventArgs e)
        {

            SiparisBaslikBilgileriniYukle();
            SiparisDetaylariniYukle();
        }

        private void SiparisBaslikBilgileriniYukle()
        {
            try
            {
                LazerSiparisDetayBaslik baslik = _lazerSiparisDetayService.GetSiparisBaslik(connectionString, siparisID);

                if (baslik == null)
                {
                    throw new InvalidOperationException("Siparis bilgisi bulunamadi.");
                }

                lblSiparisNoDeger.Text = baslik.SiparisNo;
                lblMusteriDeger.Text = baslik.Musteri;
                lblSiparisTarihiDeger.Text = baslik.SiparisTarihiText;
                lblTeslimTarihiDeger.Text = baslik.TeslimTarihiText;
                lblDurumDeger.Text = baslik.Durum;
                lblAciklamaDeger.Text = baslik.Aciklama;

                string durum = baslik.Durum ?? string.Empty;
                if (durum == "Tamamlandı")
                    lblDurumDeger.ForeColor = Color.Green;
                else if (durum == "Üretimde")
                    lblDurumDeger.ForeColor = Color.Orange;
                else if (durum == "İptal")
                    lblDurumDeger.ForeColor = Color.Red;
                else
                    lblDurumDeger.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş bilgileri yüklenirken hata: " + ex.Message);
            }
        }

        private void SiparisDetaylariniYukle()
        {
            try
            {
                DataTable dt = _lazerSiparisDetayService.GetSiparisDetaylari(connectionString, siparisID);

                dgvDetaylar.DataSource = dt;
                dgvDetaylar.Columns["SiparisDetayID"].Visible = false;

                foreach (DataGridViewRow row in dgvDetaylar.Rows)
                {
                    string durum = row.Cells["Durum"].Value?.ToString();
                    if (durum == "Tamamlandı")
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
                    else if (durum == "Üretimde")
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 205);
                    else if (durum == "Beklemede")
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 200);
                }

                GuncelIstatistikleriGoster(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş detayları yüklenirken hata: " + ex.Message);
            }
        }

        private void GuncelIstatistikleriGoster(DataTable dt)
        {
            int toplamSiparis = 0;
            int toplamUretilen = 0;
            int toplamKalan = 0;

            foreach (DataRow row in dt.Rows)
            {
                toplamSiparis += Convert.ToInt32(row["Sipariş Adedi"]);
                toplamUretilen += Convert.ToInt32(row["Üretilen Adet"]);
                toplamKalan += Convert.ToInt32(row["Kalan Adet"]);
            }

            lblToplamSiparis.Text = $"Toplam Sipariş: {toplamSiparis} adet";
            lblToplamUretilen.Text = $"Toplam Üretilen: {toplamUretilen} adet";
            lblToplamKalan.Text = $"Toplam Kalan: {toplamKalan} adet";

            if (toplamSiparis > 0)
            {
                decimal yuzde = (decimal)toplamUretilen / toplamSiparis * 100;
                lblGenelTamamlanma.Text = $"Genel Tamamlanma: %{yuzde:F1}";
            }
            else
            {
                lblGenelTamamlanma.Text = "Genel Tamamlanma: %0.0";
            }
        }

        private void btnUretimGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvDetaylar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir ürün seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int detayID = Convert.ToInt32(dgvDetaylar.SelectedRows[0].Cells["SiparisDetayID"].Value);
            string urunKodu = dgvDetaylar.SelectedRows[0].Cells["Ürün Kodu"].Value.ToString();
            string urunAdi = dgvDetaylar.SelectedRows[0].Cells["Ürün Adı"].Value.ToString();
            int siparisAdedi = Convert.ToInt32(dgvDetaylar.SelectedRows[0].Cells["Sipariş Adedi"].Value);
            int mevcutUretilen = Convert.ToInt32(dgvDetaylar.SelectedRows[0].Cells["Üretilen Adet"].Value);
            string mevcutDurum = dgvDetaylar.SelectedRows[0].Cells["Durum"].Value.ToString();

            UretimGuncellemeForm frm = new UretimGuncellemeForm(
                urunKodu,
                urunAdi,
                siparisAdedi,
                mevcutUretilen,
                mevcutDurum
            );

            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LazerSiparisDetayGuncelleTalep talep = new LazerSiparisDetayGuncelleTalep
                    {
                        SiparisId = siparisID,
                        SiparisDetayId = detayID,
                        UretilenAdet = frm.YeniUretilenAdet,
                        Durum = frm.YeniDurum
                    };

                    _lazerSiparisDetayService.GuncelleUretimBilgisi(connectionString, talep);

                    MessageBox.Show("Üretim bilgileri başarıyla güncellendi!", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SiparisDetaylariniYukle();
                    SiparisBaslikBilgileriniYukle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sırasında hata: " + ex.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDetaylar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnUretimGuncelle_Click(sender, e);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProfilOptimizasyonu_Click(object sender, EventArgs e)
        {
            try
            {
                List<UrunBilgisi> urunler = SiparisUrunleriniAl();

                if (urunler.Count == 0)
                {
                    MessageBox.Show("Bu siparişe ait Boru tipi ürün bulunamadı!\n\n" +
                        "Kontrol Edilecekler:\n" +
                        "• Ürünlerin LazerTipi = 'Boru' olmalı\n" +
                        "• UrunBoyu alanı dolu olmalı\n" +
                        "• ProfilEbati alanı dolu olmalı",
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string urunListesi = $"Toplam {urunler.Count} ürün bulundu:\n\n";
                foreach (var urun in urunler.Take(5))
                {
                    urunListesi += $"• {urun.UrunKodu} - {urun.UrunBoyu}mm - {urun.ProfilEbati} ({urun.ProfilUzunlugu}mm) x{urun.Adet}\n";
                }
                if (urunler.Count > 5)
                {
                    urunListesi += $"... ve {urunler.Count - 5} ürün daha\n";
                }

                var result = MessageBox.Show(urunListesi + "\nOptimizasyon yapılsın mı?",
                    "Ürün Listesi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                decimal varsayilanProfilUzunlugu = 6000m;

                // Optimizasyonu hesapla
                var optimizasyonSonucu = ProfilOptimizasyonuHesapla(urunler, varsayilanProfilUzunlugu);

                // Sonuçları göster
                ProfilOptimizasyonSonucForm sonucForm = new ProfilOptimizasyonSonucForm(optimizasyonSonucu);
                sonucForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Profil optimizasyonu hesaplanırken hata: " + ex.Message + "\n\nDetay: " + ex.StackTrace,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<UrunBilgisi> SiparisUrunleriniAl()
        {
            List<UrunBilgisi> urunler = new List<UrunBilgisi>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Ana ürün
                string anaQuery = @"SELECT U.UrunKodu, U.UrunAdi, U.UrunBoyu, U.ProfilEbati, SD.SiparisAdedi,
                                          PS.ProfilUzunlugu
                                   FROM SiparisDetay SD
                                   INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                                   LEFT JOIN ProfilStok PS ON U.ProfilEbati = PS.ProfilEbati
                                   WHERE SD.SiparisID = @SiparisID 
                                   AND U.LazerTipi = 'Boru' 
                                   AND U.GrupluUrunMu = 0
                                   AND U.UrunBoyu IS NOT NULL";

                SqlCommand anaCmd = new SqlCommand(anaQuery, conn);
                anaCmd.Parameters.AddWithValue("@SiparisID", siparisID);

                SqlDataReader anaReader = anaCmd.ExecuteReader();
                while (anaReader.Read())
                {

                    decimal profilUzunlugu = 6000m;
                    if (anaReader["ProfilUzunlugu"] != DBNull.Value)
                    {
                        profilUzunlugu = Convert.ToDecimal(anaReader["ProfilUzunlugu"]);
                    }

                    urunler.Add(new UrunBilgisi
                    {
                        UrunKodu = anaReader["UrunKodu"].ToString(),
                        UrunAdi = anaReader["UrunAdi"].ToString(),
                        UrunBoyu = Convert.ToDecimal(anaReader["UrunBoyu"]),
                        ProfilEbati = anaReader["ProfilEbati"]?.ToString() ?? "",
                        ProfilUzunlugu = profilUzunlugu,
                        Adet = Convert.ToInt32(anaReader["SiparisAdedi"])
                    });
                }
                anaReader.Close();

                //Alt Ürünler
                string grupluQuery = @"SELECT UDB.ParcaAdi, UDB.UrunBoyu, UDB.ProfilEbati, 
                                              (UDB.Adet * SD.SiparisAdedi) AS ToplamAdet,
                                              U.UrunKodu,
                                              PS.ProfilUzunlugu
                                       FROM SiparisDetay SD
                                       INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                                       INNER JOIN UrunDetayBoru UDB ON U.UrunID = UDB.UrunID
                                       LEFT JOIN ProfilStok PS ON UDB.ProfilEbati = PS.ProfilEbati
                                       WHERE SD.SiparisID = @SiparisID 
                                       AND U.LazerTipi = 'Boru' 
                                       AND U.GrupluUrunMu = 1";

                SqlCommand grupluCmd = new SqlCommand(grupluQuery, conn);
                grupluCmd.Parameters.AddWithValue("@SiparisID", siparisID);

                SqlDataReader grupluReader = grupluCmd.ExecuteReader();
                while (grupluReader.Read())
                {
                    decimal profilUzunlugu = 6000m;
                    if (grupluReader["ProfilUzunlugu"] != DBNull.Value)
                    {
                        profilUzunlugu = Convert.ToDecimal(grupluReader["ProfilUzunlugu"]);
                    }

                    urunler.Add(new UrunBilgisi
                    {
                        UrunKodu = grupluReader["UrunKodu"].ToString() + " - " + grupluReader["ParcaAdi"].ToString(),
                        UrunAdi = grupluReader["ParcaAdi"].ToString(),
                        UrunBoyu = Convert.ToDecimal(grupluReader["UrunBoyu"]),
                        ProfilEbati = grupluReader["ProfilEbati"].ToString(),
                        ProfilUzunlugu = profilUzunlugu,
                        Adet = Convert.ToInt32(grupluReader["ToplamAdet"])
                    });
                }
                grupluReader.Close();
            }

            return urunler;
        }

        private ProfilOptimizasyonSonuc ProfilOptimizasyonuHesapla(List<UrunBilgisi> urunler, decimal varsayilanProfilUzunlugu)
        {
            var sonuc = new ProfilOptimizasyonSonuc
            {
                ProfilUzunlugu = varsayilanProfilUzunlugu,
                ProfilListesi = new List<ProfilDetay>()
            };


            var birlesikUrunler = urunler
                .GroupBy(u => new { u.ProfilEbati, UrunBoyu = Math.Round(u.UrunBoyu, 2) })
                .Select(g => new UrunBilgisi
                {
                    UrunKodu = string.Join(", ", g.Select(x => x.UrunKodu).Distinct()),
                    UrunAdi = g.First().UrunAdi,
                    UrunBoyu = g.Key.UrunBoyu,
                    ProfilEbati = g.Key.ProfilEbati,
                    ProfilUzunlugu = g.First().ProfilUzunlugu,
                    Adet = g.Sum(x => x.Adet)
                })
                .ToList();

            // Profil ebatlarına göre grupla
            var profilGruplari = birlesikUrunler.GroupBy(u => u.ProfilEbati);

            foreach (var grup in profilGruplari)
            {
                string profilEbati = grup.Key;
                var grupUrunler = grup.ToList();

                // Bu gruptaki profil uzunluğunu belirle (ilk ürünün profil uzunluğunu kullan)
                decimal profilUzunlugu = grupUrunler.First().ProfilUzunlugu;

                // Her ürünü tekil parçalara ayır
                List<decimal> parcalar = new List<decimal>();
                Dictionary<decimal, string> parcaBilgi = new Dictionary<decimal, string>();

                foreach (var urun in grupUrunler)
                {
                    for (int i = 0; i < urun.Adet; i++)
                    {
                        parcalar.Add(urun.UrunBoyu);
                        string key = $"{urun.UrunKodu} ({urun.UrunBoyu}mm)";
                        if (!parcaBilgi.ContainsKey(urun.UrunBoyu))
                        {
                            parcaBilgi[urun.UrunBoyu] = key;
                        }
                    }
                }

                // FFD (First Fit Decreasing) algoritması ile yerleştir
                parcalar.Sort((a, b) => b.CompareTo(a)); // Büyükten küçüğe sırala

                List<ProfilDetay> profiller = new List<ProfilDetay>();

                foreach (var parca in parcalar)
                {
                    bool yerlestirildi = false;

                    // Mevcut profillere sığmaya çalış
                    foreach (var profil in profiller)
                    {
                        if (profil.KalanUzunluk >= parca)
                        {
                            profil.Parcalar.Add(new ParcaBilgi
                            {
                                UrunKodu = parcaBilgi[parca],
                                Uzunluk = parca
                            });
                            profil.KalanUzunluk -= parca;
                            yerlestirildi = true;
                            break;
                        }
                    }

                    if (!yerlestirildi)
                    {
                        var yeniProfil = new ProfilDetay
                        {
                            ProfilNo = profiller.Count + 1,
                            ProfilEbati = profilEbati,
                            ProfilUzunlugu = profilUzunlugu,
                            KalanUzunluk = profilUzunlugu - parca,
                            Parcalar = new List<ParcaBilgi>
                            {
                                new ParcaBilgi
                                {
                                    UrunKodu = parcaBilgi[parca],
                                    Uzunluk = parca
                                }
                            }
                        };
                        profiller.Add(yeniProfil);
                    }
                }

                foreach (var profil in profiller)
                {
                    profil.HurdaUzunlugu = profil.KalanUzunluk;

                    if (profil.ProfilUzunlugu > 0)
                    {
                        decimal kullanilan = profil.ProfilUzunlugu - profil.HurdaUzunlugu;
                        profil.VerimliliYuzdesi = decimal.Divide(kullanilan, profil.ProfilUzunlugu) * 100m;
                    }
                    else
                    {
                        profil.VerimliliYuzdesi = 0m;
                    }
                }

                sonuc.ProfilListesi.AddRange(profiller);
            }

            sonuc.ToplamProfilSayisi = sonuc.ProfilListesi.Count;
            sonuc.ToplamHurdaUzunlugu = sonuc.ProfilListesi.Sum(p => p.HurdaUzunlugu);
            sonuc.ToplamKullanilanUzunluk = sonuc.ProfilListesi.Sum(p => p.ProfilUzunlugu - p.HurdaUzunlugu);

            decimal toplamProfilUzunlugu = sonuc.ProfilListesi.Sum(p => p.ProfilUzunlugu);
            sonuc.GenelVerimliliYuzdesi = toplamProfilUzunlugu > 0
                ? decimal.Divide(sonuc.ToplamKullanilanUzunluk, toplamProfilUzunlugu) * 100m
                : 0;

            return sonuc;
        }

        private void btnIsciRaporu_Click(object sender, EventArgs e)
        {

            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Dosyası (*.xlsx)|*.xlsx",
                    FileName = $"IsciRaporu_{lblSiparisNoDeger.Text}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                    Title = "İşçi Üretim Raporunu Kaydet"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                // Tüm iş IsciRaporuExcelHelper'da — bu sınıf sadece çağırır
                IsciRaporuExcelHelper.RaporOlustur(
                    kayitYolu: sfd.FileName,
                    connectionString: connectionString,
                    siparisID: siparisID,
                    siparisNo: lblSiparisNoDeger.Text,
                    musteri: lblMusteriDeger.Text,
                    siparisTarihi: lblSiparisTarihiDeger.Text,
                    teslimTarihi: lblTeslimTarihiDeger.Text
                );

                var acResult = MessageBox.Show(
                    $"İşçi üretim raporu başarıyla oluşturuldu!\n\n{sfd.FileName}\n\n" +
                    "Dosyayı şimdi açmak ister misiniz?",
                    "Rapor Hazır", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (acResult == DialogResult.Yes)
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = sfd.FileName,
                        UseShellExecute = true
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "İşçi raporu oluşturulurken hata:\n\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #region Profil Optimizasyon Sınıfları

    public class UrunBilgisi
    {
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public decimal UrunBoyu { get; set; }
        public string ProfilEbati { get; set; }
        public decimal ProfilUzunlugu { get; set; }
        public int Adet { get; set; }
    }

    public class ProfilOptimizasyonSonuc
    {
        public decimal ProfilUzunlugu { get; set; }
        public int ToplamProfilSayisi { get; set; }
        public decimal ToplamHurdaUzunlugu { get; set; }
        public decimal ToplamKullanilanUzunluk { get; set; }
        public decimal GenelVerimliliYuzdesi { get; set; }
        public List<ProfilDetay> ProfilListesi { get; set; }
    }

    public class ProfilDetay
    {
        public int ProfilNo { get; set; }
        public string ProfilEbati { get; set; }
        public decimal ProfilUzunlugu { get; set; }
        public decimal KalanUzunluk { get; set; }
        public decimal HurdaUzunlugu { get; set; }
        public decimal VerimliliYuzdesi { get; set; }
        public List<ParcaBilgi> Parcalar { get; set; }
    }

    public class ParcaBilgi
    {
        public string UrunKodu { get; set; }
        public decimal Uzunluk { get; set; }
    }

    #endregion

    #region Üretim Güncelleme Formu

    public class UretimGuncellemeForm : Form
    {
        private Label lblUrunBilgi;
        private Label lblMevcutDurum;
        private NumericUpDown numUretilenAdet;
        private ComboBox cmbDurum;
        private Button btnKaydet;
        private Button btnIptal;
        private Label lblKalan;

        public int YeniUretilenAdet { get; private set; }
        public string YeniDurum { get; private set; }

        private int siparisAdedi;
        private int mevcutUretilenAdet;

        public UretimGuncellemeForm(string urunKodu, string urunAdi, int siparisAdedi,
                                    int mevcutUretilenAdet, string mevcutDurum)
        {
            this.siparisAdedi = siparisAdedi;
            this.mevcutUretilenAdet = mevcutUretilenAdet;

            InitializeComponent();

            lblUrunBilgi.Text = $"{urunKodu} - {urunAdi}";
            lblMevcutDurum.Text = $"Sipariş Adedi: {siparisAdedi} | Mevcut Üretilen: {mevcutUretilenAdet} | Kalan: {siparisAdedi - mevcutUretilenAdet}";
            numUretilenAdet.Value = mevcutUretilenAdet;
            numUretilenAdet.Maximum = siparisAdedi;
            cmbDurum.Text = mevcutDurum;

            KalanAdediGuncelle();
        }

        private void InitializeComponent()
        {
            this.lblUrunBilgi = new Label();
            this.lblMevcutDurum = new Label();
            this.numUretilenAdet = new NumericUpDown();
            this.cmbDurum = new ComboBox();
            this.btnKaydet = new Button();
            this.btnIptal = new Button();
            this.lblKalan = new Label();

            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUretilenAdet)).BeginInit();

            // lblUrunBilgi
            this.lblUrunBilgi.AutoSize = false;
            this.lblUrunBilgi.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblUrunBilgi.Location = new Point(20, 20);
            this.lblUrunBilgi.Size = new Size(460, 25);
            this.lblUrunBilgi.TextAlign = ContentAlignment.MiddleLeft;

            // lblMevcutDurum
            this.lblMevcutDurum.AutoSize = false;
            this.lblMevcutDurum.Font = new Font("Segoe UI", 9F);
            this.lblMevcutDurum.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblMevcutDurum.Location = new Point(20, 50);
            this.lblMevcutDurum.Size = new Size(460, 20);
            this.lblMevcutDurum.TextAlign = ContentAlignment.MiddleLeft;

            // Label - Üretilen Adet
            Label lblUretilenText = new Label();
            lblUretilenText.Text = "Üretilen Adet:";
            lblUretilenText.Location = new Point(20, 90);
            lblUretilenText.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUretilenText.AutoSize = true;

            // numUretilenAdet
            this.numUretilenAdet.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.numUretilenAdet.Location = new Point(20, 115);
            this.numUretilenAdet.Size = new Size(200, 29);
            this.numUretilenAdet.ValueChanged += NumUretilenAdet_ValueChanged;

            // lblKalan
            this.lblKalan.AutoSize = false;
            this.lblKalan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblKalan.ForeColor = Color.FromArgb(231, 76, 60);
            this.lblKalan.Location = new Point(240, 115);
            this.lblKalan.Size = new Size(240, 29);
            this.lblKalan.TextAlign = ContentAlignment.MiddleLeft;

            // Label - Durum
            Label lblDurumText = new Label();
            lblDurumText.Text = "Durum:";
            lblDurumText.Location = new Point(20, 160);
            lblDurumText.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDurumText.AutoSize = true;

            // cmbDurum
            this.cmbDurum.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDurum.Font = new Font("Segoe UI", 11F);
            this.cmbDurum.Location = new Point(20, 185);
            this.cmbDurum.Size = new Size(460, 28);
            this.cmbDurum.Items.AddRange(new object[] { "Beklemede", "Üretimde", "Tamamlandı" });

            // btnKaydet
            this.btnKaydet.BackColor = Color.FromArgb(46, 204, 113);
            this.btnKaydet.FlatStyle = FlatStyle.Flat;
            this.btnKaydet.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnKaydet.ForeColor = Color.White;
            this.btnKaydet.Location = new Point(20, 240);
            this.btnKaydet.Size = new Size(220, 45);
            this.btnKaydet.Text = "✓ Kaydet";
            this.btnKaydet.Click += BtnKaydet_Click;

            // btnIptal
            this.btnIptal.BackColor = Color.FromArgb(149, 165, 166);
            this.btnIptal.FlatStyle = FlatStyle.Flat;
            this.btnIptal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnIptal.ForeColor = Color.White;
            this.btnIptal.Location = new Point(260, 240);
            this.btnIptal.Size = new Size(220, 45);
            this.btnIptal.Text = "✗ İptal";
            this.btnIptal.Click += BtnIptal_Click;

            // UretimGuncellemeForm
            this.ClientSize = new Size(500, 310);
            this.Controls.Add(this.lblUrunBilgi);
            this.Controls.Add(this.lblMevcutDurum);
            this.Controls.Add(lblUretilenText);
            this.Controls.Add(this.numUretilenAdet);
            this.Controls.Add(this.lblKalan);
            this.Controls.Add(lblDurumText);
            this.Controls.Add(this.cmbDurum);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Üretim Durumu Güncelle";
            this.BackColor = Color.WhiteSmoke;

            ((System.ComponentModel.ISupportInitialize)(this.numUretilenAdet)).EndInit();
            this.ResumeLayout(false);
        }

        private void NumUretilenAdet_ValueChanged(object sender, EventArgs e)
        {
            KalanAdediGuncelle();
        }

        private void KalanAdediGuncelle()
        {
            int kalan = siparisAdedi - (int)numUretilenAdet.Value;
            lblKalan.Text = $"Kalan: {kalan} adet";

            if (kalan == 0)
            {
                lblKalan.ForeColor = Color.FromArgb(46, 204, 113);
                cmbDurum.Text = "Tamamlandı";
            }
            else if (numUretilenAdet.Value > 0)
            {
                lblKalan.ForeColor = Color.FromArgb(241, 196, 15);
                if (cmbDurum.Text == "Beklemede")
                    cmbDurum.Text = "Üretimde";
            }
            else
            {
                lblKalan.ForeColor = Color.FromArgb(231, 76, 60);
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDurum.Text))
            {
                MessageBox.Show("Lütfen durum seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            YeniUretilenAdet = (int)numUretilenAdet.Value;
            YeniDurum = cmbDurum.Text;

            // Mantık kontrolü
            if (YeniUretilenAdet == siparisAdedi && YeniDurum != "Tamamlandı")
            {
                DialogResult result = MessageBox.Show(
                    "Üretilen adet sipariş adedine eşit. Durum 'Tamamlandı' olarak değiştirilsin mi?",
                    "Durum Kontrolü",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    YeniDurum = "Tamamlandı";
                }
            }
            else if (YeniUretilenAdet < siparisAdedi && YeniDurum == "Tamamlandı")
            {
                MessageBox.Show("Üretim henüz tamamlanmamış. Durum 'Tamamlandı' olamaz!",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    #endregion

    #region Profil Optimizasyon Sonuç Formu

    public class ProfilOptimizasyonSonucForm : Form
    {
        private ProfilOptimizasyonSonuc sonuc;
        private Panel pnlOzet;
        private DataGridView dgvProfiller;
        private RichTextBox rtbDetay;
        private Button btnKapat;
        private Button btnExport;

        public ProfilOptimizasyonSonucForm(ProfilOptimizasyonSonuc optimizasyonSonucu)
        {
            this.sonuc = optimizasyonSonucu;
            InitializeComponents();
            SonuclariGoster();
        }

        private void InitializeComponents()
        {
            this.Text = "Profil Optimizasyon Sonuçları";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 240, 245);

            pnlOzet = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(1140, 120),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblBaslik = new Label
            {
                Text = "📊 OPTİMİZASYON ÖZETİ",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(15, 10),
                AutoSize = true
            };

            var lblToplamProfil = new Label
            {
                Text = $"Toplam Profil: {sonuc.ToplamProfilSayisi} adet",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 128, 185),
                Location = new Point(15, 45),
                AutoSize = true
            };

            var lblToplamHurda = new Label
            {
                Text = $"Toplam Hurda: {sonuc.ToplamHurdaUzunlugu:F2} mm",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(231, 76, 60),
                Location = new Point(250, 45),
                AutoSize = true
            };

            var lblKullanilanUzunluk = new Label
            {
                Text = $"Kullanılan: {sonuc.ToplamKullanilanUzunluk:F2} mm",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(39, 174, 96),
                Location = new Point(500, 45),
                AutoSize = true
            };

            var lblVerimlilik = new Label
            {
                Text = $"Verimlilik: %{sonuc.GenelVerimliliYuzdesi:F2}",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(142, 68, 173),
                Location = new Point(800, 45),
                AutoSize = true
            };

            var farkliUzunluklar = sonuc.ProfilListesi.Select(p => p.ProfilUzunlugu).Distinct().ToList();
            string uzunlukBilgisi = farkliUzunluklar.Count == 1
                ? $"Profil Uzunluğu: {farkliUzunluklar[0]}mm"
                : $"Profil Uzunlukları: {string.Join(", ", farkliUzunluklar.Select(u => u + "mm"))}";

            var lblProfilUzunluklari = new Label
            {
                Text = uzunlukBilgisi,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(127, 140, 141),
                Location = new Point(15, 80),
                AutoSize = true
            };

            pnlOzet.Controls.AddRange(new Control[] {
                lblBaslik, lblToplamProfil, lblToplamHurda,
                lblKullanilanUzunluk, lblVerimlilik, lblProfilUzunluklari
            });

            dgvProfiller = new DataGridView
            {
                Location = new Point(20, 160),
                Size = new Size(550, 420),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false
            };

            dgvProfiller.SelectionChanged += DgvProfiller_SelectionChanged;


            rtbDetay = new RichTextBox
            {
                Location = new Point(590, 160),
                Size = new Size(570, 420),
                ReadOnly = true,
                BackColor = Color.White,
                Font = new Font("Consolas", 9F),
                BorderStyle = BorderStyle.Fixed3D
            };

            btnKapat = new Button
            {
                Text = "❌ Kapat",
                Location = new Point(980, 600),
                Size = new Size(180, 40),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold)
            };
            btnKapat.FlatAppearance.BorderSize = 0;
            btnKapat.Click += (s, e) => this.Close();

            btnExport = new Button
            {
                Text = "📄 Rapor Al",
                Location = new Point(780, 600),
                Size = new Size(180, 40),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold)
            };
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.Click += BtnExport_Click;

            this.Controls.AddRange(new Control[] {
                pnlOzet, dgvProfiller, rtbDetay, btnKapat, btnExport
            });
        }

        private void SonuclariGoster()
        {
            dgvProfiller.Columns.Clear();
            dgvProfiller.Columns.Add("ProfilNo", "Profil No");
            dgvProfiller.Columns.Add("ProfilEbati", "Profil Ebatı");
            dgvProfiller.Columns.Add("ProfilUzunlugu", "Profil Uzunluğu");
            dgvProfiller.Columns.Add("ParcaSayisi", "Parça Sayısı");
            dgvProfiller.Columns.Add("KullanilanUzunluk", "Kullanılan (mm)");
            dgvProfiller.Columns.Add("HurdaUzunlugu", "Hurda (mm)");
            dgvProfiller.Columns.Add("Verimlilik", "Verimlilik %");

            foreach (var profil in sonuc.ProfilListesi)
            {
                decimal kullanilanUzunluk = profil.ProfilUzunlugu - profil.HurdaUzunlugu;

                int rowIndex = dgvProfiller.Rows.Add(
                    $"Profil #{profil.ProfilNo}",
                    profil.ProfilEbati,
                    profil.ProfilUzunlugu.ToString("F0") + "mm",
                    profil.Parcalar.Count,
                    kullanilanUzunluk.ToString("F2"),
                    profil.HurdaUzunlugu.ToString("F2"),
                    profil.VerimliliYuzdesi.ToString("F2")
                );

                // Verimlilik renklendir
                if (profil.VerimliliYuzdesi >= 90)
                    dgvProfiller.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
                else if (profil.VerimliliYuzdesi >= 75)
                    dgvProfiller.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 205);
                else
                    dgvProfiller.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
            }

            if (dgvProfiller.Rows.Count > 0)
                dgvProfiller.Rows[0].Selected = true;
        }

        private void DgvProfiller_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProfiller.SelectedRows.Count == 0) return;

            int selectedIndex = dgvProfiller.SelectedRows[0].Index;
            var profil = sonuc.ProfilListesi[selectedIndex];

            rtbDetay.Clear();
            rtbDetay.SelectionFont = new Font("Consolas", 11F, FontStyle.Bold);
            rtbDetay.SelectionColor = Color.FromArgb(52, 73, 94);
            rtbDetay.AppendText($"═══════════════════════════════════════════════\n");
            rtbDetay.AppendText($"  PROFİL #{profil.ProfilNo} - {profil.ProfilEbati}\n");
            rtbDetay.AppendText($"═══════════════════════════════════════════════\n\n");

            rtbDetay.SelectionFont = new Font("Consolas", 9F);
            rtbDetay.SelectionColor = Color.Black;
            rtbDetay.AppendText($"Profil Uzunluğu    : {profil.ProfilUzunlugu} mm\n");
            rtbDetay.AppendText($"Kullanılan Uzunluk : {profil.ProfilUzunlugu - profil.HurdaUzunlugu:F2} mm\n");
            rtbDetay.AppendText($"Hurda Uzunluğu     : {profil.HurdaUzunlugu:F2} mm\n");
            rtbDetay.AppendText($"Verimlilik         : %{profil.VerimliliYuzdesi:F2}\n");
            rtbDetay.AppendText($"Parça Sayısı       : {profil.Parcalar.Count}\n\n");

            rtbDetay.SelectionFont = new Font("Consolas", 10F, FontStyle.Bold);
            rtbDetay.SelectionColor = Color.FromArgb(41, 128, 185);
            rtbDetay.AppendText("PARÇA LİSTESİ:\n");
            rtbDetay.AppendText("───────────────────────────────────────────────\n\n");

            decimal toplamKesim = 0;
            for (int i = 0; i < profil.Parcalar.Count; i++)
            {
                var parca = profil.Parcalar[i];
                toplamKesim += parca.Uzunluk;

                rtbDetay.SelectionFont = new Font("Consolas", 9F);
                rtbDetay.SelectionColor = Color.Black;
                rtbDetay.AppendText($"{i + 1,3}. ");

                rtbDetay.SelectionColor = Color.FromArgb(39, 174, 96);
                rtbDetay.AppendText($"{parca.UrunKodu,-40}");

                rtbDetay.SelectionColor = Color.FromArgb(231, 76, 60);
                rtbDetay.AppendText($" {parca.Uzunluk,8:F2} mm");

                rtbDetay.SelectionColor = Color.Gray;
                rtbDetay.AppendText($"  (Toplam: {toplamKesim:F2})\n");
            }

            rtbDetay.AppendText("\n");
            rtbDetay.SelectionFont = new Font("Consolas", 9F, FontStyle.Bold);
            rtbDetay.SelectionColor = Color.FromArgb(142, 68, 173);
            rtbDetay.AppendText($"───────────────────────────────────────────────\n");
            rtbDetay.AppendText($"KALAN (HURDA): {profil.HurdaUzunlugu:F2} mm\n");
            rtbDetay.AppendText($"═══════════════════════════════════════════════");
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                    FileName = $"Profil_Optimizasyon_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                    {
                        sw.WriteLine("═══════════════════════════════════════════════════════════");
                        sw.WriteLine("              PROFİL OPTİMİZASYON RAPORU");
                        sw.WriteLine("═══════════════════════════════════════════════════════════");
                        sw.WriteLine($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                        sw.WriteLine();
                        sw.WriteLine("GENEL ÖZET");
                        sw.WriteLine("───────────────────────────────────────────────────────────");
                        sw.WriteLine($"Toplam Profil Sayısı    : {sonuc.ToplamProfilSayisi}");

                        var profilGruplari = sonuc.ProfilListesi
                            .GroupBy(p => p.ProfilEbati)
                            .Select(g => new { Ebat = g.Key, Adet = g.Count() });

                        foreach (var grup in profilGruplari)
                        {
                            sw.WriteLine($"{grup.Ebat,-23} : {grup.Adet} adet kullanıldı");
                        }

                        var farkliUzunluklar = sonuc.ProfilListesi.Select(p => p.ProfilUzunlugu).Distinct().ToList();
                        if (farkliUzunluklar.Count == 1)
                        {
                            sw.WriteLine($"Profil Uzunluğu         : {farkliUzunluklar[0]} mm");
                        }
                        else
                        {
                            sw.WriteLine($"Profil Uzunlukları      : {string.Join(", ", farkliUzunluklar.Select(u => u + "mm"))}");
                        }

                        sw.WriteLine($"Toplam Kullanılan       : {sonuc.ToplamKullanilanUzunluk:F2} mm");
                        sw.WriteLine($"Toplam Hurda            : {sonuc.ToplamHurdaUzunlugu:F2} mm");
                        sw.WriteLine($"Genel Verimlilik        : %{sonuc.GenelVerimliliYuzdesi:F2}");
                        sw.WriteLine();
                        sw.WriteLine();

                        foreach (var profil in sonuc.ProfilListesi)
                        {
                            sw.WriteLine("═══════════════════════════════════════════════════════════");
                            sw.WriteLine($"PROFİL #{profil.ProfilNo} - {profil.ProfilEbati}");
                            sw.WriteLine("═══════════════════════════════════════════════════════════");
                            sw.WriteLine($"Profil Uzunluğu    : {profil.ProfilUzunlugu} mm");
                            sw.WriteLine($"Kullanılan         : {profil.ProfilUzunlugu - profil.HurdaUzunlugu:F2} mm");
                            sw.WriteLine($"Hurda              : {profil.HurdaUzunlugu:F2} mm");
                            sw.WriteLine($"Verimlilik         : %{profil.VerimliliYuzdesi:F2}");
                            sw.WriteLine($"Parça Sayısı       : {profil.Parcalar.Count}");
                            sw.WriteLine();
                            sw.WriteLine("PARÇA LİSTESİ:");
                            sw.WriteLine("───────────────────────────────────────────────────────────");

                            decimal toplam = 0;
                            for (int i = 0; i < profil.Parcalar.Count; i++)
                            {
                                var parca = profil.Parcalar[i];
                                toplam += parca.Uzunluk;
                                sw.WriteLine($"{i + 1,3}. {parca.UrunKodu,-45} {parca.Uzunluk,8:F2} mm (Toplam: {toplam:F2})");
                            }

                            sw.WriteLine();
                            sw.WriteLine($"KALAN (HURDA): {profil.HurdaUzunlugu:F2} mm");
                            sw.WriteLine();
                            sw.WriteLine();
                        }

                        sw.WriteLine("═══════════════════════════════════════════════════════════");
                        sw.WriteLine("                    RAPOR SONU");
                        sw.WriteLine("═══════════════════════════════════════════════════════════");
                    }

                    MessageBox.Show("Rapor başarıyla kaydedildi!", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor kaydedilirken hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #endregion
}
