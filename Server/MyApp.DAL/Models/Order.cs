using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class Order
    {
        public long ID { get; set; }
        public long CustomerID { get; set; }
        public long PaymentID { get; set; }
        public long OrderStatusID { get; set; }
        public string UserID { get; set; }
        public long ShippingID { get; set; }
        public double Discount { get; set; }
        public bool IsFullPaid { get; set; }
        public DateTime DTOrderPlaced { get; set; }
        public DateTime DTOrderDelivered { get; set; }
        
        public virtual Customer Customers { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Shipping Shippings { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
