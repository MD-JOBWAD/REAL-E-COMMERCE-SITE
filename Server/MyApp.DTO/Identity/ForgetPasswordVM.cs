using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.Identity
{
    public class ForgetPasswordVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        [Required]
        public string Token { get; set; }

    }
}
