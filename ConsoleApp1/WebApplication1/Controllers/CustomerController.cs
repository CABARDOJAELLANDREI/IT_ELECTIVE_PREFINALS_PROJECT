using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskApp.Data;

namespace HelpDeskApp.Controllers;

public class CustomersController : Controller
{
    private readonly HelpDeskDbContext _context;

    public CustomersController(HelpDeskDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var customers = await _context.Customers.AsNoTracking().ToListAsync();
        return View(customers);
    }
}