using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class BrandVM
    {
        public long ID { get; set; }
        public long? CategoryID { get; set; }
        public long ParentBandID { get; set; }
        [Required]
        public string BandName { get; set; }
    }
}
