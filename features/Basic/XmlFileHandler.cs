using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

public static class XmlFileHandler
{
    public static IEnumerable<string> ReadXmlFile(string filePath)
    {
        var lines = new List<string>();

        if (File.Exists(filePath))
        {
            var document = XDocument.Load(filePath);
            foreach (var element in document.Root.Elements())
            {
                lines.Add(element.Value);
            }
        }

        return lines;
    }

    public static void WriteXmlFile(string filePath, IEnumerable<string> lines, bool append = false)
    {
        XDocument document;
        if (append && File.Exists(filePath))
        {
            document = XDocument.Load(filePath);
        }
        else
        {
            document = new XDocument(new XElement("Root"));
        }

        var root = document.Root;

        foreach (var line in lines)
        {
            root.Add(new XElement("Line", line));
        }

        document.Save(filePath);
    }
}
