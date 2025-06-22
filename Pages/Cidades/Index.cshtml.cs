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
    public class IndexModel : PageModel
    {
        private readonly LibraryContext _context;

        public IndexModel(LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreateCidade Cidade { get; set; }

        public string Mensagem { get; set; } = string.Empty;

        public List<SelectListItem> PaisesList { get; set; }

        public async Task OnGetAsync()
        {
            PaisesList = (await _context.PaisDestinos.ToListAsync())
                .Select(p => new SelectListItem
                {
                    Text = p.Pais,
                    Value = p.PaisDestinoID
                })
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PaisesList = (await _context.PaisDestinos.ToListAsync())
                    .Select(p => new SelectListItem
                    {
                        Text = p.Pais,
                        Value = p.PaisDestinoID
                    })
                    .ToList();

                Mensagem = "Erro: Verifique os dados preenchidos.";
                return Page();
            }

            Cidade.CidadeID = Guid.NewGuid().ToString();
            _context.Cidades.Add(Cidade);
            await _context.SaveChangesAsync();

            Mensagem = "Cidade cadastrada com sucesso!";
            return Page();
        }
    }
}
