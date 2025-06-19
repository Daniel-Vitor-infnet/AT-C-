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
            // Inicializa��o se necess�rio
        }

        public void OnPost()
        {

            Usuario.Validacao(); // se esse m�todo existir

            // S� uma simula��o de retorno
            Mensagem = "Usu�rio cadastrado com sucesso!";
        }
    }
}
