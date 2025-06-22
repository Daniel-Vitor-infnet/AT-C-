using AT.Ultis;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreateReservas
    {
        [Key]
        public string ReservaID { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]

        public string PacoteTuristicoId { get; set; }
        [ValidateNever]
        public CreatePacotesTurisco? PacoteTuristico { get; set; } = null!;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]

        public string ClienteId { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public decimal Total { get; set; }
    }
}
