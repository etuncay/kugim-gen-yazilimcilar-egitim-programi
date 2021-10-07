using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMuhasebeUygulamasi
{
    public static class VeritabaniTanimlama
    {
        private static string AnaDosyaYolu { get; set; } = Directory.GetCurrentDirectory();
        public static string Musteriler { get; set; } = AnaDosyaYolu + "\\musteriler.txt";
        public static string Urunler { get; set; } = AnaDosyaYolu + "\\urunler.txt";
        public static string Odemeler { get; set; } = AnaDosyaYolu + "\\odemeler.txt";
        public static string Satislar { get; set; } = AnaDosyaYolu + "\\satislar.txt";
    }
}
