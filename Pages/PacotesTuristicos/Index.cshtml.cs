using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AT.Model;

namespace AT.Pages.PacotesTuristicos
{
    public class IndexModel : PageModel
    {
        private readonly LibraryContext _context;
        public IndexModel(LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreatePacotesTurisco Pacote { get; set; }

        [BindProperty]
        public string SelectedCidadeId { get; set; }

        public SelectList Paises { get; set; }

        public async Task OnGetAsync()
        {
            await LoadPaisesAsync();
        }

        public async Task<JsonResult> OnGetCidadesAsync(string paisDestinoId)
        {
            var cidades = await _context.Cidades
                .Where(c => c.PaisDestinoId == paisDestinoId)
                .Select(c => new { c.CidadeID, c.Nome })
                .ToListAsync();
            return new JsonResult(cidades);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadPaisesAsync();
                return Page();
            }

            Pacote.PacoteTuriscoID = Guid.NewGuid().ToString();

            if (!string.IsNullOrEmpty(SelectedCidadeId))
            {
                var cidade = await _context.Cidades.FindAsync(SelectedCidadeId);
                if (cidade != null)
                    Pacote.Cidades.Add(cidade);
            }

            _context.PacotesTuristicos.Add(Pacote);
            await _context.SaveChangesAsync();

            return Page();
        }

        private async Task LoadPaisesAsync()
        {
            var lista = await _context.PaisDestinos
                .Select(p => new { p.PaisDestinoID, p.Pais })
                .ToListAsync();
            Paises = new SelectList(lista, "PaisDestinoID", "Pais");
        }
    }
}
