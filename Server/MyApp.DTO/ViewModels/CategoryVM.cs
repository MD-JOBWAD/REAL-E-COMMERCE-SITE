using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class CategoryVM
    {
        public long ID { get; set; }
        [Required]
        public string Name { get; set; }
        public long? ParentCategoryID { get; set; }
        public long? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
