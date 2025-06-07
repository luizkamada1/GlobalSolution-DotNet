using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.PedidosAjuda
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PedidoAjuda Pedido { get; set; } = new PedidoAjuda();

        public void OnGet()
        {
            Pedido.DataHora = DateTime.Now;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.PedidosAjuda.Add(Pedido);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
