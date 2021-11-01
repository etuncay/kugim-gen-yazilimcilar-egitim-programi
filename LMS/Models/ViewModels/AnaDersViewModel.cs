using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models.ViewModels
{
    public class AnaDersViewModel : BaseViewModel
    {
        public int? UstId { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Aktif { get; set; } = true;
    }
}
