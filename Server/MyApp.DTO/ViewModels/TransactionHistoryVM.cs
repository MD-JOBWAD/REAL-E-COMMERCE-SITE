using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class TransactionHistoryVM
    {
        public long ID { get; set; }
        public long OrderID { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double PayableAmount { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double PaidAmount { get; set; }
        [Required]
        public string PaymentMedia { get; set; }
        [Required]
        public long PamentRefID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PaymentDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DTPaid { get; set; }
        [Required]
        public bool IsSuccess { get; set; }
    }
}
