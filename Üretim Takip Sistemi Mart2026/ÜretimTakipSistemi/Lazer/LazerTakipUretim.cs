using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.Lazer
{
    public partial class LazerTakipUretim : Form
    {
        private string connectionString = "Data Source=192.168.1.144,1433;Network Library=DBMSSOCN; Initial Catalog=Lazer; User Id=ADMIN; Password=1;";
        private readonly ILazerUrunFormService _lazerUrunFormService;
        private readonly ILazerSiparisFormService _lazerSiparisFormService;

        public LazerTakipUretim()
        {
            InitializeComponent();
            _lazerUrunFormService = InstanceFactory.GetInstance<ILazerUrunFormService>();
            _lazerSiparisFormService = InstanceFactory.GetInstance<ILazerSiparisFormService>();
            dgvSiparisler.CellFormatting += dgvSiparisler_CellFormatting;
            TeknikResimYonetici.Baslat(dgvUrunler, connectionString);
        }

        private void LazerTakipUretim_Load(object sender, EventArgs e)
        {
            ProfilStoklariniYukle();
            SacStoklariniYukle();
            BoruLazerUrunleriniYukle();
            PlakaLazerUrunleriniYukle();
            TumUrunleriYukle();
            SiparisleriYukle();

            // Ürün yönetimi filtre ComboBox başlat
            if (cmbUrunTipiFiltre != null)
            {
                cmbUrunTipiFiltre.Items.Clear();
                cmbUrunTipiFiltre.Items.AddRange(new object[] { "Tümü", "Boru", "Plaka" });
                cmbUrunTipiFiltre.SelectedIndex = 0;
                cmbUrunTipiFiltre.SelectedIndexChanged += cmbUrunTipiFiltre_SelectedIndexChanged;
            }
        }

        #region BORU LAZER İŞLEMLERİ

        private void ProfilStoklariniYukle()
        {
            try
            {
                DataTable dt = _lazerUrunFormService.GetProfilStokListesi(connectionString);

                dgvProfilStok.DataSource = dt;
                dgvProfilStok.Columns["ProfilID"].Visible = false;
                dgvProfilStok.Columns["ProfilEbati"].HeaderText = "Profil Ebatı";
                dgvProfilStok.Columns["ProfilUzunlugu"].HeaderText = "Profil Uzunluğu (mm)";
                dgvProfilStok.Columns["StokAdedi"].HeaderText = "Stok Adedi";
                dgvProfilStok.Columns["MinimumStok"].HeaderText = "Minimum Stok";

                foreach (DataGridViewRow row in dgvProfilStok.Rows)
                {
                    if (row.Cells["Durum"].Value != null)
                    {
                        if (row.Cells["Durum"].Value.ToString().Contains("Kritik"))
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                        else if (row.Cells["Durum"].Value.ToString().Contains("Dikkat"))
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 205);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Profil stokları yüklenirken hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BoruLazerUrunleriniYukle()
        {
            try
            {
                DataTable dt = _lazerUrunFormService.GetBoruLazerUrunleri(connectionString);

                cmbBoruUrun.DisplayMember = "UrunBilgi";
                cmbBoruUrun.ValueMember = "UrunID";
                cmbBoruUrun.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Boru lazer ürünleri yüklenirken hata: " + ex.Message);
            }
        }

        private void cmbBoruUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoruUrun.SelectedValue == null) return;

            try
            {
                int urunID = Convert.ToInt32(cmbBoruUrun.SelectedValue);
                DataTable dt = _lazerUrunFormService.GetBoruUrunDetaylari(connectionString, urunID);
                dgvBoruDetay.DataSource = dt;
                if (dgvBoruDetay.Columns.Count >= 6)
                {
                    dgvBoruDetay.Columns[0].HeaderText = "Parça Adı";
                    dgvBoruDetay.Columns[1].HeaderText = "Adet";
                    dgvBoruDetay.Columns[2].HeaderText = "Ürün Boyu (mm)";
                    dgvBoruDetay.Columns[3].HeaderText = "Profil Ebatı";
                    dgvBoruDetay.Columns[4].HeaderText = "Profil Uzunluğu (mm)";
                    dgvBoruDetay.Columns[5].HeaderText = "Profil Başına Adet";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün detayları yüklenirken hata: " + ex.Message);
            }
        }

        private void btnBoruHesapla_Click(object sender, EventArgs e)
        {
            if (cmbBoruUrun.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir ürün seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int urunID = Convert.ToInt32(cmbBoruUrun.SelectedValue);
                int siparisAdedi = (int)numBoruSiparisAdet.Value;

                DataTable dtDetay = _lazerUrunFormService.GetBoruUrunDetaylari(connectionString, urunID);

                if (dtDetay.Rows.Count == 0)
                {
                    MessageBox.Show("Bu ürüne ait detay bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var urunler = new List<UrunBilgisi>();
                foreach (DataRow row in dtDetay.Rows)
                {
                    int parcaAdet = Convert.ToInt32(row[1]);
                    decimal urunBoyu = Convert.ToDecimal(row[2]);
                    string profilEbati = row[3].ToString();
                    decimal profilUzunlugu = Convert.ToDecimal(row[4]);
                    string parcaAdi = row[0].ToString();

                    urunler.Add(new UrunBilgisi
                    {
                        UrunKodu = parcaAdi,
                        UrunAdi = parcaAdi,
                        UrunBoyu = urunBoyu,
                        ProfilEbati = profilEbati,
                        ProfilUzunlugu = profilUzunlugu,
                        Adet = siparisAdedi * parcaAdet
                    });
                }

                var service = new ProfilStokService(connectionString);
                var optimizasyon = service.ProfilOptimizasyonuHesapla(urunler);

                var stokBilgisi = new Dictionary<string, int>();
                foreach (var profil in optimizasyon.ProfilListesi
                             .GroupBy(p => new { p.ProfilEbati, p.ProfilUzunlugu })
                             .Select(g => g.Key))
                {
                    string key = $"{profil.ProfilEbati}|{profil.ProfilUzunlugu}";
                    if (stokBilgisi.ContainsKey(key)) continue;

                    stokBilgisi[key] = _lazerUrunFormService.GetProfilStokAdedi(
                        connectionString,
                        profil.ProfilEbati,
                        profil.ProfilUzunlugu);
                }

                Action<string, Color, bool> Yaz = (metin, renk, bold) =>
                {
                    rtxtBoruSonuc.SelectionStart = rtxtBoruSonuc.TextLength;
                    rtxtBoruSonuc.SelectionLength = 0;
                    rtxtBoruSonuc.SelectionColor = renk;
                    rtxtBoruSonuc.SelectionFont = new Font(rtxtBoruSonuc.Font, bold ? FontStyle.Bold : FontStyle.Regular);
                    rtxtBoruSonuc.AppendText(metin + Environment.NewLine);
                    rtxtBoruSonuc.SelectionColor = rtxtBoruSonuc.ForeColor;
                };

                Color renkBaslik = Color.FromArgb(30, 144, 255);
                Color renkEbat = Color.FromArgb(70, 130, 180);
                Color renkProfilSat = Color.FromArgb(100, 149, 237);
                Color renkHurda = Color.FromArgb(180, 100, 0);
                Color renkYeter = Color.FromArgb(0, 140, 0);
                Color renkYetersiz = Color.FromArgb(200, 0, 0);
                Color renkOzet = Color.FromArgb(80, 80, 80);
                Color renkCizgi = Color.FromArgb(160, 160, 160);

                rtxtBoruSonuc.Clear();

                Yaz("═══════════════════════════════════════════════════", renkCizgi, false);
                Yaz("           BORU LAZER HESAPLAMA SONUCU              ", renkBaslik, true);
                Yaz("═══════════════════════════════════════════════════", renkCizgi, false);
                Yaz($"  Sipariş Adedi : {siparisAdedi} adet", renkOzet, false);
                Yaz($"  Toplam Profil : {optimizasyon.ToplamProfilSayisi} adet", renkOzet, false);
                Yaz($"  Verimlilik    : %{optimizasyon.GenelVerimliliYuzdesi:F2}", renkOzet, false);
                Yaz($"  Toplam Hurda  : {optimizasyon.ToplamHurdaUzunlugu:N0} mm", renkOzet, false);
                Yaz("", renkOzet, false);

                var profilOzeti = optimizasyon.ProfilListesi
                    .GroupBy(p => new { p.ProfilEbati, p.ProfilUzunlugu })
                    .Select(g => new
                    {
                        g.Key.ProfilEbati,
                        g.Key.ProfilUzunlugu,
                        ProfilAdedi = g.Count(),
                        ToplamHurda = g.Sum(x => x.HurdaUzunlugu),
                        ToplamKullanilan = g.Sum(x => x.ProfilUzunlugu - x.HurdaUzunlugu),
                        OrtVerimliliYuzdesi = g.Average(x => x.VerimliliYuzdesi)
                    }).ToList();

                Yaz("───────────────────────────────────────────────────", renkCizgi, false);
                Yaz("  PROFİL ÖZET", renkBaslik, true);
                Yaz("───────────────────────────────────────────────────", renkCizgi, false);

                bool stokYeterli = true;
                foreach (var oz in profilOzeti)
                {
                    string key = $"{oz.ProfilEbati}|{oz.ProfilUzunlugu}";
                    int stok = stokBilgisi.ContainsKey(key) ? stokBilgisi[key] : 0;
                    bool yeter = stok >= oz.ProfilAdedi;
                    if (!yeter) stokYeterli = false;

                    Yaz($"  {oz.ProfilEbati}  ({oz.ProfilUzunlugu:N0} mm'lik)", renkEbat, true);
                    Yaz($"    Gereken : {oz.ProfilAdedi} adet   |   Kullanılan: {oz.ToplamKullanilan:N0} mm   |   Hurda: {oz.ToplamHurda:N0} mm   |   Ort. Verim: %{oz.OrtVerimliliYuzdesi:F1}", renkOzet, false);
                    Yaz(yeter
                        ? $"    Stok    : ✔ YETER  (Mevcut: {stok} adet)"
                        : $"    Stok    : ✘ YETERSİZ  (Mevcut: {stok}, Eksik: {oz.ProfilAdedi - stok} adet)",
                        yeter ? renkYeter : renkYetersiz, true);
                    Yaz("", renkOzet, false);
                }

                Yaz("───────────────────────────────────────────────────", renkCizgi, false);
                Yaz("  KESİM PLANI", renkBaslik, true);
                Yaz("───────────────────────────────────────────────────", renkCizgi, false);

                var urunRenkleri = new Color[]
                {
                    Color.FromArgb(30,100,200), Color.FromArgb(0,140,100),
                    Color.FromArgb(160,60,160), Color.FromArgb(180,100,0),
                    Color.FromArgb(180,30,30),  Color.FromArgb(0,150,180),
                };
                var urunRenkMap = new Dictionary<string, Color>();
                int renkIndex = 0;

                foreach (var grup in optimizasyon.ProfilListesi.GroupBy(p => p.ProfilEbati))
                {
                    Yaz("", renkCizgi, false);
                    Yaz($"  ▌ {grup.Key}", renkEbat, true);

                    var duzenGruplari = grup
                        .GroupBy(p => string.Join("|", p.Parcalar.Select(x => $"{x.UrunKodu}:{x.Uzunluk}")))
                        .ToList();

                    foreach (var duzenGrup in duzenGruplari)
                    {
                        var profilOrnek = duzenGrup.First();
                        int ayniProfilAdedi = duzenGrup.Count();
                        decimal kullanilan = profilOrnek.ProfilUzunlugu - profilOrnek.HurdaUzunlugu;

                        string profilBaslik = $"    ┌─ Profil  ×{ayniProfilAdedi}   " +
                                              $"Kullanılan: {kullanilan:N0} mm  " +
                                              $"Hurda: {profilOrnek.HurdaUzunlugu:N0} mm  " +
                                              $"(%{profilOrnek.VerimliliYuzdesi:F1})";
                        Yaz(profilBaslik, renkProfilSat, true);

                        var parcaGruplari = profilOrnek.Parcalar
                            .GroupBy(p => p.UrunKodu)
                            .Select(g => new { UrunKodu = g.Key, Uzunluk = g.First().Uzunluk, Adet = g.Count() })
                            .ToList();

                        foreach (var pg in parcaGruplari)
                        {
                            if (!urunRenkMap.ContainsKey(pg.UrunKodu))
                                urunRenkMap[pg.UrunKodu] = urunRenkleri[renkIndex++ % urunRenkleri.Length];

                            string adetStr = pg.Adet > 1 ? $" ×{pg.Adet}" : "     ";
                            string parca = $"    │  {pg.UrunKodu,-28}{adetStr}   {pg.Uzunluk:N0} mm/adet   (toplam: {pg.Uzunluk * pg.Adet:N0} mm)";
                            Yaz(parca, urunRenkMap[pg.UrunKodu], false);
                        }

                        Yaz($"    └─ Kalan (hurda): {profilOrnek.HurdaUzunlugu:N0} mm", renkHurda, false);
                    }
                }

                Yaz("", renkCizgi, false);
                Yaz("═══════════════════════════════════════════════════", renkCizgi, false);
                if (stokYeterli)
                {
                    Yaz("  ✔ STOK DURUMU: TÜM MALZEMELER MEVCUT", renkYeter, true);
                    Yaz("    ÜRETİME BAŞLANABİLİR!", renkYeter, false);
                }
                else
                {
                    Yaz("  ✘ STOK DURUMU: EKSİK MALZEME VAR", renkYetersiz, true);
                    Yaz("    EKSİK MALZEMELERİ TEMİN EDİN!", renkYetersiz, false);
                }
                Yaz("═══════════════════════════════════════════════════", renkCizgi, false);

                rtxtBoruSonuc.SelectionStart = 0;
                rtxtBoruSonuc.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesaplama sırasında hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProfilStokGuncelle_Click(object sender, EventArgs e)
        {
            ProfilStoklariniYukle();
            MessageBox.Show("Profil stokları güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStokDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvProfilStok.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek için bir profil seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int profilID = Convert.ToInt32(dgvProfilStok.SelectedRows[0].Cells["ProfilID"].Value);
                string profilEbati = dgvProfilStok.SelectedRows[0].Cells["ProfilEbati"].Value.ToString();
                int mevcutStok = Convert.ToInt32(dgvProfilStok.SelectedRows[0].Cells["StokAdedi"].Value);

                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Profil: {profilEbati}\nMevcut Stok: {mevcutStok}\n\nYeni stok miktarını girin:",
                    "Stok Güncelleme", mevcutStok.ToString());

                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int yeniStok))
                {
                    _lazerUrunFormService.GuncelleProfilStok(connectionString, profilID, mevcutStok, yeniStok);

                    ProfilStoklariniYukle();
                    MessageBox.Show("Stok başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok güncellenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region PLAKA LAZER İŞLEMLERİ

        private void SacStoklariniYukle()
        {
            try
            {
                DataTable dt = _lazerUrunFormService.GetSacStokListesi(connectionString);

                dgvSacStok.DataSource = dt;
                dgvSacStok.Columns["SacID"].Visible = false;
                dgvSacStok.Columns["SacKalinligi"].HeaderText = "Sac Kalınlığı (mm)";
                dgvSacStok.Columns["SacEbatX"].HeaderText = "Ebat X (mm)";
                dgvSacStok.Columns["SacEbatY"].HeaderText = "Ebat Y (mm)";
                dgvSacStok.Columns["StokAdedi"].HeaderText = "Stok Adedi";
                dgvSacStok.Columns["MinimumStok"].HeaderText = "Minimum Stok";

                foreach (DataGridViewRow row in dgvSacStok.Rows)
                {
                    if (row.Cells["Durum"].Value != null)
                    {
                        if (row.Cells["Durum"].Value.ToString().Contains("Kritik"))
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                        else if (row.Cells["Durum"].Value.ToString().Contains("Dikkat"))
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 205);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sac stokları yüklenirken hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlakaLazerUrunleriniYukle()
        {
            try
            {
                DataTable dt = _lazerUrunFormService.GetPlakaLazerUrunleri(connectionString);

                cmbPlakaUrun.DisplayMember = "UrunBilgi";
                cmbPlakaUrun.ValueMember = "UrunID";
                cmbPlakaUrun.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Plaka lazer ürünleri yüklenirken hata: " + ex.Message);
            }
        }

        private void cmbPlakaUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlakaUrun.SelectedValue == null) return;

            try
            {
                int urunID = Convert.ToInt32(cmbPlakaUrun.SelectedValue);
                DataTable dt = _lazerUrunFormService.GetPlakaUrunDetaylari(connectionString, urunID);
                dgvPlakaDetay.DataSource = dt;
                if (dgvPlakaDetay.Columns.Count >= 6)
                {
                    dgvPlakaDetay.Columns[0].HeaderText = "Parça Adı";
                    dgvPlakaDetay.Columns[1].HeaderText = "Adet";
                    dgvPlakaDetay.Columns[2].HeaderText = "Sac Kalınlığı (mm)";
                    dgvPlakaDetay.Columns[3].HeaderText = "Sac Ebat X (mm)";
                    dgvPlakaDetay.Columns[4].HeaderText = "Sac Ebat Y (mm)";
                    dgvPlakaDetay.Columns[5].HeaderText = "Sac Başına Adet";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün detayları yüklenirken hata: " + ex.Message);
            }
        }

        private void btnPlakaHesapla_Click(object sender, EventArgs e)
        {
            if (cmbPlakaUrun.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir ürün seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int urunID = Convert.ToInt32(cmbPlakaUrun.SelectedValue);
                int siparisAdedi = (int)numPlakaSiparisAdet.Value;

                StringBuilder sonuc = new StringBuilder();
                sonuc.AppendLine("═══════════════════════════════════════");
                sonuc.AppendLine("   PLAKA LAZER HESAPLAMA SONUÇLARI");
                sonuc.AppendLine("═══════════════════════════════════════\n");
                sonuc.AppendLine($"Sipariş Adedi: {siparisAdedi} adet\n");

                bool stokYeterli = true;
                DataTable dtDetay = _lazerUrunFormService.GetPlakaUrunDetaylari(connectionString, urunID);

                foreach (DataRow row in dtDetay.Rows)
                {
                    string parcaAdi = row[0].ToString();
                    int parcaAdet = Convert.ToInt32(row[1]);
                    decimal sacKalinligi = Convert.ToDecimal(row[2]);
                    decimal sacEbatX = Convert.ToDecimal(row[3]);
                    decimal sacEbatY = Convert.ToDecimal(row[4]);
                    int birimSacKapasitesi = Convert.ToInt32(row[5]);

                    int toplamParcaAdedi = siparisAdedi * parcaAdet;
                    int gerekliSacAdedi = (int)Math.Ceiling((double)toplamParcaAdedi / birimSacKapasitesi);
                    int artikParca = (gerekliSacAdedi * birimSacKapasitesi) - toplamParcaAdedi;
                    int mevcutStok = _lazerUrunFormService.GetSacStokAdedi(connectionString, sacKalinligi, sacEbatX, sacEbatY);

                    sonuc.AppendLine($"📋 {parcaAdi}");
                    sonuc.AppendLine($"   • Parça Adedi (1 Üründe): {parcaAdet} adet");
                    sonuc.AppendLine($"   • Toplam Parça İhtiyacı: {toplamParcaAdedi} adet");
                    sonuc.AppendLine($"   • Sac: {sacKalinligi}mm - {sacEbatX}x{sacEbatY} mm");
                    sonuc.AppendLine($"   • Sac Başına Adet: {birimSacKapasitesi} adet");
                    sonuc.AppendLine($"   • Gerekli Sac Adedi: {gerekliSacAdedi} adet");
                    sonuc.AppendLine($"   • Artık Parça: {artikParca} adet");

                    if (mevcutStok >= gerekliSacAdedi)
                        sonuc.AppendLine($"   • Stok Durumu: ✅ YETER (Mevcut: {mevcutStok} adet)");
                    else
                    {
                        sonuc.AppendLine($"   • Stok Durumu: ❌ YETERSİZ (Mevcut: {mevcutStok}, Eksik: {gerekliSacAdedi - mevcutStok} adet)");
                        stokYeterli = false;
                    }
                    sonuc.AppendLine();
                }

                if (stokYeterli)
                {
                    sonuc.AppendLine("✅ STOK DURUMU: TÜM MALZEMELER MEVCUT");
                    sonuc.AppendLine("ÜRETİME BAŞLANABİLİR!");
                }
                else
                {
                    sonuc.AppendLine("❌ STOK DURUMU: EKSIK MALZEME VAR");
                    sonuc.AppendLine("EKSİK MALZEMELERİ TEMİN EDİN!");
                }
                sonuc.AppendLine("═══════════════════════════════════════");

                lblPlakaSonuc.Text = sonuc.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesaplama sırasında hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSacStokGuncelle_Click(object sender, EventArgs e)
        {
            SacStoklariniYukle();
            MessageBox.Show("Sac stokları güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSacStokDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvSacStok.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek için bir sac seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int sacID = Convert.ToInt32(dgvSacStok.SelectedRows[0].Cells["SacID"].Value);
                string sacBilgi = $"{dgvSacStok.SelectedRows[0].Cells["SacKalinligi"].Value}mm - " +
                                 $"{dgvSacStok.SelectedRows[0].Cells["SacEbatX"].Value}x" +
                                 $"{dgvSacStok.SelectedRows[0].Cells["SacEbatY"].Value}";
                int mevcutStok = Convert.ToInt32(dgvSacStok.SelectedRows[0].Cells["StokAdedi"].Value);

                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Sac: {sacBilgi}\nMevcut Stok: {mevcutStok}\n\nYeni stok miktarını girin:",
                    "Stok Güncelleme", mevcutStok.ToString());

                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int yeniStok))
                {
                    _lazerUrunFormService.GuncelleSacStok(connectionString, sacID, mevcutStok, yeniStok);

                    SacStoklariniYukle();
                    MessageBox.Show("Stok başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok güncellenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// YENİ: Sac stok ekleme formu — farklı ebatlarda yeni plaka ekler
        /// </summary>
        private void btnSacStokEkle_Click(object sender, EventArgs e)
        {
            var frm = new SacStokEkleForm(connectionString);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SacStoklariniYukle();
            }
        }

        private void btnStokDuzenlePlaka_Click(object sender, EventArgs e)
        {
            if (dgvSacStok.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek için bir sac seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int sacID = Convert.ToInt32(dgvSacStok.SelectedRows[0].Cells["SacID"].Value);
                string sacBilgi = $"{dgvSacStok.SelectedRows[0].Cells["SacKalinligi"].Value}mm";
                int mevcutStok = Convert.ToInt32(dgvSacStok.SelectedRows[0].Cells["StokAdedi"].Value);

                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Sac: {sacBilgi}\nMevcut Stok: {mevcutStok}\n\nYeni stok miktarını girin:",
                    "Stok Güncelleme", mevcutStok.ToString());

                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int yeniStok))
                {
                    _lazerUrunFormService.GuncelleSacStok(connectionString, sacID, mevcutStok, yeniStok);

                    SacStoklariniYukle();
                    MessageBox.Show("Stok başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok güncellenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ÜRÜN YÖNETİMİ

        private void TumUrunleriYukle()
        {
            try
            {
                DataTable dt = _lazerUrunFormService.GetTumUrunler(connectionString);

                dgvUrunler.DataSource = dt;
                dgvUrunler.Columns["UrunID"].Visible = false;
                dgvUrunler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 245, 255);
                dgvUrunler.RowsDefaultCellStyle.BackColor = Color.White;
                dgvUrunler.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
                dgvUrunler.DefaultCellStyle.SelectionForeColor = Color.White;
                dgvUrunler.GridColor = Color.LightGray;
                dgvUrunler.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata: " + ex.Message);
            }
        }

        // ── Ürün Tipi Filtresi (ComboBox) ──────────────────────────────
        private void cmbUrunTipiFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            UrunFiltreUygula();
        }

        private void txturunara_TextChanged(object sender, EventArgs e)
        {
            UrunFiltreUygula();
        }

        private void UrunFiltreUygula()
        {
            if (!(dgvUrunler.DataSource is DataTable dt)) return;

            string arananKelime = txturunara.Text.Trim().Replace("'", "''");
            string tipiFiltre = cmbUrunTipiFiltre?.SelectedItem?.ToString() ?? "Tümü";

            var filtreler = new List<string>();

            if (!string.IsNullOrEmpty(arananKelime))
                filtreler.Add($"([Ürün Kodu] LIKE '%{arananKelime}%' OR [Ürün Adı] LIKE '%{arananKelime}%')");

            if (tipiFiltre != "Tümü")
                filtreler.Add($"[Lazer Tipi] = '{tipiFiltre}'");

            dt.DefaultView.RowFilter = filtreler.Count > 0 ? string.Join(" AND ", filtreler) : string.Empty;
        }

        private void btnYeniUrun_Click(object sender, EventArgs e)
        {
            YeniUrunForm frm = new YeniUrunForm(connectionString);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TumUrunleriYukle();
                BoruLazerUrunleriniYukle();
                PlakaLazerUrunleriniYukle();
            }
        }

        private void btnUrunDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek için bir ürün seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int urunID = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["UrunID"].Value);
            YeniUrunForm frm = new YeniUrunForm(connectionString, urunID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TumUrunleriYukle();
                BoruLazerUrunleriniYukle();
                PlakaLazerUrunleriniYukle();
            }
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir ürün seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili ürünü silmek istediğinizden emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int urunID = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["UrunID"].Value);
                    _lazerUrunFormService.UrunuPasifeAl(connectionString, urunID);

                    MessageBox.Show("Ürün başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TumUrunleriYukle();
                    BoruLazerUrunleriniYukle();
                    PlakaLazerUrunleriniYukle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürün silinirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region SİPARİŞ YÖNETİMİ

        private void SiparisleriYukle()
        {
            try
            {
                DataTable dt = _lazerSiparisFormService.GetSiparisListesi(connectionString);

                dgvSiparisler.DataSource = dt;
                dgvSiparisler.Columns["SiparisID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Siparişler yüklenirken hata: " + ex.Message);
            }
        }

        private void btnYeniSiparis_Click(object sender, EventArgs e)
        {
            YeniSiparisForm frm = new YeniSiparisForm(connectionString);
            if (frm.ShowDialog() == DialogResult.OK)
                SiparisleriYukle();
        }

        private void btnSiparisDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvSiparisler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek için bir sipariş seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int siparisID = Convert.ToInt32(dgvSiparisler.SelectedRows[0].Cells["SiparisID"].Value);
            YeniSiparisForm frm = new YeniSiparisForm(connectionString, siparisID);
            if (frm.ShowDialog() == DialogResult.OK)
                SiparisleriYukle();
        }

        private void btnSiparisTamamla_Click(object sender, EventArgs e)
        {
            if (dgvSiparisler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen tamamlamak için bir sipariş seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mevcutDurum = dgvSiparisler.SelectedRows[0].Cells["Durum"].Value.ToString();
            if (mevcutDurum == "Tamamlandı")
            {
                MessageBox.Show("Bu sipariş zaten tamamlanmış!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int siparisID = Convert.ToInt32(dgvSiparisler.SelectedRows[0].Cells["SiparisID"].Value);
            var service = new ProfilStokService(connectionString);
            string onayMesaji = service.OnayMesajiOlustur(siparisID);

            string mesaj = onayMesaji
                ?? "Bu siparişte profil gerektiren ürün bulunamadı.\nYalnızca durum güncellenecek.\n\nDevam edilsin mi?";

            if (MessageBox.Show(mesaj, "Sipariş Tamamlama Onayı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (service.SiparisiBitirVeStokDus(siparisID, out string hata))
            {
                MessageBox.Show("✅ Sipariş tamamlandı ve profil stokları güncellendi.",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SiparisleriYukle();
                ProfilStoklariniYukle();
            }
            else
            {
                MessageBox.Show("Hata: " + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSiparisler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int siparisID = Convert.ToInt32(dgvSiparisler.Rows[e.RowIndex].Cells["SiparisID"].Value);
                SiparisDetayForm frm = new SiparisDetayForm(connectionString, siparisID);
                frm.ShowDialog();
                SiparisleriYukle();
            }
        }

        /// <summary>
        /// Siparişler grid renklendirmesi:
        /// - Durum bazlı renk (mevcut davranış korundu)
        /// - "Ürün Teslim (En Yakın)" sütunu için kalan gün rengi EKLENDİ
        /// </summary>
        private void dgvSiparisler_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string kolonAdi = dgvSiparisler.Columns[e.ColumnIndex].Name;

            if (kolonAdi == "Durum")
            {
                string durum = e.Value.ToString();
                DataGridViewRow row = dgvSiparisler.Rows[e.RowIndex];
                if (durum == "Beklemede")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 200);
                else
                    row.DefaultCellStyle.BackColor = Color.FromArgb(150, 255, 150);
            }
            else if (kolonAdi == "Ürün Teslim (En Yakın)")
            {
                string deger = e.Value.ToString();
                if (string.IsNullOrWhiteSpace(deger)) return;

                if (DateTime.TryParse(deger, out DateTime teslimTarihi))
                {
                    int kalanGun = (teslimTarihi - DateTime.Today).Days;

                    if (kalanGun < 0)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(220, 80, 80);
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.Font = new Font(dgvSiparisler.Font, FontStyle.Bold);
                    }
                    else if (kalanGun <= 3)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 140, 0);
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.Font = new Font(dgvSiparisler.Font, FontStyle.Bold);
                    }
                    else if (kalanGun <= 7)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 230, 80);
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.Font = new Font(dgvSiparisler.Font, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.FromArgb(180, 240, 180);
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        #region Siparişi Excel Yükleme

        private void btnExclYkl_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Sipariş Excel Dosyasını Seçin";
                ofd.Filter = "Excel Dosyaları (*.xlsx;*.xls)|*.xlsx;*.xls";

                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    DataTable dtExcel = ExceldenOku(ofd.FileName);

                    if (dtExcel == null || dtExcel.Rows.Count == 0)
                    {
                        MessageBox.Show("Excel dosyası boş veya okunamadı.", "Uyarı",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!dtExcel.Columns.Contains("StokKodu") ||
                        !dtExcel.Columns.Contains("ÜrünAdı") ||
                        !dtExcel.Columns.Contains("Adet") ||
                        !dtExcel.Columns.Contains("Teslim Tarihi"))
                    {
                        MessageBox.Show(
                            "Excel dosyasında gerekli sütunlar bulunamadı!\nBeklenen sütunlar: StokKodu | ÜrünAdı | Adet | Teslim Tarihi",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string siparisNo = SiparisNoUret();
                    LazerExcelSiparisAktarTalep talep = new LazerExcelSiparisAktarTalep
                    {
                        SiparisNo = siparisNo,
                        Musteri = "KELEBEK",
                        Aciklama = $"Excelden aktarıldı..{Path.GetFileName(ofd.FileName)}"
                    };

                    int hataliTarih = 0;
                    var hataMesajlari = new StringBuilder();

                    foreach (DataRow row in dtExcel.Rows)
                    {
                        string stokKodu = row["StokKodu"]?.ToString().Trim();
                        string adetStr = row["Adet"]?.ToString().Trim();
                        string teslimStr = row["Teslim Tarihi"]?.ToString().Trim();

                        if (string.IsNullOrEmpty(stokKodu))
                        {
                            continue;
                        }

                        if (!int.TryParse(adetStr, out int adet))
                        {
                            adet = 0;
                        }

                        DateTime? teslimTarihi = null;
                        if (!string.IsNullOrEmpty(teslimStr))
                        {
                            if (DateTime.TryParse(teslimStr, out DateTime parsedDate))
                            {
                                teslimTarihi = parsedDate;
                            }
                            else
                            {
                                hataliTarih++;
                                hataMesajlari.AppendLine($"• '{stokKodu}' - Geçersiz teslim tarihi: {teslimStr}");
                                continue;
                            }
                        }

                        talep.Satirlar.Add(new LazerExcelSiparisSatiri
                        {
                            StokKodu = stokKodu,
                            Adet = adet,
                            TeslimTarihi = teslimTarihi
                        });
                    }

                    LazerExcelSiparisAktarSonuc sonuc = _lazerSiparisFormService.AktarExcelSiparisi(connectionString, talep);

                    int toplamHatali = sonuc.HataliSatirSayisi + hataliTarih;
                    string mesaj = $"✅ Sipariş başarıyla oluşturuldu!\n\nSipariş No : {siparisNo}\nEklenen    : {sonuc.BasariliSatirSayisi} ürün\n";

                    if (toplamHatali > 0)
                    {
                        mesaj += $"Atlanan    : {toplamHatali} satır\n\nAtlanan satırlar:\n";

                        if (hataMesajlari.Length > 0)
                        {
                            mesaj += hataMesajlari.ToString();
                        }

                        if (sonuc.HataMesajlari.Count > 0)
                        {
                            mesaj += string.Join(Environment.NewLine, sonuc.HataMesajlari);
                        }
                    }

                    MessageBox.Show(mesaj, toplamHatali > 0 ? "Kısmi Başarı" : "Başarılı",
                        MessageBoxButtons.OK, toplamHatali > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                    SiparisleriYukle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private DataTable ExceldenOku(string dosyaYolu)
        {
            DataTable dt = new DataTable();
            using (var package = new ExcelPackage(new FileInfo(dosyaYolu)))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets[1];
                if (ws.Dimension == null) return dt;

                int satirSayisi = ws.Dimension.Rows;
                int sutunSayisi = ws.Dimension.Columns;

                for (int s = 1; s <= sutunSayisi; s++)
                {
                    string baslik = ws.Cells[1, s].Text.Trim();
                    dt.Columns.Add(string.IsNullOrEmpty(baslik) ? $"Sutun{s}" : baslik);
                }

                for (int r = 2; r <= satirSayisi; r++)
                {
                    DataRow dataRow = dt.NewRow();
                    bool satirDolu = false;
                    for (int s = 1; s <= sutunSayisi; s++)
                    {
                        string deger = ws.Cells[r, s].Text.Trim();
                        dataRow[s - 1] = deger;
                        if (!string.IsNullOrEmpty(deger)) satirDolu = true;
                    }
                    if (satirDolu) dt.Rows.Add(dataRow);
                }
            }
            return dt;
        }

        private string SiparisNoUret()
        {
            return _lazerSiparisFormService.UretSiparisNo(connectionString);
        }

        #endregion

        private void btnSiparisSil_Click(object sender, EventArgs e)
        {
            if (dgvSiparisler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir sipariş seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili siparişi ve içeriğindeki tüm ürünleri silmek istediğinizden emin misiniz?\nBu işlem geri alınamaz!",
                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int siparisID = Convert.ToInt32(dgvSiparisler.SelectedRows[0].Cells["SiparisID"].Value);
                    _lazerSiparisFormService.SilSiparis(connectionString, siparisID);
                    MessageBox.Show("Sipariş başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SiparisleriYukle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sipariş silinirken hata oluştu: " + ex.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTumUrunler_Click(object sender, EventArgs e)
        {
            var frm = new TumSiparisUrunleriForm(connectionString);
            frm.ShowDialog();
        }

        #endregion
    }

    public class SacStokEkleForm : Form
    {
        private readonly string _connectionString;
        private readonly ILazerUrunFormService _lazerUrunFormService;
        private NumericUpDown numKalinlik;
        private NumericUpDown numEbatX;
        private NumericUpDown numEbatY;
        private NumericUpDown numStokAdedi;
        private NumericUpDown numMinimumStok;
        private Button btnKaydet;
        private Button btnIptal;

        public SacStokEkleForm(string connectionString)
        {
            _connectionString = connectionString;
            _lazerUrunFormService = InstanceFactory.GetInstance<ILazerUrunFormService>();
            UIKurulum();
        }

        private void UIKurulum()
        {
            this.Text = "Yeni Sac Stok Ekle";
            this.ClientSize = new Size(420, 340);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(236, 240, 245);

            int y = 20;
            int labelX = 20, ctrlX = 200, ctrlW = 190;


            Action<string, NumericUpDown> SatirEkle = (etiket, num) =>
            {
                var lbl = new Label
                {
                    Text = etiket,
                    Location = new Point(labelX, y + 3),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };
                num.Location = new Point(ctrlX, y);
                num.Size = new Size(ctrlW, 25);
                num.Font = new Font("Segoe UI", 10F);

                this.Controls.Add(lbl);
                this.Controls.Add(num);
                y += 45;
            };



            numKalinlik = new NumericUpDown { Minimum = 0, Maximum = 100, DecimalPlaces = 1, Increment = 0.5m, Value = 3 };
            numEbatX = new NumericUpDown { Minimum = 0, Maximum = 99999, Value = 1000 };
            numEbatY = new NumericUpDown { Minimum = 0, Maximum = 99999, Value = 2000 };
            numStokAdedi = new NumericUpDown { Minimum = 0, Maximum = 99999, Value = 1 };
            numMinimumStok = new NumericUpDown { Minimum = 0, Maximum = 9999, Value = 2 };

            SatirEkle("Kalınlık (mm):", numKalinlik);
            SatirEkle("Ebat X (mm):", numEbatX);
            SatirEkle("Ebat Y (mm):", numEbatY);
            SatirEkle("Stok Adedi:", numStokAdedi);
            SatirEkle("Minimum Stok:", numMinimumStok);

            btnKaydet = new Button
            {
                Text = "✅ Kaydet",
                Location = new Point(20, y + 5),
                Size = new Size(170, 40),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.Click += BtnKaydet_Click;

            btnIptal = new Button
            {
                Text = "✗ İptal",
                Location = new Point(220, y + 5),
                Size = new Size(170, 40),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnIptal.FlatAppearance.BorderSize = 0;
            btnIptal.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.Add(btnKaydet);
            this.Controls.Add(btnIptal);
            this.ClientSize = new Size(420, y + 65);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (numKalinlik.Value <= 0)
            {
                MessageBox.Show("Kalınlık sıfırdan büyük olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numEbatX.Value <= 0 || numEbatY.Value <= 0)
            {
                MessageBox.Show("Ebatlar sıfırdan büyük olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LazerSacStokKaydetTalep talep = new LazerSacStokKaydetTalep
                {
                    SacKalinligi = numKalinlik.Value,
                    SacEbatX = numEbatX.Value,
                    SacEbatY = numEbatY.Value,
                    StokAdedi = (int)numStokAdedi.Value,
                    MinimumStok = (int)numMinimumStok.Value
                };

                LazerSacStokKaydetSonuc sonuc = _lazerUrunFormService.KaydetSacStok(_connectionString, talep);

                if (sonuc.MevcutKaydaEklendi)
                {
                    MessageBox.Show($"Mevcut stoka {sonuc.EklenenStokAdedi} adet eklendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Yeni sac stoku başarıyla eklendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
