using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeData.Models
{
    /*
     Id
Ad
Soyad
TCNO
DogumTarihi
DogumYeri
ResimUrl
     */

    public class Nufus
    {
        public int Id { get; set; }
        public string  Ad { get; set; }
        public string Soyad { get; set; }
        public string TCNO { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string DogumYeri { get; set; }
        public string ResimUrl { get; set; }
    }
}
