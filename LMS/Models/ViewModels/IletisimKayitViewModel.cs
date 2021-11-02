using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models.ViewModels
{
    public class IletisimKayitViewModel
    {
        [Required]
        public int IlceId { get; set; }
        [Required]
        [StringLength(5 , ErrorMessage ="En az 5 karakter giriniz")]
        public string Adres { get; set; }
        [Required]
        public string Telefon { get; set; }
    }
}
