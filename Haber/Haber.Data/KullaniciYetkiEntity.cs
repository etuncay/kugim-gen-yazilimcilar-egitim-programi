
using Haber.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Data
{
    public class KullaniciYetkiEntity : BaseEntity
    {
        [ForeignKey("Kullanici")]
        public int KullaniciId { get; set; }
        public EnumYetki Yetki { get; set; }

        public virtual KullaniciEntity Kullanici { get; set; }
    }
}
