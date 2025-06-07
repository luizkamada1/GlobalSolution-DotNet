using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.PedidosAjuda
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PedidoAjuda Pedido { get; set; } = new PedidoAjuda();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Pedido = await _context.PedidosAjuda.FindAsync(id);

            if (Pedido == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var pedido = await _context.PedidosAjuda.FindAsync(Pedido.Id);

            if (pedido != null)
            {
                _context.PedidosAjuda.Remove(pedido);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
