using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskApp.Data;
using HelpDeskApp.ViewModels;

namespace HelpDeskApp.Controllers;

public partial class ReportsController : Controller
{
    private readonly HelpDeskDbContext _context;

    public ReportsController(HelpDeskDbContext context)
    {
        _context = context;
    }

    // Workload Query: Active Employees with unresolved tickets
    public async Task<IActionResult> EmployeeWorkload()
    {
        var workloads = await _context.Employees
            .Where(e => e.IsActive)
            .Select(e => new EmployeeWorkloadViewModel
            {
                EmployeeName = e.FirstName + " " + e.LastName,
                DepartmentName = e.Department.Name,
                UnresolvedTicketCount = e.TicketAssignments
                    .Count(ta => ta.UnassignedAt == null && !ta.Ticket.Status.IsClosed)
            })
            .OrderByDescending(w => w.UnresolvedTicketCount)
            .AsNoTracking()
            .ToListAsync();

        return View(workloads);
    }

    // Workload Query: Departments with employee and unresolved ticket counts
    public async Task<IActionResult> DepartmentWorkload()
    {
        var workloads = await _context.Departments
            .Select(d => new DepartmentWorkloadViewModel
            {
                DepartmentName = d.Name,
                EmployeeCount = d.Employees.Count,
                UnresolvedTicketCount = d.Employees
                    .SelectMany(e => e.TicketAssignments)
                    .Count(ta => ta.UnassignedAt == null && !ta.Ticket.Status.IsClosed)
            })
            .OrderByDescending(w => w.UnresolvedTicketCount)
            .AsNoTracking()
            .ToListAsync();

        return View(workloads);
    }

    public async Task<IActionResult> UnassignedTickets()
    {
        var tickets = await _context.Tickets
            .Include(t => t.Customer)
            .Include(t => t.Priority)
            .Include(t => t.Status)
            .Where(t => !t.TicketAssignments.Any(ta => ta.UnassignedAt == null))
            .AsNoTracking()
            .ToListAsync();

        return View(tickets);
    }

    // Multiple-Assignee Tickets: More than 1 active assignee
    public async Task<IActionResult> MultipleAssignees()
    {
        var tickets = await _context.Tickets
            .Include(t => t.TicketAssignments)
                .ThenInclude(ta => ta.Employee)
            .Where(t => t.TicketAssignments.Count(ta => ta.UnassignedAt == null) > 1)
            .AsNoTracking()
            .ToListAsync();

        return View(tickets);
    }

    // Primary Assignee Query: Display Ticket, Subject, and Primary Assignee (or 'Unassigned')
    public async Task<IActionResult> PrimaryAssignee()
    {
        var list = await _context.Tickets
            .Select(t => new
            {
                TicketId = t.Id,
                t.Subject,
                PrimaryAssignee = t.TicketAssignments
                    .Where(ta => ta.IsPrimary && ta.UnassignedAt == null)
                    .Select(ta => ta.Employee.FirstName + " " + ta.Employee.LastName)
                    .FirstOrDefault() ?? "Unassigned"
            })
            .AsNoTracking()
            .ToListAsync();

        return View(list);
    }

    // Category Hierarchy: Root categories and subcategories
    public async Task<IActionResult> CategoryHierarchy()
    {
        var categories = await _context.TicketCategories
            .Include(c => c.ParentCategory)
            .AsNoTracking()
            .ToListAsync();

        return View(categories);
    }
}