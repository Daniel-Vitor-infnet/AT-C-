using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT.Model;
using Microsoft.EntityFrameworkCore;

namespace AT.Pages.PaisDestino
{
    public class EditarPaisDestinoModel : PageModel
    {
        private readonly LibraryContext _context;

        public EditarPaisDestinoModel(LibraryContext context)
        {
            _context = context;
        }


        [BindProperty]
        public CreatePaisDestino PaisDestino { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            PaisDestino = await _context.PaisDestinos.FindAsync(id);
            if (PaisDestino == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var existente = await _context.PaisDestinos.FindAsync(PaisDestino.PaisDestinoID);
            if (existente == null)
                return NotFound();

            existente.Pais = PaisDestino.Pais;
            existente.Description = PaisDestino.Description;

            await _context.SaveChangesAsync();

            return RedirectToPage("/PaisDestino/VerPaises");
        }
    }
}
