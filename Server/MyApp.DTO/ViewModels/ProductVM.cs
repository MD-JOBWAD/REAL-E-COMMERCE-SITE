using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class ProductVM
    {
        public long? ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long CategoryID { get; set; }
        [Required]
        public long BrandID { get; set; }
        [Required]
        [MinLength(50)]
        public string Description { get; set; }
        public string SKU { get; set; }
        public double? MarketPrice { get; set; }

        //public IFormFile ProductImages { get; set; }
        public double? DiscountPrice { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double SalesPrice { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        public bool? IsFavourite { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsCloth { get; set; }
        public List<Colors> Colors { get; set; }
        public string[] ImageName { get; set; }
        public List<ClothSizes> ClothSizes { get; set; }
        public List<OtherProductSize> OtherProductSize { get; set; }
        public string Season { get; set; }
        public double? Weight { get; set; }
    }
    public class ClothSizes
    {
        public int? Chest { get; set; }
        public int? Shoulder { get; set; }
        public string Sleeve { get; set; }
    }
    public class OtherProductSize
    {
        public double? Lenth { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
    }
    public class Colors
    {
        public long? ColorID { get; set; }
    }
}
