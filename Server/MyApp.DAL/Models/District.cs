using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.DAL.Models
{
    public class District
    {
        public int ID { get; set; }
        public string DistrictName { get; set; }
        public int CountryID { get; set; }

        public virtual IEnumerable<Country> Countries { get; set; }
    }
}
