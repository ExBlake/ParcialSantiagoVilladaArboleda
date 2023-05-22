using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.Sockets;
using TicketSystem_WebAPI.DAL;
using TicketSystem_WebAPI.DAL.Entities;

namespace TicketSystem_WebAPI.Controllers
{
    public class TicketsController : Controller
    {
        private readonly DataBaseContext _context;

        public TicketsController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Tickets>>> GetTickets()
        {
            var categories = await _context.Tickets.ToListAsync();

            if (categories == null) return NotFound();

            return categories;
        }

        [HttpGet, ActionName("Get")]
        [Route("GeTicketsById/{Id}")]
        public async Task<ActionResult<Tickets>> GetTicketsById(Guid? Id)
        {
            var tricket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == Id);

            if (tricket == null) return NotFound();

            return Ok(tricket);
        }
        //Editar si la boleta existe
        //Editar si la boleta no a sido usada

        [HttpPut, ActionName("Edit")]
        [Route("EditTicket/{id}")]
        public async Task<ActionResult<Tickets>> EditTicket(Guid? id, String entranceGate)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);

            if (ticket.Id == id)
            {
                if (ticket.IsUsed == false)
                {
                    try
                    {
                        ticket.UseDate = DateTime.Now;
                        ticket.IsUsed = true;
                        ticket.EntranceGate = entranceGate;

                        _context.Tickets.Update(ticket);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        return Conflict(e.Message);
                    }

                    return Ok("Boleta válida, puede ingresar al concierto");
                    
                    

                }
                return Conflict("Boleta ya usada");

            }
            return NotFound("Boleta no válida");

        }
    }
}


