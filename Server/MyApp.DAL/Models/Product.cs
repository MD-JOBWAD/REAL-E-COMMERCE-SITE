using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class Product
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long CategoryID { get; set; }
        public long BrandID { get; set; } //con
        //public long ColorID { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public double? MarketPrice { get; set; }
        public double? DiscountPrice { get; set; }
        public double SalesPrice { get; set; }
        public int? TotalViewed { get; set; }
        public int StockQuantity { get; set; }
        public bool? IsFavourite { get; set; }
        public bool? IsActive { get; set; }

        public virtual Category Categories { get; set; }
        public virtual Brand Brands { get; set; }
    }
}
