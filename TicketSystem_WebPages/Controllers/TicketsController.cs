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
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:7042/GeTicketsById/";
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            List<Tickets> tickets = JsonConvert.DeserializeObject<List<Tickets>>(json);
            return View(tickets);
        }
    }
}
