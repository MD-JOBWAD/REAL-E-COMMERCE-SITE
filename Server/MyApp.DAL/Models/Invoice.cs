using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class Invoice
    {
        public Invoice()
        {
            this.Orders = new List<Order>();
        }
        public long ID { get; set; }
        public string UserID { get; set; }
        public long OrderID { get; set; }
        public double SubTotal { get; set; }
        public double DiscountRate { get; set; }
        public double TaxRate { get; set; }
        public double GrandTotal { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
