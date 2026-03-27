using System.Data;
using System.Linq;

namespace ÜretimTakipSistemi.Siparis
{
    internal static class SiparisGridFilterHelper
    {
        internal static void Uygula(DataView dataView, string aramaMetni, params string[] kolonlar)
        {
            if (dataView == null)
            {
                return;
            }

            string temizMetin = KacisliMetinGetir(aramaMetni);

            if (string.IsNullOrWhiteSpace(temizMetin) || kolonlar == null || kolonlar.Length == 0)
            {
                dataView.RowFilter = string.Empty;
                return;
            }

            string filtre = string.Join(" OR ", kolonlar.Select(kolon => $"{kolon} LIKE '%{temizMetin}%'"));
            dataView.RowFilter = filtre;
        }

        private static string KacisliMetinGetir(string aramaMetni)
        {
            return (aramaMetni ?? string.Empty).Trim().Replace("'", "''");
        }
    }
}
