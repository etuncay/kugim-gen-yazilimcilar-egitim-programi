using System;

namespace HataYakalamaUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Yaşınızı Giriniz: ");
            //var yas = Console.ReadLine();
            Console.WriteLine("İsminizi Giriniz");
            var ismi = Console.ReadLine();
            var yasInt = 0;
            
            try
            {
                // yasInt = int.Parse(yas);
                var ilkUcHarfi = ismi.Substring(0, 3);
                Console.WriteLine("Yaşınız : " + yasInt);
            }
            catch (Exception ex)
            {
                var hata = ex.Message;
                //Console.WriteLine("Lütfen geçerli bir değer giriniz.Giriş yaş değeri : " + yas);
            }
            

        }
    }
}
