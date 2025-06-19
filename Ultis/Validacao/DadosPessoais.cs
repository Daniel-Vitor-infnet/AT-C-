namespace AT.Ultis.Validacao
{
    public static class DadosPessoais
    {

        //Obs: //Como a class "não pode" retornar dois tipos diferentes vai string mesmo o "false"
        // Alguns nem vou colocar comentario pq é auto explicativo o nome

        
        public static string ValidarID(string id)
        {
            int idContador = id.ToString().Length;
            //Verifica se o id tem pelo menos 36 números
            if (idContador != 36)
            {
                return "false ID";
            }
            else
            {
                return id;
            }

        }

        public static string ValidarNome(string nome)
        {
            // Formatar e converter para array de string
            var nomes = nome.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (nome.Length < 2) return "false Nome";

            // Faça toda formatação necessaaria pra saida
            var nomesSaida = string.Join(" ", nomes.Select(n => char.ToUpper(n[0]) + n.Substring(1)));

            return nomesSaida;

        }


        public static string ValidarEmail(string email)
        {
            string emailFalse = "Esse email não é valido verifique";

            //Verificar sem contem @ e .
            if (!email.Contains('@') || !email.Contains('.')) return emailFalse;

            //Verificar se tem algo depois do @
            var partes = email.Split('@');
            if (partes.Length != 2) return emailFalse;

            //Verificar se tem algum espaçamento
            if (string.IsNullOrWhiteSpace(partes[0]) || string.IsNullOrWhiteSpace(partes[1])) return emailFalse;


            return email;
        }


        public static string ValidarCPF(string cpf)
        {
            string numeros = new string(cpf.Where(char.IsDigit).ToArray());

            //Verifica se o cpf tem 11 digitos.
            if (numeros.Length == 11)
            {
                return cpf;
            }
            else
            {
                return "false Cpf";
            }

        }






    }
}