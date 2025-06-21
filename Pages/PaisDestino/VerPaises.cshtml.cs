using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AT.Model;

namespace AT.Pages.PaisDestino
{
    public class VerPaisesModel : PageModel
    {
        private readonly LibraryContext _context;

        public VerPaisesModel(LibraryContext context)
        {
            _context = context;
        }

        public List<CreatePaisDestino>? Paises { get; set; }

        public async Task OnGetAsync()
        {
            Paises = await _context
                .PaisesDestino
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
