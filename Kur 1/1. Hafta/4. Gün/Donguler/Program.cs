using System;
using System.Collections.Generic;

namespace Donguler
{
    class Program
    {
        static void Main(string[] args)
        {
            var yasListesi2 = new int[10];
            yasListesi2[0] = 15;
            yasListesi2[1] = 2;
            yasListesi2[2] = 25;
            yasListesi2[3] = 6;
            yasListesi2[4] = 15;
            yasListesi2[5] = 25;
            yasListesi2[6] = 36;
            yasListesi2[7] = 5;
            yasListesi2[8] = 55;
            yasListesi2[9] = 48;


            var yasListesi = new List<int>() { 
                15,2,25,6
            }; 
            yasListesi.Add(15);
            yasListesi.Add(25);
            yasListesi.Add(36);
            yasListesi.Add(5);
            yasListesi.Add(55);
            yasListesi.Add(48);

            var listesayisi = yasListesi.Count;


            for (int i = 0; i < listesayisi; i++)
            {
                int yas = yasListesi[i];

                if (yas >= 18)
                {
                    if (yas >= 40)
                    {
                        Console.WriteLine("Fahri Polis Olablirsiniz.");
                    }
                    else
                    {
                        Console.WriteLine("Ehliyet Alabilirsiniz...");
                    }     
                }
                else
                {
                    Console.WriteLine("Ehliyet Alamazsınız,,,");
                }
            }
            
        }
    }
}
