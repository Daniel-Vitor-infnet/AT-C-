using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT.Model;
using AT.Ultis.Validacao;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public string Mensagem { get; set; }

        public async Task OnPostAsync()
        {
            // Validações dos dados
            if (!DadosPessoais.ValidarNome(Cliente.Nome, out string nomeFormatado))
                ModelState.AddModelError("Cliente.Nome", nomeFormatado);
            else
                Cliente.Nome = nomeFormatado;

            if (!DadosPessoais.ValidarEmail(Cliente.Email, out string emailFormatado))
                ModelState.AddModelError("Cliente.Email", emailFormatado);
            else
                Cliente.Email = emailFormatado;

            if (!DadosPessoais.ValidarCPF(Cliente.Cpf, out string cpfFormatado))
                ModelState.AddModelError("Cliente.Cpf", cpfFormatado);
            else
                Cliente.Cpf = cpfFormatado;

            if (!ModelState.IsValid)
            {
                Mensagem = "Erro na validação dos dados.";
                return;
            }

            _context.Add(Cliente);
            await _context.SaveChangesAsync(); // Salva as alterações no banco de forma assíncrona

            Mensagem = "Usuário cadastrado com sucesso!";
        }
    }
}
