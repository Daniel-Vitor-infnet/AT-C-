using AT.Model;
using AT.Ultis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AT.Pages.Reservas
{
    public class CadastrarReservaModel : PageModel
    {
        private readonly LibraryContext _context;
        private const string FixedClientId = "4d831d57-5848-4bc0-bb21-60ebb4cbeffc";

        public CadastrarReservaModel(LibraryContext context)
            => _context = context;

        [BindProperty]
        public CreateReservas Reserva { get; set; } = new();

        public CreatePacotesTurisco Pacote { get; set; } = null!;

        public decimal DiariaComDesconto { get; set; }

        public bool MostrarTotal { get; set; }

        public async Task<IActionResult> OnGetAsync(string pacoteId)
        {
            Pacote = await _context.PacotesTuristicos
                .Include(p => p.PaisDestino)
                .Include(p => p.Cidade)
                .FirstOrDefaultAsync(p => p.PacoteTuriscoID == pacoteId);

            if (Pacote == null)
                return NotFound();

            CalculateDelegate calc = Desconto.AplicarDesconto10;
            DiariaComDesconto = calc(Pacote.Preco);

            Reserva = new CreateReservas
            {
                PacoteTuristicoId = Pacote.PacoteTuriscoID,
                ClienteId = FixedClientId,
                DataInicio = Pacote.DataDaViagem,
                Total = 0m
            };

            MostrarTotal = false;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Pacote = await _context.PacotesTuristicos
                .Include(p => p.PaisDestino)
                .Include(p => p.Cidade)
                .FirstOrDefaultAsync(p => p.PacoteTuriscoID == Reserva.PacoteTuristicoId)!;

            CalculateDelegate calc = Desconto.AplicarDesconto10;
            DiariaComDesconto = calc(Pacote.Preco);

            if (!ModelState.IsValid)
            {
                MostrarTotal = false;
                return Page();
            }

            var dias = (Reserva.DataFim.Date - Reserva.DataInicio.Date).Days;
            if (dias < 1)
            {
                ModelState.AddModelError(nameof(Reserva.DataFim), "A data final deve ser após a data de início.");
                MostrarTotal = false;
                return Page();
            }

            Reserva.Total = dias * DiariaComDesconto;
            Reserva.ReservaID = Guid.NewGuid().ToString();
            Reserva.ClienteId = FixedClientId;

            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();

            MostrarTotal = true;
            return Page();
        }
    }
}
