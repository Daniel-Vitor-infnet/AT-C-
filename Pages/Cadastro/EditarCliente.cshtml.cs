using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT.Model;
using Microsoft.EntityFrameworkCore;

namespace AT.Pages.Cadastro
{
    public class EditarClienteModel : PageModel
    {
        private readonly LibraryContext _context;

        public EditarClienteModel(LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreateCliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            Cliente = await _context.Cliente.FindAsync(id);
            if (Cliente == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var clienteExistente = await _context.Cliente.FindAsync(Cliente.ClienteID);
            if (clienteExistente == null)
                return NotFound();

            Cliente.Validacao(ModelState);

            if (!ModelState.IsValid)
                return Page();

            clienteExistente.Nome = Cliente.Nome;
            clienteExistente.Idade = Cliente.Idade;
            clienteExistente.Cpf = Cliente.Cpf;
            clienteExistente.Email = Cliente.Email;
            clienteExistente.Senha = Cliente.Senha;

            await _context.SaveChangesAsync();

            return RedirectToPage("/Cadastro/VerCadastros");
        }
    }
}
