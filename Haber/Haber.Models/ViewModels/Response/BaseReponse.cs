using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels.Response
{
    public abstract class BaseReponse
    {
        public int Id { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public DateTime? GuncellenmeTarihi { get; set; }
    }
}
