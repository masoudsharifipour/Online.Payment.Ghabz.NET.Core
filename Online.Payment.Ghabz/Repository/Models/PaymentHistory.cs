using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online.Payment.Ghabz.Repository.Models
{
    public class PaymentHistory : BaseEntity
    {
        public bool IsPayment { get; set; }

        public string TrakingNumber { get; set; }

        [ForeignKey("GhabzHistoryId")]
        public GhabzHistory GhabzHistory { get; set; }
    }
}
