using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }
        public long ID { get; set; }
        public string Name { get; set; }
        public long ParentCategoryID { get; set; }
        public long DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
