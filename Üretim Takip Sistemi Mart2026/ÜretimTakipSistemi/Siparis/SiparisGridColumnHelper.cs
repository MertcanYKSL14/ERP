using System.Collections.Generic;
using System.Windows.Forms;

namespace ÜretimTakipSistemi.Siparis
{
    internal static class SiparisGridColumnHelper
    {
        internal static void Uygula(DataGridView grid, IDictionary<string, string> basliklar)
        {
            if (grid == null || grid.Columns.Count == 0)
            {
                return;
            }

            if (grid.Columns["SiparisID"] != null)
            {
                grid.Columns["SiparisID"].Visible = false;
            }

            foreach (KeyValuePair<string, string> kolon in basliklar)
            {
                if (grid.Columns[kolon.Key] != null)
                {
                    grid.Columns[kolon.Key].HeaderText = kolon.Value;
                }
            }

            if (grid.Columns["KayitTarihi"] != null)
            {
                grid.Columns["KayitTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
        }
    }
}
