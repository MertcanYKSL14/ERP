using System;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class LazerSiparisDetaySatiri
    {
        public int UrunID { get; set; }
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public string LazerTipi { get; set; }
        public int SiparisAdedi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
    }
}
