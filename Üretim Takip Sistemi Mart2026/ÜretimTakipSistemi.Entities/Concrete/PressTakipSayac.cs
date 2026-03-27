using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.Entities.Abstract;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    [Table("PressTakipSayac")]
    public class PressTakipSayac : IEntity
    {
        public int Id { get; set; }
        public int PressId { get; set; }
        public int DurumId { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string Operasyon { get; set; }
        public int Adet { get; set; }
        public TimeSpan? Saat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        public virtual PressDurum PressDurum { get; set; }
        public virtual Pressler Pressler { get; set; }
    }
}
