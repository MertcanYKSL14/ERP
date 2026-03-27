using System;
using System.Collections.Generic;
using System.Linq;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.BusinessLogic.Concrete
{
    public class SiparisManager : ISiparisService
    {
        private readonly ISiparisDal _siparisDal;
        private readonly ISiparisIhtiyacDal _siparisIhtiyacDal;
        private readonly ISiparisDurumGecmisiDal _siparisDurumGecmisiDal;
        private readonly ISiparisTamamlamaDal _siparisTamamlamaDal;
        private readonly ISiparisUretimStokDal _siparisUretimStokDal;
        private readonly ISiparisArsivDal _siparisArsivDal;
        private readonly ISiparisArsivGeriAlDal _siparisArsivGeriAlDal;
        private readonly ISiparisArsivlemeDal _siparisArsivlemeDal;
        private readonly ISiparisChatDal _siparisChatDal;
        private readonly IStokGuncelleDal _stokGuncelleDal;

        public SiparisManager(
            ISiparisDal siparisDal,
            ISiparisIhtiyacDal siparisIhtiyacDal,
            ISiparisDurumGecmisiDal siparisDurumGecmisiDal,
            ISiparisTamamlamaDal siparisTamamlamaDal,
            ISiparisUretimStokDal siparisUretimStokDal,
            ISiparisArsivDal siparisArsivDal,
            ISiparisArsivGeriAlDal siparisArsivGeriAlDal,
            ISiparisArsivlemeDal siparisArsivlemeDal,
            ISiparisChatDal siparisChatDal,
            IStokGuncelleDal stokGuncelleDal)
        {
            _siparisDal = siparisDal;
            _siparisIhtiyacDal = siparisIhtiyacDal;
            _siparisDurumGecmisiDal = siparisDurumGecmisiDal;
            _siparisTamamlamaDal = siparisTamamlamaDal;
            _siparisUretimStokDal = siparisUretimStokDal;
            _siparisArsivDal = siparisArsivDal;
            _siparisArsivGeriAlDal = siparisArsivGeriAlDal;
            _siparisArsivlemeDal = siparisArsivlemeDal;
            _siparisChatDal = siparisChatDal;
            _stokGuncelleDal = stokGuncelleDal;
        }

        public int ArsivleTamamlananSiparisler()
        {
            return _siparisArsivlemeDal.ArsivleTamamlananSiparisler();
        }

        public void ArsivdenGeriAl(int siparisId)
        {
            _siparisArsivGeriAlDal.GeriAl(siparisId);
        }

        public List<BitenSiparisKaydi> GetBitenSiparisler(DateTime baslangic, DateTime bitis)
        {
            return _siparisArsivDal.GetBitenSiparisler(baslangic, bitis);
        }

        public void ChatDosyasiGonder(string gonderen, string dosyaAdi, byte[] dosyaVerisi)
        {
            if (string.IsNullOrWhiteSpace(gonderen))
            {
                throw new InvalidOperationException("Gonderen bilgisi bos olamaz.");
            }

            if (string.IsNullOrWhiteSpace(dosyaAdi))
            {
                throw new InvalidOperationException("Dosya adi bos olamaz.");
            }

            if (dosyaVerisi == null || dosyaVerisi.Length == 0)
            {
                throw new InvalidOperationException("Gonderilecek dosya bulunamadi.");
            }

            _siparisChatDal.DosyaGonder(gonderen.Trim(), dosyaAdi.Trim(), dosyaVerisi);
        }

        public void ChatMesajiGonder(string gonderen, string mesaj)
        {
            if (string.IsNullOrWhiteSpace(gonderen))
            {
                throw new InvalidOperationException("Gonderen bilgisi bos olamaz.");
            }

            if (string.IsNullOrWhiteSpace(mesaj))
            {
                throw new InvalidOperationException("Mesaj bos olamaz.");
            }

            _siparisChatDal.MesajGonder(gonderen.Trim(), mesaj.Trim());
        }

        public void ChatMesajiSil(int mesajId)
        {
            if (mesajId <= 0)
            {
                throw new InvalidOperationException("Silinecek mesaj bulunamadi.");
            }

            _siparisChatDal.MesajSil(mesajId);
        }

        public List<SiparisChatMesaji> GetChatMesajlari(int sonMesajId)
        {
            return _siparisChatDal.GetMesajlar(sonMesajId);
        }

        public List<Siparis> GetByDateRange(DateTime baslangic, DateTime bitis)
        {
            return _siparisDal
                .GetAll(x => x.KayitTarihi >= baslangic && x.KayitTarihi <= bitis && x.SiparisAdeti > 0)
                .OrderByDescending(x => x.KayitTarihi)
                .ToList();
        }

        public List<Siparis> GetAktifSiparisler()
        {
            return _siparisDal
                .GetAll(x => x.Durum != "Tamamlandı")
                .OrderBy(x => DurumSirasiGetir(x.Durum))
                .ThenByDescending(x => x.KayitTarihi)
                .ToList();
        }

        public List<StokGuncelleUrunu> GetStokGuncelleUrunleri()
        {
            return _stokGuncelleDal.GetUrunler();
        }

        public void StokGuncelle(int urunId, int miktar, bool ekle)
        {
            if (urunId <= 0)
            {
                throw new InvalidOperationException("Guncellenecek urun bulunamadi.");
            }

            if (miktar <= 0)
            {
                throw new InvalidOperationException("Stok miktari sifirdan buyuk olmalidir.");
            }

            StokGuncelleUrunu urun = _stokGuncelleDal.GetUrunById(urunId);

            if (urun == null)
            {
                throw new InvalidOperationException("Guncellenecek urun bulunamadi.");
            }

            if (!ekle && urun.StokMiktari < miktar)
            {
                throw new InvalidOperationException("Stok miktari negatife dusemez.");
            }

            _stokGuncelleDal.StokGuncelle(urunId, miktar, ekle);
        }

        public List<SiparisDurumGecmisi> GetDurumGecmisi(int siparisId)
        {
            return _siparisDurumGecmisiDal.GetBySiparisId(siparisId);
        }

        public void KaydetDurumGecmisi(SiparisDurumGecmisiKayitTalep talep)
        {
            _siparisDurumGecmisiDal.Add(talep);
        }

        public SiparisTamamlamaSonuc SiparisiTamamla(SiparisTamamlamaTalep talep)
        {
            return _siparisTamamlamaDal.Tamamla(talep);
        }

        public void UretimStoklariniGuncelle(string stokNo, int uretilenAdet)
        {
            _siparisUretimStokDal.UretimStoklariniGuncelle(stokNo, uretilenAdet);
        }

        public void SiparisDurumunuGuncelle(int siparisId, string yeniDurum)
        {
            Siparis siparis = _siparisDal.Get(x => x.SiparisID == siparisId);

            if (siparis == null)
            {
                throw new InvalidOperationException("Guncellenecek siparis bulunamadi.");
            }

            siparis.Durum = yeniDurum;
            _siparisDal.Update(siparis);
        }

        public void SiparisNotunuGuncelle(int siparisId, string siparisNotu)
        {
            Siparis siparis = _siparisDal.Get(x => x.SiparisID == siparisId);

            if (siparis == null)
            {
                throw new InvalidOperationException("Not eklenecek siparis bulunamadi.");
            }

            siparis.SiparisNotu = siparisNotu;
            _siparisDal.Update(siparis);
        }

        public SiparisKpiOzet GetKpiOzet()
        {
            var aktifSiparisler = _siparisDal.GetAll(x => x.SiparisAdeti > 0);

            return new SiparisKpiOzet
            {
                ToplamSiparisSayisi = aktifSiparisler.Count,
                BekleyenSiparisSayisi = aktifSiparisler.Count(x => x.Durum == "Beklemede"),
                BugunIhtiyacSayisi = 0
            };
        }

        public SiparisImportSonuc ImportSiparisler(List<SiparisExcelSatir> satirlar)
        {
            var sonuc = new SiparisImportSonuc();

            foreach (var satir in satirlar)
            {
                if (string.IsNullOrWhiteSpace(satir.StokNo))
                {
                    continue;
                }

                var mevcutBekleyenSiparis = _siparisDal.Get(x => x.StokNo == satir.StokNo && x.Durum == "Beklemede");

                if (satir.Adet == 0)
                {
                    if (mevcutBekleyenSiparis != null)
                    {
                        _siparisDal.Delete(mevcutBekleyenSiparis);
                        sonuc.Silinen++;
                    }

                    continue;
                }

                if (mevcutBekleyenSiparis != null)
                {
                    mevcutBekleyenSiparis.SiparisAdeti += satir.Adet;
                    mevcutBekleyenSiparis.KayitTarihi = DateTime.Now;
                    mevcutBekleyenSiparis.ParcaAdi = satir.ParcaAdi;
                    mevcutBekleyenSiparis.Bolum = satir.Bolum;

                    _siparisDal.Update(mevcutBekleyenSiparis);
                    sonuc.Guncellenen++;
                }
                else
                {
                    var yeniSiparis = new Siparis
                    {
                        StokNo = satir.StokNo,
                        MusteriAdi = "Arcelik",
                        ParcaAdi = satir.ParcaAdi,
                        Bolum = satir.Bolum,
                        SiparisAdeti = satir.Adet,
                        Durum = "Beklemede",
                        KayitTarihi = DateTime.Now
                    };

                    _siparisDal.Add(yeniSiparis);
                    sonuc.Eklenen++;
                }
            }

            var sifirAdetliSiparisler = _siparisDal.GetAll(x => x.SiparisAdeti == 0);
            foreach (var siparis in sifirAdetliSiparisler)
            {
                _siparisDal.Delete(siparis);
                sonuc.Silinen++;
            }

            return sonuc;
        }

        public List<SiparisIhtiyacSonuc> GetIhtiyacListesi(List<SiparisIhtiyacTalep> talepler)
        {
            return _siparisIhtiyacDal.GetIhtiyacListesi(talepler);
        }

        private int DurumSirasiGetir(string durum)
        {
            switch (durum)
            {
                case "Beklemede":
                    return 1;
                case "Uretimde":
                    return 2;
                case "Paketleme":
                    return 3;
                case "Sevkiyat":
                    return 4;
                default:
                    return 5;
            }
        }
    }
}
