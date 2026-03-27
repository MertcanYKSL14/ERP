using System;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    public class SiparisChatMesaji
    {
        public int Id { get; set; }
        public string Gonderen { get; set; }
        public string Mesaj { get; set; }
        public DateTime Tarih { get; set; }
        public string DosyaAdi { get; set; }
        public byte[] DosyaVerisi { get; set; }

        public bool DosyaVarMi
        {
            get { return DosyaVerisi != null && DosyaVerisi.Length > 0; }
        }
    }
}
