using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class OrderStatusVM
    {
        public long ID { get; set; }
        [Required]
        public string Caption { get; set; }
        public bool IsActive { get; set; }
    }
}
