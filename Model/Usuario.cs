using AT.Ultis.Validacao;

namespace AT.Model
{
    public class Usuario
    {
        public string nome { get; set; } = string.Empty;
        public int idade { get; set; }
        public string cpf { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;

        public void Validacao()
        {
            string nomeValidado = DadosPessoais.ValidarNome(nome);
            string emailValidado = DadosPessoais.ValidarEmail(email);
            string cpfValidado = DadosPessoais.ValidarCPF(cpf);
        }



    }
}
