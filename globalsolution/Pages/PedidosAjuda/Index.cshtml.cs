using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.PedidosAjuda
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<PedidoAjuda> Pedidos { get; set; } = new List<PedidoAjuda>();

        public async Task OnGetAsync()
        {
            Pedidos = await _context.PedidosAjuda.ToListAsync();
        }
    }
}
