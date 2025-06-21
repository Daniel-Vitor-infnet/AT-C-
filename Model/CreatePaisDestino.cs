using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreatePaisDestino
    {
        [Key]
        public string PaisDestinoID { get; set; } = Guid.NewGuid().ToString();

        public string Pais { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string ClienteID {  get; set; }
        public CreateCliente Cliente { get; set; }

    }
}
