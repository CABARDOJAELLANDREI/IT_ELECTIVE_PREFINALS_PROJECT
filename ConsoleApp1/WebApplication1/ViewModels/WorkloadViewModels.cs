namespace WebApplication1.ViewModels;

public class EmployeeWorkloadViewModel
{
    public string EmployeeName { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public int UnresolvedTicketCount { get; set; }
}

public class DepartmentWorkloadViewModel
{
    public string DepartmentName { get; set; } = string.Empty;
    public int EmployeeCount { get; set; }
    public int UnresolvedTicketCount { get; set; }
}