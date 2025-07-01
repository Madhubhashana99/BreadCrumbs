using Microsoft.EntityFrameworkCore;
using student_management_system.Models;
using System.Data;

namespace student_management_system.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<StudentDetail> Students { get; set; }


    }
}
