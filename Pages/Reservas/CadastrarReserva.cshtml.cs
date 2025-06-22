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

        // Minha ideia inicial era fazer uma lógica de login via localStorage, porém nem precisava e era pra ter feito o 
        private const string FixedClientId = "4d831d57-5848-4bc0-bb21-60ebb4cbeffc";

        public CadastrarReservaModel(LibraryContext context)
            => _context = context;

        [BindProperty]
        public CreateReservas Reserva { get; set; } = new();

        public CreatePacotesTurisco Pacote { get; set; } = null!;

        public decimal DiariaComDesconto { get; set; }

        public bool MostrarTotal { get; set; } = false;

        public int DiasCalculados { get; set; }
        public decimal TotalCalculado { get; set; }

        public async Task<IActionResult> OnGetAsync(string pacoteId)
        {
            if (string.IsNullOrEmpty(pacoteId))
                return BadRequest();

            // carrega pacote para exibir nome, país e cidade
            Pacote = await _context.PacotesTuristicos
                .Include(p => p.PaisDestino)
                .Include(p => p.Cidade)
                .FirstOrDefaultAsync(p => p.PacoteTuriscoID == pacoteId)
                ?? throw new InvalidOperationException("Pacote não encontrado");

            // aplica o delegate de desconto
            CalculateDelegate calc = Desconto.AplicarDesconto10;
            DiariaComDesconto = calc(Pacote.Preco);

            // pré-preenche reserva
            Reserva = new CreateReservas
            {
                PacoteTuristicoId = pacoteId,
                ClienteId = FixedClientId,
                DataInicio = Pacote.DataDaViagem,
                Total = 0m
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string action)
        {
            Pacote = await _context.PacotesTuristicos
                .Include(p => p.PaisDestino)
                .Include(p => p.Cidade)
                .FirstOrDefaultAsync(p => p.PacoteTuriscoID == Reserva.PacoteTuristicoId)
                ?? throw new InvalidOperationException("Pacote não encontrado");

            // aplica desconto
            CalculateDelegate calc = Desconto.AplicarDesconto10;
            DiariaComDesconto = calc(Pacote.Preco);

            if (action == "calcular")
            {
                ModelState.ClearValidationState(nameof(Reserva.DataFim));
                ModelState.ClearValidationState(nameof(Reserva.Total));

                // calcula dias e total
                DiasCalculados = (Reserva.DataFim.Date - Reserva.DataInicio.Date).Days;
                if (DiasCalculados < 1)
                {
                    ModelState.AddModelError(nameof(Reserva.DataFim), "A data final deve ser após a data de início.");
                }
                else
                {
                    TotalCalculado = DiasCalculados * DiariaComDesconto;
                    Reserva.Total = TotalCalculado;
                    MostrarTotal = true;
                }

                return Page();
            }

            if (action == "confirmar")
            {
                if (!ModelState.IsValid)
                {
                    MostrarTotal = Reserva.Total > 0;
                    return Page();
                }

                var dias = (Reserva.DataFim.Date - Reserva.DataInicio.Date).Days;
                Reserva.Total = dias * DiariaComDesconto;
                Reserva.ReservaID = Guid.NewGuid().ToString();
                Reserva.ClienteId = FixedClientId;

                _context.Reservas.Add(Reserva);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Reservas/VerReservas");
            }

            return Page();
        }
    }
}
