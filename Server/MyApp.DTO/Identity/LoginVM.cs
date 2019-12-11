using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.Identity
{
    public class LoginVM
    {
        [Required(ErrorMessage = "User Name is Required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required.")]

        public string Password { get; set; }
        public bool RememberMe { get; set; }


    }
}
