using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class ShippingVM
    {
        public long ShippingID { get; set; }
        public string UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [Range(11, 11)]
        [DataType(DataType.PhoneNumber)]
        public string UserPhone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        public string Sate { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string Channel { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ShippingDate { get; set; }
    }
}
