using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices; 
using Excel = Microsoft.Office.Interop.Excel;

namespace ÜretimTakipSistemi.SacAmbarı
{
    public class ExcelService
    {
        public void ExportTreeViewToExcel(TreeView tv)
        {
            if (tv.Nodes.Count == 0)
            {
                MessageBox.Show("Dışa aktarılacak veri bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                excelApp.Visible = true;
                excelApp.ScreenUpdating = false; // Ürünlerin daha hızlı yüklenmesi için ürünleri arka planda yüklüyor

                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = "Üretim Ürün Ağacı";

                Excel.Range statusCell = worksheet.Range["D1"];

                // --- 1. ANA BAŞLIK TASARIMI ---
                Excel.Range titleRange = worksheet.Range["A1", "C1"];
                titleRange.Merge();
                titleRange.Value = "ÜRETİM ÜRÜN AĞACI DETAYLI RAPORU";
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 20;
                titleRange.Font.Color = ColorTranslator.ToOle(Color.White);
                titleRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(31, 73, 125));
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                titleRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                titleRange.RowHeight = 45;

                // --- 2. SÜTUN BAŞLIKLARI ---
                worksheet.Cells[3, 1] = "Ürün Yapısı / Parça Adı";
                worksheet.Cells[3, 2] = "Ürün Kodu";
                worksheet.Cells[3, 3] = "Sistem No";

                Excel.Range headerRow = worksheet.Range["A3", "C3"];
                headerRow.Font.Bold = true;
                headerRow.Font.Color = ColorTranslator.ToOle(Color.White);
                headerRow.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(89, 89, 89));
                headerRow.RowHeight = 30;
                headerRow.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                int rowIndex = 4;
                int startRow = 4;

                statusCell.Value = "⏳ Veriler aktarılıyor, lütfen bekleyiniz...";
                statusCell.Font.Bold = true;
                statusCell.Font.Color = ColorTranslator.ToOle(Color.OrangeRed);

                foreach (TreeNode node in tv.Nodes)
                {
                    WriteVisibleNodesToExcel(node, worksheet, ref rowIndex);
                }

                // --- 3. TABLO FORMATLAMA ---
                int lastRow = rowIndex - 1;
                if (lastRow >= startRow)
                {
                    Excel.Range dataRows = worksheet.Range["A" + startRow, "C" + lastRow];
                    dataRows.Font.Size = 12; 
                    dataRows.RowHeight = 22;
                    dataRows.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    
                    for (int i = startRow; i <= lastRow; i++)
                    {
                        if (i % 2 == 0)
                        {
                            worksheet.Range["A" + i, "C" + i].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(245, 245, 245));
                        }
                    }

                    // Kenarlıklar
                    Excel.Range fullTableRange = worksheet.Range["A3", "C" + lastRow];
                    fullTableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    fullTableRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    fullTableRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
                }

                worksheet.Columns[1].ColumnWidth = 60;
                worksheet.Columns[2].ColumnWidth = 25;
                worksheet.Columns[3].ColumnWidth = 15;
                worksheet.Range["B4", "C" + lastRow].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                statusCell.Value = "✅ Tüm Ürünler Başarıyla Yüklendi.";
                statusCell.Font.Color = ColorTranslator.ToOle(Color.DarkGreen);

                excelApp.ScreenUpdating = true;
            }
            catch (Exception ex)
            {
                if (excelApp != null) excelApp.ScreenUpdating = true;
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bellek temizliği (Excel'i açık bırakmak istiyorsanız silme)
                // GC.Collect();
                // GC.WaitForPendingFinalizers();
            }
        }

        private void WriteVisibleNodesToExcel(TreeNode node, Excel.Worksheet sheet, ref int rowIndex)
        {
            Excel.Range nameCell = (Excel.Range)sheet.Cells[rowIndex, 1];
            nameCell.Value = node.Text;
            nameCell.IndentLevel = node.Level * 2;

            if (node.Level == 0)
            {
                nameCell.Font.Bold = true;
                nameCell.Font.Color = ColorTranslator.ToOle(Color.DarkBlue);
            }

            if (node.Tag is UrunNodeInfo info)
            {
                sheet.Cells[rowIndex, 2] = info.UrunKodu;
                sheet.Cells[rowIndex, 3] = info.UrunID;
            }
            else if (node.Tag != null)
            {
                sheet.Cells[rowIndex, 2] = node.Tag.ToString();
            }

            rowIndex++;

            // Sadece açık (expanded) olanları değil, agaca sahip olanları görünecekse bunu sil
            if (node.IsExpanded)
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    WriteVisibleNodesToExcel(childNode, sheet, ref rowIndex);
                }
            }
        }
    }
}