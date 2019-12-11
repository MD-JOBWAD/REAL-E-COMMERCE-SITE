using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class ProductRating
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public int Star { get; set; }

        public virtual Product Products { get; set; }
    }
}
