namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class SiparisIhtiyacSonuc
    {
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public decimal BirimSarfiyat { get; set; }
        public decimal ToplamIhtiyac { get; set; }
        public decimal MevcutStok { get; set; }
        public decimal KalanStok { get; set; }
        public string Durum { get; set; }
        public string Aciliyet { get; set; }
    }
}
