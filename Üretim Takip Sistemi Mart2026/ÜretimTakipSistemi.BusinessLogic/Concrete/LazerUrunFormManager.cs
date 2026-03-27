using System;
using System.Data;
using System.Collections.Generic;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.BusinessLogic.Concrete
{
    public class LazerUrunFormManager : ILazerUrunFormService
    {
        private readonly ILazerUrunFormDal _lazerUrunFormDal;

        public LazerUrunFormManager(ILazerUrunFormDal lazerUrunFormDal)
        {
            _lazerUrunFormDal = lazerUrunFormDal;
        }

        public List<LazerProfilSecenek> GetProfilListesi(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            return _lazerUrunFormDal.GetProfilListesi(connectionString);
        }

        public LazerUrunDuzenlemeModel GetUrunDuzenlemeModel(string connectionString, int urunId)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (urunId <= 0)
            {
                throw new InvalidOperationException("Gecerli urun secilmelidir.");
            }

            return _lazerUrunFormDal.GetUrunDuzenlemeModel(connectionString, urunId);
        }

        public void KaydetUrun(string connectionString, LazerUrunKaydetTalep talep)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (talep == null)
            {
                throw new InvalidOperationException("Kayit bilgisi bulunamadi.");
            }

            if (string.IsNullOrWhiteSpace(talep.UrunKodu))
            {
                throw new InvalidOperationException("Urun kodu bos olamaz.");
            }

            if (string.IsNullOrWhiteSpace(talep.UrunAdi))
            {
                throw new InvalidOperationException("Urun adi bos olamaz.");
            }

            if (string.IsNullOrWhiteSpace(talep.LazerTipi))
            {
                throw new InvalidOperationException("Lazer tipi secilmelidir.");
            }

            if (talep.LazerTipi == "Boru")
            {
                if (talep.GrupluUrunMu)
                {
                    if (talep.AltUrunler == null || talep.AltUrunler.Count == 0)
                    {
                        throw new InvalidOperationException("Gruplu urun icin en az bir alt urun eklenmelidir.");
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(talep.ProfilEbati))
                    {
                        throw new InvalidOperationException("Profil ebati secilmelidir.");
                    }

                    if (!talep.UrunBoyu.HasValue || talep.UrunBoyu.Value <= 0)
                    {
                        throw new InvalidOperationException("Urun boyu girilmelidir.");
                    }
                }
            }

            if (talep.LazerTipi == "Plaka" && (!talep.SacKalinligi.HasValue || talep.SacKalinligi.Value <= 0))
            {
                throw new InvalidOperationException("Plaka urunleri icin sac kalinligi girilmelidir.");
            }

            _lazerUrunFormDal.KaydetUrun(connectionString, talep);
        }

        public List<LazerAltUrunSecimItem> GetAltUrunSecenekleri(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            return _lazerUrunFormDal.GetAltUrunSecenekleri(connectionString);
        }

        public LazerAltUrunDetay GetAltUrunDetayi(string connectionString, string parcaAdi)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (string.IsNullOrWhiteSpace(parcaAdi))
            {
                return null;
            }

            return _lazerUrunFormDal.GetAltUrunDetayi(connectionString, parcaAdi);
        }

        public DataTable GetTumUrunler(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            return _lazerUrunFormDal.GetTumUrunler(connectionString);
        }

        public void UrunuPasifeAl(string connectionString, int urunId)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (urunId <= 0)
            {
                throw new InvalidOperationException("Gecerli urun secilmelidir.");
            }

            _lazerUrunFormDal.UrunuPasifeAl(connectionString, urunId);
        }

        public DataTable GetBoruLazerUrunleri(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            return _lazerUrunFormDal.GetBoruLazerUrunleri(connectionString);
        }

        public DataTable GetBoruUrunDetaylari(string connectionString, int urunId)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (urunId <= 0)
            {
                throw new InvalidOperationException("Gecerli urun secilmelidir.");
            }

            return _lazerUrunFormDal.GetBoruUrunDetaylari(connectionString, urunId);
        }

        public DataTable GetProfilStokListesi(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            return _lazerUrunFormDal.GetProfilStokListesi(connectionString);
        }

        public void GuncelleProfilStok(string connectionString, int profilId, int oncekiStok, int yeniStok)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (profilId <= 0)
            {
                throw new InvalidOperationException("Gecerli profil secilmelidir.");
            }

            if (yeniStok < 0)
            {
                throw new InvalidOperationException("Stok adedi negatif olamaz.");
            }

            _lazerUrunFormDal.GuncelleProfilStok(connectionString, profilId, oncekiStok, yeniStok);
        }

        public DataTable GetSacStokListesi(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            return _lazerUrunFormDal.GetSacStokListesi(connectionString);
        }

        public void GuncelleSacStok(string connectionString, int sacId, int oncekiStok, int yeniStok)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (sacId <= 0)
            {
                throw new InvalidOperationException("Gecerli sac secilmelidir.");
            }

            if (yeniStok < 0)
            {
                throw new InvalidOperationException("Stok adedi negatif olamaz.");
            }

            _lazerUrunFormDal.GuncelleSacStok(connectionString, sacId, oncekiStok, yeniStok);
        }

        public LazerSacStokKaydetSonuc KaydetSacStok(string connectionString, LazerSacStokKaydetTalep talep)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (talep == null)
            {
                throw new InvalidOperationException("Kayit bilgisi bulunamadi.");
            }

            if (talep.SacKalinligi <= 0)
            {
                throw new InvalidOperationException("Sac kalinligi sifirdan buyuk olmalidir.");
            }

            if (talep.SacEbatX <= 0 || talep.SacEbatY <= 0)
            {
                throw new InvalidOperationException("Sac ebatlari sifirdan buyuk olmalidir.");
            }

            if (talep.StokAdedi <= 0)
            {
                throw new InvalidOperationException("Stok adedi sifirdan buyuk olmalidir.");
            }

            if (talep.MinimumStok < 0)
            {
                throw new InvalidOperationException("Minimum stok negatif olamaz.");
            }

            return _lazerUrunFormDal.KaydetSacStok(connectionString, talep);
        }

        public DataTable GetPlakaLazerUrunleri(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            return _lazerUrunFormDal.GetPlakaLazerUrunleri(connectionString);
        }

        public DataTable GetPlakaUrunDetaylari(string connectionString, int urunId)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (urunId <= 0)
            {
                throw new InvalidOperationException("Gecerli urun secilmelidir.");
            }

            return _lazerUrunFormDal.GetPlakaUrunDetaylari(connectionString, urunId);
        }

        public int GetSacStokAdedi(string connectionString, decimal sacKalinligi, decimal sacEbatX, decimal sacEbatY)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            return _lazerUrunFormDal.GetSacStokAdedi(connectionString, sacKalinligi, sacEbatX, sacEbatY);
        }

        public int GetProfilStokAdedi(string connectionString, string profilEbati, decimal profilUzunlugu)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Baglanti bilgisi bulunamadi.");
            }

            if (string.IsNullOrWhiteSpace(profilEbati))
            {
                return 0;
            }

            return _lazerUrunFormDal.GetProfilStokAdedi(connectionString, profilEbati, profilUzunlugu);
        }
    }
}
