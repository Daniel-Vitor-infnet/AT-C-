using AT.Ultis;
using AT.Ultis.Validacao;
using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreateCliente
    {
        public string id = Guid.NewGuid().ToString();

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string nome { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        [Range(18, 120, ErrorMessage = "Idade deve estar entre 18 e 120 anos")]
        public int idade { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string email { get; set; } = string.Empty;

        public void Validacao()
        {
            bool nomeValidado = DadosPessoais.ValidarNome(nome, out string nomeFormatado);
            string teste = nomeFormatado;
            bool emailValidado = DadosPessoais.ValidarEmail(email, out string emailFormatado);
            string teste2 = emailFormatado;
            bool cpfValidado = DadosPessoais.ValidarCPF(cpf, out string cpfFormatado);
            string teste3 = cpfFormatado;
        } 


    }
}
