using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class InvoiceVM
    {
        public long ID { get; set; }
        public string UserID { get; set; }
        public long OrderID { get; set; }
        public double SubTotal { get; set; }
        public double DiscountRate { get; set; }
        public double TaxRate { get; set; }
        public double GrandTotal { get; set; }
        public string Note { get; set; }
    }
}
