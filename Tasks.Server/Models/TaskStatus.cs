namespace Tasks.Server.Models
{
    public class TaskStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
