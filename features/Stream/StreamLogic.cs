using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileComparison.features.Stream
{
    internal class StreamLogic
    {
        public static void CreateTextFiles()
        {
            Console.WriteLine("Enter the path for the first text file:");
            string textFilePath1 = Console.ReadLine();

            Console.WriteLine("Enter the path for the second text file:");
            string textFilePath2 = Console.ReadLine();

            Console.WriteLine("Enter the content for the first text file:");
            string textContent1 = Console.ReadLine();

            Console.WriteLine("Enter the content for the second text file:");
            string textContent2 = Console.ReadLine();

            StreamManager.CreateFile(textFilePath1, textContent1);
            StreamManager.CreateFile(textFilePath2, textContent2);

            Console.WriteLine("Text files created successfully.");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public static void CreateBinaryFiles()
        {
            Console.WriteLine("Enter the path for the first binary file:");
            string binaryFilePath1 = Console.ReadLine();

            Console.WriteLine("Enter the path for the second binary file:");
            string binaryFilePath2 = Console.ReadLine();

            Console.WriteLine("Enter the content for the first binary file (comma-separated bytes, e.g., 1,2,3,4,5):");
            string binaryContentInput1 = Console.ReadLine();
            byte[] binaryContent1 = Array.ConvertAll(binaryContentInput1.Split(','), byte.Parse);

            Console.WriteLine("Enter the content for the second binary file (comma-separated bytes, e.g., 6,7,8,9,10):");
            string binaryContentInput2 = Console.ReadLine();
            byte[] binaryContent2 = Array.ConvertAll(binaryContentInput2.Split(','), byte.Parse);

            StreamManager.WriteBinaryFile(binaryFilePath1, binaryContent1);
            StreamManager.WriteBinaryFile(binaryFilePath2, binaryContent2);

            Console.WriteLine("Binary files created successfully.");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public static void InsertTextIntoFile()
        {
            Console.WriteLine("Enter the path for the text file:");
            string textFilePath = Console.ReadLine();

            Console.WriteLine("Enter the content to insert:");
            string content = Console.ReadLine();

            Console.WriteLine("Enter the position to insert the content:");
            if (int.TryParse(Console.ReadLine(), out int position))
            {
                StreamManager.InsertText(textFilePath, content, position);
                Console.WriteLine("Text inserted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid position.");
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public static void DeleteTextFromFile()
        {
            Console.WriteLine("Enter the path for the text file:");
            string textFilePath = Console.ReadLine();

            Console.WriteLine("Enter the start position to delete content:");
            if (int.TryParse(Console.ReadLine(), out int start))
            {
                Console.WriteLine("Enter the length of content to delete:");
                if (int.TryParse(Console.ReadLine(), out int length))
                {
                    StreamManager.DeleteText(textFilePath, start, length);
                    Console.WriteLine("Text deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid length.");
                }
            }
            else
            {
                Console.WriteLine("Invalid start position.");
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public static void InsertBinaryDataIntoFile()
        {
            Console.WriteLine("Enter the path for the binary file:");
            string binaryFilePath = Console.ReadLine();

            Console.WriteLine("Enter the binary content to insert (comma-separated bytes, e.g., 1,2,3):");
            string binaryContentInput = Console.ReadLine();
            byte[] content = Array.ConvertAll(binaryContentInput.Split(','), byte.Parse);

            Console.WriteLine("Enter the position to insert the binary content:");
            if (int.TryParse(Console.ReadLine(), out int position))
            {
                StreamManager.InsertBinary(binaryFilePath, content, position);
                Console.WriteLine("Binary data inserted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid position.");
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public static void DeleteBinaryDataFromFile()
        {
            Console.WriteLine("Enter the path for the binary file:");
            string binaryFilePath = Console.ReadLine();

            Console.WriteLine("Enter the start position to delete binary data:");
            if (int.TryParse(Console.ReadLine(), out int start))
            {
                Console.WriteLine("Enter the length of binary data to delete:");
                if (int.TryParse(Console.ReadLine(), out int length))
                {
                    StreamManager.DeleteBinary(binaryFilePath, start, length);
                    Console.WriteLine("Binary data deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid length.");
                }
            }
            else
            {
                Console.WriteLine("Invalid start position.");
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public static void FindDuplicateLinesInTextFiles()
        {
            Console.WriteLine("Enter the path for the first text file:");
            string textFilePath1 = Console.ReadLine();

            Console.WriteLine("Enter the path for the second text file:");
            string textFilePath2 = Console.ReadLine();

            // Finding duplicates in text files
            List<string> duplicateLines = StreamManager.FindDuplicateLines(textFilePath1, textFilePath2);
            if (duplicateLines.Count > 0)
            {
                Console.WriteLine("Duplicate lines found in text files:");
                foreach (var line in duplicateLines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("No duplicate lines found in text files.");
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public static void FindDuplicateBinaryContent()
        {
            Console.WriteLine("Enter the path for the first binary file:");
            string binaryFilePath1 = Console.ReadLine();

            Console.WriteLine("Enter the path for the second binary file:");
            string binaryFilePath2 = Console.ReadLine();

            // Finding duplicates 
            List<byte[]> duplicateBinaryContents = StreamManager.FindDuplicateBinaryContent(binaryFilePath1, binaryFilePath2);
            if (duplicateBinaryContents.Count > 0)
            {
                Console.WriteLine("Duplicate binary content found in binary files:");
                foreach (var binaryData in duplicateBinaryContents)
                {
                    Console.WriteLine(BitConverter.ToString(binaryData));
                }
            }
            else
            {
                Console.WriteLine("No duplicate binary content found in binary files.");
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
