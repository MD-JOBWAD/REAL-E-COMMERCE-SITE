using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.Identity
{
    public class RoleVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Name is Required.")]
        public string Name { get; set; }
    }
}
