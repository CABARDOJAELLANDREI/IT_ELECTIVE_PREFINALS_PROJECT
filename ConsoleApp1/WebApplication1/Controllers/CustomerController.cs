using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskApp.Data;

namespace WebApplication1.Controllers;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

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