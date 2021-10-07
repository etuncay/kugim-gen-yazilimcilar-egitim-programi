using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMuhasebeUygulamasi.satis.Models
{
    public class SatisDbModel
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
    }
}
