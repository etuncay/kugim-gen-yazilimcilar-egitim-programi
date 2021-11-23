using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels.Request
{
    public class YorumRequestViewModel
    {
        public int IcerikId { get; set; }
        public int KullaniciId { get; set; }
        public string Govde { get; set; }
        public bool Aktif { get; set; } = false;
    }
}
