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
    public class UrunlerManager:IUrunlerService
    {
        private IUrunlerDal _urunlerDal;

        public UrunlerManager(IUrunlerDal urunlerDal)
        {
            _urunlerDal = urunlerDal;
        }

      

        public List<Urunler> GetAll()
        {
            return _urunlerDal.GetAll();
        }
    }
}
