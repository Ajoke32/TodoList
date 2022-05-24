using System.ComponentModel.DataAnnotations;
using System;
using System.Data;
using System.Data.SqlClient;
using WebAppTodo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAppTodo.MyServices;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Query;
using Dapper;
using WebAppTodo.ModelXml;

namespace WebAppTodo.ModelXml
{
    public class TaskXml
    {
        public int Id { get; set; }
       
        public string? Title { get; set; }
        public int TaskComplete { get; set; }
        public DateTime DeadLine { get; set; }
        public string? CategoryName { get; set; }
    }
}
