using System;
using System.Collections.Generic;

namespace ForeachUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            var isimler = new List<string>()
            {
                "Ahmet",
                "Mehmet",
                "Ali",
                "Hatice",
                "Ayşe",
                "Fatma"
            };

            

            //for (int i = 0; i < isimler.Count; i++)

            foreach (var isim in isimler)
            {
               // var isim = isimler[i];
                var isimHeceleri = isim.Split('e');
                Console.WriteLine("İsim : " + isim);
                if (isimHeceleri.Length > 1)
                {
                    Console.WriteLine("e karakteri ile bölünen kelimeler : ");
                    foreach (var hece in isimHeceleri)
                    {
                        Console.Write(hece + ", ");
                    }
                }
                Console.WriteLine();                
            }


            isimler.ForEach(isim =>
            {
                var isimHeceleri = isim.Split('e');
                Console.WriteLine("İsim : " + isim);
                if (isimHeceleri.Length > 1)
                {
                    Console.WriteLine("e karakteri ile bölünen kelimeler : ");
                    foreach (var hece in isimHeceleri)
                    {
                        Console.Write(hece + ", ");
                    }
                }
                Console.WriteLine();
            });
        }
    }
}
