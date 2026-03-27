using System;
using System.Collections.Generic;
using System.Data;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.BusinessLogic.Concrete
{
    public class LazerSiparisDetayManager : ILazerSiparisDetayService
    {
        private readonly ILazerSiparisDetayDal _lazerSiparisDetayDal;

        public LazerSiparisDetayManager(ILazerSiparisDetayDal lazerSiparisDetayDal)
        {
            _lazerSiparisDetayDal = lazerSiparisDetayDal;
        }

        public LazerSiparisDetayBaslik GetSiparisBaslik(string connectionString, int siparisId)
        {
            BaglantiVeSiparisKontrol(connectionString, siparisId);
            return _lazerSiparisDetayDal.GetSiparisBaslik(connectionString, siparisId);
        }

        public DataTable GetSiparisDetaylari(string connectionString, int siparisId)
        {
            BaglantiVeSiparisKontrol(connectionString, siparisId);
            return _lazerSiparisDetayDal.GetSiparisDetaylari(connectionString, siparisId);
        }

        public List<LazerProfilOptimizasyonUrunu> GetProfilOptimizasyonUrunleri(string connectionString, int siparisId)
        {
            BaglantiVeSiparisKontrol(connectionString, siparisId);
            return _lazerSiparisDetayDal.GetProfilOptimizasyonUrunleri(connectionString, siparisId);
        }

        public void GuncelleUretimBilgisi(string connectionString, LazerSiparisDetayGuncelleTalep talep)
        {
            if (talep == null)
            {
                throw new InvalidOperationException("Guncelleme bilgisi bulunamadi.");
            }

            BaglantiVeSiparisKontrol(connectionString, talep.SiparisId);

            if (talep.SiparisDetayId <= 0)
            {
                throw new InvalidOperationException("Gecerli siparis detayi secilmelidir.");
            }

            if (talep.UretilenAdet < 0)
            {
                throw new InvalidOperationException("Uretilen adet negatif olamaz.");
            }

            if (string.IsNullOrWhiteSpace(talep.Durum))
            {
                throw new InvalidOperationException("Durum bilgisi zorunludur.");
            }

            _lazerSiparisDetayDal.GuncelleUretimBilgisi(connectionString, talep);
        }

        private static void BaglantiVeSiparisKontrol(string connectionString, int siparisId)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (siparisId <= 0)
            {
                throw new InvalidOperationException("Gecerli siparis secilmelidir.");
            }
        }
    }
}
