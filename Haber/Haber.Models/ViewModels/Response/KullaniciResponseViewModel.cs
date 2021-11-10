using Haber.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels.Response
{
    public class KullaniciResponseViewModel : BaseReponse
    {
        public string KullaniciAdi { get; set; }
        public string Eposta { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public List<EnumYetki> Yetkiler { get; set; } = new List<EnumYetki>();
    }
}
