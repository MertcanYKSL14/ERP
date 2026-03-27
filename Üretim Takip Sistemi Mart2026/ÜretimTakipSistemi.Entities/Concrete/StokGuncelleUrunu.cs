using ÜretimTakipSistemi.Entities.Abstract;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class StokGuncelleUrunu : IEntity
    {
        public int UrunID { get; set; }
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public int StokMiktari { get; set; }
    }
}
