using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}
