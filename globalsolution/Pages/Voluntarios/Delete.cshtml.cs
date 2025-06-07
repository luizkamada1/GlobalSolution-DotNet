using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.Voluntarios
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Voluntario Voluntario { get; set; } = new Voluntario();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Voluntario = await _context.Voluntarios.FindAsync(id);

            if (Voluntario == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var voluntario = await _context.Voluntarios.FindAsync(Voluntario.Id);

            if (voluntario != null)
            {
                _context.Voluntarios.Remove(voluntario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
