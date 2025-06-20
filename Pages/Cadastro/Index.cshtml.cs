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
            if (!DadosPessoais.ValidarNome(Cliente.nome, out string nomeFormatado))
                ModelState.AddModelError("Cliente.nome", nomeFormatado);
            else
                Cliente.nome = nomeFormatado;

            if (!DadosPessoais.ValidarEmail(Cliente.email, out string emailFormatado))
                ModelState.AddModelError("Cliente.email", emailFormatado);
            else
                Cliente.email = emailFormatado;

            if (!DadosPessoais.ValidarCPF(Cliente.cpf, out string cpfFormatado))
                ModelState.AddModelError("Cliente.cpf", cpfFormatado);
            else
                Cliente.cpf = cpfFormatado;

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
