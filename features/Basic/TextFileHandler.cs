using System;
using System.Collections.Generic;
using System.IO;

public static class TextFileHandler
{
    public static string[] ReadFileLines(string filePath)
    {
        if (File.Exists(filePath))
        {
            return File.ReadAllLines(filePath);
        }
        else
        {
            Console.WriteLine($"File {filePath} does not exist.");
            return Array.Empty<string>();
        }
    }

    public static void WriteLinesToFile(string filePath, IEnumerable<string> lines, bool append = false)
    {
        if (append)
        {
            File.AppendAllLines(filePath, lines);
        }
        else
        {
            File.WriteAllLines(filePath, lines);
        }
    }
}
