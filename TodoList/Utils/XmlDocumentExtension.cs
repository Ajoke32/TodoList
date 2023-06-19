using System.Xml;
using System.Xml.Linq;

namespace TodoList.Utils;

public static class XmlDocumentExtension
{
    public static async Task<XDocument> LoadDocumentAsync(string path)
    {
        try
        {
            var reader = XmlReader.Create(path,new XmlReaderSettings{ Async = true});
				
            var doc = await XDocument.LoadAsync(reader,LoadOptions.None,CancellationToken.None);
            reader.Close();
            return doc;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public static async Task SaveDocumentAsync(this XDocument doc,string path,CancellationToken token = default)
    {
        try
        {
            var writer = XmlWriter.Create(path,new XmlWriterSettings { Async = true });

            await doc.SaveAsync(writer,token);
            
            writer.Close();	
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        
    }

    public static XElement? GetElementBy(this XDocument doc,string by,string compare)
    {
        var root = doc.Root;
        if (root == null)
        {
            throw new XmlException("Root element is missing");
        }
        
        return root.Elements().FirstOrDefault(e => e.Element(by)?.Value == compare);
    }
}