using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Server.Data;
using Tasks.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrarController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public BorrarController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get() => _context.Users.ToList();

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Validación fallida
            }

            // Añadir el nuevo usuario al contexto
            _context.Users.Add(user);
            await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user); // Devolver el objeto creado y su ruta
        }
    }
}
