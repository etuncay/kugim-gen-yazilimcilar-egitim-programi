
using System.ComponentModel.DataAnnotations.Schema;

namespace Haber.Data
{
    public class YorumEntity : BaseEntity 
    {
        [ForeignKey("Icerik")]
        public int IcerikId { get; set; }
        public string Govde { get; set; }
        public bool Aktif { get; set; } = false;


        public virtual  IcerikEntity Icerik { get; set; }
    }
}
