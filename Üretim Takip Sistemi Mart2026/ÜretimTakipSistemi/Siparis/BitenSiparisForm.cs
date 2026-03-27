using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using BitenSiparisKaydiEntity = ÜretimTakipSistemi.Entities.Concrete.BitenSiparisKaydi;

namespace ÜretimTakipSistemi.Siparis
{
    public partial class BitenSiparisForm : Form
    {
        DataTable tablo = new DataTable();
        private readonly ISiparisService _siparisService;

        public BitenSiparisForm()
        {
            InitializeComponent();
            _siparisService = InstanceFactory.GetInstance<ISiparisService>();
        }

        private void BitenSiparisForm_Load(object sender, EventArgs e)
        {
            dtBaslangic.Value = DateTime.Now.AddDays(-30);
            SiparisleriArsivle();
            Listele();
        }

        private void SiparisleriArsivle()
        {
            try
            {
                int adet = _siparisService.ArsivleTamamlananSiparisler();

                if (adet > 0)
                    MessageBox.Show($"{adet} adet sipariş başarıyla arşive taşındı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Arşivleme Hatası: " + ex.Message); }
        }

        private void Listele()
        {
            try
            {
                List<BitenSiparisKaydiEntity> kayitlar = _siparisService.GetBitenSiparisler(dtBaslangic.Value, dtBitis.Value);
                GridiDoldur(kayitlar);
                ArsivBilgisiGuncelle();
            }
            catch (Exception ex) { MessageBox.Show("Listeleme Hatası: " + ex.Message); }
        }

        private void GridiDoldur(List<BitenSiparisKaydiEntity> kayitlar)
        {
            tablo = BitenSiparisleriDataTableaDonustur(kayitlar);
            dgvBitenler.DataSource = tablo;
        }

        private void ArsivBilgisiGuncelle()
        {
            if (dgvBitenler.Rows.Count > 0)
            {
                lblBilgi.Text = "Toplam Arşiv Kaydı: " + dgvBitenler.Rows.Count.ToString();
                lblBilgi.ForeColor = Color.DarkGreen;
                return;
            }

            lblBilgi.Text = "Bu tarih aralığında kayıt bulunamadı.";
            lblBilgi.ForeColor = Color.Red;
        }

        private DataTable BitenSiparisleriDataTableaDonustur(List<BitenSiparisKaydiEntity> kayitlar)
        {
            DataTable dataTable = BitenSiparisTablosuOlustur();

            foreach (BitenSiparisKaydiEntity kayit in kayitlar)
            {
                dataTable.Rows.Add(
                    kayit.SiparisID,
                    kayit.StokNo,
                    kayit.MusteriAdi,
                    kayit.ParcaAdi,
                    kayit.Bolum,
                    kayit.SiparisAdeti,
                    kayit.Durum,
                    kayit.KayitTarihi,
                    kayit.SiparisNotu,
                    kayit.TamamlanmaTarihi,
                    kayit.UretimSuresiGun.HasValue ? (object)kayit.UretimSuresiGun.Value : DBNull.Value,
                    kayit.UretilenMiktar.HasValue ? (object)kayit.UretilenMiktar.Value : DBNull.Value);
            }

            return dataTable;
        }

        private DataTable BitenSiparisTablosuOlustur()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SiparisID", typeof(int));
            dataTable.Columns.Add("StokNo", typeof(string));
            dataTable.Columns.Add("MusteriAdi", typeof(string));
            dataTable.Columns.Add("ParcaAdi", typeof(string));
            dataTable.Columns.Add("Bolum", typeof(string));
            dataTable.Columns.Add("SiparisAdeti", typeof(int));
            dataTable.Columns.Add("Durum", typeof(string));
            dataTable.Columns.Add("KayitTarihi", typeof(DateTime));
            dataTable.Columns.Add("SiparisNotu", typeof(string));
            dataTable.Columns.Add("TamamlanmaTarihi", typeof(DateTime));
            dataTable.Columns.Add("UretimSuresiGun", typeof(int));
            dataTable.Columns.Add("UretilenMiktar", typeof(int));
            return dataTable;
        }

        private void btnListele_Click(object sender, EventArgs e) => Listele();

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula(txtArama.Text);
        }

        private void FiltreUygula(string aramaMetni)
        {
            if (tablo == null || tablo.Columns.Count == 0)
            {
                return;
            }

            DataView filtrelenmisGorunum = tablo.DefaultView;
            filtrelenmisGorunum.RowFilter = string.Format("StokNo LIKE '%{0}%' OR MusteriAdi LIKE '%{0}%'", aramaMetni);
            dgvBitenler.DataSource = filtrelenmisGorunum;
            ArsivBilgisiGuncelle();
        }

        private void btnGeriAl_Click(object sender, EventArgs e)
        {
            if (dgvBitenler.SelectedRows.Count == 0) return;

            var result = MessageBox.Show("Seçili sipariş aktif listeye (Beklemede olarak) geri alınsın mı?", "Geri Al", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int siparisId = SeciliSiparisIdGetir();
                    _siparisService.ArsivdenGeriAl(siparisId);
                    Listele();
                }
                catch (Exception ex) { MessageBox.Show("Geri alma hatası: " + ex.Message); }
            }
        }

        private int SeciliSiparisIdGetir()
        {
            return Convert.ToInt32(dgvBitenler.SelectedRows[0].Cells["SiparisID"].Value);
        }
    }
}
