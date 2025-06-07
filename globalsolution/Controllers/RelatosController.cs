using globalsolution.Data;
using globalsolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace globalsolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RelatosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Relatos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relato>>> GetRelatos()
        {
            return await _context.Relatos
                .Include(r => r.Usuario)
                .ToListAsync();
        }

        // GET: api/Relatos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relato>> GetRelato(int id)
        {
            var relato = await _context.Relatos
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (relato == null)
                return NotFound();

            return relato;
        }

        // POST: api/Relatos
        [HttpPost]
        public async Task<ActionResult<Relato>> PostRelato(Relato relato)
        {
            _context.Relatos.Add(relato);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRelato), new { id = relato.Id }, relato);
        }

        // PUT: api/Relatos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelato(int id, Relato relato)
        {
            if (id != relato.Id)
                return BadRequest();

            _context.Entry(relato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Relatos.Any(r => r.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Relatos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelato(int id)
        {
            var relato = await _context.Relatos.FindAsync(id);
            if (relato == null)
                return NotFound();

            _context.Relatos.Remove(relato);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
