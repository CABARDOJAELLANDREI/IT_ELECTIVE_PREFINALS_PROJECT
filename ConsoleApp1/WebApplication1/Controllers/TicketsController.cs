using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskApp.Data;

namespace WebApplication1.Controllers;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

public class TicketsController : Controller
{
    private readonly HelpDeskDbContext _context;

    public TicketsController(HelpDeskDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var tickets = await _context.Tickets
            .Include(t => t.Customer)
            .Include(t => t.Category)
            .Include(t => t.Priority)
            .Include(t => t.Status)
            .AsNoTracking()
            .ToListAsync();

        return View(tickets);
    }

    public async Task<IActionResult> Details(int id)
    {
        var ticket = await _context.Tickets
            .Include(t => t.Customer)
            .Include(t => t.Category)
            .Include(t => t.Priority)
            .Include(t => t.Status)
            .Include(t => t.TicketAssignments)
                .ThenInclude(ta => ta.Employee)
            .Include(t => t.TicketComments)
                .ThenInclude(tc => tc.Employee)
            .Include(t => t.TicketAttachments)
            .Include(t => t.TicketTags)
                .ThenInclude(tt => tt.Tag)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);

        if (ticket == null)
        {
            return NotFound();
        }

        return View(ticket);
    }
}