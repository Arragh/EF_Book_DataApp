using EF_Book_DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EF_Book_DataApp.Controllers
{
    public class SuppliersController : Controller
    {
        private ISupplierRepository repository;
        private EFDatabaseContext context;

        public SuppliersController(ISupplierRepository repository, EFDatabaseContext context)
        {
            this.repository = repository;
            this.context = context;
        }

        public IActionResult Index()
        {
            ViewBag.SupplierEditId = Convert.ToInt64(TempData["SupplierEditId"]); // Конвертация строки обратно в long
            ViewBag.SupplierCreateId = Convert.ToInt64(TempData["SupplierCreateId"]); // Конвертация строки обратно в long
            ViewBag.SupplierRelationshipId = Convert.ToInt64(TempData["SupplierRelationshipId"]); // Конвертация строки обратно в long
            return View(repository.GetAllSuppliers());
        }

        public IActionResult Edit(long supplierId)
        {
            TempData["SupplierEditId"] = supplierId.ToString(); // Требуется приводить к строке, иначе будет ошибка сериализации
            return RedirectToAction("Index");
        }

        public IActionResult Create(long supplierId)
        {
            TempData["SupplierCreateId"] = supplierId.ToString(); // Требуется приводить к строке, иначе будет ошибка сериализации
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Supplier supplier)
        {
            repository.UpdateSupplier(supplier);
            return RedirectToAction("Index");
        }

        public IActionResult Change(long supplierId)
        {
            TempData["SupplierRelationshipId"] = supplierId.ToString();
            return RedirectToAction("Index");
        }

        [HttpPost]
        //public IActionResult Change(Supplier supplier)
        public IActionResult Change(long supplierId, Product[] products)
        {
            context.Products.UpdateRange(products.Where(p => p.SupplierId != supplierId));
            context.SaveChanges();

            //IEnumerable<Product> changed = supplier.Products.Where(p => p.SupplierId != supplier.SupplierId);
            //if (changed.Count() > 0)
            //{
            //    IEnumerable<Supplier> allSuppliers = repository.GetAllSuppliers().ToArray();
            //    Supplier currentSupplier = allSuppliers.First(s => s.SupplierId == supplier.SupplierId);

            //    foreach (var p in changed)
            //    {
            //        Supplier newSupplier = allSuppliers.First(s => s.SupplierId == p.SupplierId);
            //        newSupplier.Products = newSupplier.Products.Append(currentSupplier.Products.First(op => op.ProductId == p.ProductId)).ToArray();
            //        repository.UpdateSupplier(newSupplier);
            //    }
            //}

            //IEnumerable<Product> changed = supplier.Products.Where(p => p.SupplierId != supplier.SupplierId);
            //IEnumerable<long> targetSupplierIds = changed.Select(p => p.SupplierId).Distinct();

            //if (changed.Count() > 0)
            //{
            //    IEnumerable<Supplier> targetSuppliers = context.Suppliers.Where(s => targetSupplierIds.Contains(s.SupplierId)).AsNoTracking().ToArray();
            //    foreach (var p in changed)
            //    {
            //        Supplier newSupplier = targetSuppliers.First(s => s.SupplierId == p.SupplierId);
            //        newSupplier.Products = newSupplier.Products == null ? new Product[] { p } : newSupplier.Products.Append(p).ToArray();
            //    }

            //    context.Suppliers.UpdateRange(targetSuppliers);
            //    context.SaveChanges();
            //}

            return RedirectToAction("Index");
        }
    }
}
