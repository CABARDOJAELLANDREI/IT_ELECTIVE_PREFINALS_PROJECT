using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Data
{
    public class HelpDeskDbContext : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
