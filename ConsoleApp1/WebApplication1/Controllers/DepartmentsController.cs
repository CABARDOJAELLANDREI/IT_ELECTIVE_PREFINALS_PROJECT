using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskApp.Data;

namespace HelpDeskApp.Controllers;

public class DepartmentsController : Controller
{
    private readonly HelpDeskDbContext _context;

    public DepartmentsController(HelpDeskDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var departments = await _context.Departments
            .Include(d => d.Employees)
            .AsNoTracking()
            .ToListAsync();
        return View(departments);
    }
}