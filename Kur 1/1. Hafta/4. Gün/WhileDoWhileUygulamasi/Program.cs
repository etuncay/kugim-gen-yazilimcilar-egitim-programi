using System;

namespace WhileDoWhileUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            var sayi = 0;
            while (sayi<=10)
            {
                Console.WriteLine(sayi+" *");
                sayi = sayi+1;
            }
            sayi = 0;
            Console.WriteLine("-----------------------------");
            do
            {
                Console.WriteLine(sayi + " *");
                sayi = sayi + 1;
            } while (sayi <= 10);
        }
    }
}
