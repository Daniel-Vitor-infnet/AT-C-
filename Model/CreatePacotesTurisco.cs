using AT.Ultis;
using AT.Ultis.Validacao;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreatePacotesTurisco
    {
        [Key]
        public string PacoteTuriscoID { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string NomeDoPacote { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public DateTime DataDaViagem { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public int CapacidadeMax { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string PaisDestinoId { get; set; } = string.Empty;

        [ValidateNever]
        public CreatePaisDestino? PaisDestino { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string CidadeId { get; set; } = string.Empty;

        [ValidateNever]
        public CreateCidade? Cidade { get; set; }

        public List<CreateReservas> Reservas { get; set; } = new();
    }
}
