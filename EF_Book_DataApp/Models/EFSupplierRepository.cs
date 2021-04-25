using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_DataApp.Models
{
    public class EFSupplierRepository : ISupplierRepository
    {
        private EFDatabaseContext context;
        public EFSupplierRepository(EFDatabaseContext context) => this.context = context;

        public Supplier GetSupplier(long supplierId) => context.Suppliers.Find(supplierId);

        public IEnumerable<Supplier> GetAllSuppliers() => context.Suppliers.Include(s => s.Products);
        //public IEnumerable<Supplier> GetAllSuppliers() => context.Suppliers.Include(s => s.Products.AsQueryable().Where(p => p.Price > 50));
        //public IEnumerable<Supplier> GetAllSuppliers()
        //{
        //    IEnumerable<Supplier> data = context.Suppliers.ToArray();
        //    foreach (var supplier in data)
        //    {
        //        context.Entry(supplier).Collection(e => e.Products).Query().Where(p => p.Price > 50).Load();
        //    }
        //    return data;
        //}
        //public IEnumerable<Supplier> GetAllSuppliers()
        //{
        //    context.Products.Where(p => p.Supplier != null && p.Price > 50).Load();
        //    return context.Suppliers;
        //}

        public void CreateSupplier(Supplier newSupplier)
        {
            context.Suppliers.Add(newSupplier);
            context.SaveChanges();
        }

        public void UpdateSupplier(Supplier changedSupplier)
        {
            context.Suppliers.Update(changedSupplier);
            context.SaveChanges();
        }

        public void DeleteSupplier(long supplierId)
        {
            context.Suppliers.Remove(new Supplier { SupplierId = supplierId });
            context.SaveChanges();
        }
    }
}