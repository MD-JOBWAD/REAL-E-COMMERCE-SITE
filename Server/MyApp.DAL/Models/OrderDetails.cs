using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class OrderDetails
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public long OrderID { get; set; }
        public double SigleItemPrice { get; set; }
        public DateTime ShipingDate { get; set;  }
        public int Quantity { get; set; }
        public string State { get; set; }

        public Product Products { get; set; }
        public virtual Order Orders { get; set; }
    }
}

