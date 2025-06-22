using AT.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AT.Pages.Reservas
{
    public class VerReservasModel : PageModel
    {
        private readonly LibraryContext _context;

        public VerReservasModel(LibraryContext context)
            => _context = context;

        public List<CreatePacotesTurisco> PacotesDisponiveis { get; set; } = new();

        public async Task OnGetAsync()
        {
            PacotesDisponiveis = await _context.PacotesTuristicos
                .Include(p => p.PaisDestino)
                .Include(p => p.Cidade)
                .ToListAsync();
        }
    }
}
