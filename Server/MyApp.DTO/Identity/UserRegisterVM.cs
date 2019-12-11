using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.Identity
{
    public class UserVM
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "User Name is Required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        

        public string Address { get; set; }
        
        public bool IsMale { get; set; }
       
        public int DistrictID { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        //[Required(ErrorMessage = "Confirm Password is Required.")]
        //[Compare("Password", ErrorMessage = "Password not match.")]
        public string ConfirmPassword { get; set; }
        /// Role input r set From UI hidden field with default value
        /// for exampule if the perpose of register normal user than  UI Input field are set with 
        /// default value Normal make is hidden.... if MarchandRegistration than  UI Input field are set with 
        /// default value Marchand make is hidden
        [Required]
        public string Role { get; set; }
        public IList<string> Roles { get; set; }
    }
}
