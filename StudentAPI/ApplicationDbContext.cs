using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
