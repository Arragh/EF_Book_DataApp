using System.Collections.Generic;

namespace EF_Book_DataApp.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAlLCustomers();
    }
    public class EFCustomerRepository : ICustomerRepository
    {
        private EFCustomerContext context;
        public EFCustomerRepository(EFCustomerContext context) => this.context = context;

        public IEnumerable<Customer> GetAlLCustomers() => context.Customers;
    }
}