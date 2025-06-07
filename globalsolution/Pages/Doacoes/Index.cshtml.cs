using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using globalsolution.Data;
using globalsolution.Models;

namespace globalsolution.Pages.Doacoes
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Doacao> ListaDoacoes { get; set; } = new List<Doacao>();

        public async Task OnGetAsync()
        {
            ListaDoacoes = await _context.Doacoes.ToListAsync();
        }
    }
}
