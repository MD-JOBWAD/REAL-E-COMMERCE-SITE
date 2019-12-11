using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class ProductSizeVM
    {
        public long ID { get; set; }
        public int? Chest { get; set; }
        public int? Shoulder { get; set; }
        public string Sleeve { get; set; }
        public double? Weight { get; set; }
        [Required]
        public bool? IsCloth { get; set; }
        public double? Lenth { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public string Season { get; set; }
    }
}
