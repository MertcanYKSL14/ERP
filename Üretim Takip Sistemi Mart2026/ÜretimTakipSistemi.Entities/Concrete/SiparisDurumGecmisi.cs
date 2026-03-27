using System;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class SiparisDurumGecmisi
    {
        public string EskiDurum { get; set; }
        public string YeniDurum { get; set; }
        public string DegistirenKullanici { get; set; }
        public DateTime DegisiklikTarihi { get; set; }
        public int? UretilenMiktar { get; set; }
        public string Aciklama { get; set; }
    }
}
