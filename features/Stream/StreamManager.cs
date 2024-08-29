using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileComparison.features
{
    internal static class StreamManager
    {
        public static void CreateFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public static void WriteBinaryFile(string path, byte[] content)
        {
            File.WriteAllBytes(path, content);
        }

        public static void InsertText(string path, string content, int position)
        {
            var existingContent = File.ReadAllText(path);
            var sb = new StringBuilder(existingContent);
            sb.Insert(position, content);
            File.WriteAllText(path, sb.ToString());
        }

        public static void DeleteText(string path, int start, int length)
        {
            var existingContent = File.ReadAllText(path);
            if (start < 0 || start >= existingContent.Length || length < 0)
                throw new ArgumentOutOfRangeException();

            var sb = new StringBuilder(existingContent);
            sb.Remove(start, Math.Min(length, sb.Length - start));
            File.WriteAllText(path, sb.ToString());
        }

        public static void InsertBinary(string path, byte[] content, int position)
        {
            var existingContent = File.ReadAllBytes(path);
            var newContent = new byte[existingContent.Length + content.Length];
            Buffer.BlockCopy(existingContent, 0, newContent, 0, position);
            Buffer.BlockCopy(content, 0, newContent, position, content.Length);
            Buffer.BlockCopy(existingContent, position, newContent, position + content.Length, existingContent.Length - position);
            File.WriteAllBytes(path, newContent);
        }

        public static void DeleteBinary(string path, int start, int length)
        {
            var existingContent = File.ReadAllBytes(path);
            if (start < 0 || start >= existingContent.Length || length < 0)
                throw new ArgumentOutOfRangeException();

            var newContent = new byte[existingContent.Length - length];
            Buffer.BlockCopy(existingContent, 0, newContent, 0, start);
            Buffer.BlockCopy(existingContent, start + length, newContent, start, existingContent.Length - (start + length));
            File.WriteAllBytes(path, newContent);
        }

        public static List<string> FindDuplicateLines(string filePath1, string filePath2)
        {
            var lines1 = new HashSet<string>(File.ReadLines(filePath1));
            var lines2 = new HashSet<string>(File.ReadLines(filePath2));
            lines1.IntersectWith(lines2);
            return new List<string>(lines1);
        }

        public static List<byte[]> FindDuplicateBinaryContent(string filePath1, string filePath2)
        {
            var content1 = File.ReadAllBytes(filePath1);
            var content2 = File.ReadAllBytes(filePath2);

            var duplicates = new List<byte[]>();

            if (content1.Length == content2.Length && content1.Length > 0)
            {
                bool isDuplicate = true;
                for (int i = 0; i < content1.Length; i++)
                {
                    if (content1[i] != content2[i])
                    {
                        isDuplicate = false;
                        break;
                    }
                }
                if (isDuplicate)
                {
                    duplicates.Add(content1);
                }
            }
            return duplicates;
        }
    }
}
