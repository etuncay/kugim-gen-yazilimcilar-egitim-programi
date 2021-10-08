using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFMuhasebeUygulamasi.musteri;
using WPFMuhasebeUygulamasi.odeme;
using WPFMuhasebeUygulamasi.satis;
using WPFMuhasebeUygulamasi.urun;

namespace WPFMuhasebeUygulamasi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            if (!File.Exists(VeritabaniTanimlama.Musteriler))
            {
                File.Create(VeritabaniTanimlama.Musteriler);
            }

            if (!File.Exists(VeritabaniTanimlama.Urunler))
            {
                File.Create(VeritabaniTanimlama.Urunler);
            }

            if (!File.Exists(VeritabaniTanimlama.Odemeler))
            {
                File.Create(VeritabaniTanimlama.Odemeler);
            }
            if (!File.Exists(VeritabaniTanimlama.Satislar))
            {
                File.Create(VeritabaniTanimlama.Satislar);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var satislarPencere = new SatisListe();

            satislarPencere.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var musteriPencere = new MusteriListe();

            musteriPencere.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var urunlerPencere = new UrunListe();

            urunlerPencere.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var odemelerPencere = new OdemeListe();
            odemelerPencere.Show();

            this.Close();

            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
