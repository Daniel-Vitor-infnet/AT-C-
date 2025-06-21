using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT.Model;

namespace AT.Pages.Cidade
{
    public class IndexModel : PageModel
    {
        private readonly LibraryContext _context;

        public IndexModel(LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreateCidade Cidade { get; set; }

        public string Mensagem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Mensagem = "Erro: Verifique os dados preenchidos.";
                return Page();
            }

            _context.Add(Cidade);
            await _context.SaveChangesAsync();

            Mensagem = "Cidade cadastrada com sucesso!";
            return Page();
        }
    }
}
