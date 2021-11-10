using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Data
{
    public class EtiketEntity : BaseEntity
    {
        public string Ad { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<IcerikEtiketEntity>  IcerikEtiketler { get; set; }
    }
}
