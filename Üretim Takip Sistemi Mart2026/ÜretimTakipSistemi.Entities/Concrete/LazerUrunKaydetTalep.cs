using System.Collections.Generic;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class LazerUrunKaydetTalep
    {
        public LazerUrunKaydetTalep()
        {
            AltUrunler = new List<LazerAltUrunDetay>();
        }

        public int? UrunId { get; set; }
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public string LazerTipi { get; set; }
        public string Aciklama { get; set; }
        public bool GrupluUrunMu { get; set; }
        public decimal? UrunBoyu { get; set; }
        public string ProfilEbati { get; set; }
        public decimal? ProfilUzunlugu { get; set; }
        public decimal? SacKalinligi { get; set; }
        public List<LazerAltUrunDetay> AltUrunler { get; set; }
    }
}
