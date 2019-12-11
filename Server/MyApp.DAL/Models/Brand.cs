using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class Brand
    {
        public Brand()
        {
            this.Categories = new List<Category>();
        }
        public long ID { get; set; }
        public long? CategoryID { get; set; }
        public long ParentBandID { get; set; }
        public string BandName { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
