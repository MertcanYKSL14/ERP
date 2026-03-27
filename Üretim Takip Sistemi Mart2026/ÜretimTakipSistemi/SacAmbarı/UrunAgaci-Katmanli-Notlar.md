# UrunAgaci Katmanli Yapi Notlari

Bu not, `UrunAgaci` modulu icin mevcut katmanli yapiyi hizli anlamak ve gelistirmeye kaldigi yerden devam etmek icin hazirlandi.

## 1) Katman sorumluluklari

- UI (`UrunAgaciApp`, `TreeOperationsManager`)
  - Secim, onay, mesaj gosterimi, dosya secimi, TreeView cizimi
  - Servis cagirma
- Business (`IUrunAgaciService`, `UrunAgaciManager`)
  - Girdi dogrulama
  - Is kurallari
  - DAL yonlendirme
- DataAccess (`IUrunAgaciDal`, `AdoUrunAgaciDal`)
  - SQL sorgulari
  - Transaction ve DB islemleri

## 2) Tasinan ana akislar

- Okuma akislar:
  - `GetUrunAgaci`
  - `GetTumUrunler`
- Kaydetme akislar:
  - `KaydetUrunAgaci` (ana urun + alt urun)
- Silme akislar:
  - `SilUrunAgaci`
- Guncelleme akislar:
  - `GuncelleUrunAdi`
- Teknik cizim akislar:
  - `GuncelleTeknikCizim`
  - `GetTeknikCizim`
- DB hazirlama:
  - `VeritabaniHazirla` (`Urunler` ve `UrunAgaci` tablo kontrol/olusturma)

## 3) Onemli dosyalar

- UI:
  - `ÜretimTakipSistemi/SacAmbarı/UrunAgaciApp.cs`
  - `ÜretimTakipSistemi/SacAmbarı/TreeOperationsManager.cs`
- Business:
  - `ÜretimTakipSistemi.BusinessLogic/Abstract/IUrunAgaciService.cs`
  - `ÜretimTakipSistemi.BusinessLogic/Concrete/UrunAgaciManager.cs`
- DataAccess:
  - `ÜretimTakipSistemi.DataAccess/Abstract/IUrunAgaciDal.cs`
  - `ÜretimTakipSistemi.DataAccess/Concrete/AdoNet/AdoUrunAgaciDal.cs`

## 4) Guncel durum ozeti

- `TreeOperationsManager` icinde SQL kullanimi kaldirildi.
- `UrunAgaciApp` icinde DB hazirlama SQL'i kaldirildi.
- Teknik resim yukleme/acma servis katmanina tasindi.
- TreeView draw artefakt (satir kararmasi) duzeltildi.
- Kullanilmayan metotlar ve using'ler temizlendi.

## 5) Sonraki adim onerileri

1. `connectionString` yonetimini ortak bir konfig katmanina tasimak.
2. `UrunAgaciManager` icin birim testleri eklemek (validasyon senaryolari).
3. Teknik cizim icin dosya uzantisi/tip bilgisini ileride ayri kolonla izlemek.
4. UI hata mesajlarini merkezi bir helper ile standartlastirmak.

