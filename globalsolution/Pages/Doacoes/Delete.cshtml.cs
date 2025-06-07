using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.Doacoes
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doacao Doacao { get; set; } = new Doacao();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Doacao = await _context.Doacoes.FindAsync(id);

            if (Doacao == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var registro = await _context.Doacoes.FindAsync(Doacao.Id);

            if (registro != null)
            {
                _context.Doacoes.Remove(registro);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
