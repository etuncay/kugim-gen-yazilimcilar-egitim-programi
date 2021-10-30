using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models.ViewModels
{
    public class KullaniciGirisViewModel
    {
        [Required(ErrorMessage = "Eposta alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli Eposta adresi giriniz")]
        public string Eposta { get; set; }

        [Required(ErrorMessage = "Şifire alanı zorunludur.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Şifre uzunluğu 6 karakter ile 20 karakter arasında olmalıdır.")]
        public string Sifre { get; set; }
    }
}
