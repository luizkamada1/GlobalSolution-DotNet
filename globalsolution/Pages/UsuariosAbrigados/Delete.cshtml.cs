using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.UsuariosAbrigados
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UsuarioAbrigado Registro { get; set; } = new UsuarioAbrigado();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Registro = await _context.UsuariosAbrigados.FindAsync(id);

            if (Registro == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var registro = await _context.UsuariosAbrigados.FindAsync(Registro.Id);

            if (registro != null)
            {
                _context.UsuariosAbrigados.Remove(registro);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}

