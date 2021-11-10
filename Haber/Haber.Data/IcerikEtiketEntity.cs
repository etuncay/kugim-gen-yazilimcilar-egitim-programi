using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Data
{
    public class IcerikEtiketEntity : BaseEntity
    {
        [ForeignKey("Icerik")]
        public int IcerikId { get; set; }
        [ForeignKey("Etiket")]
        public int EtiketId { get; set; }

        public virtual IcerikEntity Icerik { get; set; }
        public virtual EtiketEntity Etiket { get; set; }
    }
}
