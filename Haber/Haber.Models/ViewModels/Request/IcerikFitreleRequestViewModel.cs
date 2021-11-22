using Haber.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels.Request
{
    public class IcerikFitreleRequestViewModel
    {
        public SayfalamaViewModel Sayfalama { get; set; } = new SayfalamaViewModel();
        public int? KategoriId { get; set; }
        public EnumIcerikTipi? IcerikTipi { get; set; }
        public string AraString { get; set; }
    }
}
