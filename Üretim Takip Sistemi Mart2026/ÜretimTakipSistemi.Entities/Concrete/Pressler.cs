using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.Entities.Abstract;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    [Table("Pressler")]
    public class Pressler:IEntity
    {
        public Pressler()
        {
            PressTakipSayac = new HashSet<PressTakipSayac>();
            PressTakipDurum = new HashSet<PressTakipDurum>();
            PressTakipSayacGecmis = new HashSet<PressTakipSayacGecmis>();
        }

        public int Id { get; set; }
        public string PressAd { get; set; }
        public int PressTon { get; set; }

        public virtual ICollection<PressTakipSayac> PressTakipSayac { get; set; }
        public virtual ICollection<PressTakipDurum> PressTakipDurum { get; set; }
        public virtual ICollection<PressTakipSayacGecmis> PressTakipSayacGecmis { get; set; }
    }
}
