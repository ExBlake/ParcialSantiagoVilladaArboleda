using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Route("GeTicketsById/{TicketsId}")]
        public async Task<ActionResult<Tickets>> xd(Guid? Id)
        {
            var tricket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == Id);

            if (tricket == null) return NotFound();

            return Ok(tricket);
        }

        
        }
    }

