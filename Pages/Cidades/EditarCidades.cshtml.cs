using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT.Model;
using Microsoft.EntityFrameworkCore;

namespace AT.Pages.Cidades
{
    public class EditarCidadesModel : PageModel
    {
        private readonly LibraryContext _context;

        public EditarCidadesModel(LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreateCidade Cidade { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            Cidade = await _context.Cidades.FindAsync(id);
            if (Cidade == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var cidadeExistente = await _context.Cidades.FindAsync(Cidade.CidadeID);
            if (cidadeExistente == null)
                return NotFound();

            cidadeExistente.Nome = Cidade.Nome;
            cidadeExistente.Descricao = Cidade.Descricao;
            cidadeExistente.NumHabitantes = Cidade.NumHabitantes;

            await _context.SaveChangesAsync();

            return RedirectToPage("/Cidades/VerCidades");
        }
    }
}
