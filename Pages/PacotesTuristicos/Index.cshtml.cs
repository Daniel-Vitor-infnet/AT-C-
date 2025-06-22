using AT.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT.Pages.PacotesTuristicos
{
    public class IndexModel : PageModel
    {
        private readonly LibraryContext _context;
        public IndexModel(LibraryContext context)
            => _context = context;

        [BindProperty]
        public CreatePacotesTurisco Pacote { get; set; } = new();

        public SelectList Paises { get; set; }
        public SelectList Cidades { get; set; }

        public async Task OnGetAsync()
        {
            var paises = await _context.PaisDestinos
                              .Select(p => new { p.PaisDestinoID, p.Pais })
                              .ToListAsync();
            Paises = new SelectList(paises, "PaisDestinoID", "Pais");

            Cidades = new SelectList(new List<object>(), "CidadeID", "Nome");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            Pacote.PacoteTuriscoID = System.Guid.NewGuid().ToString();
            _context.PacotesTuristicos.Add(Pacote);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<JsonResult> OnGetCidades(string paisDestinoId)
        {
            var lista = await _context.Cidades
                .Where(c => c.PaisDestinoId == paisDestinoId)
                .Select(c => new { cidadeID = c.CidadeID, nome = c.Nome })
                .ToListAsync();

            return new JsonResult(lista);
        }
    }
}
