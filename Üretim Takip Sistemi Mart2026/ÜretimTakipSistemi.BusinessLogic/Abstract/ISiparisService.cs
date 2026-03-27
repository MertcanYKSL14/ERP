using System;
using System.Collections.Generic;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.BusinessLogic.Abstract
{
    public interface ISiparisService
    {
        int ArsivleTamamlananSiparisler();
        void ArsivdenGeriAl(int siparisId);
        List<BitenSiparisKaydi> GetBitenSiparisler(DateTime baslangic, DateTime bitis);
        void ChatDosyasiGonder(string gonderen, string dosyaAdi, byte[] dosyaVerisi);
        void ChatMesajiGonder(string gonderen, string mesaj);
        void ChatMesajiSil(int mesajId);
        List<SiparisChatMesaji> GetChatMesajlari(int sonMesajId);
        List<Siparis> GetByDateRange(DateTime baslangic, DateTime bitis);
        List<Siparis> GetAktifSiparisler();
        List<StokGuncelleUrunu> GetStokGuncelleUrunleri();
        void StokGuncelle(int urunId, int miktar, bool ekle);
        List<SiparisDurumGecmisi> GetDurumGecmisi(int siparisId);
        void KaydetDurumGecmisi(SiparisDurumGecmisiKayitTalep talep);
        SiparisTamamlamaSonuc SiparisiTamamla(SiparisTamamlamaTalep talep);
        void UretimStoklariniGuncelle(string stokNo, int uretilenAdet);
        void SiparisDurumunuGuncelle(int siparisId, string yeniDurum);
        void SiparisNotunuGuncelle(int siparisId, string siparisNotu);
        SiparisKpiOzet GetKpiOzet();
        SiparisImportSonuc ImportSiparisler(List<SiparisExcelSatir> satirlar);
        List<SiparisIhtiyacSonuc> GetIhtiyacListesi(List<SiparisIhtiyacTalep> talepler);
    }
}
