using FileComparison.features;
using FileComparison.features.Stream;
using System;


namespace FileComparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // C:/Projects/FileComparison/testFiles/sample1
            // C:/Projects/FileComparison/files/file1.txt;
            // C:/Projects/FileComparison/files/file2.txt;
            // C:/Projects/FileComparison/files/output.txt;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("File Comparison");
                Console.WriteLine("1. Basic Program");
                Console.WriteLine("2. Stream Program");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option (1-3): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        basicEntry.main();
                        break;

                    case "2":
                        StreamEntry.main();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        Console.ReadKey();
                        break;
                }
            }

        }



    }
}