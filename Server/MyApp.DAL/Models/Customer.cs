using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new List<Order>();
        }
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string DeliveryNumber { get; set; }
        public string DeliveryAddress { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
