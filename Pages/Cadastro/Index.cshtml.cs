using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT.Model;

namespace AT.Pages.Cadastro
{
    public class IndexModel : PageModel
    {
        private readonly LibraryContext _context;

        public IndexModel(LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreateCliente Cliente { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Cliente.Validacao(ModelState);

            if (!ModelState.IsValid)
                return Page();

            Cliente.ClienteID = Guid.NewGuid().ToString();
            _context.Add(Cliente);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
