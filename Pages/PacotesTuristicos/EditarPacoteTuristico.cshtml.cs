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
    public class EditarPacoteTuristicoModel : PageModel
    {
        private readonly LibraryContext _context;
        public EditarPacoteTuristicoModel(LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreatePacotesTurisco Pacote { get; set; }

        public SelectList Paises { get; set; }

        [BindProperty]
        public string SelectedCidadeId { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            Pacote = await _context.PacotesTuristicos
                .Include(p => p.Cidades)
                .FirstOrDefaultAsync(p => p.PacoteTuriscoID == id); // 

            if (Pacote == null)
                return NotFound();

            await LoadPaisesAsync();
            SelectedCidadeId = Pacote.Cidades.FirstOrDefault()?.CidadeID;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadPaisesAsync();
                return Page();
            }

            var existente = await _context.PacotesTuristicos
                .Include(p => p.Cidades)
                .FirstOrDefaultAsync(p => p.PacoteTuriscoID == Pacote.PacoteTuriscoID);

            if (existente == null)
                return NotFound();

            existente.NomeDoPacote = Pacote.NomeDoPacote;
            existente.DataDaViagem = Pacote.DataDaViagem;
            existente.CapacidadeMax = Pacote.CapacidadeMax;
            existente.Preco = Pacote.Preco;
            existente.PaisDestinoId = Pacote.PaisDestinoId;

            existente.Cidades.Clear();
            if (!string.IsNullOrEmpty(SelectedCidadeId))
            {
                var cidade = await _context.Cidades.FindAsync(SelectedCidadeId);
                if (cidade != null)
                    existente.Cidades.Add(cidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/PacotesTuristicos/VerPacotes");
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
