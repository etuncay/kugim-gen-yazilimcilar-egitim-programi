using System;
using System.Collections.Generic;

namespace Uygulama3
{
    class Program
    {
        static void Main(string[] args)
        {
            string kisiAdi = "Mehmet ";


            int kisiYasi = 1;
            int kisiYasi1 = 1;
            string kisiYasi2String = "15";

            

            var toplamKisiYasi = 5;

            toplamKisiYasi = toplamKisiYasi + kisiYasi--;


            if ((kisiYasi != toplamKisiYasi || kisiYasi1 != toplamKisiYasi) && (kisiYasi1 > 5))
            {

            }

            kisiYasi1 = kisiYasi1 + 10;
            kisiYasi1 += 10;

            kisiYasi1 = kisiYasi1 - 10;
            kisiYasi1 -= 10;
            var sonuc = kisiYasi == 5 ? true : false;

            if (kisiYasi == 5)
            {
                sonuc = true;
            }
            else
            {
                sonuc = false;
            }

            


            double? rakam = 1.1;

            var harf = "a";
            char harf2 = 'a';

            bool? deger = true;

            var modsayisi = 125 % 3;


            List<int> IntDizi2 = new List<int>();

            IntDizi2.Add(10);

            int[] IntDizi = new int[10];
            IntDizi[0] = 10;


            List<string> stringDizi1 = new List<string>();

            stringDizi1.Add("Emrullah");
            stringDizi1.Add("Mehmet");
            stringDizi1.Add("Ahmet");

            string[] stringDizi2 = new string[10];
            stringDizi2[0] = "Emrullah";
            stringDizi2[1] = "Mehmet";
            stringDizi2[2] = "Ahmet";

            bool[] boolDizi = new bool[10];

            boolDizi[0] = true;
            boolDizi[11] = true;









            Console.WriteLine("Hello World!");
        }
    }
}
