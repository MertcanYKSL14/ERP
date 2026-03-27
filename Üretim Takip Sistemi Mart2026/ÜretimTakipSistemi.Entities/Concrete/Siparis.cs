using System;
using System.ComponentModel.DataAnnotations.Schema;
using ÜretimTakipSistemi.Entities.Abstract;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    [Table("Siparisler")]
    public class Siparis : IEntity
    {
        public int SiparisID { get; set; }
        public string StokNo { get; set; }
        public string MusteriAdi { get; set; }
        public string ParcaAdi { get; set; }
        public string Bolum { get; set; }
        public int SiparisAdeti { get; set; }
        public string Durum { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string SiparisNotu { get; set; }
    }
}
