namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class SiparisDurumGecmisiKayitTalep
    {
        public int SiparisID { get; set; }
        public string StokNo { get; set; }
        public string UrunAdi { get; set; }
        public string EskiDurum { get; set; }
        public string YeniDurum { get; set; }
        public string DegistirenKullanici { get; set; }
        public int? UretilenMiktar { get; set; }
        public string Aciklama { get; set; }
    }
}
