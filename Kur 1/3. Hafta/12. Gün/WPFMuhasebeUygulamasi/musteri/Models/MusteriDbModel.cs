using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMuhasebeUygulamasi.musteri.Models
{
    public class MusteriDbModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TCNO { get; set; }
        public string Adres { get; set; }
        public string CepTelefonu { get; set; }
    }
}
