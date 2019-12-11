using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class ProductRatingVM
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        [Required]
        public int Star { get; set; }

    }
}
