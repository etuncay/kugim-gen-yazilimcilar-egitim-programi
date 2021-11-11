using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels.Response
{
    public class EtiketResponseViewModel  :BaseReponse
    {
        public string Ad { get; set; }
        public string Slug { get; set; }
    }
}
