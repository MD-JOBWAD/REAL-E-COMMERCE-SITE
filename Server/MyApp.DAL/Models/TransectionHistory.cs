using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.DAL.Models
{
    public class TransectionHistory
    {
        public long ID { get; set; }
        public long OrderID { get; set; }
        public double PayableAmount { get; set; }
        public double PaidAmount { get; set; }
        public string PaymentMedia { get; set; }
        public long PamentRefID { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime DTPaid { get; set; }
        public bool IsSuccess { get; set; }

        public virtual Order Orders { get; set; }
    }
}

