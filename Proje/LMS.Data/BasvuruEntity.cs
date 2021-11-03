using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data
{
    public class BasvuruEntity : BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TCNO { get; set; }
        public string CepTelefonu { get; set; }
        public string Eposta { get; set; }
        public string BasvuruDosyaYol { get; set; }
        public string ResimDosyaYol { get; set; }

        public virtual ICollection<BasvuruSureciEntity> BasvuruSurecleri { get; set; }
    }
}
