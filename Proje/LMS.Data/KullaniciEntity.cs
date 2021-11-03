using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data
{
    public class KullaniciEntity : BaseEntity
    {
        [Required]
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [Required]
        public string Eposta { get; set; }
        [Required]
        public string Sifre { get; set; }
        public string Yetki { get; set; }
        [Required]
        public bool Aktif { get; set; } = true;
    }
}
