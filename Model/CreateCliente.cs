using AT.Ultis;
using AT.Ultis.Validacao;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreateCliente
    {
        [Key]
        public string ClienteID { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        [Range(18, 120, ErrorMessage = "Idade deve estar entre 18 e 120 anos")]
        public int Idade { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Email { get; set; } = string.Empty;


        public List<CreateReservas> Reservas { get; set; } = new();


        public void Validacao(ModelStateDictionary modelState)
        {
            if (!DadosPessoais.ValidarNome(Nome, out string nomeFormatado))
                modelState.AddModelError("Cliente.Nome", nomeFormatado);
            else
                Nome = nomeFormatado;

            if (!DadosPessoais.ValidarSenha(Senha, out string senhaFormatado))
                modelState.AddModelError("Cliente.Senha", senhaFormatado);
            else
                Senha = senhaFormatado;

            if (!DadosPessoais.ValidarEmail(Email, out string emailFormatado))
                modelState.AddModelError("Cliente.Email", emailFormatado);
            else
                Email = emailFormatado;

            if (!DadosPessoais.ValidarCPF(Cpf, out string cpfFormatado))
                modelState.AddModelError("Cliente.Cpf", cpfFormatado);
            else
                Cpf = cpfFormatado;
        }
    }
}
