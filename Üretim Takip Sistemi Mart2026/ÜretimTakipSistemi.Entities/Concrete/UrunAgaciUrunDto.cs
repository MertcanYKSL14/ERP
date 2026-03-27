using System.Collections.Generic;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class UrunAgaciUrunDto
    {
        public UrunAgaciUrunDto()
        {
            AltUrunler = new List<UrunAgaciUrunDto>();
        }

        public int UrunId { get; set; }
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public string Birim { get; set; }
        public decimal Miktar { get; set; }
        public int SiraNo { get; set; }
        public List<UrunAgaciUrunDto> AltUrunler { get; set; }
    }
}
