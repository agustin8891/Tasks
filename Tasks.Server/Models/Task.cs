namespace Tasks.Server.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public TaskStatus Status { get; set; }
    }
}
