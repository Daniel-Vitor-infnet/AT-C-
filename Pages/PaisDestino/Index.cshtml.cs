using AT.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT.Pages.PaisDestino
{
    public class IndexModel : PageModel
    {
        private readonly LibraryContext _context;

        public IndexModel(LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreatePaisDestino PaisDestino { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            PaisDestino.PaisDestinoID = Guid.NewGuid().ToString(); 
            _context.PaisDestinos.Add(PaisDestino);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
