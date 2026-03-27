using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.Concrete;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.DataAccess.Concrete.EntityFramework;

namespace ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPresslerService>().To<PresslerManager>().InSingletonScope();
            Bind<IPressDurumService>().To<PressDurumManager>().InSingletonScope();
            Bind<IPressTakipSayacService>().To<PressTakipSayacManager>().InSingletonScope();
            Bind<IPressTakipSayacGecmisService>().To<PressTakipSayacGecmisManager>().InSingletonScope();
            Bind<IPressTakipDurumService>().To<PressTakipDurumManager>().InSingletonScope();

            Bind<IUrunlerService>().To<UrunlerManager>().InSingletonScope();

            Bind<ISacAmbariBarkodService>().To<SacAmbariBarkodManager>().InSingletonScope();
            Bind<ISacAmbariStokKartiService>().To<SacAmbariStokKartiManager>().InSingletonScope();
            Bind<ISacAmbariStokListesiService>().To<SacAmbariStokListesiManager>().InSingletonScope();
            Bind<ISacAmbariUrunGecmisiService>().To<SacAmbariUrunGecmisiManager>().InSingletonScope();

            Bind<IPresslerDal>().To<EfPresslerDal>().InSingletonScope();
            Bind<IPressDurumDal>().To<EfPressDurumDal>().InSingletonScope();
            Bind<IPressTakipSayacDal>().To<EfPressTakipSayacDal>().InSingletonScope();
            Bind<IPressTakipSayacGecmisDal>().To<EfPressTakipSayacGecmisDal>().InSingletonScope();
            Bind<IPressTakipDurumDal>().To<EfPressTakipDurumDal>().InSingletonScope();

            Bind<IUrunlerDal>().To<EfUrunlerDal>().InSingletonScope();

            Bind<ISacAmbariBarkodDal>().To<EfSacAmbariBarkodDal>().InSingletonScope();
            Bind<ISacAmbariStokKartiDal>().To<EfSacAmbariStokKartiDal>().InSingletonScope();
            Bind<ISacAmbariStokListesiDal>().To<EfSacAmbariStokListesiDal>().InSingletonScope();
            Bind<ISacAmbariUrunGecmisiDal>().To<EfSacAmbariUrunGecmisiDal>().InSingletonScope();

            // Bind<DbContext>().To<PressTakipSayacContext>();
        }
    }
}
