using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
