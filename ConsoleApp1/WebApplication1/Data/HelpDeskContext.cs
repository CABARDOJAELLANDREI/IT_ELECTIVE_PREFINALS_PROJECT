using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Emit;
using WebApplication1.Models;

public class HelpDeskContext : DbContext
{
    public HelpDeskContext(DbContextOptions<HelpDeskContext> options) : base(options) { }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<TicketCategory> TicketCategories { get; set; }
    public DbSet<TicketPriority> TicketPriorities { get; set; }
    public DbSet<TicketStatus> TicketStatuses { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketAssignment> TicketAssignments { get; set; }
    public DbSet<TicketComment> TicketComments { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TicketTag> TicketTags { get; set; }
    public DbSet<TicketAttachment> TicketAttachments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Composite keys for junction tables
        modelBuilder.Entity<TeamMember>()
            .HasKey(tm => new { tm.TeamId, tm.EmployeeId });

        modelBuilder.Entity<TicketAssignment>()
            .HasKey(ta => new { ta.TicketId, ta.EmployeeId });

        modelBuilder.Entity<TicketTag>()
            .HasKey(tt => new { tt.TicketId, tt.TagId });

        modelBuilder.Entity<Team>()
            .HasIndex(t => new { t.DepartmentId, t.Name })
            .IsUnique();
    }
}