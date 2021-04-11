using Microsoft.EntityFrameworkCore;

namespace EF_Book_DataApp.Models
{
    public class EFCustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public EFCustomerContext(DbContextOptions<EFCustomerContext> options) : base(options) { }
    }
}
