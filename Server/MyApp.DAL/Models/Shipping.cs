using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class Shipping
    {
        public Shipping()
        {
            this.Orders = new List<Order>();
        }
        public long ShippingID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Sate { get; set; }
        public int ZipCode { get; set; }
        public string Channel { get; set; }
        public DateTime ShippingDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
