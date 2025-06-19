using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT.Model;
using AT.Ultis.Validacao;

namespace AT.Pages.Cadastro
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; }

        public string Mensagem { get; set; }


        public void OnPost()
        {
            if (!DadosPessoais.ValidarNome(Usuario.nome, out string nomeFormatado))
                ModelState.AddModelError("Usuario.nome", nomeFormatado);
            else
                Usuario.nome = nomeFormatado;

            if (!DadosPessoais.ValidarEmail(Usuario.email, out string emailFormatado))
                ModelState.AddModelError("Usuario.email", emailFormatado);
            else
                Usuario.email = emailFormatado;

            if (!DadosPessoais.ValidarCPF(Usuario.cpf, out string cpfFormatado))
                ModelState.AddModelError("Usuario.cpf", cpfFormatado);
            else
                Usuario.cpf = cpfFormatado;

            if (!ModelState.IsValid)
            {
                Mensagem = "Erro na validação dos dados.";
                return;
            }

            Mensagem = "Usuário cadastrado com sucesso!";
        }
    }
}
