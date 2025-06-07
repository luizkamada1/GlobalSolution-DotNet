using globalsolution.Data;
using globalsolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace globalsolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbrigosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AbrigosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Abrigos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abrigo>>> GetAbrigos()
        {
            return await _context.Abrigos
                .Include(a => a.UsuariosAbrigados)
                .ToListAsync();
        }

        // GET: api/Abrigos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Abrigo>> GetAbrigo(int id)
        {
            var abrigo = await _context.Abrigos
                .Include(a => a.UsuariosAbrigados)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (abrigo == null)
                return NotFound();

            return abrigo;
        }

        // POST: api/Abrigos
        [HttpPost]
        public async Task<ActionResult<Abrigo>> PostAbrigo(Abrigo abrigo)
        {
            _context.Abrigos.Add(abrigo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAbrigo), new { id = abrigo.Id }, abrigo);
        }

        // PUT: api/Abrigos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbrigo(int id, Abrigo abrigo)
        {
            if (id != abrigo.Id)
                return BadRequest();

            _context.Entry(abrigo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Abrigos.Any(a => a.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Abrigos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbrigo(int id)
        {
            var abrigo = await _context.Abrigos.FindAsync(id);
            if (abrigo == null)
                return NotFound();

            _context.Abrigos.Remove(abrigo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
