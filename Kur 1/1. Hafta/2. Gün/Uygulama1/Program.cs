using System;
using System.Collections.Generic;

namespace Uygulama1
{
    class Program
    {
        static void Main(string[] args)
        {
            var diziDeger = 5;

            var yasDizisi = new int[diziDeger];

            for (int i = 0; i < diziDeger; i++)
            {
                var kisi = i + 1;

                Console.Write(kisi + " Kişi Doğum yılı = ");
                var dyString = Console.ReadLine();
                var dyInt = int.Parse(dyString);

                yasDizisi[i] = dyInt;

            }
            var suankiyil = DateTime.Now.Year;

            for (int i = 0; i < diziDeger; i++)
            {
                var yas = suankiyil - yasDizisi[i];
                var kisi = i + 1;
                Console.WriteLine(kisi + " nin yaşı = " + yas);
            }

            Console.WriteLine(" sayı çift sayıdır.");

            //Console.WriteLine(adet + " sayı çift sayıdır.");

            //int adet = 0;
            //for (int i = 0; i < 15; i++)
            //{
            //    Console.Write((i + 1) + " Sayıyı Giriniz =");
            //    var sayiString = Console.ReadLine();

            //    var sayiInt = int.Parse(sayiString);
            //    if (sayiInt > 0)
            //    {
            //        adet = adet + 1;
            //    }
            //}

            //Console.WriteLine(adet + " sayı 0 dan büyüktür");


            //for (int i = 0; i < 5; i++)
            //{
            //    var kisi = i+1;

            //    Console.Write(kisi + " Kişi Doğum yılı = ");
            //    var dyString = Console.ReadLine();
            //    var dyInt = int.Parse(dyString);
            //    var suankiyil = DateTime.Now.Year;
            //    var yas = suankiyil - dyInt;
            //    Console.WriteLine(kisi + " nin yaşı = " + yas);
            //}


            //Console.WriteLine("A Değerini Giriniz");
            //var aString = Console.ReadLine();
            //Console.WriteLine("B Değerini Giriniz");
            //var bString = Console.ReadLine();

            //int aIntx = int.Parse(aString);
            //int bInty = int.Parse(bString);
            //var c = 0;
            //for (int i = 0; i < 5; i++)
            //{
            //    c = c + aIntx + bInty;
            //}

            //Console.WriteLine("Toplam Değer =" + c);

            //var mesaj = "";
            //if(aIntx> bInty)
            //{
            //    mesaj = "A";
            //}
            //else
            //{
            //    mesaj = "B";
            //}
            //Console.WriteLine("En büyük sayı =" + mesaj);


            //int c =0;

            //if (aIntx > bInty)
            //{
            //    c = aIntx * bInty;
            //}
            //else
            //{
            //    c = aIntx + bInty;
            //}



            //Console.WriteLine("Toplam ="+ c);


        }
    }
}
