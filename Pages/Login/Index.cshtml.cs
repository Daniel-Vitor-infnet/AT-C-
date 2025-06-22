using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT.Model;

namespace AT.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly LibraryContext _context;

        public IndexModel(LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreateLogin Login { get; set; }

        public string Mensagem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var usuario = _context.Clientes
                .FirstOrDefault(u => u.Nome == Login.Nome && u.Senha == Login.Senha);

            if (usuario == null)
            {
                Mensagem = "Nome ou senha inválidos.";
                return Page();
            }

            Mensagem = "Login realizado com sucesso!";
            return Page();
        }
    }
}
