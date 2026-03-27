using System.Collections.Generic;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class LazerExcelSiparisAktarTalep
    {
        public LazerExcelSiparisAktarTalep()
        {
            Satirlar = new List<LazerExcelSiparisSatiri>();
        }

        public string SiparisNo { get; set; }
        public string Musteri { get; set; }
        public string Aciklama { get; set; }
        public List<LazerExcelSiparisSatiri> Satirlar { get; set; }
    }
}
