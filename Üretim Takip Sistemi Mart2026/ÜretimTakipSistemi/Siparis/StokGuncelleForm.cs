using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using StokGuncelleUrunuEntity = ÜretimTakipSistemi.Entities.Concrete.StokGuncelleUrunu;

namespace ÜretimTakipSistemi.Siparis
{
    public partial class StokGuncelleForm : Form
    {
        DataTable tablo = new DataTable();
        DataView dv;
        private readonly ISiparisService _siparisService;

        // Seçili ürünün ID ve Stok bilgilerini tutmak için
        int seciliUrunID = -1;
        string seciliUrunKodu = "";
        int mevcutStok = 0;
        public StokGuncelleForm()
        {
            InitializeComponent();
            _siparisService = InstanceFactory.GetInstance<ISiparisService>();
        }

        private void StokGuncelleForm_Load(object sender, EventArgs e)
        {
            UrunleriListele();
            Temizle();
        }

        private void UrunleriListele()
        {
            try
            {
                List<StokGuncelleUrunuEntity> urunler = _siparisService.GetStokGuncelleUrunleri();
                GridiDoldur(urunler);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme Hatası: " + ex.Message);
            }
        }

        private DataTable UrunleriDataTableaDonustur(List<StokGuncelleUrunuEntity> urunler)
        {
            DataTable dataTable = UrunTablosuOlustur();

            foreach (StokGuncelleUrunuEntity urun in urunler)
            {
                dataTable.Rows.Add(urun.UrunID, urun.UrunKodu, urun.UrunAdi, urun.StokMiktari);
            }

            return dataTable;
        }

        private DataTable UrunTablosuOlustur()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("UrunID", typeof(int));
            dataTable.Columns.Add("UrunKodu", typeof(string));
            dataTable.Columns.Add("UrunAdi", typeof(string));
            dataTable.Columns.Add("StokMiktari", typeof(int));
            return dataTable;
        }

        private void GridiDoldur(List<StokGuncelleUrunuEntity> urunler)
        {
            tablo = UrunleriDataTableaDonustur(urunler);
            dv = new DataView(tablo);
            dgvUrunler.DataSource = dv;

            KolonlariHazirla();
            Renklendir();
        }

        private void KolonlariHazirla()
        {
            dgvUrunler.Columns["UrunID"].Visible = false;
            dgvUrunler.Columns["UrunKodu"].HeaderText = "ÜRÜN KODU";
            dgvUrunler.Columns["UrunAdi"].HeaderText = "ÜRÜN ADI";
            dgvUrunler.Columns["StokMiktari"].HeaderText = "MEVCUT STOK";
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula(txtArama.Text);
        }

        private void FiltreUygula(string aramaMetni)
        {
            if (dv == null)
            {
                return;
            }

            dv.RowFilter = string.Format("UrunKodu LIKE '%{0}%' OR UrunAdi LIKE '%{0}%'", aramaMetni);
            Renklendir();
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            SeciliUrunuHazirla(dgvUrunler.Rows[e.RowIndex]);
        }

        private void SeciliUrunuHazirla(DataGridViewRow seciliSatir)
        {
            seciliUrunID = Convert.ToInt32(seciliSatir.Cells["UrunID"].Value);
            seciliUrunKodu = seciliSatir.Cells["UrunKodu"].Value.ToString();
            mevcutStok = Convert.ToInt32(seciliSatir.Cells["StokMiktari"].Value);

            lblSeciliUrun.Text = $"{seciliUrunKodu}\n{seciliSatir.Cells["UrunAdi"].Value}";
            lblSeciliUrun.ForeColor = Color.Black;
            MevcutStoguDuzenlemeAlaninaYaz();
            IslemButonlariniAyarla(true);
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            StokGuncelle(true); 
        }

        private void btnStokCikar_Click(object sender, EventArgs e)
        {
            StokGuncelle(false); 
        }

        private void StokGuncelle(bool ekle)
        {
            if (seciliUrunID == -1)
            {
                MessageBox.Show("Lütfen listeden bir ürün seçiniz.");
                return;
            }

            int miktar = (int)numMiktar.Value;

            if (miktar == 0)
            {
                MessageBox.Show("Lütfen 0'dan büyük bir miktar giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _siparisService.StokGuncelle(seciliUrunID, miktar, ekle);
                BasariMesajiGoster(miktar, ekle);
                UrunleriListele();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme Hatası: " + ex.Message);
            }
        }

        private void Temizle()
        {
            seciliUrunID = -1;
            seciliUrunKodu = string.Empty;
            mevcutStok = 0;
            lblSeciliUrun.Text = "Lütfen listeden bir ürün seçin...";
            lblSeciliUrun.ForeColor = Color.DimGray;
            numMiktar.Value = 0;
            IslemButonlariniAyarla(false);
        }

        private void IslemButonlariniAyarla(bool aktif)
        {
            btnStokEkle.Enabled = aktif;
            btnStokCikar.Enabled = aktif;
        }

        private void BasariMesajiGoster(int miktar, bool ekle)
        {
            string islemTuru = ekle ? "Girişi" : "Çıkışı";
            MessageBox.Show($"{seciliUrunKodu} kodlu ürüne {miktar} adet stok {islemTuru} yapıldı.");
        }

        private void MevcutStoguDuzenlemeAlaninaYaz()
        {
            if (mevcutStok > (int)numMiktar.Maximum)
            {
                numMiktar.Maximum = mevcutStok;
            }

            numMiktar.Value = mevcutStok;
        }

        private void dgvUrunler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Renklendir();
        }

        private void Renklendir()
        {
            foreach (DataGridViewRow row in dgvUrunler.Rows)
            {
                if (row.Cells["StokMiktari"].Value != null)
                {
                    int stok = Convert.ToInt32(row.Cells["StokMiktari"].Value);

                    if (stok < 50)
                    {
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = dgvUrunler.DefaultCellStyle.BackColor;
                        row.DefaultCellStyle.ForeColor = dgvUrunler.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }
    }
}
