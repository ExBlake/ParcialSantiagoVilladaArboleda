using Microsoft.AspNetCore.Mvc;

namespace TicketSystem_WebPages.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:7042/GeTicketsById/";
            var json = "";
            return View();
        }
    }
}
