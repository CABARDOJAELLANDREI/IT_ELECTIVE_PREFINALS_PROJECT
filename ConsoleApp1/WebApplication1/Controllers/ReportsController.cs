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
}