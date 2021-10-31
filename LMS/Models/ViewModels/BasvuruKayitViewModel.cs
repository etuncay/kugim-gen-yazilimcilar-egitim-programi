using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models.ViewModels
{
    public class BasvuruKayitViewModel
    {
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Ad en az 4 en çok 50 karakterden oluşur")]
        public string Ad { get; set; }
        
        
        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Soyad en az 4 en çok 50 karakterden oluşur")]
        public string Soyad { get; set; }
        
        
        [Required(ErrorMessage = "TCNO alanı zorunludur")]
        public string TCNO { get; set; }

        
        [Required(ErrorMessage = "CepTelefonu alanı zorunludur")]
        [StringLength(30, MinimumLength = 7, ErrorMessage = "Cep en az 4 en çok 50 karakterden oluşur")]
        public string CepTelefonu { get; set; }

        
        [Required(ErrorMessage = "Eposta alanı zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir eposta giriniz")]
        public string Eposta { get; set; }

        
        [Required(ErrorMessage = "Başvuru Dosya alanı zorunludur")]
        public IFormFile BasvuruDosya { get; set; }

        
        [Required(ErrorMessage = "Resim Dosya alanı zorunludur")]
        public IFormFile ResimDosya { get; set; }
    }
}
