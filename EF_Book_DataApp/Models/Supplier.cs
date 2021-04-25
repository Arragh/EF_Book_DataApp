using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_DataApp.Models
{
    public class Supplier
    {
        public long SupplierId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public ContactDetails Contact { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
