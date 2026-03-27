namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class LazerSiparisUrunSecimItem
    {
        public int UrunID { get; set; }
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public string LazerTipi { get; set; }
        public string UrunBilgi
        {
            get { return UrunKodu + " - " + UrunAdi + " (" + LazerTipi + ")"; }
        }
    }
}
