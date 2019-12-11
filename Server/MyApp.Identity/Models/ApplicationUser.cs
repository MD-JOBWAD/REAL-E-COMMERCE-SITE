using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public bool IsMale { get; set; }
        public string ConfirmPassword { get; set; }
        public string OrganizationName { get; set; }
        public int OrganizationNumber { get; set; }
        public string FacebookPage { get; set; }
        public string Website { get; set; }
        public int DistrictID { get; set; }
        public int AlternativeNumber { get; set; }
        public string ContactorName { get; set; }
        public int ContactorNumber { get; set; }
        public string BusinessType { get; set; }
        public string BankName { get; set; }
        public string AccountHolderName { get; set; }
        public int AccountNumber { get; set; }
        public string BranchName { get; set; }
    }//c
}//ns
