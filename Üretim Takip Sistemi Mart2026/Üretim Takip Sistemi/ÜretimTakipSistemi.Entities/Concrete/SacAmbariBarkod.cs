using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.Entities.Abstract;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    [Table("SacAmbariBarkod")]
    public class SacAmbariBarkod : IEntity
    {
        public int Id { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string Barkod { get; set; }
        public string Kalite { get; set; }
        public int Miktar { get; set; }
        public string Kalinlik { get; set; }
        public string TbEn { get; set; }
        public string TbBoy { get; set; }
        public TimeSpan? Saat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }
    }
}
