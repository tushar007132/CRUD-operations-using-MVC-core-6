using Microsoft.EntityFrameworkCore;
using UdemyProject1.Models;

namespace UdemyProject1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
    }
}
