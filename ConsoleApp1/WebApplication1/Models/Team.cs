using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Team : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
