namespace WebAppTodo.Models
{
    public class TaskRepositoryList
    {
        public Tasks? Tasks { get; set; }
        public List<Tasks>? Taskes { get; set; }
        public List <Tasks>? CompletedTask { get; set; }
        public Category? Category { get; set; }

        public List<Category> Categories { get; set; }

        


}
}
