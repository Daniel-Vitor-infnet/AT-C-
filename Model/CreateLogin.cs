using AT.Ultis;
using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreateLogin
    {


        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Senha { get; set; } = string.Empty;

    }
}
