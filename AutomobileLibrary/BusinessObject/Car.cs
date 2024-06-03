using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.BusinessObject
{
    public class Car
    {
        public int CarID { get; set; }
        public String CarName { get; set; }
        public String Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int ReleaseYear { get; set; }

    }
}
