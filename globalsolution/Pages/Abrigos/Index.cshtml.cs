using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.Abrigos
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Abrigo> Abrigos { get; set; } = new List<Abrigo>();

        public async Task OnGetAsync()
        {
            Abrigos = await _context.Abrigos.ToListAsync();
        }
    }
}
