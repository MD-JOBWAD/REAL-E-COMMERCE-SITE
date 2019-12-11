using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class CustomerVM
    {
        public long CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
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
        public string DeliveryNumber { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
    }
}
