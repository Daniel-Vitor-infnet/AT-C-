using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AT.Model;

namespace AT.Pages.Cidades
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

        public async Task<IActionResult> OnPostExcluirAsync(string id)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade != null)
            {
                _context.Cidades.Remove(cidade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(); // Recarrega a própria página
        }
    }
}
