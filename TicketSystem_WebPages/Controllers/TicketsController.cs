using Microsoft.AspNetCore.Mvc;
using TicketSystem_WebAPI.DAL.Entities;
using Newtonsoft.Json;

namespace TicketSystem_WebPages.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;


        public TicketsController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:7042/Get/";
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            List<Tickets> tickets = JsonConvert.DeserializeObject<List<Tickets>>(json);
            return View(tickets);
        }
        [HttpGet]

        public async Task<IActionResult> EditTickets(Guid? Id)
        {
            var url = String.Format("https://localhost:7042/Get/{0}", Id);
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            var tickets = JsonConvert.DeserializeObject<Tickets>(json);
            return View(tickets);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            var url = String.Format("https://localhost:7042/Get/{0}", id);
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            var tickets = JsonConvert.DeserializeObject<Tickets>(json);
            return View(tickets);
        }
       
    }
}
