using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.Entities.Abstract;

namespace ÜretimTakipSistemi.Entities.Concrete
{
    [Table("PressTakipDurum")]
    public class PressTakipDurum : IEntity
    {
        public int Id { get; set; }
        public int PressId { get; set; }
        public int DurumId { get; set; }

        public virtual PressDurum PressDurum { get; set; }
        public virtual Pressler Pressler { get; set; }
    }
}
