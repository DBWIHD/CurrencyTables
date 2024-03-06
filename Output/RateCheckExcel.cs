using OfficeOpenXml;
using System.Drawing;

namespace CurrencyTables.Output;

    public class RateCheckExcel
    {
        public string filePath { get; }
        public RateCheckExcel(string path)
        {
            filePath = path;
        }
        /// <summary>
        /// Writes data to report file
        /// </summary>
        /// <param name="dataReport"></param>
        public void ReportToExcel(List<ReportData> dataReport)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                int i = 1;
                foreach (ReportData line in dataReport)
                {
                    workSheet.Cells[i, 1].Value = line.Currency;
                    if (line.Color)
                    {
                        // colors the cell according to results of the check
                        workSheet.Cells[i, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        workSheet.Cells[i, 1].Style.Fill.BackgroundColor.SetColor(Color.Green);
                    }
                    else
                    {
                        workSheet.Cells[i, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        workSheet.Cells[i, 1].Style.Fill.BackgroundColor.SetColor(Color.Red);
                    }
                    i++;
                }
                workSheet.Column(1).AutoFit();
                FileInfo excelFile = new FileInfo(filePath);
                excelPackage.SaveAs(excelFile);
            }
        }
    }