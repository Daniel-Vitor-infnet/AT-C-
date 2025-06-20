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


        public List<CreateCliente> Clientes { get; set; }


        public async Task OnGetAsync()
        {

            Clientes = await _context
                .Cliente
                .ToListAsync();
        }
    }
}
