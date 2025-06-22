namespace AT.Ultis
{
    public delegate decimal CalculateDelegate(decimal valorOriginal);

    public static class Desconto
    {
        public static decimal AplicarDesconto10(decimal valorOriginal)
        {
            return valorOriginal * 0.9m;
        }
    }
}
