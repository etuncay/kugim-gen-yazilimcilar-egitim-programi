using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels.Response
{
    public class ResimResponseViewModel :BaseReponse
    {
        public string ResimUrl { get; set; }
        public string Aciklama { get; set; }
    }
}
