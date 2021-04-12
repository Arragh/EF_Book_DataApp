using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EF_Book_DataApp.Models
{
    public static class SeedData
    {
        private static Product[] Products
        {
            get {
                Product[] products = new Product[]
                {
                new Product{ Name = "Апельсины", Category = "Фрукты", Price = 50, Color = Colors.Red, InStock = true },
                new Product{ Name = "Бананы", Category = "Фрукты", Price = 35, Color = Colors.Red, InStock = true },
                new Product{ Name = "Мандарины", Category = "Фрукты", Price = 55, Color = Colors.Red, InStock = true },
                new Product{ Name = "Киви", Category = "Фрукты", Price = 70, Color = Colors.Red, InStock = true },
                new Product{ Name = "Яблоки", Category = "Фрукты", Price = 30, Color = Colors.Red, InStock = true },
                new Product{ Name = "Картошка", Category = "Овощи", Price = 20, Color = Colors.Green, InStock = true },
                new Product{ Name = "Кабачки", Category = "Овощи", Price = 25, Color = Colors.Green, InStock = true },
                new Product{ Name = "Капуста", Category = "Овощи", Price = 15, Color = Colors.Green, InStock = true },
                new Product{ Name = "Батон", Category = "Хлебобулочные изделия", Price = 10, Color = Colors.Blue, InStock = true },
                new Product{ Name = "Плюшка", Category = "Хлебобулочные изделия", Price = 17, Color = Colors.Blue, InStock = true },
                new Product{ Name = "Молоко коровье", Category = "Молочная продукция", Price = 33, Color = Colors.Yellow, InStock = true },
                new Product{ Name = "Творог", Category = "Молочная продукция", Price = 57, Color = Colors.Yellow, InStock = true }
                };

                ContactLocation gdeto = new ContactLocation
                {
                    LocationName = "Где-то далеко",
                    Adress = "Где-то еще дальше"
                };
                ContactDetails vasya = new ContactDetails
                {
                    Name = "Вася Васюков", Phone = "123456789", Location = gdeto
                };

                Supplier supplier1 = new Supplier
                {
                    Name = "Огород",
                    City = "Хутор",
                    Contact = vasya
                };
                Supplier supplier2 = new Supplier
                {
                    Name = "Коровник",
                    City = "Дыра"
                };
                Supplier supplier3 = new Supplier
                {
                    Name = "Пекарня",
                    City = "Печка"
                };

                foreach (var p in products)
                {
                    if (p.Category == "Хлебобулочные изделия")
                    {
                        p.Supplier = supplier3;
                    }
                    else if (p.Category == "Молочная продукция")
                    {
                        p.Supplier = supplier2;
                    }
                    else if (p.Category == "Фрукты" || p.Category == "Овощи")
                    {
                        p.Supplier = supplier1;
                    }
                }

                return products;
            }
        }

        private static Customer[] Customers =
        {
            new Customer { Name = "Петя Петров", City = "Мухосранск", Country = "ноунейм" },
            new Customer { Name = "Вася Васюков", City = "Жукосранск", Country = "ноунейм" },
            new Customer { Name = "Ваня Ванюков", City = "Молесранск", Country = "ноунейм" },
        };

        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context is EFDatabaseContext prodContext && prodContext.Products.Count() == 0)
                {
                    prodContext.Products.AddRange(Products);
                }
                else if (context is EFCustomerContext custContext && custContext.Customers.Count() == 0)
                {
                    custContext.Customers.AddRange(Customers);
                }
                context.SaveChanges();
            }
        }

        public static void Clear(DbContext context)
        {
            if (context is EFDatabaseContext prodContext && prodContext.Products.Count() > 0)
            {
                prodContext.Products.RemoveRange(prodContext.Products);
            }
            else if (context is EFCustomerContext custContext && custContext.Customers.Count() > 0)
            {
                custContext.Customers.RemoveRange(custContext.Customers);
            }
            context.SaveChanges();
        }
    }
}
