using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class TeamMember : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
