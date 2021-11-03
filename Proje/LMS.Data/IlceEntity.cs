using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data
{
    public class IlceEntity : BaseEntity
    {
        [ForeignKey("Il")]
        public int IlId { get; set; }
        public string Tanim { get; set; }

        public virtual   IlEntity Il { get; set; }
    }
}
