using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class OrderDetailsVM
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public long OrderID { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double SigleItemPrice { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ShipingDate { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string State { get; set; }
    }
}
