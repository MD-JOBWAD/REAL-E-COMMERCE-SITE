using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.Identity
{
    public class ResetPasswordVM
    {
        //[Required]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
