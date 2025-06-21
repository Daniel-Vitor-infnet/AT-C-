using AT.Ultis;
using AT.Ultis.Validacao;
using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreatePaisDestino
    {
        // Como tem diversos paises n tem muito oq verificação extensa vai ser no banco de dados para n repetir os paises.
        [Key]
        public string PaisDestinoID { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Pais { get; set; } = string.Empty;
        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Description { get; set; } = string.Empty;


    }
}
