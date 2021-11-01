using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.Data
{
    public class AnaDersEntity : BaseEntity
    {
        [ForeignKey("UstAnaDers")]
        public int? UstId { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Aktif { get; set; } = true;


        public virtual AnaDersEntity UstAnaDers { get; set; }

    }
}
