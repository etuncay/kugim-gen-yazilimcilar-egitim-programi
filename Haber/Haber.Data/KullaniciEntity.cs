using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Data
{
    public class KullaniciEntity : BaseEntity
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Eposta { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public virtual ICollection<KullaniciYetkiEntity> KullaniciYetki { get; set; }
    }
}
