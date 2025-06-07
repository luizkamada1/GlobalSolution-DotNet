using globalsolution.Data;
using globalsolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace globalsolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DoacoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Doacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doacao>>> GetDoacoes()
        {
            return await _context.Doacoes
                .Include(d => d.Voluntario)
                .ThenInclude(v => v.Usuario)
                .ToListAsync();
        }

        // GET: api/Doacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doacao>> GetDoacao(int id)
        {
            var doacao = await _context.Doacoes
                .Include(d => d.Voluntario)
                .ThenInclude(v => v.Usuario)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (doacao == null)
                return NotFound();

            return doacao;
        }

        // POST: api/Doacoes
        [HttpPost]
        public async Task<ActionResult<Doacao>> PostDoacao(Doacao doacao)
        {
            _context.Doacoes.Add(doacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDoacao), new { id = doacao.Id }, doacao);
        }

        // PUT: api/Doacoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoacao(int id, Doacao doacao)
        {
            if (id != doacao.Id)
                return BadRequest();

            _context.Entry(doacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Doacoes.Any(d => d.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Doacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoacao(int id)
        {
            var doacao = await _context.Doacoes.FindAsync(id);
            if (doacao == null)
                return NotFound();

            _context.Doacoes.Remove(doacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
