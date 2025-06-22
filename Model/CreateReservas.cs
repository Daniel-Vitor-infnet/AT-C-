using AT.Ultis;
using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreateReservas
    {
        [Key]
        public string ReservaID { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public DateTime DataFim {  get; set; } // Essa data significa quantos dias a pessoa vai ficar (diaria)

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public decimal PrecoTotal { get; set; } // Preço Baseado nas diarias


        public string? ClienteId { get; set; }
        public CreateCliente? Cliente { get; set; }
        public string? PacoteTuristicoId { get; set; }
        public CreatePacotesTurisco? PacoteTuristico { get; set; }
    }
}
