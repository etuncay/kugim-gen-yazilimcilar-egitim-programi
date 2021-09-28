using System;

namespace Arabam
{
    class Program
    {
        static void Main(string[] args)
        {
            var arabam1 = new Araba("Mercedes");
            var arabam2 = new Araba(3);
            var arabam3 = new Araba(2);

            arabam1.MotorYagiKontrol();
            arabam1.TekerHavaBasincKontrol();
            arabam1.BenzinKontrol();

            arabam2.MotorYagiKontrol();
            arabam2.TekerHavaBasincKontrol();
            arabam2.BenzinKontrol();

            arabam3.MotorYagiKontrol();
            arabam3.TekerHavaBasincKontrol();
            arabam3.BenzinKontrol();

            

            Console.WriteLine("Hello World!");
        }
    }
}
