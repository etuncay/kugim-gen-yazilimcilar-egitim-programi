using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Data
{
    public class KategoriEntity : BaseEntity
    {
        public string Ad { get; set; }
        public string Aciklama { get; set; }

        public virtual  ICollection<IcerikEntity> Icerikler { get; set; }
    }
}
