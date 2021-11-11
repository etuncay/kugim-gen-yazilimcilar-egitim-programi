using Haber.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels.Request
{
    public class IcerikRequestViewModel
    {
        public string Baslik { get; set; }
        public EnumIcerikTipi IcerikTipi { get; set; }
        public int KategoriId { get; set; }
        public string ResimUrl { get; set; }
        public string Ozet { get; set; }
        public string Govde { get; set; }
    }
}
