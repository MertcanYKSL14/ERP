namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class SiparisTamamlamaTalep
    {
        public int SiparisID { get; set; }
        public string StokNo { get; set; }
        public string UrunAdi { get; set; }
        public string EskiDurum { get; set; }
        public string DegistirenKullanici { get; set; }
        public int SiparisAdeti { get; set; }
        public int UretilenAdet { get; set; }
    }
}
