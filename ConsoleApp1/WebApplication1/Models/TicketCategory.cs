using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class TicketCategory : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
