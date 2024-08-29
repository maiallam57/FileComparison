using System;
using System.Collections.Generic;
using System.IO;

public static class FileManager
{
    public static (HashSet<string> UniqueLines, List<string> DuplicateLines) CompareFiles(string firstFilePath, string secondFilePath)
    {
        var extension1 = Path.GetExtension(firstFilePath).ToLower();
        var extension2 = Path.GetExtension(secondFilePath).ToLower();

        if (extension1 != extension2)
        {
            throw new InvalidOperationException("Files have different extensions. Please provide files with the same extension.");
        }

        var lines1 = ReadFile(firstFilePath);
        var lines2 = ReadFile(secondFilePath);

        //HashSet<T> to ensures that all elements are unique
        var uniqueLines = new HashSet<string>(lines1);
        var duplicates = new List<string>();

        foreach (var line in lines2)
        {
            if (!uniqueLines.Add(line))
            {
                duplicates.Add(line);
            }
        }

        return (uniqueLines, duplicates);
    }

    private static IEnumerable<string> ReadFile(string filePath)
    {
        var extension = Path.GetExtension(filePath).ToLower();

        if (extension == ".txt")
        {
            return TextFileHandler.ReadFileLines(filePath);
        }
        else if (extension == ".csv")
        {
            return ConvertToTextArray(CsvFileHandler.ReadCsvFile(filePath));
        }
        else if (extension == ".xml")
        {
            return XmlFileHandler.ReadXmlFile(filePath);
        }
        else if (extension == ".xlsx")
        {
            return ExcelFileHandler.ReadExcelFile(filePath);
        }
        else
        {
            throw new NotSupportedException("File type not supported.");
        }
    }

    public static void WriteFile(string filePath, IEnumerable<string> lines, bool append = false)
    {
        var extension = Path.GetExtension(filePath).ToLower();

        if (extension == ".txt")
        {
            TextFileHandler.WriteLinesToFile(filePath, lines, append);
        }
        else if (extension == ".csv")
        {
            CsvFileHandler.WriteCsvFile(filePath, ConvertToCsvRecords(lines), append);
        }
        else if (extension == ".xml")
        {
            XmlFileHandler.WriteXmlFile(filePath, lines, append);
        }
        else if (extension == ".xlsx")
        {
            ExcelFileHandler.WriteExcelFile(filePath, lines, append);
        }
        else
        {
            throw new NotSupportedException("File type not supported.");
        }
    }

    public static void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine($"File {filePath} deleted successfully.");
        }
        else
        {
            Console.WriteLine($"File {filePath} does not exist.");
        }
    }

    public static void UpdateFile(string filePath, IEnumerable<string> newLines)
    {
        var extension = Path.GetExtension(filePath).ToLower();

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File {filePath} does not exist. Creating a new file.");
            return;
        }

        if (extension == ".txt")
        {
            TextFileHandler.WriteLinesToFile(filePath, newLines, append: true);
        }
        else if (extension == ".csv")
        {
            CsvFileHandler.WriteCsvFile(filePath, ConvertToCsvRecords(newLines), append: true);
        }
        else if (extension == ".xml")
        {
            XmlFileHandler.WriteXmlFile(filePath, newLines, append: true);
        }
        else if (extension == ".xlsx")
        {
            ExcelFileHandler.WriteExcelFile(filePath, newLines, append: true);
        }
        else
        {
            throw new NotSupportedException("File type not supported.");
        }
    }

    private static IEnumerable<string[]> ConvertToCsvRecords(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            yield return line.Split(',');
        }
    }

    private static string[] ConvertToTextArray(IEnumerable<string[]> records)
    {
        var lines = new List<string>();
        foreach (var record in records)
        {
            lines.Add(string.Join(",", record));
        }
        return lines.ToArray();
    }
}
