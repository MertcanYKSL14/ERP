using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ÜretimTakipSistemi.Lazer
{
    public class ProfilStokService
    {
        private readonly string connectionString;

        public ProfilStokService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // ─────────────────────────────────────────────
        // 1) Siparişe ait ürün listesini çeker
        // ─────────────────────────────────────────────
        public List<UrunBilgisi> SiparisUrunleriniAl(int siparisID)
        {
            var urunler = new List<UrunBilgisi>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Tekil (gruplu olmayan) boru ürünleri
                string anaQuery = @"
                    SELECT U.UrunKodu, U.UrunAdi, U.UrunBoyu, U.ProfilEbati, SD.SiparisAdedi,
                           ISNULL(PS.ProfilUzunlugu, 6000) AS ProfilUzunlugu
                    FROM SiparisDetay SD
                    INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                    LEFT JOIN ProfilStok PS ON U.ProfilEbati = PS.ProfilEbati
                    WHERE SD.SiparisID = @SiparisID 
                      AND U.LazerTipi = 'Boru' 
                      AND U.GrupluUrunMu = 0
                      AND U.UrunBoyu IS NOT NULL";

                SqlCommand anaCmd = new SqlCommand(anaQuery, conn);
                anaCmd.Parameters.AddWithValue("@SiparisID", siparisID);

                SqlDataReader reader = anaCmd.ExecuteReader();
                while (reader.Read())
                {
                    urunler.Add(new UrunBilgisi
                    {
                        UrunKodu = reader["UrunKodu"].ToString(),
                        UrunAdi = reader["UrunAdi"].ToString(),
                        UrunBoyu = Convert.ToDecimal(reader["UrunBoyu"]),
                        ProfilEbati = reader["ProfilEbati"]?.ToString() ?? "",
                        ProfilUzunlugu = Convert.ToDecimal(reader["ProfilUzunlugu"]),
                        Adet = Convert.ToInt32(reader["SiparisAdedi"])
                    });
                }
                reader.Close();

                // Gruplu ürünlerin alt parçaları
                string grupluQuery = @"
                    SELECT UDB.ParcaAdi, UDB.UrunBoyu, UDB.ProfilEbati,
                           (UDB.Adet * SD.SiparisAdedi) AS ToplamAdet,
                           U.UrunKodu,
                           ISNULL(PS.ProfilUzunlugu, 6000) AS ProfilUzunlugu
                    FROM SiparisDetay SD
                    INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                    INNER JOIN UrunDetayBoru UDB ON U.UrunID = UDB.UrunID
                    LEFT JOIN ProfilStok PS ON UDB.ProfilEbati = PS.ProfilEbati
                    WHERE SD.SiparisID = @SiparisID 
                      AND U.LazerTipi = 'Boru' 
                      AND U.GrupluUrunMu = 1";

                SqlCommand grupluCmd = new SqlCommand(grupluQuery, conn);
                grupluCmd.Parameters.AddWithValue("@SiparisID", siparisID);

                SqlDataReader grupluReader = grupluCmd.ExecuteReader();
                while (grupluReader.Read())
                {
                    urunler.Add(new UrunBilgisi
                    {
                        UrunKodu = grupluReader["UrunKodu"].ToString() + " - " + grupluReader["ParcaAdi"].ToString(),
                        UrunAdi = grupluReader["ParcaAdi"].ToString(),
                        UrunBoyu = Convert.ToDecimal(grupluReader["UrunBoyu"]),
                        ProfilEbati = grupluReader["ProfilEbati"].ToString(),
                        ProfilUzunlugu = Convert.ToDecimal(grupluReader["ProfilUzunlugu"]),
                        Adet = Convert.ToInt32(grupluReader["ToplamAdet"])
                    });
                }
                grupluReader.Close();
            }

            return urunler;
        }

        // ─────────────────────────────────────────────
        // 2) FFD algoritması ile optimizasyon hesaplar
        // ─────────────────────────────────────────────
        public ProfilOptimizasyonSonuc ProfilOptimizasyonuHesapla(List<UrunBilgisi> urunler)
        {
            var sonuc = new ProfilOptimizasyonSonuc
            {
                ProfilListesi = new List<ProfilDetay>()
            };

            var birlesikUrunler = urunler
                .GroupBy(u => new { u.ProfilEbati, UrunBoyu = Math.Round(u.UrunBoyu, 2) })
                .Select(g => new UrunBilgisi
                {
                    UrunKodu = string.Join(", ", g.Select(x => x.UrunKodu).Distinct()),
                    UrunAdi = g.First().UrunAdi,
                    UrunBoyu = g.Key.UrunBoyu,
                    ProfilEbati = g.Key.ProfilEbati,
                    ProfilUzunlugu = g.First().ProfilUzunlugu,
                    Adet = g.Sum(x => x.Adet)
                })
                .ToList();

            foreach (var grup in birlesikUrunler.GroupBy(u => u.ProfilEbati))
            {
                string profilEbati = grup.Key;
                decimal profilUzunlugu = grup.First().ProfilUzunlugu;

                var parcalar = new List<decimal>();
                var parcaBilgi = new Dictionary<decimal, string>();

                foreach (var urun in grup)
                {
                    for (int i = 0; i < urun.Adet; i++)
                        parcalar.Add(urun.UrunBoyu);

                    if (!parcaBilgi.ContainsKey(urun.UrunBoyu))
                        parcaBilgi[urun.UrunBoyu] = $"{urun.UrunKodu} ({urun.UrunBoyu}mm)";
                }

                parcalar.Sort((a, b) => b.CompareTo(a)); // Büyükten küçüğe (FFD)

                var profiller = new List<ProfilDetay>();

                foreach (var parca in parcalar)
                {
                    bool yerlestirildi = false;

                    foreach (var profil in profiller)
                    {
                        if (profil.KalanUzunluk >= parca)
                        {
                            profil.Parcalar.Add(new ParcaBilgi { UrunKodu = parcaBilgi[parca], Uzunluk = parca });
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
                            ProfilEbati = profilEbati,
                            ProfilUzunlugu = profilUzunlugu,
                            KalanUzunluk = profilUzunlugu - parca,
                            Parcalar = new List<ParcaBilgi>
                            {
                                new ParcaBilgi { UrunKodu = parcaBilgi[parca], Uzunluk = parca }
                            }
                        });
                    }
                }

                foreach (var profil in profiller)
                {
                    profil.HurdaUzunlugu = profil.KalanUzunluk;
                    profil.VerimliliYuzdesi = profil.ProfilUzunlugu > 0
                        ? decimal.Divide(profil.ProfilUzunlugu - profil.HurdaUzunlugu, profil.ProfilUzunlugu) * 100m
                        : 0m;
                }

                sonuc.ProfilListesi.AddRange(profiller);
            }

            sonuc.ToplamProfilSayisi = sonuc.ProfilListesi.Count;
            sonuc.ToplamHurdaUzunlugu = sonuc.ProfilListesi.Sum(p => p.HurdaUzunlugu);
            sonuc.ToplamKullanilanUzunluk = sonuc.ProfilListesi.Sum(p => p.ProfilUzunlugu - p.HurdaUzunlugu);

            decimal toplamUzunluk = sonuc.ProfilListesi.Sum(p => p.ProfilUzunlugu);
            sonuc.GenelVerimliliYuzdesi = toplamUzunluk > 0
                ? decimal.Divide(sonuc.ToplamKullanilanUzunluk, toplamUzunluk) * 100m
                : 0m;

            return sonuc;
        }

        // ─────────────────────────────────────────────
        // 3) Siparişi tamamlar + stoktan düşer
        // ─────────────────────────────────────────────
        public bool SiparisiBitirVeStokDus(int siparisID, out string hataMessaji)
        {
            hataMessaji = string.Empty;

            try
            {
                // Ürünleri al ve optimizasyon hesapla
                List<UrunBilgisi> urunler = SiparisUrunleriniAl(siparisID);
                ProfilOptimizasyonSonuc optimizasyon = urunler.Count > 0
                    ? ProfilOptimizasyonuHesapla(urunler)
                    : null;

                // Profil özeti: ebat+uzunluk bazında kaç profil kullanıldı
                var profilDusumleri = optimizasyon?.ProfilListesi
                    .GroupBy(p => new { p.ProfilEbati, p.ProfilUzunlugu })
                    .Select(g => new ProfilDusumBilgisi
                    {
                        ProfilEbati = g.Key.ProfilEbati,
                        ProfilUzunlugu = g.Key.ProfilUzunlugu,
                        KullanilanAdet = g.Count()
                    })
                    .ToList();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Siparişi tamamlandı yap
                        new SqlCommand(
                            "UPDATE Siparisler SET Durum = 'Tamamlandı' WHERE SiparisID = @ID",
                            conn, transaction)
                        { Parameters = { new SqlParameter("@ID", siparisID) } }
                        .ExecuteNonQuery();

                        new SqlCommand(
                            "UPDATE SiparisDetay SET Durum = 'Tamamlandı' WHERE SiparisID = @ID",
                            conn, transaction)
                        { Parameters = { new SqlParameter("@ID", siparisID) } }
                        .ExecuteNonQuery();

                        // Stok düş
                        if (profilDusumleri != null)
                        {
                            foreach (var dusum in profilDusumleri)
                            {
                                SqlCommand stokOkuCmd = new SqlCommand(
                                    @"SELECT ProfilID, StokAdedi FROM ProfilStok 
                                      WHERE ProfilEbati = @Ebat AND ProfilUzunlugu = @Uzunluk",
                                    conn, transaction);
                                stokOkuCmd.Parameters.AddWithValue("@Ebat", dusum.ProfilEbati);
                                stokOkuCmd.Parameters.AddWithValue("@Uzunluk", dusum.ProfilUzunlugu);

                                SqlDataReader reader = stokOkuCmd.ExecuteReader();
                                if (!reader.Read()) { reader.Close(); continue; }

                                int profilID = reader.GetInt32(0);
                                int mevcutStok = reader.GetInt32(1);
                                reader.Close();

                                int yeniStok = Math.Max(0, mevcutStok - dusum.KullanilanAdet);

                                new SqlCommand(
                                    @"UPDATE ProfilStok SET StokAdedi = @Stok, GuncellemeTarihi = GETDATE()
                                      WHERE ProfilID = @PID",
                                    conn, transaction)
                                {
                                    Parameters =
                                    {
                                        new SqlParameter("@Stok", yeniStok),
                                        new SqlParameter("@PID",  profilID)
                                    }
                                }.ExecuteNonQuery();

                                new SqlCommand(@"
                                    INSERT INTO StokHareketleri 
                                        (HareketTipi, ReferansID, IslemTipi, Miktar, OncekiStok, YeniStok, Aciklama, IslemTarihi)
                                    VALUES ('Profil', @RefID, 'Sipariş Tamamlama', @Miktar, @Onceki, @Yeni, @Aciklama, GETDATE())",
                                    conn, transaction)
                                {
                                    Parameters =
                                    {
                                        new SqlParameter("@RefID",    profilID),
                                        new SqlParameter("@Miktar",   -dusum.KullanilanAdet),
                                        new SqlParameter("@Onceki",   mevcutStok),
                                        new SqlParameter("@Yeni",     yeniStok),
                                        new SqlParameter("@Aciklama",
                                            $"Sipariş Tamamlama - SiparisID:{siparisID} | " +
                                            $"{dusum.ProfilEbati} {dusum.ProfilUzunlugu}mm x{dusum.KullanilanAdet}")
                                    }
                                }.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        hataMessaji = ex.Message;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                hataMessaji = ex.Message;
                return false;
            }
        }

        // ─────────────────────────────────────────────
        // 4) Onay mesajı metnini oluşturur
        // ─────────────────────────────────────────────
        public string OnayMesajiOlustur(int siparisID)
        {
            var urunler = SiparisUrunleriniAl(siparisID);
            if (urunler.Count == 0)
                return null; // Boru tipi ürün yok

            var opt = ProfilOptimizasyonuHesapla(urunler);

            var sb = new StringBuilder();
            sb.AppendLine("Sipariş tamamlandığında aşağıdaki profil stokları düşülecektir:\n");

            var ozet = opt.ProfilListesi
                .GroupBy(p => new { p.ProfilEbati, p.ProfilUzunlugu })
                .Select(g => new { g.Key.ProfilEbati, g.Key.ProfilUzunlugu, Adet = g.Count() });

            foreach (var p in ozet)
                sb.AppendLine($"  • {p.ProfilEbati} ({p.ProfilUzunlugu} mm) → {p.Adet} adet");

            sb.AppendLine($"\nToplam: {opt.ToplamProfilSayisi} profil");
            sb.AppendLine($"Verimlilik: %{opt.GenelVerimliliYuzdesi:F2}");
            sb.AppendLine("\nDevam edilsin mi?");

            return sb.ToString();
        }
    }

    // ─────────────────────────────────────────────
    // Yardımcı iç sınıf (sadece bu servis kullanır)
    // ─────────────────────────────────────────────
    internal class ProfilDusumBilgisi
    {
        public string ProfilEbati { get; set; }
        public decimal ProfilUzunlugu { get; set; }
        public int KullanilanAdet { get; set; }
    }
}