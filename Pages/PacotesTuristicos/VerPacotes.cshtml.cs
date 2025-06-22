using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT.Model;
using Microsoft.EntityFrameworkCore;

namespace AT.Pages.PacotesTuristicos
{
    public class VerPacotesModel : PageModel
    {
        private readonly LibraryContext _context;
        public VerPacotesModel(LibraryContext context)
        {
            _context = context;
        }

        public List<CreatePacotesTurisco>? Pacotes { get; set; }

        public async Task OnGetAsync()
        {
            Pacotes = await _context.PacotesTuristicos
                .Include(p => p.PaisDestino)     
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostExcluirAsync(string id)
        {
            var pacote = await _context.PacotesTuristicos.FindAsync(id);
            if (pacote != null)
            {
                _context.PacotesTuristicos.Remove(pacote);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
