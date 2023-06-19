using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TodoList.Interfaces;
using TodoList.Models;
using TodoList.Models.DTOs.DisplayDtos;
using TodoList.Utils;

#pragma warning disable CS8604
#pragma warning disable CS8600
#pragma warning disable CS8619
#pragma warning disable CS8602

namespace TodoList.Repositories
{
    public class XmlTaskRepository : ITaskRepository
    {

        private readonly string _path = Directory.GetCurrentDirectory() + "/Todos.xml";
        public async Task<TaskViewModel> AddTaskAsync(TaskViewModel task)
        {
            var doc = await XmlDocumentExtension.LoadDocumentAsync(_path);
            task.Id = new Random().Next();
            var element = XmlModelSerializer.EntityToXmlElement(task);
            doc.Root.Add(element);
            await doc.SaveDocumentAsync(_path);
            
            return task;
        }

        public async Task DeleteTaskAsync(int id)
        {

            var doc = await XmlDocumentExtension.LoadDocumentAsync(_path);
            
            var xElement = doc.Root.Elements().FirstOrDefault(e => e.Element("Id").Value == id.ToString());
            
            xElement.Remove();

            await doc.SaveDocumentAsync(_path);
        }

        public Task<List<TaskViewModel>> GetAllTasksAsync()
        {
            var sr = new StreamReader(_path);
            var tasks = sr.Deserialize<TaskViewModel>()
                .OrderBy(t => t.IsCompleted).ToList();

            var cateReader = new StreamReader(Directory.GetCurrentDirectory()+"/Categories.xml");
            
            var categories = cateReader.Deserialize<Category>();
            foreach (var task in tasks)
            {
                task.Category = categories.FirstOrDefault(c => c.Id == task.CategoryId);
            }
            return Task.Run(() => tasks);
        }
        
        public async Task<TaskViewModel?> GetTaskByIdAsync(int id)
        {
            var doc = await XmlDocumentExtension.LoadDocumentAsync(_path);
            
            return doc.DeserializeFirstOfDefault<TaskViewModel>(e=>
                e.Element("Id")?.Value==id.ToString());
        }
        

        public async Task<IEnumerable<TaskViewModel>> GetTasksWith<T>(Func<TaskViewModel, T, TaskViewModel>? map = null, string spitOn = "")
        {
           
            return await GetAllTasksAsync();
        }

        public async Task UpdateCompletionState(bool state, int id)
        {
            var doc = await XmlDocumentExtension.LoadDocumentAsync(_path);

            var elem = doc.GetElementBy("Id",id.ToString());
            
            elem.SetElementValue("IsCompleted",state);
            
            await doc.SaveDocumentAsync(_path);
            
        }

        public async Task UpdateTaskAsync(TaskViewModel task, int id)
        {
            var doc =  await XmlDocumentExtension.LoadDocumentAsync(_path);
            
            var el = doc.GetElementBy("Id",id.ToString());

            var taskElement = XmlModelSerializer.EntityToXmlElement(task);
            
            el.ReplaceWith(taskElement);

            await doc.SaveDocumentAsync(_path);

        }
        
    }
}
