using Microsoft.EntityFrameworkCore;
using EmployeeAdmin.Models;
namespace EmployeeAdmin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }

    }
}
