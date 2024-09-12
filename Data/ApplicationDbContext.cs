using Microsoft.EntityFrameworkCore;
using Task2MVC.Models;

namespace Task2MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
