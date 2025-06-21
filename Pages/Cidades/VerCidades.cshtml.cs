using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AT.Model;

namespace AT.Pages.Cidade
{
    public class VerCidadesModel : PageModel
    {
        private readonly LibraryContext _context;

        public VerCidadesModel(LibraryContext context)
        {
            _context = context;
        }

        public List<CreateCidade>? Cidades { get; set; }

        public async Task OnGetAsync()
        {
            Cidades = await _context
                .Cidades
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
