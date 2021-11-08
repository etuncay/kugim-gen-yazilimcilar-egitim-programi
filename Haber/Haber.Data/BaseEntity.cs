using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Data
{
    public abstract class BaseEntity
    {
        [Key] //Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Auto Increment
        [Required] //Zorunlu
        public int Id { get; set; }
        [Required]
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now; //Varsayılan Değer Ataması
        public DateTime? GuncellenmeTarihi { get; set; }
    }
}
