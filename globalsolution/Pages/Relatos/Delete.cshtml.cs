using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.Relatos
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Relato Relato { get; set; } = new Relato();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Relato = await _context.Relatos.FindAsync(id);

            if (Relato == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var relato = await _context.Relatos.FindAsync(Relato.Id);

            if (relato != null)
            {
                _context.Relatos.Remove(relato);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
