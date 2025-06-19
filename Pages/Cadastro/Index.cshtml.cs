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

        public void OnGet()
        {
            // Inicialização se necessário
        }

        public void OnPost()
        {

            Usuario.Validacao(); // se esse método existir

            // Só uma simulação de retorno
            Mensagem = "Usuário cadastrado com sucesso!";
        }
    }
}
