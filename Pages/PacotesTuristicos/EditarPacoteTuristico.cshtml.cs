using AT.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace AT.Pages.PacotesTuristicos
{
    public class EditarPacoteTuristicoModel : PageModel
    {
        private readonly LibraryContext _context;
        public EditarPacoteTuristicoModel(LibraryContext context)
            => _context = context;

        [BindProperty]
        public CreatePacotesTurisco Pacote { get; set; } = new();

        [BindProperty]
        public string SelectedPaisId { get; set; }

        [BindProperty]
        public string SelectedCidadeId { get; set; }

        public SelectList Paises { get; set; }
        public SelectList Cidades { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Pacote = await _context.PacotesTuristicos
                .Include(pt => pt.PaisDestino)
                .Include(pt => pt.Cidade)       
                .FirstOrDefaultAsync(pt => pt.PacoteTuriscoID == id);

            if (Pacote == null) return NotFound();

            SelectedPaisId = Pacote.PaisDestinoId;
            SelectedCidadeId = Pacote.CidadeId;

            await LoadPaisesAsync();
            await LoadCidadesAsync(SelectedPaisId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadPaisesAsync();
                await LoadCidadesAsync(SelectedPaisId);
                return Page();
            }

            Pacote.PaisDestinoId = SelectedPaisId;
            Pacote.CidadeId = SelectedCidadeId;

            _context.Attach(Pacote).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        private async Task LoadPaisesAsync()
        {
            var lista = await _context.PaisDestinos
                .Select(p => new { p.PaisDestinoID, p.Pais })
                .ToListAsync();
            Paises = new SelectList(lista, "PaisDestinoID", "Pais");
        }

        private async Task LoadCidadesAsync(string paisId)
        {
            var lista = await _context.Cidades
                .Where(c => c.PaisDestinoId == paisId)
                .Select(c => new { c.CidadeID, c.Nome })
                .ToListAsync();
            Cidades = new SelectList(lista, "CidadeID", "Nome");
        }
    }
}
