using System;
using System.Data;
using System.Data.SqlClient;
using WebAppTodo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Query;
using Dapper;
using System.Web;
using System.IO;


namespace WebAppTodo.MyServices
{
    public class TaskRepository : ITaskRepository
    {
        private IConfiguration Configuration;
        public TaskRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConectionString = Configuration.GetConnectionString("DBConnection");
            provaiderName = "System.Date.SqlClient";
        }

        public string ConectionString { get; }
        public string provaiderName { get; }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConectionString);
            }
        }

        public List<Tasks> GetTask()
        {
            List<Tasks> result = new List<Tasks>();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                result = dbConnection.Query<Tasks>("GetsTask", commandType: CommandType.StoredProcedure).ToList();
                dbConnection.Close();
                return result;
            }
        }

        public List<Category> GetCategories()
        {
            List<Category> result = new List<Category>();
            using (IDbConnection dbconnection = Connection)
            {
                dbconnection.Open();
                result = dbconnection.Query<Category>("GetCategory", commandType: CommandType.StoredProcedure).ToList();
                dbconnection.Close();
                return result;
            }
        }
        public void CreateTask(Tasks model)
        {
            using (IDbConnection dbconnection = Connection)
            {

                if (model.id == 0)
                {
                    dbconnection.Open();
                    var result = dbconnection.Query<Tasks>("CreateTasks", new { Title = model.Title, Deadline = model.DeadLine, CategoryName = model.CategoryName }, commandType: CommandType.StoredProcedure);
                    dbconnection.Close();
                }
                else
                {
                    dbconnection.Open();
                    var result = dbconnection.Query<Tasks>("UpdateTasks", new { Title = model.Title, Deadline = model.DeadLine, CategoryName = model.CategoryName, id = model.id }, commandType: CommandType.StoredProcedure);
                    dbconnection.Close();
                }

            }
        }

        public void DeleteTask(int TaskId)
        {
            using (IDbConnection dbconnection = Connection)
            {
                dbconnection.Open();
                var result = dbconnection.Query<Tasks>("DeleteTask", new { id = TaskId }, commandType: CommandType.StoredProcedure);
                dbconnection.Close();
            }
        }

        public void TaskIsComplete(int TaskId)
        {
            using (IDbConnection dbconnection = Connection)
            {
                dbconnection.Open();
                var result = dbconnection.Query<Tasks>("CompleteTasks", new { id = TaskId }, commandType: CommandType.StoredProcedure);
                dbconnection.Close();
            }
        }
        public List<Tasks> FilterByCategory(Tasks model)
        {
            List<Tasks> result = new List<Tasks>();
            if (model.CategoryName == "All")
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    result = dbConnection.Query<Tasks>("GetsTask", commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return result;
                }
            }
            else
            {

                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    result = dbConnection.Query<Tasks>("FilterBy", new { Category = model.CategoryName }, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return result;
                }
            }
        }
        public void FilterByTime()
        {
            using (IDbConnection dbConnection = Connection)
            {

                dbConnection.Open();
                dbConnection.Query<Tasks>("FilterByTime", commandType: CommandType.StoredProcedure).ToList();
                dbConnection.Close();

            }

        }
        public void CreateCategory(Category model)
        {
           
            if (model.Id == 0)
            {
                using (IDbConnection dbconnection = Connection)
                {
                    dbconnection.Open();
                    var result = dbconnection.Query<Tasks>("CreateCategory", new { CateName = model.Name }, commandType: CommandType.StoredProcedure);
                    dbconnection.Close();

                }
            }
            else
            {
                using (IDbConnection dbconnection = Connection)
                {
                    dbconnection.Open();
                    var result = dbconnection.Query<Tasks>("UpdateCategory", new { Name = model.Name,id=model.Id }, commandType: CommandType.StoredProcedure);
                    dbconnection.Close();

                }
            }
        }
        public void DeleteCategory(int CategoryId)
        {
            using (IDbConnection dbconnection = Connection)
            {
                dbconnection.Open();
                dbconnection.Query<Tasks>("DeleteCategory", new { id = CategoryId }, commandType: CommandType.StoredProcedure);
                dbconnection.Close();
            }
        }

    }
    public interface ITaskRepository
    {
        public List<Category> GetCategories();
        public List<Tasks> GetTask();
        public void CreateTask(Tasks model);
        public void DeleteTask(int TaskId);
        public void TaskIsComplete(int TaskId);
        public List<Tasks> FilterByCategory(Tasks model);
        public void FilterByTime();
        public void CreateCategory(Category model);
        public void DeleteCategory(int CategoryId);
    }
}
