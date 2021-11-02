using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models.ViewModels
{
    public class IletisimViewModel : BaseViewModel
    {
        public int IlId { get; set; }
        public int IlceId { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
    }
}
