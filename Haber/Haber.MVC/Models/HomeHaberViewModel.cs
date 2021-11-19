using Haber.Models.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haber.MVC.Models
{
    public class HomeHaberViewModel
    {
        public List<IcerikResponseViewModel> MansetHaberleri { get; set; }
    }
}
