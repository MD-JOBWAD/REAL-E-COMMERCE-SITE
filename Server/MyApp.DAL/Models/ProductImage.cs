using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MyApp.DAL.Models
{
    public class ProductImage
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public string Caption { get; set; }
        public string FilePath { get; set; }
        public string Thumbnail1 { get; set; }
        public string Thumbnail2 { get; set; }
        public string Thumbnail3 { get; set; }
        public bool? IsDefault { get; set; }
        public int DisplayOrder { get; set; }
        public bool? IsActive { get; set; }

        public virtual Product Products { get; set; }
    }
}
