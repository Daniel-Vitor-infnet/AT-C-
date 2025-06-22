using AT.Ultis;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AT.Model
{
    public class CreateCidade
    {
        [Key]
        public string CidadeID { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string Descricao { get; set; } = string.Empty;

        [Range(1000, long.MaxValue, ErrorMessage = "Número de habitantes deve ser no mínimo 1000")]
        public int NumHabitantes { get; set; }

        [Required(ErrorMessage = MsgPerson.CAMPO_OBRIGATORIO)]
        public string PaisDestinoId { get; set; } = string.Empty;

        [ValidateNever]
        public CreatePaisDestino? PaisDestino { get; set; }

        public List<CreatePacotesTurisco> PacotesTuristicos { get; set; } = new();
    }
}
