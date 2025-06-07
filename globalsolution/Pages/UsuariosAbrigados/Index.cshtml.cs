using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.UsuariosAbrigados
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<UsuarioAbrigado> Registros { get; set; } = new List<UsuarioAbrigado>();

        public async Task OnGetAsync()
        {
            Registros = await _context.UsuariosAbrigados.ToListAsync();
        }
    }
}
