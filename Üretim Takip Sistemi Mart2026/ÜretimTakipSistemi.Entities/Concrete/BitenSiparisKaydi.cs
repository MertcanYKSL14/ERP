using System;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class BitenSiparisKaydi
    {
        public int SiparisID { get; set; }
        public string StokNo { get; set; }
        public string MusteriAdi { get; set; }
        public string ParcaAdi { get; set; }
        public string Bolum { get; set; }
        public int SiparisAdeti { get; set; }
        public string Durum { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string SiparisNotu { get; set; }
        public DateTime TamamlanmaTarihi { get; set; }
        public int? UretimSuresiGun { get; set; }
        public int? UretilenMiktar { get; set; }
    }
}
