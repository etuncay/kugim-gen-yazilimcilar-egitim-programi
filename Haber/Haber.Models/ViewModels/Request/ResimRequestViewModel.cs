using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels.Request
{
    public class ResimRequestViewModel
    {
        public int IcerikId { get; set; }
        public string ResimUrl { get; set; }
        public string Aciklama { get; set; }
    }
}
