using Microsoft.EntityFrameworkCore;
using DB2_Project.Models;

namespace DB2_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Productor> Productores { get; set; }
        public DbSet<Finca> Fincas { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        
    }
}
