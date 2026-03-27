using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.Entities.Abstract;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    [Table("PressTakipSayacGecmis")]
    public class PressTakipSayacGecmis : IEntity
    {
        public int Id { get; set; }
        public int PressId { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string Operasyon { get; set; }
        public int Adet { get; set; }
        public TimeSpan? BaslamaSaat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BaslamaTarih { get; set; }
        public TimeSpan? BitisSaat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BitisTarih { get; set; }

        public virtual Pressler Pressler { get; set; }
    }
}
