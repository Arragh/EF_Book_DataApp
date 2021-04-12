namespace EF_Book_DataApp.Models
{
    public enum Colors
    {
        Red,
        Green,
        Blue,
        Yellow
    }

    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public Colors Color { get; set; }
        public bool InStock { get; set; }
        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
