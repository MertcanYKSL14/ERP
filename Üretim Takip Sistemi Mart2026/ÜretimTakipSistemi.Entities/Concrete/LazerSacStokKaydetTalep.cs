namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class LazerSacStokKaydetTalep
    {
        public decimal SacKalinligi { get; set; }
        public decimal SacEbatX { get; set; }
        public decimal SacEbatY { get; set; }
        public int StokAdedi { get; set; }
        public int MinimumStok { get; set; }
    }
}
