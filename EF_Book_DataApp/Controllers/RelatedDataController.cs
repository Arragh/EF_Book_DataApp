using EF_Book_DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_DataApp.Controllers
{
    public class RelatedDataController : Controller
    {
        private ISupplierRepository supplierRepository;
        private IGenericRepository<ContactDetails> contactRepository;
        private IGenericRepository<ContactLocation> locationRepository;
        public RelatedDataController(ISupplierRepository supplierRepository, IGenericRepository<ContactDetails> contactRepository, IGenericRepository<ContactLocation> locationRepository)
        {
            this.supplierRepository = supplierRepository;
            this.contactRepository = contactRepository;
            this.locationRepository = locationRepository;
        }

        public IActionResult Index() => View(supplierRepository.GetAllSuppliers());

        public IActionResult Contacts() => View(contactRepository.GetAllObjects());
        public IActionResult Locations() => View(locationRepository.GetAllObjects());
    }
}
