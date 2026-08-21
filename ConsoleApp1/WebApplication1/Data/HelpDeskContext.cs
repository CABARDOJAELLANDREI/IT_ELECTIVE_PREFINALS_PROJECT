using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Data
{
    public class HelpDeskContext : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
