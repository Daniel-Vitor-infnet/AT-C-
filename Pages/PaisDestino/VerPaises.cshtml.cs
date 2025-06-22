using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT.Model;
using Microsoft.EntityFrameworkCore;

namespace AT.Pages.PaisDestino
{
    public class Index1Model : PageModel
    {
        private readonly LibraryContext _context;

        public Index1Model(LibraryContext context)
        {
            _context = context;
        }

        public List<CreatePaisDestino>? PaisDestinos { get; set; }

        public async Task OnGetAsync()
        {
            PaisDestinos = await _context
                .PaisDestinos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostExcluirAsync(string id)
        {
            var pais = await _context.PaisDestinos.FindAsync(id);
            if (pais != null)
            {
                _context.PaisDestinos.Remove(pais);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(); // recarrega esta mesma página
        }
    }
}
