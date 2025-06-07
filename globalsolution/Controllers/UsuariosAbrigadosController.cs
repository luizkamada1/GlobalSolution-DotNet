using globalsolution.Data;
using globalsolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace globalsolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosAbrigadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosAbrigadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosAbrigados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioAbrigado>>> GetUsuariosAbrigados()
        {
            return await _context.UsuariosAbrigados
                .Include(ua => ua.Usuario)
                .Include(ua => ua.Abrigo)
                .ToListAsync();
        }

        // GET: api/UsuariosAbrigados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioAbrigado>> GetUsuarioAbrigado(int id)
        {
            var usuarioAbrigado = await _context.UsuariosAbrigados
                .Include(ua => ua.Usuario)
                .Include(ua => ua.Abrigo)
                .FirstOrDefaultAsync(ua => ua.Id == id);

            if (usuarioAbrigado == null)
                return NotFound();

            return usuarioAbrigado;
        }

        // POST: api/UsuariosAbrigados
        [HttpPost]
        public async Task<ActionResult<UsuarioAbrigado>> PostUsuarioAbrigado(UsuarioAbrigado usuarioAbrigado)
        {
            _context.UsuariosAbrigados.Add(usuarioAbrigado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarioAbrigado), new { id = usuarioAbrigado.Id }, usuarioAbrigado);
        }

        // PUT: api/UsuariosAbrigados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioAbrigado(int id, UsuarioAbrigado usuarioAbrigado)
        {
            if (id != usuarioAbrigado.Id)
                return BadRequest();

            _context.Entry(usuarioAbrigado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.UsuariosAbrigados.Any(ua => ua.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/UsuariosAbrigados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioAbrigado(int id)
        {
            var usuarioAbrigado = await _context.UsuariosAbrigados.FindAsync(id);
            if (usuarioAbrigado == null)
                return NotFound();

            _context.UsuariosAbrigados.Remove(usuarioAbrigado);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
