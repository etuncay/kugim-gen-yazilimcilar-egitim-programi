using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels.Response
{
    public class YorumResponseViewModel :BaseReponse
    {
        public string Govde { get; set; }
        public bool Aktif { get; set; } = false;
        public LabelValueModel Kullanici { get; set; } = new LabelValueModel();
    }
}
