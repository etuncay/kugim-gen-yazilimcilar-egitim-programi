using Haber.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models.ViewModels.Response
{
    public class IcerikResponseViewModel  :BaseReponse
    {
        public string Baslik { get; set; }
        public string Slug { get; set; }

        public LabelValueModel IcerikTipi { get; set; }
        public LabelValueModel Kategori { get; set; }
        public string ResimUrl { get; set; }
        public string Ozet { get; set; }
        public string Govde { get; set; }

        public List<YorumResponseViewModel> Yorumlar { get; set; }
        public List<ResimResponseViewModel> Resimler { get; set; }
        public List<LabelValueModel> Etiketler { get; set; }
    }
}
