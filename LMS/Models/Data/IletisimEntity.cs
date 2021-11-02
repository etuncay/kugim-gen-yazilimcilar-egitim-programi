using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models.Data
{
    public class IletisimEntity : BaseEntity
    {
        [ForeignKey("Kullanici")]
        public int KullaniciId { get; set; }
        [ForeignKey("Ilce")]
        public int IlceId { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }


        public virtual  KullaniciEntity Kullanici{ get; set; }
        public virtual IlceEntity Ilce { get; set; }
    }
}
