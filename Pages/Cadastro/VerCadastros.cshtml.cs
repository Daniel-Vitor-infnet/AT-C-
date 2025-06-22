using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT.Model;
using Microsoft.EntityFrameworkCore;

namespace AT.Pages.Cadastro
{
    public class Index1Model : PageModel
    {
        private readonly LibraryContext _context;

        public Index1Model(LibraryContext context)
        {
            _context = context;
        }


        public List<CreateCliente>? Clientes { get; set; }


        public async Task OnGetAsync()
        {
            Clientes = await _context
                .Cliente
                .AsNoTracking() //Caso for apenas para exibir dados sem nenhuma outra função
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostExcluirAsync(string id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(); // recarrega a própria página
        }

    }
}
