using AT.Ultis;
using AT.Ultis.Validacao;
using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreateCliente
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        [Range(18, 120, ErrorMessage = "Idade deve estar entre 18 e 120 anos")]
        public int Idade { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Email { get; set; } = string.Empty;

        public void Validacao()
        {
            bool nomeValidado = DadosPessoais.ValidarNome(Nome, out string nomeFormatado);
            bool emailValidado = DadosPessoais.ValidarEmail(Email, out string emailFormatado);
            bool cpfValidado = DadosPessoais.ValidarCPF(Cpf, out string cpfFormatado);
        }
    }
}
