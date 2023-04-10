namespace TodoList.Models
{
    public class TasksWithCategories
    {
        public List<Category> Categories { get; set; }

        public List<TaskViewModel> Tasks { get; set;}
    }
}
