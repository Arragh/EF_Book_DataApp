using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_DataApp.Models
{
    public class ContactLocation
    {
        public long ContactLocationId { get; set; }
        public string LocationName { get; set; }
        public string Adress { get; set; }
    }
}
