namespace AT.Ultis.Validacao
{
    public static class IDUUID
    {
        public static bool ValidarID(string id, out string idFormatado)

        {
            idFormatado = string.Empty;

            int idContador = id.ToString().Length;
            //Verifica se o id tem pelo menos 36 números

            if (idContador != 36)
            {
                idFormatado = "Esse id é invalido";
                return false;
            }
            else
            {
                idFormatado = id;
                return true;
            }

        }
    }
}
