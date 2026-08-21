using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Employee : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
