using AT.Ultis;
using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreateReservas
    {
        [Key]
        public string ReservaID { get; set; } = Guid.NewGuid().ToString();

        public string ClienteID { get; set; }
        public CreateCliente Cliente { get; set; }
        public string PacoteTuriscoID { get; set; }

        public CreatePacotesTurisco PacotesTurisco { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public DateTime DataReserva { get; set; }

    }
}
