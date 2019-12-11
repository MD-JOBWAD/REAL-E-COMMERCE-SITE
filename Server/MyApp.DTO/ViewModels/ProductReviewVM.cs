using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.DTO.ViewModels
{
    public class ProductReviewVM
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public string UserID { get; set; }
        public string fkUserReviewGave { get; set; }
        [Required]
        public string Review { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; }
        [Required]
        public bool IsApproved { get; set; }
    }
}
