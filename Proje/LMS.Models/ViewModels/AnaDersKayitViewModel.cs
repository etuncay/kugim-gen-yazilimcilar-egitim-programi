using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models.ViewModels
{
    public class AnaDersKayitViewModel
    {
        public int? UstId { get; set; }
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [StringLength(200, ErrorMessage = "En az 5 en çok 200 karakter giriniz", MinimumLength = 5)]
        public string Ad { get; set; }
        [StringLength(500, ErrorMessage = "En çok 500 karakter giriniz")]
        public string Aciklama { get; set; }
        [Required(ErrorMessage = "Aktif alanı zorunludur")]
        public bool Aktif { get; set; } = true;
    }
}
