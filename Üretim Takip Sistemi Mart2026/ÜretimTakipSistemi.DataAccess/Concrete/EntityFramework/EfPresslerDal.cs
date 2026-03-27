using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.EntityFramework
{
    public class EfPresslerDal:EfEntityRepositoryBase<Pressler,UretimTakipSistemiContext>,IPresslerDal
    {
    }
}
