using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks.Server.Data;

namespace Tasks.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TaskDbContext _dbcontext;

        public TestController(TaskDbContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Hello World");
        }
    }
}
