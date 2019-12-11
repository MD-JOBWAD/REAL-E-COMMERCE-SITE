using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.Identity
{
    public class MerchantRegisterVM
    {
        [Required(ErrorMessage = "Organization Name is Required.")]
        public string OrganizationName { get; set; }
        [Required(ErrorMessage = "Organization Number is Required.")]
        public int OrganizationNumber { get; set; }
        [Required(ErrorMessage = "Facebook Page is Required.")]
        public string FacebookPage { get; set; }
        public string Address { get; set; }
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
    }
}
