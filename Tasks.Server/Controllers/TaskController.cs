using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Server.Data;
using Tasks.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace Tasks.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public TaskController(TaskDbContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //public async System.Threading.Tasks.Task<IActionResult> CreateTask([FromBody] Tasks.Server.Models.Task task)
        //{
        //    return Ok(task);
        //}

        [HttpPost]
        [Route("guardar")]

        public dynamic guardarCliente(Tasks.Server.Models.TaskStatus taskStatus)
        {
            taskStatus.Id = 1;
            taskStatus.Name = "1";
            return new
            {
                success = true,
                message = "cliente registrado",
                result = taskStatus

            };
        }

        // Método GET para obtener una tarea por Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _context.Tasks.Include(t => t.Status).FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return Ok("No encontrado");
            }

            return Ok(task);
        }


    }
}
