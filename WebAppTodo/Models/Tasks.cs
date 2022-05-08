using System;
using System.Data;
using System.Data.SqlClient;
using WebAppTodo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAppTodo.MyServices;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;
using Dapper;



namespace WebAppTodo.Models
{
    public class Tasks
    {
        public int id { get; set; }
        [Required]
        public string Title { get;set;}
        public DateTime? DeadLine { get; set; }
        public int TaskComplete { get; set; }
        public string? CategoryName { get; set; }
        
    }
}
