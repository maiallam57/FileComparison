using FileComparison.features.Stream;
using System;
using System.Collections.Generic;

namespace FileComparison.features
{
    internal class StreamEntry
    {
        public static void main()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("File Comparison Program");
                Console.WriteLine("1. Create Text Files");
                Console.WriteLine("2. Create Binary Files");
                Console.WriteLine("3. Insert Text into File");
                Console.WriteLine("4. Delete Text from File");
                Console.WriteLine("5. Insert Binary Data into File");
                Console.WriteLine("6. Delete Binary Data from File");
                Console.WriteLine("7. Find Duplicate Lines in Text Files");
                Console.WriteLine("8. Find Duplicate Binary Content");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option (1-9): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StreamLogic.CreateTextFiles();
                        break;

                    case "2":
                        StreamLogic.CreateBinaryFiles();
                        break;

                    case "3":
                        StreamLogic.InsertTextIntoFile();
                        break;

                    case "4":
                        StreamLogic.DeleteTextFromFile();
                        break;

                    case "5":
                        StreamLogic.InsertBinaryDataIntoFile();
                        break;

                    case "6":
                        StreamLogic.DeleteBinaryDataFromFile();
                        break;

                    case "7":
                        StreamLogic.FindDuplicateLinesInTextFiles();
                        break;

                    case "8":
                        StreamLogic.FindDuplicateBinaryContent();
                        break;

                    case "9":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 9.");
                        Console.ReadKey();
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
}
