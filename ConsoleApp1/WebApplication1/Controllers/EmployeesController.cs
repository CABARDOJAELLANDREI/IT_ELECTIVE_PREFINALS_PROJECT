using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskApp.Data;

namespace HelpDeskApp.Controllers;

public class EmployeesController : Controller
{
    private readonly HelpDeskDbContext _context;

    public EmployeesController(HelpDeskDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _context.Employees
            .Include(e => e.Department)
            .AsNoTracking()
            .ToListAsync();
        return View(employees);
    }
}