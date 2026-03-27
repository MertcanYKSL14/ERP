namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class UrunAgaciKaydetTalep
    {
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public bool AltUrunEklenecek { get; set; }
        public string AltUrunKodu { get; set; }
        public string AltUrunAdi { get; set; }
        public decimal Miktar { get; set; }
    }
}
