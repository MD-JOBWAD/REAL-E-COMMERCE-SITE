using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class OrderStatus
    { 
        public long ID { get; set; }
        public string Caption { get; set; }
        public bool IsActive { get; set; }

        public virtual Order Orders { get; set; }
    }
}

