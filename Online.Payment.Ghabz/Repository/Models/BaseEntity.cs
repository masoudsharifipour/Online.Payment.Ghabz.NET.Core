using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online.Payment.Ghabz.Repository.Models
{
    public class BaseEntity
    {
        public long Id { get; set; }
        [DisplayName("تاریخ ثبت")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CretionDate => DateTime.Now;
    }
}
