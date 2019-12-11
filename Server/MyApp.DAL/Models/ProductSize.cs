using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class ProductSize
    {
        public ProductSize()
        {
            this.Products = new List<Product>();
        }
        public long ID { get; set; }
        public long ProductId { get; set; }
        public int? Chest { get; set; }
        public int? Shoulder { get; set; }
        public string Sleeve { get; set; }
        public double? Weight { get; set; }
        public bool? IsCloth { get; set; }
        public double? Lenth { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public string Season { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
