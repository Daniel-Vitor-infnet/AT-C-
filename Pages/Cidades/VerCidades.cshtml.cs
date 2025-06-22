using AT.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AT.Pages.Cidades
{
    public class VerCidadesModel : PageModel
    {
        private readonly LibraryContext _context;
        public VerCidadesModel(LibraryContext context) => _context = context;

        public IList<CreateCidade> Cidades { get; set; }

        public async Task OnGetAsync()
        {
            Cidades = await _context.Cidades
                .Include(c => c.PaisDestino)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
