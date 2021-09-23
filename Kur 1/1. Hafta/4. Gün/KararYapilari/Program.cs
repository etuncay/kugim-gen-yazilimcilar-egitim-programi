using System;

namespace KararYapilari
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Lütfen yaşınızı giriniz: ");
            var yasString = Console.ReadLine();

            var yasInt = int.Parse(yasString);

            var yasiniz18denBuyukmu = (yasInt > 18) ? true : false;
            
            

            if (yasInt > 18)
            {
                yasiniz18denBuyukmu = true;
            }
            else
            {
                yasiniz18denBuyukmu = false;
            }

            var fahriPolisOlabilirmisiniz = false;

            if (yasInt > 40) 
                fahriPolisOlabilirmisiniz = true;
            else if (yasInt > 18) 
                yasiniz18denBuyukmu = true;
            else if (yasInt < 0) 
                yasiniz18denBuyukmu = false;
            else if (yasInt < 18) 
                yasiniz18denBuyukmu = false;



            if (yasInt >= 40)
            {
                Console.WriteLine("Fahri Polis olabilirsiniz");
            }else if(yasInt >= 18)
            {
                Console.WriteLine("Ehliyet alabilirsiniz");
            }
            else if(yasInt < 0)
            {
                Console.WriteLine("Yaşınız 0 dan küçük olamaz");
            }
            else if (yasInt <= 18)
            {
                Console.WriteLine("Ehliyet alamazsınız");
            }
            else
            {

            }

            switch (yasInt)
            {
                case  >= 40 :
                    Console.WriteLine("Fahri Polis olabilirsiniz --1");
                break;
                case >= 18:
                    Console.WriteLine("Ehliyet alabilirsiniz --1");
                break;
                case < 0:
                    Console.WriteLine("Yaşınız 0 dan küçük olamaz --1");
                break;
                case < 18:
                    Console.WriteLine("Ehliyet alamazsınız --1");
                break;
            }

            switch (yasInt)
            {
                case 18:
                    Console.WriteLine("Yaşınız 18 dir");
                    break;
                default:
                    Console.WriteLine("yaş 18 değil");
                    break;
            }
        }
    }
}
