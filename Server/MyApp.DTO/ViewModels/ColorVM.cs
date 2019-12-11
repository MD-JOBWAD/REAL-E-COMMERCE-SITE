using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class ColorVM
    {
        public long ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
