using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.BusinessLogic.Concrete
{
    public class PressTakipSayacManager : IPressTakipSayacService
    {
        private IPressTakipSayacDal _pressTakipSayacDal;

        public PressTakipSayacManager(IPressTakipSayacDal pressTakipSayacDal)
        {
            _pressTakipSayacDal = pressTakipSayacDal;
        }

        public List<PressTakipSayac> GetAll()
        {
            return _pressTakipSayacDal.GetAll();
        }
    }
}
