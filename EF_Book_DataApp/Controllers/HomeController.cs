using EF_Book_DataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_Book_DataApp.Controllers
{
    public class HomeController : Controller
    {
        private EFDatabaseContext context;
        public HomeController(EFDatabaseContext context) => this.context = context;

        public IActionResult Index() => View(context.Products);
    }
}
