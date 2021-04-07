using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EF_Book_DataApp.Models
{
    public class EFDataRepository : IDataRepository
    {
        private EFDatabaseContext context;
        public EFDataRepository(EFDatabaseContext context) => this.context = context;

        //public IQueryable<Product> Products => context.Products;
        //public IEnumerable<Product> GetProductsByPrice(decimal minPrice) => context.Products.Where(p => p.Price >= minPrice).ToArray();

        public Product GetProduct(long productId)
        {
            Console.WriteLine("GetProduct: " + productId);
            return new Product();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            Console.WriteLine("GetAllProducts");
            return context.Products;
        }

        public void CreateProduct(Product newProduct)
        {
            Console.WriteLine("CreateProduct: " + JsonSerializer.Serialize(newProduct));
        }

        public void UpdateProduct(Product changedProduct)
        {
            Console.WriteLine("UpdateProduct: " + JsonSerializer.Serialize(changedProduct));
        }

        public void DeleteProduct(long productId)
        {
            Console.WriteLine("DeleteProduct: " + productId);
        }
    }
}
