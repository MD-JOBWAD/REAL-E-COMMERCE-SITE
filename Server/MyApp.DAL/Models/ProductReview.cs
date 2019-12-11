using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class ProductReview
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public string UserID { get; set; }
        public string fkUserReviewGave { get; set;  }
        public string Review { get; set;  }
        public DateTime ReviewDate { get; set; }
        public bool IsApproved { get; set;  }

        public virtual Product Products { get; set; }
    }
}
