using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.DAL.Models
{
    public class ProductColor
    {
        public int ID { get; set; }
        public long ProductID { get; set; }
        public long ColorID { get; set; }
    }
}
