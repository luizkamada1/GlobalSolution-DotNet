using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.Relatos
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Relato> Relatos { get; set; } = new List<Relato>();

        public async Task OnGetAsync()
        {
            Relatos = await _context.Relatos
                .Include(r => r.Usuario)
                .ToListAsync();
        }
    }
}
