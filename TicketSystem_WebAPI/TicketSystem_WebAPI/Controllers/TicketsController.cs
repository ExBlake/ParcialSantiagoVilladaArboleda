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

        [HttpPut, ActionName("Put")]
        [Route("Put/{Id]")]
        public async Task<ActionResult> EditTicket(Guid? id, Tickets tickets)
        {
            try
            {
                if (tickets.Id == id)
                {
                    if (tickets.IsUsed == false)
                    {
                        try
                        {
                            tickets.UseDate = DateTime.Now;
                            tickets.IsUsed = true;
                            tickets.EntranceGate = "";
                            _context.Tickets.Update(tickets);
                            await _context.SaveChangesAsync();
                        }
                        catch (Exception e)
                        {
                            return Conflict(e.Message);
                        }

                        return Ok(tickets);

                    }
                    return Conflict("La entrada ya se utilizo");

                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}


