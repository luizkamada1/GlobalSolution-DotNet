using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.Doacoes
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doacao Doacao { get; set; } = new Doacao();

        public void OnGet()
        {
            Doacao.Data = DateTime.Today;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Doacoes.Add(Doacao);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

