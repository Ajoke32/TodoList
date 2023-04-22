using System;
using System.Xml.Serialization;
using TodoList.Models;

namespace TodoList.Utils
{
	internal static class XmlModelSerializer
	{
		public static void Serialize<T>(this StreamWriter writer, T model)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T),new XmlRootAttribute("Root"));
			serializer.Serialize(writer, model);
			writer.Close();
		}

		public static IEnumerable<T>? Deserialize<T>(this StreamReader reader)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("Root"));
			List<T>? result = (List<T>?)serializer.Deserialize(reader);
			reader.Close();
			return result;
		}
		
		public static Task SaveAsync(this StreamWriter writer,List<TaskViewModel> tasks)
		{
			return Task.Run(() =>
			{
				writer.Serialize<List<TaskViewModel>>(tasks.ToList());
			});
		}

	}
}
