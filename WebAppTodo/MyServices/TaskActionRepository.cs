using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppTodo.Models;
using WebAppTodo.ModelXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace WebAppTodo.MyServices
{
    public class TaskActionRepository : ITaskRepository
    {
        int id;
        XDocument xdoc = XDocument.Load("C:/Users/bekke/source/repos/WebAppTodo/WebAppTodo/wwwroot/TOdo.xml");
        int categoryID;
        public List<Tasks> GetTask()
        {

            List<Tasks> task = new List<Tasks>();
            var elem = xdoc.Element("Todolist").Element("Tasks").Elements("task");
            id = 0;
            foreach (var node in elem)
            {
                task.Add(new Tasks
                {
                    Title = node.Element("Title").Value,
                    TaskComplete = int.Parse(node.Element("TaskComplete").Value),
                    id = int.Parse(node.Element("taskId").Value),
                    CategoryName = node.Element("CategoryName").Value,
                    DeadLine = DateTime.Parse(node.Element("DeadLine").Value)
                });
                id++;
            }
            return task;
        }
        
        public void CreateTask(Tasks model)
        {
            XElement? tmp = xdoc.Element("Todolist");
            XElement? root = tmp.Element("Tasks");
            
            id++;
            if (model.id==0)
            {
                root.Add(new XElement("task",
                            new XAttribute("id", $"{id}"),
                            new XElement("taskId", id),
                            new XElement("Title", model.Title),
                            new XElement("TaskComplete", 0),
                            new XElement("DeadLine", model.DeadLine.ToString()),
                            new XElement("CategoryName", model.CategoryName)
                            ));
            }
            else
            {
                var title = root.Elements("task").FirstOrDefault(p => p.Attribute("id")?.Value == $"{model.id}");

                var Title = title.Element("Title");
                var DeadLine = title.Element("DeadLine");
                var CategoryName = title.Element("CategoryName");
                Title.Value = model.Title;
                DeadLine.Value = model.DeadLine.ToString();
                CategoryName.Value  =  model.CategoryName;
            }
                xdoc.Save("wwwroot/TOdo.xml");
        }
        public void DeleteTask(int id)
        {
            XElement? tmp = xdoc.Element("Todolist");
            XElement? root = tmp.Element("Tasks");
            var title = root.Elements("task").FirstOrDefault(p => p.Attribute("id")?.Value == $"{id}");
            title.Remove();
            xdoc.Save("wwwroot/TOdo.xml");
        }
        public void TaskIsComplete(int id)
        {
            XElement? tmp = xdoc.Element("Todolist");
            XElement? root = tmp.Element("Tasks");
            var title = root.Elements("task").FirstOrDefault(p => p.Attribute("id")?.Value == $"{id}");
            var CompleteTask = title.Element("TaskComplete");
            CompleteTask.Value = "1";
            xdoc.Save("wwwroot/TOdo.xml");
        }
        public List<Category> GetCategories()
        {
            var elem = xdoc.Element("Todolist").Element("Categories").Elements("Category");
            List<Category> category = new List<Category>();
            categoryID = 0;
            foreach (var node in elem)
            {
                categoryID++;
                category.Add(new Category
                {
                    Name = node.Element("Name").Value,
                    Id = int.Parse(node.Element("Id").Value)
                });
            }
            return category;
        }
        public void CreateCategory(Category model)
        {
            TaskRepositoryXml categorys = new TaskRepositoryXml();
            
            XElement? tmp = xdoc.Element("Todolist");
            XElement? root = tmp.Element("Categories");
            categoryID++;
            if (model.Id == null)
            {
                root.Add(new XElement("Category",
                            new XAttribute("id", $"{categoryID}"),
                            new XElement("Id", categoryID),
                            new XElement("Name", model.Name)
                            ));
            }
            else
            {
                var title = root.Elements("Category").FirstOrDefault(p => p.Attribute("id")?.Value == $"{model.Id}");
                var Name = title.Element("Name");
                Name.Value = model.Name;
            }

                xdoc.Save("wwwroot/TOdo.xml");
        }
        public void DeleteCategory(int id)
        {
            categoryID--;
            XDocument xdoc = XDocument.Load("C:/Users/bekke/source/repos/WebAppTodo/WebAppTodo/wwwroot/TOdo.xml");
            XElement? tmp = xdoc.Element("Todolist");
            XElement? root = tmp.Element("Categories");
            var category = root.Elements("Category").FirstOrDefault(p => p.Attribute("id")?.Value == $"{id}");
            category.Remove();
            xdoc.Save("wwwroot/TOdo.xml");
        }
        public List<Tasks> FilterByCategory(Tasks model)
        {
            List<Tasks> result = new List<Tasks>();

            return result;
        }
        public void FilterByTime()
        {
            
        }
    }
    
}
