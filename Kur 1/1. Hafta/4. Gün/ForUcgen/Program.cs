using System;

namespace ForUcgen
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j <(i+1) ; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            var boslukSayisi = 10;
            
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < boslukSayisi; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < (i+1); k++)
                {
                    Console.Write("**");                    
                }
                boslukSayisi = boslukSayisi - 1;
                Console.WriteLine();
            }
        }        
    }
}
