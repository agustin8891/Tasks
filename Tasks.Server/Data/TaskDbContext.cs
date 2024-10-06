using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tasks.Server.Models;
using TaskEntity = Tasks.Server.Models.Task;
using TaskStatusEntity = Tasks.Server.Models.TaskStatus;

namespace Tasks.Server.Data
{
    public class TaskDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public TaskDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskStatusEntity> TaskStatuses { get; set; }
    }
}