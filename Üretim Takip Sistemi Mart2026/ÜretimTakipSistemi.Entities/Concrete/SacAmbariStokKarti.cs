using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.Entities.Abstract;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    [Table("SacAmbariStokKarti")]
    public class SacAmbariStokKarti : IEntity
    {
        public int Id { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string Kalinlik { get; set; }
        public string Kalite { get; set; }
        public string SacKalitesi { get; set; }
    }
}
