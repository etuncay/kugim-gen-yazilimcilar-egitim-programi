using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels.Response
{
    public class TokenResponseResultViewModel
    {
        public string kullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string FotografUrl { get; set; }
        public string Token { get; set; }
    }
}
