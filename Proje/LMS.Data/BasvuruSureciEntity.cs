using LMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data
{
    public class BasvuruSureciEntity : BaseEntity
    {
        [ForeignKey("Basvuru")]
        public int BasvuruId { get; set; }

        public EnumBasvuruSurecTipi BasvuruSurecTipi { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }


        public virtual BasvuruEntity Basvuru { get; set; }
    }
}
