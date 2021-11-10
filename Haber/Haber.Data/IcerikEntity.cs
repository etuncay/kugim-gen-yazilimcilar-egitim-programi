using Haber.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Data
{
    public class IcerikEntity  :BaseEntity
    {
        public string Baslik { get; set; }
        public EnumIcerikTipi IcerikTipi { get; set; }
        [ForeignKey("Kategori")]
        public int KategoriId { get; set; }
        public string ResimUrl { get; set; }
        public string Ozet { get; set; }
        public string Govde { get; set; }

        public virtual KategoriEntity Kategori { get; set; }

        public virtual ICollection<ResimEntity> Resimler { get; set; }
        public virtual ICollection<YorumEntity> Yorumlar { get; set; }
        public virtual ICollection<IcerikEtiketEntity> IcerikEtiketler { get; set; }
    }
}
