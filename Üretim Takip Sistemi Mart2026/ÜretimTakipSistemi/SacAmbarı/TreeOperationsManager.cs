using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.SacAmbarı
{
    public class UrunNodeInfo
    {
        public int UrunID { get; set; }
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class TreeOperationsManager
    {
        private readonly string _connectionString;
        private readonly TreeView _treeView;
        private readonly Action _refreshCallback;
        private readonly IUrunAgaciService _urunAgaciService;

        public TreeOperationsManager(TreeView treeView, string connectionString, Action refreshCallback)
        {
            _treeView = treeView;
            _connectionString = connectionString;
            _refreshCallback = refreshCallback;
            _urunAgaciService = InstanceFactory.GetInstance<IUrunAgaciService>();
        }

        public void SetupContextMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Yeni Alt Parça Ekle", null, (s, e) => Context_AltParcaEkle());
            menu.Items.Add("Bu Parçayı Düzenle", null, (s, e) => Context_Duzenle());
            menu.Items.Add(new ToolStripSeparator());

            menu.Items.Add("Teknik Resmi Gör", null, (s, e) => Context_TeknikResimAc());
            menu.Items.Add("Teknik Resim Yükle/Güncelle", null, (s, e) => Context_TeknikResimYukle());

            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("Bu Parçayı Sil (Sistemden)", null, (s, e) => Context_Sil());

            _treeView.ContextMenuStrip = menu;

            _treeView.NodeMouseClick += (s, e) => {
                if (e.Button == MouseButtons.Right) _treeView.SelectedNode = e.Node;
            };
        }

        // --- TEKNIK RESIM YUKLEME METODU ---
        private void Context_TeknikResimYukle()
        {
            if (_treeView.SelectedNode == null) return;
            var info = (UrunNodeInfo)_treeView.SelectedNode.Tag;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Resim Dosyaları|*.jpg;*.png";
                ofd.Title = $"{info.UrunAdi} İçin Teknik Çizim Seçin";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] dosyaVerisi = File.ReadAllBytes(ofd.FileName);
                        _urunAgaciService.GuncelleTeknikCizim(_connectionString, info.UrunID, dosyaVerisi);
                        MessageBox.Show("Teknik çizim başarıyla veritabanına kaydedildi.");
                        _refreshCallback?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem hatası: " + ex.Message);
                    }
                }
            }
        }

        // --- TEKNIK RESIM ACMA METODU ---
        private void Context_TeknikResimAc()
        {
            if (_treeView.SelectedNode == null) return;
            var info = (UrunNodeInfo)_treeView.SelectedNode.Tag;

            try
            {
                byte[] cizimBytes = _urunAgaciService.GetTeknikCizim(_connectionString, info.UrunID);

                if (cizimBytes != null && cizimBytes.Length > 0)
                {
                    // Geçici dosya oluştur (Her PC'de çalışır)
                    string uzanti = ".pdf"; // Veritabanında tip tutulursa dinamikleştirilebilir
                    string tempDosyaYolu = Path.Combine(Path.GetTempPath(), $"{info.UrunKodu}_Cizim{uzanti}");

                    File.WriteAllBytes(tempDosyaYolu, cizimBytes);

                    // Dosyayı sistemin varsayılan uygulamasıyla aç
                    ProcessStartInfo psi = new ProcessStartInfo(tempDosyaYolu) { UseShellExecute = true };
                    Process.Start(psi);
                }
                else
                {
                    MessageBox.Show("Bu ürüne ait kayıtlı bir teknik çizim bulunamadı.\nLütfen 'Teknik Resim Yükle' seçeneğini kullanın.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void Context_AltParcaEkle()
        {
            if (_treeView.SelectedNode == null) return;
            var nodeInfo = (UrunNodeInfo)_treeView.SelectedNode.Tag;

            using (var form = new SimpleUrunEkleForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        UrunAgaciKaydetTalep talep = new UrunAgaciKaydetTalep
                        {
                            UrunKodu = nodeInfo.UrunKodu,
                            UrunAdi = nodeInfo.UrunAdi,
                            AltUrunEklenecek = true,
                            AltUrunKodu = form.UrunKodu,
                            AltUrunAdi = form.UrunAdi,
                            Miktar = form.Miktar
                        };

                        _urunAgaciService.KaydetUrunAgaci(_connectionString, talep);
                        MessageBox.Show("Alt parça başarıyla eklendi.");
                        _refreshCallback?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem hatası: " + ex.Message);
                    }
                }
            }
        }

        private void Context_Duzenle()
        {
            if (_treeView.SelectedNode == null) return;
            var info = (UrunNodeInfo)_treeView.SelectedNode.Tag;
            string yeniAd = Interaction.InputBox($"{info.UrunKodu} kodlu ürünün yeni adını girin:", "Ürün Düzenle", info.UrunAdi);

            if (!string.IsNullOrWhiteSpace(yeniAd))
            {
                try
                {
                    _urunAgaciService.GuncelleUrunAdi(_connectionString, info.UrunID, yeniAd);
                    MessageBox.Show("Ürün adı başarıyla güncellendi.");
                    _refreshCallback?.Invoke();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem hatası: " + ex.Message);
                }
            }
        }

        private void Context_Sil()
        {
            if (_treeView.SelectedNode == null) return;
            var info = (UrunNodeInfo)_treeView.SelectedNode.Tag;

            var onay = MessageBox.Show($"'{info.UrunAdi}' ürününü sistemden SİLMEK üzeresiniz.\nDİKKAT: Bu işlem tüm bağlantıları koparacaktır!",
                "Kritik Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    _urunAgaciService.SilUrunAgaci(_connectionString, info.UrunID);
                    MessageBox.Show("Ürün sistemden tamamen kaldırıldı.");
                    _refreshCallback?.Invoke();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem hatası: " + ex.Message);
                }
            }
        }

    }
}