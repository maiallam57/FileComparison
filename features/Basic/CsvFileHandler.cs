using System.Collections.Generic;
using System.IO;

public static class CsvFileHandler
{
    public static IEnumerable<string[]> ReadCsvFile(string filePath)
    {
        var lines = new List<string[]>();

        if (File.Exists(filePath))
        {
            var allLines = File.ReadAllLines(filePath);
            foreach (var line in allLines)
            {
                lines.Add(line.Split(','));
            }
        }

        return lines;
    }

    public static void WriteCsvFile(string filePath, IEnumerable<string[]> records, bool append = false)
    {
        var writer = new StreamWriter(filePath, append);
        foreach (var record in records)
        {
            writer.WriteLine(string.Join(",", record));
        }
    }
}
