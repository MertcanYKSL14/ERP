using System;
using System.Collections.Generic;
using System.Data;
using SiparisEntity = ÜretimTakipSistemi.Entities.Concrete.Siparis;

namespace ÜretimTakipSistemi.Siparis
{
    internal static class SiparisGridTableHelper
    {
        internal static DataTable SiparisleriDataTableaDonustur(IEnumerable<SiparisEntity> siparisler)
        {
            DataTable dataTable = SiparisTablosuOlustur();

            foreach (SiparisEntity siparis in siparisler)
            {
                dataTable.Rows.Add(
                    siparis.SiparisID,
                    siparis.StokNo,
                    siparis.MusteriAdi,
                    siparis.ParcaAdi,
                    siparis.Bolum,
                    siparis.SiparisAdeti,
                    siparis.Durum,
                    siparis.KayitTarihi,
                    siparis.SiparisNotu);
            }

            return dataTable;
        }

        private static DataTable SiparisTablosuOlustur()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SiparisID", typeof(int));
            dataTable.Columns.Add("StokNo", typeof(string));
            dataTable.Columns.Add("MusteriAdi", typeof(string));
            dataTable.Columns.Add("ParcaAdi", typeof(string));
            dataTable.Columns.Add("Bolum", typeof(string));
            dataTable.Columns.Add("SiparisAdeti", typeof(int));
            dataTable.Columns.Add("Durum", typeof(string));
            dataTable.Columns.Add("KayitTarihi", typeof(DateTime));
            dataTable.Columns.Add("SiparisNotu", typeof(string));
            return dataTable;
        }
    }
}
