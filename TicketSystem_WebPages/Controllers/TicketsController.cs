using Microsoft.AspNetCore.Mvc;
using TicketSystem_WebAPI.DAL.Entities;
using Newtonsoft.Json;

namespace TicketSystem_WebPages.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;


        public TicketsController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:7042/EditTicket/";
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            List<Tickets> tickets = JsonConvert.DeserializeObject<List<Tickets>>(json);
            return View(tickets);
        }

        [HttpPost, ActionName("EditTicket")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTicket(Guid? id, Tickets tickets)
        {
            
            var url = String.Format("https://localhost:7042/EditTicket/{0}", id);
            var json = await _httpClient.CreateClient().PutAsJsonAsync(url, tickets);
            return View(tickets);
        }

        
        [HttpGet]
        public IActionResult Valide()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TicketEdit(Guid? id, Tickets tickets)
        {
            var url = String.Format("https://localhost:7042/EditTicket/{0}", id);
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            Tickets ticket = JsonConvert.DeserializeObject<Tickets>(json);
            return View(ticket);
            //if (tickets.Id == id)
            //{
            //    if (tickets.IsUsed == false)
            //    {
            //        try
            //        {
            //            tickets.UseDate = DateTime.Now;
            //            tickets.IsUsed = true;
            //            tickets.EntranceGate = "";


            //            return View(tickets);
            //        }
            //        catch (Exception e)
            //        {
            //            return Conflict(e.Message);
            //        }





            //    }

            //    return Conflict("Boleta ya usada");

            //}
            //return NotFound("Boleta no válida");
        }

        
        



    }
}

