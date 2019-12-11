using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class Merchant
    {
        public long MerchantID { get; set; }
        public string CompanyName { get; set; }
        public string ProprietorName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public long AlternativeMobile { get; set; }
        public string FbLink { get; set; }
        public string Address { get; set; }
        public string WebSiteName { get; set; }
        public string BankAccount { get; set; }
        public string BussinessType { get; set; }
        public string Location { get; set; }
        public string AccountHolderName { get; set; }
        public string District { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string RoutingNumber { get; set; }
    }
}
