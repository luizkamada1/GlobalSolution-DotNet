using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.Voluntarios
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Voluntario> Voluntarios { get; set; } = new List<Voluntario>();

        public async Task OnGetAsync()
        {
            Voluntarios = await _context.Voluntarios.ToListAsync();
        }
    }
}
