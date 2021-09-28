using System;

namespace Arabam
{
    class Araba
    {
        public string _arabaAdi = "";
        
        public Araba(string ArabaAdi)
        {
            _arabaAdi = ArabaAdi;
        }

        public Araba(int arabaNumara)
        {
            switch (arabaNumara)
            {
                case 1:
                    _arabaAdi = "Mercedes";
                    break;
                case 2:
                    _arabaAdi = "BMW";
                    break;
                case 3:
                    _arabaAdi = "Renault";
                    break;
                case 4:
                    _arabaAdi = "Tofaş";
                    break;

                default:
                    _arabaAdi = "Tanımli Değil";
                    break;
            }
        }

        public void TekerHavaBasincKontrol()
        {
            Console.WriteLine(_arabaAdi + " markalı arabanın tekerlek hava basınçları kontrol edildi.");
        }

        public void BenzinKontrol()
        {
            Console.WriteLine(_arabaAdi + " markalı arabanın benzini kontrol edildi.");
        }

        public void MotorYagiKontrol()
        {
            Console.WriteLine(_arabaAdi+ " markalı arabanın motor yağı kontrol edildi.");
        }        

    }
}
