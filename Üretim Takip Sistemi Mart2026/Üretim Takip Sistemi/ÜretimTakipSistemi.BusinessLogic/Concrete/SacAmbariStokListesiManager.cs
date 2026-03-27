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
    public class SacAmbariStokListesiManager : ISacAmbariStokListesiService
    {
        private ISacAmbariStokListesiDal _sacAmbariStokListesiDal;

        public SacAmbariStokListesiManager(ISacAmbariStokListesiDal sacAmbariStokListesiDal)
        {
            _sacAmbariStokListesiDal = sacAmbariStokListesiDal;
        }

        public List<SacAmbariStokListesi> GetAll()
        {
            throw new NotImplementedException();
        }
        //public List<SacAmbariStokListesi> GetAll()
        //{
        //    var result=_sacAmbariStokListesiDal.GetAll().OrderByDescending(p=>p.Id);
        //    List<SacAmbariStokListesi> SacambariStokListesi=new List<SacAmbariStokListesi>();
        //    foreach (var StokListesi in result)
        //    {
        //        SacAmbariStokListesi sacAmbariStokListesi1 = new SacAmbariStokListesi
        //        {
        //            StokKodu = StokListesi.StokKodu,
        //            StokAdi = StokListesi.StokAdi
        //        };
        //    }
        //    SacambariStokListesi.Add(sacAmbariStokListesi1)

        //}
    }
}
