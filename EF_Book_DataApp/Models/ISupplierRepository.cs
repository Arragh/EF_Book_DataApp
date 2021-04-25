using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_DataApp.Models
{
    public interface ISupplierRepository
    {
        Supplier GetSupplier(long supplierId);
        IEnumerable<Supplier> GetAllSuppliers();
        void CreateSupplier(Supplier supplier);
        void UpdateSupplier(Supplier changedSupplier);
        void DeleteSupplier(long supplierId);
    }
}
