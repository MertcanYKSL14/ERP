using System;
using System.Data;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.DataAccess.Abstract;

namespace ÜretimTakipSistemi.BusinessLogic.Concrete
{
    public class TumSiparisUrunleriManager : ITumSiparisUrunleriService
    {
        private readonly ITumSiparisUrunleriDal _tumSiparisUrunleriDal;

        public TumSiparisUrunleriManager(ITumSiparisUrunleriDal tumSiparisUrunleriDal)
        {
            _tumSiparisUrunleriDal = tumSiparisUrunleriDal;
        }

        public DataTable GetTumSiparisUrunleri(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            return _tumSiparisUrunleriDal.GetTumSiparisUrunleri(connectionString);
        }
    }
}
