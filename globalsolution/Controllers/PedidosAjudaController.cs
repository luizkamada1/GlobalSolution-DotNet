using globalsolution.Data;
using globalsolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace globalsolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosAjudaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidosAjudaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PedidosAjuda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoAjuda>>> GetPedidosAjuda()
        {
            return await _context.PedidosAjuda
                .Include(p => p.Usuario)
                .ToListAsync();
        }

        // GET: api/PedidosAjuda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoAjuda>> GetPedidoAjuda(int id)
        {
            var pedido = await _context.PedidosAjuda
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
                return NotFound();

            return pedido;
        }

        // POST: api/PedidosAjuda
        [HttpPost]
        public async Task<ActionResult<PedidoAjuda>> PostPedidoAjuda(PedidoAjuda pedido)
        {
            _context.PedidosAjuda.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedidoAjuda), new { id = pedido.Id }, pedido);
        }

        // PUT: api/PedidosAjuda/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoAjuda(int id, PedidoAjuda pedido)
        {
            if (id != pedido.Id)
                return BadRequest();

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PedidosAjuda.Any(p => p.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/PedidosAjuda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoAjuda(int id)
        {
            var pedido = await _context.PedidosAjuda.FindAsync(id);
            if (pedido == null)
                return NotFound();

            _context.PedidosAjuda.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
