using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models.ViewModels
{
    public class KullaniciKayitViewModel
    {
        [Required (ErrorMessage ="Ad alanı zorunludur.")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="Adınız 3 karakterden az olamaz")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Soyadınız 3 karakterden az olamaz")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Eposta alanı zorunludur.")]
        [EmailAddress(ErrorMessage ="Geçerli Eposta adresi giriniz")]
        public string Eposta { get; set; }
        [Required(ErrorMessage = "Şifire alanı zorunludur.")]
        [StringLength(20, MinimumLength =6, ErrorMessage ="Şifre uzunluğu 6 karakter ile 20 karakter arasında olmalıdır.")]
        public string Sifre { get; set; }
        [Required(ErrorMessage = "Şifre Doğrula alanı zorunludur.")]
        [Compare("Sifre",ErrorMessage ="Şifre ile uyuşmamaktadır.")]
        public string SifreDogrula { get; set; }
    }
}
