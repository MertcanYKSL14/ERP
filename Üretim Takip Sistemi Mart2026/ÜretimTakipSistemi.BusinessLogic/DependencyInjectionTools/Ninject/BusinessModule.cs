using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.Concrete;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.DataAccess.Concrete.AdoNet;
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
            Bind<ISiparisService>().To<SiparisManager>().InSingletonScope();
            Bind<ILazerSiparisFormService>().To<LazerSiparisFormManager>().InSingletonScope();
            Bind<ILazerSiparisDetayService>().To<LazerSiparisDetayManager>().InSingletonScope();
            Bind<ILazerUrunFormService>().To<LazerUrunFormManager>().InSingletonScope();
            Bind<IProfilStokEditorService>().To<ProfilStokEditorManager>().InSingletonScope();
            Bind<ITumSiparisUrunleriService>().To<TumSiparisUrunleriManager>().InSingletonScope();
            Bind<IUrunAgaciService>().To<UrunAgaciManager>().InSingletonScope();

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
            Bind<ISiparisDal>().To<EfSiparisDal>().InSingletonScope();
            Bind<ISiparisIhtiyacDal>().To<AdoSiparisIhtiyacDal>().InSingletonScope();
            Bind<ISiparisDurumGecmisiDal>().To<AdoSiparisDurumGecmisiDal>().InSingletonScope();
            Bind<ISiparisTamamlamaDal>().To<AdoSiparisTamamlamaDal>().InSingletonScope();
            Bind<ISiparisUretimStokDal>().To<AdoSiparisUretimStokDal>().InSingletonScope();
            Bind<ISiparisArsivDal>().To<AdoSiparisArsivDal>().InSingletonScope();
            Bind<ISiparisArsivGeriAlDal>().To<AdoSiparisArsivGeriAlDal>().InSingletonScope();
            Bind<ISiparisArsivlemeDal>().To<AdoSiparisArsivlemeDal>().InSingletonScope();
            Bind<ISiparisChatDal>().To<AdoSiparisChatDal>().InSingletonScope();
            Bind<ILazerSiparisFormDal>().To<AdoLazerSiparisFormDal>().InSingletonScope();
            Bind<ILazerSiparisDetayDal>().To<AdoLazerSiparisDetayDal>().InSingletonScope();
            Bind<ILazerUrunFormDal>().To<AdoLazerUrunFormDal>().InSingletonScope();
            Bind<IStokGuncelleDal>().To<AdoStokGuncelleDal>().InSingletonScope();
            Bind<IProfilStokEditorDal>().To<AdoProfilStokEditorDal>().InSingletonScope();
            Bind<ITumSiparisUrunleriDal>().To<AdoTumSiparisUrunleriDal>().InSingletonScope();
            Bind<IUrunAgaciDal>().To<AdoUrunAgaciDal>().InSingletonScope();

            Bind<IUrunlerDal>().To<EfUrunlerDal>().InSingletonScope();
            Bind<ISacAmbariBarkodDal>().To<EfSacAmbariBarkodDal>().InSingletonScope();
            Bind<ISacAmbariStokKartiDal>().To<EfSacAmbariStokKartiDal>().InSingletonScope();
            Bind<ISacAmbariStokListesiDal>().To<EfSacAmbariStokListesiDal>().InSingletonScope();
            Bind<ISacAmbariUrunGecmisiDal>().To<EfSacAmbariUrunGecmisiDal>().InSingletonScope();

            // Bind<DbContext>().To<PressTakipSayacContext>();
        }
    }
}
