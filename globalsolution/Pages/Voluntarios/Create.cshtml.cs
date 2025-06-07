using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.Voluntarios
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Voluntario Voluntario { get; set; } = new Voluntario();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Voluntarios.Add(Voluntario);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
