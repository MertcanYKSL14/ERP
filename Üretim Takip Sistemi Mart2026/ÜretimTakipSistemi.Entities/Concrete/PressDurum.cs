using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.Entities.Abstract;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    [Table("PressDurum")]
    public class PressDurum : IEntity
    {
        public PressDurum()
        {
            PressTakipSayac = new HashSet<PressTakipSayac>();
            PressTakipDurum = new HashSet<PressTakipDurum>();
        }

        public int Id { get; set; }
        public string Kategori { get; set; }

        public virtual ICollection<PressTakipSayac> PressTakipSayac { get; set; }
        public virtual ICollection<PressTakipDurum> PressTakipDurum { get; set; }

    }
}
