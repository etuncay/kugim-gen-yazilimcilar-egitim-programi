using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels.Response
{
    public class YorumResponseViewComponent
    {
        public LabelValueModel Kullanici { get; set; }
        public string Govde { get; set; }
        public bool Aktif { get; set; } 
    }
}
