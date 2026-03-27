using System;
using System.Collections.Generic;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class LazerSiparisKaydetTalep
    {
        public LazerSiparisKaydetTalep()
        {
            Detaylar = new List<LazerSiparisDetaySatiri>();
        }

        public int? SiparisId { get; set; }
        public string SiparisNo { get; set; }
        public string Musteri { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public string Aciklama { get; set; }
        public List<LazerSiparisDetaySatiri> Detaylar { get; set; }
    }
}
