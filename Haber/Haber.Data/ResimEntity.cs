using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Data
{
    public class ResimEntity : BaseEntity 
    {
        [ForeignKey("Icerik")]
        public int IcerikId { get; set; }
        public string ResimUrl { get; set; }

        public virtual IcerikEntity Icerik { get; set; }
    }
}
