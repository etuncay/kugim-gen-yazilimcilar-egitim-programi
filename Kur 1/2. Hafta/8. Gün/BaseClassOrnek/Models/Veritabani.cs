using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassOrnek.Models
{
    public static class Veritabani
    {

        public static int KisiId { get; set; } = 1;
        public static int PersonelId { get; set; } = 1;
        public static int OgrenciId { get; set; } = 1;
        public static List<KisiModel> Kisi { get; set; } = new List<KisiModel>();
        public static List<PersonelModel> Personel { get; set; } = new List<PersonelModel>();
        public static List<OgrenciModel> Ogrenci { get; set; } = new List<OgrenciModel>();
    }
}
