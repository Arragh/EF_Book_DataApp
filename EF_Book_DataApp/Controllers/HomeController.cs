using EF_Book_DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EF_Book_DataApp.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository repository;
        public HomeController(IDataRepository repository) => this.repository = repository;

        //public IActionResult Index()
        //{
        //    var products = repository.GetProductsByPrice(25);
        //    ViewBag.ProductsCount = products.Count();
        //    return View(products);
        //}

        public IActionResult Index(string category = null, decimal? price = null)
        {
            var products = repository.GetFilteredProducts(category, price);
            ViewBag.Category = category;
            ViewBag.Price = price;
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CreateMode = true;
            return View("Editor", new Product());
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            repository.CreateProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(long productId)
        {
            ViewBag.CreateMode = false;
            return View("Editor", repository.GetProduct(productId));
        }

        [HttpPost]
        public IActionResult Edit(Product product, Product original)
        {
            repository.UpdateProduct(product, original);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(long productId)
        {
            repository.DeleteProduct(productId);
            return RedirectToAction("Index");
        }
    }
}
