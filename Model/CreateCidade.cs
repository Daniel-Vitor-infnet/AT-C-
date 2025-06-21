using AT.Ultis;
using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreateCidade
    {
        // Como tem diversos cidades n tem muito oq verificação extensa vai ser no banco de dados para n repetir as cidades.
        [Key]
        public string CidadeID { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        [MinLength(3, ErrorMessage = "O nome da cidade deve ter no mínimo 3 letras.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        [Range(2001, int.MaxValue, ErrorMessage = "A cidade deve ter no minimo 2000 habitantes.")]
        public int NumHabitantes { get; set; }
    }
}
