using System.Collections.Generic;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class LazerExcelSiparisAktarSonuc
    {
        public LazerExcelSiparisAktarSonuc()
        {
            HataMesajlari = new List<string>();
        }

        public int BasariliSatirSayisi { get; set; }
        public int HataliSatirSayisi { get; set; }
        public List<string> HataMesajlari { get; set; }
    }
}
