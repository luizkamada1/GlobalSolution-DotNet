using globalsolution.Data;
using globalsolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace globalsolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoluntariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VoluntariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Voluntarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voluntario>>> GetVoluntarios()
        {
            return await _context.Voluntarios
                .Include(v => v.Usuario)
                .Include(v => v.Doacoes)
                .ToListAsync();
        }

        // GET: api/Voluntarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voluntario>> GetVoluntario(int id)
        {
            var voluntario = await _context.Voluntarios
                .Include(v => v.Usuario)
                .Include(v => v.Doacoes)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (voluntario == null)
                return NotFound();

            return voluntario;
        }

        // POST: api/Voluntarios
        [HttpPost]
        public async Task<ActionResult<Voluntario>> PostVoluntario(Voluntario voluntario)
        {
            _context.Voluntarios.Add(voluntario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVoluntario), new { id = voluntario.Id }, voluntario);
        }

        // PUT: api/Voluntarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoluntario(int id, Voluntario voluntario)
        {
            if (id != voluntario.Id)
                return BadRequest();

            _context.Entry(voluntario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Voluntarios.Any(v => v.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Voluntarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoluntario(int id)
        {
            var voluntario = await _context.Voluntarios.FindAsync(id);
            if (voluntario == null)
                return NotFound();

            _context.Voluntarios.Remove(voluntario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
