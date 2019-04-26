using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online.Payment.Ghabz.Repository.Models
{
    public class GhabzHistory : BaseEntity
    {
        public string ShenaseGhabz { get; set; }

        public string ShenasePardakht { get; set; }

        public int Price { get; set; }

        public string Type { get; set; }

    }
}
