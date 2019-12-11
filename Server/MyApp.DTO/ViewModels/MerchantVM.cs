using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class MerchantVM
    {
        public long MerchantID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string ProprietorName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Range(11, 11)]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Required]
        [Range(11, 11)]
        [DataType(DataType.PhoneNumber)]
        public long AlternativeMobile { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string FbLink { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string WebSiteName { get; set; }
        [Required]
        public string BankAccount { get; set; }
        [Required]
        public string BussinessType { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string AccountHolderName { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public string BranchName { get; set; }
        [Required]
        public string RoutingNumber { get; set; }
    }
}
