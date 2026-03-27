using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÜretimTakipSistemi
{
    class PressTakip
    {
        public int Id { get; set; }
        public int PressId { get; set; }
        public int DurumId { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string Operasyon { get; set; }
        public int Adet { get; set; }
        public DateTime Saat { get; set; }
        public DateTime Tarih { get; set; }
    }
}
