using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppTodo.Models;
using WebAppTodo.ModelXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;



namespace WebAppTodo.ModelXml
{
    public class TaskRepositoryXml
    {
        public TaskXml? TaskXml { get; set; }
        public List<TaskXml>? TasksList { get; set; }
        public CategoryXml? CategoryXml { get; set; }
        public List<CategoryXml>? Categories {get;set;}
        
       
       
    }
}
