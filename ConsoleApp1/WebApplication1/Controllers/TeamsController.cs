using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskApp.Data;

namespace HelpDeskApp.Controllers;

public class TeamsController : Controller
{
    private readonly HelpDeskDbContext _context;

    public TeamsController(HelpDeskDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var teams = await _context.Teams
            .Include(t => t.Department)
            .Include(t => t.TeamMembers)
                .ThenInclude(tm => tm.Employee)
            .AsNoTracking()
            .ToListAsync();

        return View(teams);
    }
}