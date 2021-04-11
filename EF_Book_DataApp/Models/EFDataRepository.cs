using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_Book_DataApp.Models
{
    public class EFDataRepository : IDataRepository
    {
        private EFDatabaseContext context;
        public EFDataRepository(EFDatabaseContext context) => this.context = context;

        //public IQueryable<Product> Products => context.Products;
        //public IEnumerable<Product> GetProductsByPrice(decimal minPrice) => context.Products.Where(p => p.Price >= minPrice).ToArray();

        public Product GetProduct(long productId) => context.Products.Find(productId);

        public IEnumerable<Product> GetAllProducts()
        {
            Console.WriteLine("GetAllProducts()");
            return context.Products;
        }

        public IEnumerable<Product> GetFilteredProducts(string category = null, decimal? price = null)
        {
            IQueryable<Product> data = context.Products;
            if (category != null)
            {
                data = data.Where(p => p.Category == category);
            }
            if (price != null)
            {
                data = data.Where(p => p.Price >= price);
            }
            return data;
        }

        public void CreateProduct(Product newProduct)
        {
            newProduct.ProductId = 0;
            context.Products.Add(newProduct);
            context.SaveChanges();
        }

        public void UpdateProduct(Product changedProduct, Product originalProduct = null)
        {
            if (originalProduct == null)
            {
                originalProduct = context.Products.Find(changedProduct.ProductId);
            }
            else
            {
                context.Products.Attach(originalProduct);
            }

            //Product originalProduct = context.Products.Find(changedProduct.ProductId);
            originalProduct.Name = changedProduct.Name;
            originalProduct.Category = changedProduct.Category;
            originalProduct.Price = changedProduct.Price;

            EntityEntry entry = context.Entry(originalProduct);
            Console.WriteLine($"Entity State: {entry.State}");
            foreach (var p_name in new string[] { "Name", "Category", "Price" })
            {
                Console.WriteLine($"{p_name} - Old: {entry.OriginalValues[p_name]}, New: {entry.CurrentValues[p_name]}");
            }

            context.SaveChanges();
        }

        public void DeleteProduct(long productId)
        {
            context.Products.Remove(new Product { ProductId = productId });
            context.SaveChanges();
        }
    }
}
