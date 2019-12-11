using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class ProductImageVM
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string FilePath { get; set; }
        [Required]
        public string Thumbnail1 { get; set; }
        public string Thumbnail2 { get; set; }
        public int DisplayOrder { get; set; }
        public string Thumbnail3 { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsActive { get; set; }
    }
}
