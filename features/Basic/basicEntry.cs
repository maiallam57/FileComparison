using System;
using System.Collections.Generic;
using System.IO;

public static class basicEntry
{
    public static void main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Compare Files");
            Console.WriteLine("2. Write to File");
            Console.WriteLine("3. Delete File");
            Console.WriteLine("4. Update File");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the path of the first file: ");
                    var firstFilePath = Console.ReadLine();
                    Console.Write("Enter the path of the second file: ");
                    var secondFilePath = Console.ReadLine();
                    Console.Write("Enter the path for the output file: ");
                    var outputFilePath = Console.ReadLine();

                    var (uniqueLines, duplicateLines) = FileManager.CompareFiles(firstFilePath, secondFilePath);
                    FileManager.WriteFile(outputFilePath, uniqueLines, append: false);

                    if (duplicateLines.Count > 0)
                    {
                        Console.WriteLine("Duplicate lines found:");
                        foreach (var line in duplicateLines)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No duplicate lines found.");
                    }
                    break;

                case "2":
                    Console.Write("Enter the path for the file to write to: ");
                    var writeFilePath = Console.ReadLine();
                    Console.Write("Enter the lines to write (separated by '|'): ");
                    var linesToWrite = Console.ReadLine().Split('|');
                    Console.Write("Do you want to append the data? (yes/no): ");
                    var append = Console.ReadLine().Trim().ToLower() == "yes";
                    FileManager.WriteFile(writeFilePath, linesToWrite, append);
                    Console.WriteLine("Data written to file.");
                    break;

                case "3":
                    Console.Write("Enter the path of the file to delete: ");
                    var deleteFilePath = Console.ReadLine();
                    FileManager.DeleteFile(deleteFilePath);
                    break;

                case "4":
                    Console.Write("Enter the path of the file to update: ");
                    var updateFilePath = Console.ReadLine();
                    Console.Write("Enter the lines to update (separated by '|'): ");
                    var linesToUpdate = Console.ReadLine().Split('|');
                    FileManager.UpdateFile(updateFilePath, linesToUpdate);
                    Console.WriteLine("File updated.");
                    break;

                case "5":
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            // Keep the console window open
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            // Keep the console window open
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        
    }
}
