using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models.ViewModels
{
    public class KullaniciViewModel : BaseViewModel
    {
       
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string Yetki { get; set; }
        public bool Aktif { get; set; } = true;
        
    }
}
