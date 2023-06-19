using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TodoList.Models;

namespace TodoList.Utils
{
	internal static class XmlModelSerializer
	{
		private static void Serialize<T>(this StreamWriter writer, T model)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T),new XmlRootAttribute("Root"));
			serializer.Serialize(writer, model);
			writer.Close();
		}

		public static IEnumerable<T>? Deserialize<T>(this StreamReader reader)
		{
			var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("Root"));
			var result = (List<T>?)serializer.Deserialize(reader);
			reader.Close();
			return result;
		}


		public static Task SaveAsync(this StreamWriter writer,List<TaskViewModel> tasks)
		{
			return Task.Run(() =>
			{
				writer.Serialize(tasks.ToList());
				writer.Close();
			});
		}
		
		private static T? DeserializeEntity<T>(this XmlReader reader)
		{
			var serializer = new XmlSerializer(typeof(T));
			var result = serializer.Deserialize(reader);
			reader.Close();
			return (T?)result;
		}

		public static T? DeserializeFirstOfDefault<T>(this XDocument doc,Func<XElement, bool> search)
		{
			try
			{
				var root = doc.Root;
      
				var elem = root?.Elements().FirstOrDefault(search);
        
				if (elem == null) { return default;}
        
        
				var r = elem.CreateReader();
				
				return r.DeserializeEntity<T>();
			}
			catch
			{
				return default;
			}
		}

		public static XElement EntityToXmlElement<T>(T entity)
		{
			var serializer = new XmlSerializer(typeof(T));
			var stringWriter = new StringWriter();
			serializer.Serialize(stringWriter, entity);
			var xmlString = stringWriter.ToString();
			var element = XElement.Parse(xmlString);
			stringWriter.Close();
			return element;
		}
		
		public static T? XmlElementToEntity<T>(XElement element)
		{
			var serializer = new XmlSerializer(typeof(T));
        
			var entity = serializer.Deserialize(element.CreateReader());

			return (T?)entity;
		}

	}
}
