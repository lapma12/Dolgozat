using Microsoft.EntityFrameworkCore;

namespace Dolgozat.Models
{
    public class ComputerDbContext : DbContext
    {
        public ComputerDbContext() { }

        public ComputerDbContext(DbContextOptions<ComputerDbContext> options) : base(options) { }

        public DbSet<Computer> Computers { get; set; }

        public DbSet<Os> Os { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=computer;user=root;password=");
        }


    }
}
