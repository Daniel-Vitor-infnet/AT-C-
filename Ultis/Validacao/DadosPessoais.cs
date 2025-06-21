namespace AT.Ultis.Validacao
{
    public static class DadosPessoais
    {

        //Obs: //Como a class "não pode" retornar dois tipos diferentes vai string mesmo o "false"
        // Alguns nem vou colocar comentario pq é auto explicativo o nome




        public static bool ValidarNome(string nome, out string nomeFormatado)
        {
            nomeFormatado = string.Empty;


            // Formatar e converter para array de string
            var nomes = nome.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (nome.Length < 2)
            {
                nomeFormatado = "Esse nome é invalido";
                return false;
            }

            // Faça toda formatação necessaaria pra saida
            var nomesSaida = string.Join(" ", nomes.Select(n => char.ToUpper(n[0]) + n.Substring(1)));

            nomeFormatado = nomesSaida;
            return true;

        }

        public static bool ValidarSenha(string senha, out string senhaFormatado)
        {
            senhaFormatado = string.Empty;


            //Verificar tamanho minimo
            if (senha.Length < 8)
            {
                senhaFormatado = "Senha deve contar no minímo 8 digitos";
                return false;
            }

            // Verifica se tem pelo menos um caractere especial.
            if (!senha.Any(s => "@%$#@!%¨&&*".Contains(s)))
            {
                senhaFormatado = "Senha deve contar pelo menos um caractere especial";
                return false;
            }

            // Verifica se tem pelo menos 2 números
            int quantidadeNumeros = senha.Count(char.IsDigit);
            if (quantidadeNumeros < 2)
            {
                senhaFormatado = "Senha deve conter pelo menos 2 números";
                return false;
            }

            senhaFormatado = senha;
            return true;

        }


        //Sei que o próprio razor tem validação, porém n sei como funciona direito e n tinha tempo de tentar entender
        public static bool ValidarEmail(string email, out string emailFormatado)
        {
            emailFormatado = string.Empty;
            string emailFalse = "Esse email não é valido verifique";

            //Verificar sem contem @ e .
            if (!email.Contains('@') || !email.Contains('.'))
            {
                emailFormatado = emailFalse;
                return false;
            }


            //Verificar se tem algo depois do @
            var partes = email.Split('@');
            if (partes.Length != 2)
            {
                emailFormatado = emailFalse;
                return false;
            }

            //Verificar se tem algum espaçamento
            if (string.IsNullOrWhiteSpace(partes[0]) || string.IsNullOrWhiteSpace(partes[1]))
            {
                emailFormatado = emailFalse;
                return false;
            }

            emailFormatado = email;
            return true;
        }


        public static bool ValidarCPF(string cpf, out string cpfFormatado)
        {
            cpfFormatado = string.Empty;
            string numeros = new string(cpf.Where(char.IsDigit).ToArray());

            //Verifica se o cpf tem 11 digitos.
            if (numeros.Length == 11)
            {
                cpfFormatado = cpf;
                return true;
            }
            else
            {
                cpfFormatado = "Esse cpf é invalido";
                return false;
            }
        }

    }
}
