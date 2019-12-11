using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class Color
    {
        public Color()
        {
            this.Products = new List<Product>();
        }
        public long ID { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
