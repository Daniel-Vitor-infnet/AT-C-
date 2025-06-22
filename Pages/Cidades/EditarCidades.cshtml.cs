using AT.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT.Pages.Cidades
{
    public class EditarCidadesModel : PageModel
    {
        private readonly LibraryContext _context;
        public EditarCidadesModel(LibraryContext context) => _context = context;

        [BindProperty]
        public CreateCidade Cidade { get; set; }

        public List<SelectListItem> PaisesList { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            // carrega dropdown de países
            PaisesList = (await _context.PaisDestinos.ToListAsync())
                .Select(p => new SelectListItem
                {
                    Text = p.Pais,
                    Value = p.PaisDestinoID
                })
                .ToList();

            Cidade = await _context.Cidades.FindAsync(id);
            if (Cidade == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // repopula em caso de falha
                PaisesList = (await _context.PaisDestinos.ToListAsync())
                    .Select(p => new SelectListItem
                    {
                        Text = p.Pais,
                        Value = p.PaisDestinoID
                    })
                    .ToList();
                return Page();
            }

            var existing = await _context.Cidades.FindAsync(Cidade.CidadeID);
            if (existing == null) return NotFound();

            existing.Nome = Cidade.Nome;
            existing.Descricao = Cidade.Descricao;
            existing.NumHabitantes = Cidade.NumHabitantes;
            existing.PaisDestinoId = Cidade.PaisDestinoId;

            await _context.SaveChangesAsync();
            return RedirectToPage("/Cidades/VerCidades");
        }
    }
}
