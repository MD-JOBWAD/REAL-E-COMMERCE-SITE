using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class OrderVM
    {
        public long ID { get; set; }
        public long CustomerID { get; set; }
        public long PaymentID { get; set; }
        public long OrderStatusID { get; set; }
        public string UserID { get; set; }
        public long ShippingID { get; set; }
        public double Discount { get; set; }
        [Required]
        public bool IsFullPaid { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DTOrderPlaced { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DTOrderDelivered { get; set; }
    }
}
