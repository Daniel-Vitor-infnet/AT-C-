using AT.Ultis;
using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreatePacotesTurisco
    {
        [Key]
        public string PacoteTuriscoID { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string NomeDoPacote { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public DateTime DataDaViagem { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public int CapacidadeMax { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public decimal Preco { get; set; }

        public string PaisDestinoId { get; set; }
        public CreatePaisDestino PaisDestino { get; set; }

        public List<CreateCidade> Cidades { get; set; } = new();

        public List<CreateReservas> Reservas { get; set; } = new();



    }
}
