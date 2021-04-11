using System.Collections.Generic;

namespace EF_Book_DataApp.Models
{
    public interface IDataRepository
    {
        //IQueryable<Product> Products { get; }
        //IEnumerable<Product> GetProductsByPrice(decimal minPrice);

        Product GetProduct(long productId);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetFilteredProducts(string category = null, decimal? price = null);
        void CreateProduct(Product newProduct);
        void UpdateProduct(Product changedProduct, Product originalProduct = null);
        void DeleteProduct(long productId);
    }
}
