using EF_Book_DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EF_Book_DataApp.Controllers
{
    public class MigrationsController : Controller
    {
        private MigrationsManager manager;
        public MigrationsController(MigrationsManager manager) => this.manager = manager;

        public IActionResult Index(string context)
        {
            ViewBag.Context = manager.ContextName = context ?? manager.ContextNames.First();
            return View(manager);
        }

        [HttpPost]
        public IActionResult Migrate(string context, string migration)
        {
            manager.ContextName = context;
            manager.Migrate(context, migration);
            return RedirectToAction("Index", new { context = context });
        }

        [HttpPost]
        public IActionResult Seed(string context)
        {
            manager.ContextName = context;
            SeedData.Seed(manager.Context);
            return RedirectToAction("Index", new { context = context });
        }

        [HttpPost]
        public IActionResult Clear(string context)
        {
            manager.ContextName = context;
            SeedData.Clear(manager.Context);
            return RedirectToAction("Index", new { context = context });
        }
    }
}
