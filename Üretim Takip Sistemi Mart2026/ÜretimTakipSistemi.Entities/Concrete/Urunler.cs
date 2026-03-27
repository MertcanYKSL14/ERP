using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.Entities.Abstract;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    [Table("Urunler")]
    public class Urunler : IEntity
    {
        public int Id { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
    }
}
