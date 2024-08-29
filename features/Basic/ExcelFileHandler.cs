using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

public static class ExcelFileHandler
{
    public static IEnumerable<string> ReadExcelFile(string filePath)
    {
        var lines = new List<string>();

        if (File.Exists(filePath))
        {
            var package = new ExcelPackage(new FileInfo(filePath));
            var worksheet = package.Workbook.Worksheets[0];
            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;

            for (int row = 1; row <= rowCount; row++)
            {
                var rowValues = new List<string>();
                for (int col = 1; col <= colCount; col++)
                {
                    rowValues.Add(worksheet.Cells[row, col].Text);
                }
                lines.Add(string.Join(",", rowValues));
            }
        }
        else
        {
            Console.WriteLine($"File {filePath} does not exist.");
        }

        return lines;
    }

    public static void WriteExcelFile(string filePath, IEnumerable<string> lines, bool append = false)
    {
        var package = new ExcelPackage(new FileInfo(filePath));
        var worksheet = package.Workbook.Worksheets.Count > 0 ? package.Workbook.Worksheets[0] : package.Workbook.Worksheets.Add("Sheet1");

        int startRow = append ? worksheet.Dimension.Rows + 1 : 1;

        int row = startRow;
        foreach (var line in lines)
        {
            var values = line.Split(',');
            for (int col = 1; col <= values.Length; col++)
            {
                worksheet.Cells[row, col].Value = values[col - 1];
            }
            row++;
        }

        package.Save();
    }
}
