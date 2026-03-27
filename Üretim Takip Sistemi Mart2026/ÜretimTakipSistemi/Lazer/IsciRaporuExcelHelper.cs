using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ÜretimTakipSistemi.Lazer
{
    public class IsciRaporuExcelHelper
    {
     
        // ─────────────────────────────────────────────────────────────────────
        // Renkler
        // ─────────────────────────────────────────────────────────────────────
        private static readonly System.Drawing.Color RenkBaslik = System.Drawing.Color.FromArgb(52, 73, 94);
        private static readonly System.Drawing.Color RenkSatirAcik = System.Drawing.Color.FromArgb(232, 244, 255);
        private static readonly System.Drawing.Color RenkAltUrun = System.Drawing.Color.FromArgb(212, 245, 228);
        private static readonly System.Drawing.Color RenkAyirici = System.Drawing.Color.FromArgb(200, 200, 200);
        private static readonly System.Drawing.Color RenkGri = System.Drawing.Color.FromArgb(150, 150, 150);
        private static readonly System.Drawing.Color RenkLazer = System.Drawing.Color.FromArgb(41, 128, 185);
        private static readonly System.Drawing.Color RenkKaynak = System.Drawing.Color.FromArgb(192, 57, 43);
        private static readonly System.Drawing.Color RenkBoya = System.Drawing.Color.FromArgb(39, 174, 96);
        private static readonly System.Drawing.Color RenkKalinCerc = System.Drawing.Color.FromArgb(30, 30, 30);

        // ─────────────────────────────────────────────────────────────────────
        // Sütun düzeni  (toplam 11 sütun)
        //  1:Sıra  2:Kod  3:Ad  4:Tip/Kullanılan  5:Adet
        //  6:LAZ-İmza  7:LAZ-Tarih
        //  8:KAY-Tik   9:KAY-Tarih
        //  10:BOY-Tik  11:BOY-Adet  12:BOY-Tarih
        // ─────────────────────────────────────────────────────────────────────
        private const int KOL_SIRA = 1;
        private const int KOL_KOD = 2;
        private const int KOL_AD = 3;
        private const int KOL_TIP = 4;
        private const int KOL_ADET = 5;

        private const int KOL_LAZ_IMZA = 6;
        private const int KOL_LAZ_TAR = 7;

        private const int KOL_KAY_TIK = 8;
        private const int KOL_KAY_TAR = 9;

        private const int KOL_BOY_TIK = 10;
        private const int KOL_BOY_ADET = 11;
        private const int KOL_BOY_TAR = 12;

        private const int SON_SUTUN = 12;

        // ═════════════════════════════════════════════════════════════════════
        // ANA METOD
        // ═════════════════════════════════════════════════════════════════════
        public static void RaporOlustur(
            string kayitYolu,
            string connectionString,
            int siparisID,
            string siparisNo,
            string musteri,
            string siparisTarihi,
            string teslimTarihi)
        {
            using (var package = new ExcelPackage())
            {
                DataTable dtUrunler = AnaUrunleriGetir(connectionString, siparisID);
                ProfilOptimizasyonSonuc profilSonucu =
                    ProfilOptimizasyonuHesapla(connectionString, siparisID);

                var ws = package.Workbook.Worksheets.Add("İşçi Üretim Raporu");
                TekSayfaOlustur(ws, dtUrunler, profilSonucu, connectionString,
                    siparisNo, musteri, siparisTarihi, teslimTarihi);

                package.SaveAs(new FileInfo(kayitYolu));
            }
        }

        // ═════════════════════════════════════════════════════════════════════
        // TEK SAYFA KOORDİNATÖR
        // ═════════════════════════════════════════════════════════════════════
        private static void TekSayfaOlustur(
            ExcelWorksheet ws,
            DataTable dtUrunler,
            ProfilOptimizasyonSonuc profilSonucu,
            string connectionString,
            string siparisNo, string musteri,
            string siparisTarihi, string teslimTarihi)
        {
            int satir = 1;
            satir = BaslikBolumu(ws, satir, siparisNo, musteri, siparisTarihi, teslimTarihi);
            satir = ProfilOzetBolumu(ws, satir, profilSonucu);
            satir = SutunBasliklari(ws, satir);
            UrunSatirlari(ws, satir, dtUrunler, connectionString);

            SutunGenislikleri(ws);

            // Siyah-beyaz baskıda da okunacak şekilde A4 yatay
            ws.PrinterSettings.FitToPage = true;
            ws.PrinterSettings.FitToWidth = 1;
            ws.PrinterSettings.FitToHeight = 0;
            ws.PrinterSettings.Orientation = eOrientation.Landscape;
            ws.PrinterSettings.PaperSize = ePaperSize.A4;
            ws.PrinterSettings.BlackAndWhite = false; // Renkli yazdır
            ws.PrinterSettings.LeftMargin = 0.4m / 2.54m;
            ws.PrinterSettings.RightMargin = 0.4m / 2.54m;
            ws.PrinterSettings.TopMargin = 0.8m / 2.54m;
            ws.PrinterSettings.BottomMargin = 0.8m / 2.54m;
        }

        // ─────────────────────────────────────────────────────────────────────
        // BÖLÜM 1 — Başlık
        // ─────────────────────────────────────────────────────────────────────
        private static int BaslikBolumu(ExcelWorksheet ws, int satir,
            string siparisNo, string musteri,
            string siparisTarihi, string teslimTarihi)
        {
            ws.Cells[satir, 1, satir, SON_SUTUN].Merge = true;
            var h = ws.Cells[satir, 1];
            h.Value = "ÜRETİM TAKİP SİSTEMİ — SAHA ÇALIŞMA RAPORU";
            h.Style.Font.Size = 13;
            h.Style.Font.Bold = true;
            h.Style.Font.Color.SetColor(System.Drawing.Color.White);
            h.Style.Fill.PatternType = ExcelFillStyle.Solid;
            h.Style.Fill.BackgroundColor.SetColor(RenkBaslik);
            h.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            h.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Row(satir).Height = 26;
            satir++;

            ws.Cells[satir, 1, satir, SON_SUTUN].Merge = true;
            var b = ws.Cells[satir, 1];
            b.Value = $"Sipariş: {siparisNo}   |   Müşteri: {musteri}   |   " +
                      $"Sipariş Tarihi: {siparisTarihi}   |   " +
                      $"Teslim Tarihi: {teslimTarihi}   |   " +
                      $"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}";
            b.Style.Font.Bold = true;
            b.Style.Font.Size = 8;
            b.Style.Fill.PatternType = ExcelFillStyle.Solid;
            b.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(210, 215, 220));
            b.Style.Indent = 1;
            ws.Row(satir).Height = 16;
            satir++;

            return satir + 1;
        }

        // ─────────────────────────────────────────────────────────────────────
        // BÖLÜM 2 — Profil Özet
        // Değişiklikler:
        //   - Profil ebatı sütunu genişletildi (20x30, CAP25 okunur)
        //   - Tip+Kullanılan ayrı sütun yapıldı
        //   - Verimlilik kaldırıldı
        //   - Sağdaki boş alan → Açıklama sütunu
        // ─────────────────────────────────────────────────────────────────────
        private static int ProfilOzetBolumu(ExcelWorksheet ws, int satir,
            ProfilOptimizasyonSonuc sonuc)
        {
            var renkMor = System.Drawing.Color.FromArgb(142, 68, 173);
            var renkMorAc = System.Drawing.Color.FromArgb(243, 232, 255);
            var renkMorBas = System.Drawing.Color.FromArgb(220, 210, 235);

            // Özet bölüm başlığı
            ws.Cells[satir, 1, satir, SON_SUTUN].Merge = true;
            var bas = ws.Cells[satir, 1];
            bas.Value = "PROFİL KESİM ÖZETİ";
            bas.Style.Font.Bold = true;
            bas.Style.Font.Size = 10;
            bas.Style.Font.Color.SetColor(System.Drawing.Color.White);
            bas.Style.Fill.PatternType = ExcelFillStyle.Solid;
            bas.Style.Fill.BackgroundColor.SetColor(renkMor);
            bas.Style.Indent = 1;
            ws.Row(satir).Height = 20;
            satir++;

            if (sonuc == null || sonuc.ProfilListesi == null || sonuc.ProfilListesi.Count == 0)
            {
                ws.Cells[satir, 1, satir, SON_SUTUN].Merge = true;
                ws.Cells[satir, 1].Value = "Bu siparişe ait boru tipi ürün bulunamadı.";
                ws.Cells[satir, 1].Style.Font.Italic = true;
                ws.Cells[satir, 1].Style.Font.Color.SetColor(System.Drawing.Color.Gray);
                ws.Row(satir).Height = 16;
                return satir + 2;
            }

            // Özet tablo sütun başlıkları
            // Sütunlar: 1:Profil Ebatı  2:Boy(mm)  3:Profil Adedi
            //           4:Kullanılan(mm)  5:Hurda(mm)
            //           6-12: Açıklama (birleştirilmiş)
            string[] ozetKol = { "Profil Ebatı", "Boy\n(mm)", "Profil\nAdedi", "Kullanılan\n(mm)", "Hurda\n(mm)" };
            for (int i = 0; i < ozetKol.Length; i++)
            {
                var c = ws.Cells[satir, i + 1];
                c.Value = ozetKol[i];
                c.Style.Font.Bold = true;
                c.Style.Font.Size = 8;
                c.Style.Fill.PatternType = ExcelFillStyle.Solid;
                c.Style.Fill.BackgroundColor.SetColor(renkMorBas);
                c.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                c.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                c.Style.WrapText = true;
                c.Style.Border.BorderAround(ExcelBorderStyle.Thin, renkMor);
            }

            // Açıklama başlığı (sağdaki geniş alan)
            ws.Cells[satir, 6, satir, SON_SUTUN].Merge = true;
            var acikBas = ws.Cells[satir, 6];
            acikBas.Value = "Açıklama / Not";
            acikBas.Style.Font.Bold = true;
            acikBas.Style.Font.Size = 8;
            acikBas.Style.Fill.PatternType = ExcelFillStyle.Solid;
            acikBas.Style.Fill.BackgroundColor.SetColor(renkMorBas);
            acikBas.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            acikBas.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            acikBas.Style.Indent = 1;
            acikBas.Style.Border.BorderAround(ExcelBorderStyle.Thin, renkMor);
            ws.Row(satir).Height = 26;
            satir++;

            // Ebat bazlı veri satırları
            var gruplar = sonuc.ProfilListesi
                .GroupBy(p => new { p.ProfilEbati, p.ProfilUzunlugu })
                .Select(g => new
                {
                    g.Key.ProfilEbati,
                    g.Key.ProfilUzunlugu,
                    Adet = g.Count(),
                    ToplamKullanilan = g.Sum(p => p.ProfilUzunlugu - p.HurdaUzunlugu),
                    ToplamHurda = g.Sum(p => p.HurdaUzunlugu)
                });

            foreach (var oz in gruplar)
            {
                ws.Cells[satir, 1].Value = oz.ProfilEbati;
                ws.Cells[satir, 2].Value = (double)oz.ProfilUzunlugu;
                ws.Cells[satir, 3].Value = oz.Adet;
                ws.Cells[satir, 4].Value = (double)oz.ToplamKullanilan;
                ws.Cells[satir, 5].Value = (double)oz.ToplamHurda;

                for (int s = 1; s <= 5; s++)
                {
                    ws.Cells[satir, s].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[satir, s].Style.Fill.BackgroundColor.SetColor(renkMorAc);
                    ws.Cells[satir, s].Style.Border.BorderAround(ExcelBorderStyle.Thin, RenkGri);
                    ws.Cells[satir, s].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[satir, s].Style.Font.Size = 9;
                }
                ws.Cells[satir, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[satir, 3].Style.Font.Bold = true;

                // Açıklama alanı — kullanıcı dolduracak, geniş, beyaz
                ws.Cells[satir, 6, satir, SON_SUTUN].Merge = true;
                var acik = ws.Cells[satir, 6];
                acik.Style.Fill.PatternType = ExcelFillStyle.Solid;
                acik.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(252, 250, 255));
                acik.Style.Border.BorderAround(ExcelBorderStyle.Thin, RenkGri);
                acik.Style.Border.Top.Style = ExcelBorderStyle.None;
                acik.Style.Border.Bottom.Style = ExcelBorderStyle.None;
                acik.Style.Border.Left.Style = ExcelBorderStyle.None;
                acik.Style.Border.Right.Style = ExcelBorderStyle.None;

                ws.Row(satir).Height = 18;
                satir++;
            }

            // Toplam satırı
            ws.Cells[satir, 1].Value = "TOPLAM";
            ws.Cells[satir, 1].Style.Font.Bold = true;
            ws.Cells[satir, 2].Value = "";
            ws.Cells[satir, 3].Value = sonuc.ToplamProfilSayisi;
            ws.Cells[satir, 3].Style.Font.Bold = true;
            ws.Cells[satir, 4].Value = (double)sonuc.ToplamKullanilanUzunluk;
            ws.Cells[satir, 5].Value = (double)sonuc.ToplamHurdaUzunlugu;

            for (int s = 1; s <= 5; s++)
            {
                ws.Cells[satir, s].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[satir, s].Style.Fill.BackgroundColor.SetColor(renkMorBas);
                ws.Cells[satir, s].Style.Border.BorderAround(ExcelBorderStyle.Thin, renkMor);
                ws.Cells[satir, s].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[satir, s].Style.Font.Size = 9;
            }
            ws.Cells[satir, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            ws.Cells[satir, 6, satir, SON_SUTUN].Merge = true;
            ws.Cells[satir, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[satir, 6].Style.Fill.BackgroundColor.SetColor(renkMorBas);
            ws.Cells[satir, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin, renkMor);

            ws.Row(satir).Height = 18;
            satir++;

            return satir + 1;
        }

        // ─────────────────────────────────────────────────────────────────────
        // BÖLÜM 3 — Sütun Başlıkları
        // ─────────────────────────────────────────────────────────────────────
        private static int SutunBasliklari(ExcelWorksheet ws, int satir)
        {
            // Üst grup başlıkları
            ws.Cells[satir, KOL_SIRA, satir, KOL_ADET].Merge = true;
            GrupBaslikYaz(ws.Cells[satir, KOL_SIRA], "SİPARİŞ BİLGİLERİ", RenkBaslik);

            ws.Cells[satir, KOL_LAZ_IMZA, satir, KOL_LAZ_TAR].Merge = true;
            GrupBaslikYaz(ws.Cells[satir, KOL_LAZ_IMZA], "LAZER", RenkLazer);

            ws.Cells[satir, KOL_KAY_TIK, satir, KOL_KAY_TAR].Merge = true;
            GrupBaslikYaz(ws.Cells[satir, KOL_KAY_TIK], "KAYNAK", RenkKaynak);

            ws.Cells[satir, KOL_BOY_TIK, satir, KOL_BOY_TAR].Merge = true;
            GrupBaslikYaz(ws.Cells[satir, KOL_BOY_TIK], "BOYAHANE", RenkBoya);

            ws.Row(satir).Height = 20;
            satir++;

            // Alt başlıklar
            string[] urunAlt = { "Sıra", "Ürün Kodu", "Ürün Adı", "Tip / Profil", "Adet" };
            for (int i = 0; i < urunAlt.Length; i++)
                AltBaslikYaz(ws.Cells[satir, i + 1], urunAlt[i], RenkBaslik);

            // Lazer: İmza + Tarih
            AltBaslikYaz(ws.Cells[satir, KOL_LAZ_IMZA], "İmza", RenkLazer);
            AltBaslikYaz(ws.Cells[satir, KOL_LAZ_TAR], "Tarih", RenkLazer);

            // Kaynak: Tik kutusu + Tarih
            AltBaslikYaz(ws.Cells[satir, KOL_KAY_TIK], "✓", RenkKaynak);
            AltBaslikYaz(ws.Cells[satir, KOL_KAY_TAR], "Tarih", RenkKaynak);

            // Boyahane: Tik kutusu + Adet + Tarih
            AltBaslikYaz(ws.Cells[satir, KOL_BOY_TIK], "✓", RenkBoya);
            AltBaslikYaz(ws.Cells[satir, KOL_BOY_ADET], "Adet", RenkBoya);
            AltBaslikYaz(ws.Cells[satir, KOL_BOY_TAR], "Tarih", RenkBoya);

            ws.Row(satir).Height = 18;
            satir++;

            return satir;
        }

        // ─────────────────────────────────────────────────────────────────────
        // BÖLÜM 4 — Ürün Satırları
       
        // ─────────────────────────────────────────────────────────────────────
        private static void UrunSatirlari(ExcelWorksheet ws, int satir,
            DataTable dtUrunler, string connectionString)
        {
            int siraNo = 1;

            foreach (DataRow row in dtUrunler.Rows)
            {
                bool grupluMu = Convert.ToBoolean(row["GrupluUrunMu"]);
                int urunID = Convert.ToInt32(row["UrunID"]);
                int sipAdedi = Convert.ToInt32(row["SiparisAdedi"]);
                var renkAna = (siraNo % 2 == 0) ? RenkSatirAcik : System.Drawing.Color.White;
                int anaUrunSat = satir; // Ana ürünün başladığı satır

                // Ana ürün satırı
                ws.Cells[satir, KOL_SIRA].Value = siraNo;
                ws.Cells[satir, KOL_KOD].Value = row["UrunKodu"].ToString();
                ws.Cells[satir, KOL_AD].Value = row["UrunAdi"].ToString();
                ws.Cells[satir, KOL_TIP].Value = row["LazerTipi"].ToString();
                ws.Cells[satir, KOL_ADET].Value = sipAdedi;

                // Ürün bilgi sütunları stil
                for (int s = KOL_SIRA; s <= KOL_ADET; s++)
                {
                    ws.Cells[satir, s].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[satir, s].Style.Fill.BackgroundColor.SetColor(renkAna);
                    ws.Cells[satir, s].Style.Font.Size = 9;
                    ws.Cells[satir, s].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                ws.Cells[satir, KOL_SIRA].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[satir, KOL_ADET].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[satir, KOL_ADET].Style.Font.Bold = true;
                ws.Cells[satir, KOL_AD].Style.Font.Bold = true;

                // Lazer alanı
                LazerAlani(ws, satir, renkAna);
                // Kaynak: sadece tik kutusu
                KaynakAlani(ws, satir, System.Drawing.Color.FromArgb(255, 240, 240));
                // Boyahane: tik + adet + tarih
                BoyahaneAlani(ws, satir, sipAdedi, System.Drawing.Color.FromArgb(235, 255, 240));

                ws.Row(satir).Height = 20;
                satir++;

                // Alt ürünler
                DataTable dtAlt = null;
                if (grupluMu)
                {
                    dtAlt = AltUrunleriGetir(connectionString, urunID);
                    foreach (DataRow alt in dtAlt.Rows)
                    {
                        int altAdet = Convert.ToInt32(alt["Adet"]);
                        int topAdet = altAdet * sipAdedi;
                        string profil = alt["ProfilEbati"]?.ToString() ?? "-";
                        string uzunluk = alt["UrunBoyu"] != DBNull.Value
                                          ? alt["UrunBoyu"] + " mm" : "-";

                        ws.Cells[satir, KOL_SIRA].Value = "";
                        ws.Cells[satir, KOL_KOD].Value = "  ↳";
                        ws.Cells[satir, KOL_AD].Value = alt["ParcaAdi"].ToString();
                        ws.Cells[satir, KOL_TIP].Value = profil + " / " + uzunluk;
                        ws.Cells[satir, KOL_ADET].Value = topAdet;

                        for (int s = KOL_SIRA; s <= KOL_ADET; s++)
                        {
                            ws.Cells[satir, s].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[satir, s].Style.Fill.BackgroundColor.SetColor(RenkAltUrun);
                            ws.Cells[satir, s].Style.Font.Italic = true;
                            ws.Cells[satir, s].Style.Font.Size = 9;
                            ws.Cells[satir, s].Style.Font.Bold = true;
                            ws.Cells[satir, KOL_KOD].Style.Indent = 2;
                            ws.Cells[satir, s].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Cells[satir, s].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                            ws.Cells[satir, s].Style.Border.Top.Color.SetColor(RenkAyirici);
                        }
                        ws.Cells[satir, KOL_ADET].Style.Font.Bold = true;
                        ws.Cells[satir, KOL_ADET].Style.Font.Italic = false;
                        ws.Cells[satir, KOL_ADET].Style.HorizontalAlignment =
                            ExcelHorizontalAlignment.Center;

                        LazerAlani(ws, satir,
                            System.Drawing.Color.FromArgb(235, 244, 255));
                        KaynakAlani(ws, satir,
                            System.Drawing.Color.FromArgb(255, 245, 245));
                        BoyahaneAlani(ws, satir, topAdet,
                            System.Drawing.Color.FromArgb(240, 255, 245));

                        ws.Row(satir).Height = 17;
                        satir++;
                    }
                }

                // ── Kalın dış kenarlık: tüm ürün bloğunu çerçevele ──────────
                int sonSatir = satir - 1;
                // Üst kenar
                for (int s = KOL_SIRA; s <= SON_SUTUN; s++)
                    ws.Cells[anaUrunSat, s].Style.Border.Top.Style = ExcelBorderStyle.Medium;


                // Alt kenar
                for (int s = KOL_SIRA; s <= SON_SUTUN; s++)
                    ws.Cells[sonSatir, s].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;


                // Sol kenar
                for (int r = anaUrunSat; r <= sonSatir; r++)
                    ws.Cells[r, KOL_SIRA].Style.Border.Left.Style = ExcelBorderStyle.Medium;

                // Sağ kenar
                for (int r = anaUrunSat; r <= sonSatir; r++)
                    ws.Cells[r, SON_SUTUN].Style.Border.Right.Style = ExcelBorderStyle.Medium;

                // Ana ürün + alt ürünler arasında ince iç çizgi
                if (grupluMu && dtAlt != null && dtAlt.Rows.Count > 0)
                {
                    // Ana ürün altı çizgi
                    for (int s = KOL_SIRA; s <= SON_SUTUN; s++)
                        ws.Cells[anaUrunSat, s].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                siraNo++;
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // İMZA / TİK ALAN METODLARI
        // ─────────────────────────────────────────────────────────────────────

        private static void LazerAlani(ExcelWorksheet ws, int satir,
            System.Drawing.Color renk)
        {
            // İmza kutusu
            ws.Cells[satir, KOL_LAZ_IMZA].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[satir, KOL_LAZ_IMZA].Style.Fill.BackgroundColor.SetColor(
                System.Drawing.Color.FromArgb(235, 244, 255));
            ws.Cells[satir, KOL_LAZ_IMZA].Style.Border.BorderAround(
                ExcelBorderStyle.Thin, RenkGri);
            ws.Cells[satir, KOL_LAZ_IMZA].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            // Tarih kutusu
            TarihAlani(ws, satir, KOL_LAZ_TAR,
                System.Drawing.Color.FromArgb(235, 244, 255));
        }

        private static void KaynakAlani(ExcelWorksheet ws, int satir,
            System.Drawing.Color renk)
        {
            // Küçük tik kutusu — ortalanmış boş kare, elle tik atılacak
            var tikCell = ws.Cells[satir, KOL_KAY_TIK];
            tikCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            tikCell.Style.Fill.BackgroundColor.SetColor(renk);
            tikCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            tikCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            tikCell.Style.Font.Size = 14;
            // İnce border ile kutu görünümü
            tikCell.Style.Border.Top.Style = ExcelBorderStyle.Medium;
            tikCell.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
            tikCell.Style.Border.Left.Style = ExcelBorderStyle.Medium;
            tikCell.Style.Border.Right.Style = ExcelBorderStyle.Medium;
            tikCell.Style.Border.Top.Color.SetColor(RenkKaynak);
            tikCell.Style.Border.Bottom.Color.SetColor(RenkKaynak);
            tikCell.Style.Border.Left.Color.SetColor(RenkKaynak);
            tikCell.Style.Border.Right.Color.SetColor(RenkKaynak);

            TarihAlani(ws, satir, KOL_KAY_TAR, renk);
        }

        private static void BoyahaneAlani(ExcelWorksheet ws, int satir,
            int adet, System.Drawing.Color renk)
        {
            // Tik kutusu
            var tikCell = ws.Cells[satir, KOL_BOY_TIK];
            tikCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            tikCell.Style.Fill.BackgroundColor.SetColor(renk);
            tikCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            tikCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            tikCell.Style.Font.Size = 14;
            tikCell.Style.Border.Top.Style = ExcelBorderStyle.Medium;
            tikCell.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
            tikCell.Style.Border.Left.Style = ExcelBorderStyle.Medium;
            tikCell.Style.Border.Right.Style = ExcelBorderStyle.Medium;
            tikCell.Style.Border.Top.Color.SetColor(RenkBoya);
            tikCell.Style.Border.Bottom.Color.SetColor(RenkBoya);
            tikCell.Style.Border.Left.Color.SetColor(RenkBoya);
            tikCell.Style.Border.Right.Color.SetColor(RenkBoya);

            // Adet kutusu
            var adetCell = ws.Cells[satir, KOL_BOY_ADET];
            
            adetCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            adetCell.Style.Fill.BackgroundColor.SetColor(renk);
            adetCell.Style.Font.Bold = true;
            adetCell.Style.Font.Size = 9;
            adetCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            adetCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            adetCell.Style.Border.BorderAround(ExcelBorderStyle.Thin, RenkGri);

            TarihAlani(ws, satir, KOL_BOY_TAR, renk);
        }

        private static void TarihAlani(ExcelWorksheet ws, int satir,
            int kolNo, System.Drawing.Color renk)
        {
            var c = ws.Cells[satir, kolNo];
            c.Value = "__.__.______";
            c.Style.Fill.PatternType = ExcelFillStyle.Solid;
            c.Style.Fill.BackgroundColor.SetColor(renk);
            c.Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(190, 190, 190));
            c.Style.Font.Size = 7;
            c.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            c.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            c.Style.Border.BorderAround(ExcelBorderStyle.Thin, RenkGri);
        }

        // ─────────────────────────────────────────────────────────────────────
        // STİL YARDIMCI METODLAR
        // ─────────────────────────────────────────────────────────────────────
        private static void GrupBaslikYaz(ExcelRange cell, string metin,
            System.Drawing.Color renk)
        {
            cell.Value = metin;
            cell.Style.Font.Bold = true;
            cell.Style.Font.Size = 10;
            cell.Style.Font.Color.SetColor(System.Drawing.Color.White);
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(renk);
            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            cell.Style.Border.BorderAround(ExcelBorderStyle.Medium,
                System.Drawing.Color.White);
        }

        private static void AltBaslikYaz(ExcelRange cell, string metin,
            System.Drawing.Color renk)
        {
            int r = Math.Min(255, renk.R + 50);
            int g = Math.Min(255, renk.G + 50);
            int b = Math.Min(255, renk.B + 50);

            cell.Value = metin;
            cell.Style.Font.Bold = true;
            cell.Style.Font.Size = 8;
            cell.Style.Font.Color.SetColor(System.Drawing.Color.White);
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(r, g, b));
            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            cell.Style.WrapText = false;
            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin,
                System.Drawing.Color.White);
        }

        // ─────────────────────────────────────────────────────────────────────
        // SÜTUN GENİŞLİKLERİ
        // ─────────────────────────────────────────────────────────────────────
        private static void SutunGenislikleri(ExcelWorksheet ws)
        {
            ws.Column(1).Width = 10;   // Sıra
            ws.Column(KOL_KOD).Width = 13;    // Ürün Kodu
            ws.Column(KOL_AD).Width = 21;    // Ürün Adı  (eski 28'in 3/4'ü ≈ 21)
            ws.Column(KOL_TIP).Width = 16;    // Tip / Profil — genişletildi (20x30, CAP25 okunur)
            ws.Column(KOL_ADET).Width = 6;     // Adet

            // Lazer
            ws.Column(KOL_LAZ_IMZA).Width = 16; // İmza
            ws.Column(KOL_LAZ_TAR).Width = 11; // Tarih

            // Kaynak
            ws.Column(KOL_KAY_TIK).Width = 5;  // Tik kutusu — küçük kare
            ws.Column(KOL_KAY_TAR).Width = 11; // Tarih

            // Boyahane
            ws.Column(KOL_BOY_TIK).Width = 5;  // Tik kutusu
            ws.Column(KOL_BOY_ADET).Width = 6;  // Adet
            ws.Column(KOL_BOY_TAR).Width = 11; // Tarih


        }

        // ═════════════════════════════════════════════════════════════════════
        // VERİ KATMANI
        // ═════════════════════════════════════════════════════════════════════
        private static DataTable AnaUrunleriGetir(string connectionString, int siparisID)
        {
            DataTable dt = new DataTable();
            using (var conn = new SqlConnection(connectionString))
            {
                var da = new SqlDataAdapter(@"
                    SELECT U.UrunID, U.UrunKodu, U.UrunAdi,
                           U.LazerTipi, U.GrupluUrunMu, SD.SiparisAdedi
                    FROM SiparisDetay SD
                    INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                    WHERE SD.SiparisID = @SiparisID
                    ORDER BY U.UrunKodu", conn);
                da.SelectCommand.Parameters.AddWithValue("@SiparisID", siparisID);
                da.Fill(dt);
            }
            return dt;
        }

        private static DataTable AltUrunleriGetir(string connectionString, int urunID)
        {
            DataTable dt = new DataTable();
            using (var conn = new SqlConnection(connectionString))
            {
                var da = new SqlDataAdapter(@"
                    SELECT ParcaAdi, Adet, ProfilEbati, UrunBoyu, Sira
                    FROM UrunDetayBoru
                    WHERE UrunID = @UrunID
                    ORDER BY Sira", conn);
                da.SelectCommand.Parameters.AddWithValue("@UrunID", urunID);
                da.Fill(dt);
            }
            return dt;
        }

        private static List<UrunBilgisi> BoruUrunleriniGetir(string connectionString, int siparisID)
        {
            var liste = new List<UrunBilgisi>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var anaCmd = new SqlCommand(@"
                    SELECT U.UrunKodu, U.UrunAdi, U.UrunBoyu, U.ProfilEbati,
                           SD.SiparisAdedi,
                           ISNULL(PS.ProfilUzunlugu, 6000) AS ProfilUzunlugu
                    FROM SiparisDetay SD
                    INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                    LEFT  JOIN ProfilStok PS ON U.ProfilEbati = PS.ProfilEbati
                    WHERE SD.SiparisID  = @SID
                      AND U.LazerTipi   = 'Boru'
                      AND U.GrupluUrunMu = 0
                      AND U.UrunBoyu IS NOT NULL", conn);
                anaCmd.Parameters.AddWithValue("@SID", siparisID);
                var rdr = anaCmd.ExecuteReader();
                while (rdr.Read())
                    liste.Add(new UrunBilgisi
                    {
                        UrunKodu = rdr["UrunKodu"].ToString(),
                        UrunAdi = rdr["UrunAdi"].ToString(),
                        UrunBoyu = Convert.ToDecimal(rdr["UrunBoyu"]),
                        ProfilEbati = rdr["ProfilEbati"]?.ToString() ?? "",
                        ProfilUzunlugu = Convert.ToDecimal(rdr["ProfilUzunlugu"]),
                        Adet = Convert.ToInt32(rdr["SiparisAdedi"])
                    });
                rdr.Close();

                var altCmd = new SqlCommand(@"
                    SELECT UDB.ParcaAdi, UDB.UrunBoyu, UDB.ProfilEbati,
                           (UDB.Adet * SD.SiparisAdedi) AS ToplamAdet,
                           U.UrunKodu,
                           ISNULL(PS.ProfilUzunlugu, 6000) AS ProfilUzunlugu
                    FROM SiparisDetay SD
                    INNER JOIN Urunler U         ON SD.UrunID  = U.UrunID
                    INNER JOIN UrunDetayBoru UDB ON U.UrunID   = UDB.UrunID
                    LEFT  JOIN ProfilStok PS     ON UDB.ProfilEbati = PS.ProfilEbati
                    WHERE SD.SiparisID  = @SID
                      AND U.LazerTipi   = 'Boru'
                      AND U.GrupluUrunMu = 1", conn);
                altCmd.Parameters.AddWithValue("@SID", siparisID);
                var altRdr = altCmd.ExecuteReader();
                while (altRdr.Read())
                    liste.Add(new UrunBilgisi
                    {
                        UrunKodu = altRdr["UrunKodu"] + " - " + altRdr["ParcaAdi"],
                        UrunAdi = altRdr["ParcaAdi"].ToString(),
                        UrunBoyu = Convert.ToDecimal(altRdr["UrunBoyu"]),
                        ProfilEbati = altRdr["ProfilEbati"].ToString(),
                        ProfilUzunlugu = Convert.ToDecimal(altRdr["ProfilUzunlugu"]),
                        Adet = Convert.ToInt32(altRdr["ToplamAdet"])
                    });
                altRdr.Close();
            }
            return liste;
        }


        private static ProfilOptimizasyonSonuc ProfilOptimizasyonuHesapla(
            string connectionString, int siparisID)
        {
            var urunler = BoruUrunleriniGetir(connectionString, siparisID);
            if (urunler.Count == 0) return null;

            var sonuc = new ProfilOptimizasyonSonuc
            {
                ProfilListesi = new List<ProfilDetay>()
            };

            var birlesik = urunler
                .GroupBy(u => new { u.ProfilEbati, Boy = Math.Round(u.UrunBoyu, 2) })
                .Select(g => new UrunBilgisi
                {
                    UrunKodu = string.Join(", ", g.Select(x => x.UrunKodu).Distinct()),
                    UrunBoyu = g.Key.Boy,
                    ProfilEbati = g.Key.ProfilEbati,
                    ProfilUzunlugu = g.First().ProfilUzunlugu,
                    Adet = g.Sum(x => x.Adet)
                }).ToList();

            foreach (var grup in birlesik.GroupBy(u => u.ProfilEbati))
            {
                var grupUrunler = grup.ToList();
                decimal profilBoyu = grupUrunler.First().ProfilUzunlugu;

                var parcalar = new List<decimal>();
                var parcaBilgi = new Dictionary<decimal, string>();

                foreach (var u in grupUrunler)
                {
                    for (int i = 0; i < u.Adet; i++)
                        parcalar.Add(u.UrunBoyu);
                    if (!parcaBilgi.ContainsKey(u.UrunBoyu))
                        parcaBilgi[u.UrunBoyu] = u.UrunKodu + " (" + u.UrunBoyu + "mm)";
                }

                parcalar.Sort((a, b) => b.CompareTo(a));
                var profiller = new List<ProfilDetay>();

                foreach (var parca in parcalar)
                {
                    bool yerlestirildi = false;
                    foreach (var profil in profiller)
                    {
                        if (profil.KalanUzunluk >= parca)
                        {
                            profil.Parcalar.Add(new ParcaBilgi
                            {
                                UrunKodu = parcaBilgi[parca],
                                Uzunluk = parca
                            });
                            profil.KalanUzunluk -= parca;
                            yerlestirildi = true;
                            break;
                        }
                    }
                    if (!yerlestirildi)
                    {
                        profiller.Add(new ProfilDetay
                        {
                            ProfilNo = profiller.Count + 1,
                            ProfilEbati = grup.Key,
                            ProfilUzunlugu = profilBoyu,
                            KalanUzunluk = profilBoyu - parca,
                            Parcalar = new List<ParcaBilgi>
                            {
                                new ParcaBilgi
                                {
                                    UrunKodu = parcaBilgi[parca],
                                    Uzunluk  = parca
                                }
                            }
                        });
                    }
                }

                foreach (var p in profiller)
                {
                    p.HurdaUzunlugu = p.KalanUzunluk;
                    p.VerimliliYuzdesi = p.ProfilUzunlugu > 0
                        ? (p.ProfilUzunlugu - p.HurdaUzunlugu) / p.ProfilUzunlugu * 100m
                        : 0m;
                }
                sonuc.ProfilListesi.AddRange(profiller);
            }

            sonuc.ToplamProfilSayisi = sonuc.ProfilListesi.Count;
            sonuc.ToplamHurdaUzunlugu = sonuc.ProfilListesi.Sum(p => p.HurdaUzunlugu);
            sonuc.ToplamKullanilanUzunluk = sonuc.ProfilListesi.Sum(p =>
                p.ProfilUzunlugu - p.HurdaUzunlugu);

            decimal toplamBoy = sonuc.ProfilListesi.Sum(p => p.ProfilUzunlugu);
            sonuc.GenelVerimliliYuzdesi = toplamBoy > 0
                ? sonuc.ToplamKullanilanUzunluk / toplamBoy * 100m : 0m;

            return sonuc;
        }
    }
}