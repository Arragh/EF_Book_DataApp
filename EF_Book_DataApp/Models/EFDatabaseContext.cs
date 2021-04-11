using Microsoft.EntityFrameworkCore;

namespace EF_Book_DataApp.Models
{
    public class EFDatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public EFDatabaseContext(DbContextOptions<EFDatabaseContext> options) : base(options) { }
    }
}
