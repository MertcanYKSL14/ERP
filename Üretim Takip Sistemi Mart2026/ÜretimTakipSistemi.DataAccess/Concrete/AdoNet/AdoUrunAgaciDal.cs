using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ÜretimTakipSistemi.DataAccess.Abstract;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.DataAccess.Concrete.AdoNet
{
    public class AdoUrunAgaciDal : IUrunAgaciDal
    {
        public List<UrunAgaciUrunDto> GetUrunAgaci(string connectionString)
        {
            List<UrunAgaciUrunDto> kokUrunler = new List<UrunAgaciUrunDto>();
            List<UrunAgaciSatiri> altUrunSatirlari = new List<UrunAgaciSatiri>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string rootQuery = @"
                    SELECT u.UrunID, u.UrunKodu, u.UrunAdi
                    FROM Urunler u
                    WHERE u.UrunID IN (SELECT DISTINCT AnaUrunID FROM UrunAgaci)
                    AND u.UrunID NOT IN (SELECT DISTINCT AltUrunID FROM UrunAgaci)
                    ORDER BY u.UrunAdi";

                using (SqlCommand rootCmd = new SqlCommand(rootQuery, conn))
                using (SqlDataReader rootReader = rootCmd.ExecuteReader())
                {
                    while (rootReader.Read())
                    {
                        kokUrunler.Add(new UrunAgaciUrunDto
                        {
                            UrunId = Convert.ToInt32(rootReader["UrunID"]),
                            UrunKodu = rootReader["UrunKodu"].ToString(),
                            UrunAdi = rootReader["UrunAdi"].ToString()
                        });
                    }
                }

                string childQuery = @"
                    SELECT
                        ua.AnaUrunID,
                        u.UrunID,
                        u.UrunAdi,
                        u.UrunKodu,
                        u.Birim,
                        ua.Miktar,
                        ua.SiraNo
                    FROM UrunAgaci ua
                    INNER JOIN Urunler u ON ua.AltUrunID = u.UrunID";

                using (SqlCommand childCmd = new SqlCommand(childQuery, conn))
                using (SqlDataReader childReader = childCmd.ExecuteReader())
                {
                    while (childReader.Read())
                    {
                        altUrunSatirlari.Add(new UrunAgaciSatiri
                        {
                            AnaUrunId = Convert.ToInt32(childReader["AnaUrunID"]),
                            Urun = new UrunAgaciUrunDto
                            {
                                UrunId = Convert.ToInt32(childReader["UrunID"]),
                                UrunAdi = childReader["UrunAdi"].ToString(),
                                UrunKodu = childReader["UrunKodu"].ToString(),
                                Birim = childReader["Birim"] == DBNull.Value ? string.Empty : childReader["Birim"].ToString(),
                                Miktar = childReader["Miktar"] == DBNull.Value ? 0m : Convert.ToDecimal(childReader["Miktar"]),
                                SiraNo = childReader["SiraNo"] == DBNull.Value ? 999 : Convert.ToInt32(childReader["SiraNo"])
                            }
                        });
                    }
                }
            }

            Dictionary<int, List<UrunAgaciUrunDto>> altUrunlerMap = altUrunSatirlari
                .GroupBy(x => x.AnaUrunId)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderBy(x => x.Urun.SiraNo).ThenBy(x => x.Urun.UrunAdi).Select(x => x.Urun).ToList());

            foreach (UrunAgaciUrunDto kokUrun in kokUrunler)
            {
                kokUrun.AltUrunler = AltUrunleriOlustur(kokUrun.UrunId, altUrunlerMap);
            }

            return kokUrunler;
        }

        public List<UrunAgaciUrunDto> GetTumUrunler(string connectionString)
        {
            List<UrunAgaciUrunDto> urunler = new List<UrunAgaciUrunDto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT UrunID, UrunKodu, UrunAdi FROM Urunler ORDER BY UrunAdi";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        urunler.Add(new UrunAgaciUrunDto
                        {
                            UrunId = Convert.ToInt32(reader["UrunID"]),
                            UrunKodu = reader["UrunKodu"].ToString(),
                            UrunAdi = reader["UrunAdi"].ToString()
                        });
                    }
                }
            }

            return urunler;
        }

        public void VeritabaniHazirla(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string checkTablesQuery = @"
                    SELECT 
                        CASE WHEN EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Urunler') THEN 1 ELSE 0 END as UrunlerVar,
                        CASE WHEN EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UrunAgaci') THEN 1 ELSE 0 END as AgacVar";

                bool urunlerVar = false;
                bool agacVar = false;

                using (SqlCommand cmd = new SqlCommand(checkTablesQuery, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        urunlerVar = Convert.ToInt32(reader["UrunlerVar"]) == 1;
                        agacVar = Convert.ToInt32(reader["AgacVar"]) == 1;
                    }
                }

                if (!urunlerVar)
                {
                    string createUrunler = @"
                        CREATE TABLE Urunler (
                            UrunID INT IDENTITY(1,1) PRIMARY KEY,
                            UrunKodu NVARCHAR(50) NOT NULL,
                            UrunAdi NVARCHAR(100) NOT NULL,
                            Birim NVARCHAR(20) DEFAULT 'Adet',
                            BirimFiyat DECIMAL(18,2) DEFAULT 0,
                            Aciklama NVARCHAR(500),
                            KayitTarihi DATETIME DEFAULT GETDATE()
                        )";

                    using (SqlCommand cmd = new SqlCommand(createUrunler, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                if (!agacVar)
                {
                    string createUrunAgaci = @"
                        CREATE TABLE UrunAgaci (
                            AgacID INT IDENTITY(1,1) PRIMARY KEY,
                            AnaUrunID INT NOT NULL,
                            AltUrunID INT NOT NULL,
                            Miktar DECIMAL(10,3) DEFAULT 1,
                            SiraNo INT DEFAULT 0,
                            Aciklama NVARCHAR(200),
                            FOREIGN KEY (AnaUrunID) REFERENCES Urunler(UrunID),
                            FOREIGN KEY (AltUrunID) REFERENCES Urunler(UrunID)
                        )";

                    using (SqlCommand cmd = new SqlCommand(createUrunAgaci, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void KaydetUrunAgaci(string connectionString, UrunAgaciKaydetTalep talep)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        int anaUrunId = GetOrCreateUrun(talep.UrunKodu, talep.UrunAdi, conn, tran);

                        if (talep.AltUrunEklenecek)
                        {
                            int altUrunId = GetOrCreateUrun(talep.AltUrunKodu, talep.AltUrunAdi, conn, tran);

                            string queryAgac = "INSERT INTO UrunAgaci (AnaUrunID, AltUrunID, Miktar) VALUES (@Ana, @Alt, @Miktar)";
                            using (SqlCommand cmd = new SqlCommand(queryAgac, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@Ana", anaUrunId);
                                cmd.Parameters.AddWithValue("@Alt", altUrunId);
                                cmd.Parameters.AddWithValue("@Miktar", talep.Miktar);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public void SilUrunAgaci(string connectionString, int urunId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlAgac = "DELETE FROM UrunAgaci WHERE AnaUrunID = @id OR AltUrunID = @id";
                        using (SqlCommand cmd = new SqlCommand(sqlAgac, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", urunId);
                            cmd.ExecuteNonQuery();
                        }

                        string sqlUrun = "DELETE FROM Urunler WHERE UrunID = @id";
                        using (SqlCommand cmd = new SqlCommand(sqlUrun, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", urunId);
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public void GuncelleUrunAdi(string connectionString, int urunId, string yeniAd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Urunler SET UrunAdi = @ad WHERE UrunID = @id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ad", yeniAd);
                    cmd.Parameters.AddWithValue("@id", urunId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void GuncelleTeknikCizim(string connectionString, int urunId, byte[] teknikCizim)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Urunler SET TeknikCizim = @data WHERE UrunID = @id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@data", teknikCizim);
                    cmd.Parameters.AddWithValue("@id", urunId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public byte[] GetTeknikCizim(string connectionString, int urunId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT TeknikCizim FROM Urunler WHERE UrunID = @id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", urunId);
                    object sonuc = cmd.ExecuteScalar();
                    if (sonuc == null || sonuc == DBNull.Value)
                    {
                        return null;
                    }

                    return (byte[])sonuc;
                }
            }
        }

        private static List<UrunAgaciUrunDto> AltUrunleriOlustur(int parentUrunId, Dictionary<int, List<UrunAgaciUrunDto>> altUrunlerMap)
        {
            if (!altUrunlerMap.ContainsKey(parentUrunId))
            {
                return new List<UrunAgaciUrunDto>();
            }

            List<UrunAgaciUrunDto> altUrunler = altUrunlerMap[parentUrunId];

            foreach (UrunAgaciUrunDto altUrun in altUrunler)
            {
                altUrun.AltUrunler = AltUrunleriOlustur(altUrun.UrunId, altUrunlerMap);
            }

            return altUrunler;
        }

        private static int GetOrCreateUrun(string kod, string ad, SqlConnection conn, SqlTransaction tran)
        {
            string query = "SELECT UrunID FROM Urunler WHERE UrunKodu = @Kod";
            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@Kod", kod);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return (int)result;
                }
            }

            string insert = "INSERT INTO Urunler (UrunKodu, UrunAdi, Birim) OUTPUT INSERTED.UrunID VALUES (@Kod, @Ad, 'Adet')";
            using (SqlCommand cmdIns = new SqlCommand(insert, conn, tran))
            {
                cmdIns.Parameters.AddWithValue("@Kod", kod);
                cmdIns.Parameters.AddWithValue("@Ad", ad);
                return (int)cmdIns.ExecuteScalar();
            }
        }

        private class UrunAgaciSatiri
        {
            public int AnaUrunId { get; set; }
            public UrunAgaciUrunDto Urun { get; set; }
        }
    }
}
