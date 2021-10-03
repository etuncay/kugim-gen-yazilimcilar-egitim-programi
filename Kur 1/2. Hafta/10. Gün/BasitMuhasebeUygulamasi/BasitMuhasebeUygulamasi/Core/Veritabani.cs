using BasitMuhasebeUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitMuhasebeUygulamasi.Core
{
    public static class Veritabani
    {
        public static int MusteriId { get; set; } = 1;
        public static int UrunId { get; set; } = 1;
        public static int SatisId { get; set; } = 1;
        public static int OdemeId { get; set; } = 1;
        public static List<MusteriModel> Musteri { get; set; } = new List<MusteriModel>();
        public static List<UrunModel> Urun { get; set; } = new List<UrunModel>();
        public static List<SatisModel> Satis { get; set; } = new List<SatisModel>();
        public static List<OdemeModel> Odeme { get; set; } = new List<OdemeModel>();
    }
}
