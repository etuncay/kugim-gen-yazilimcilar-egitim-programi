using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models.Data
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
        [Required]
        public string AktivasyonKey { get; set; }
        [Required]
        public DateTime AktivasyonSonTarihSaat { get; set; }
        [Required]
        public bool Aktif { get; set; } = false;
    }
}
