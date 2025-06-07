using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuarios { get; set; }

        public async Task OnGetAsync()
        {
            Usuarios = await _context.Usuarios.ToListAsync();
        }
    }
}
