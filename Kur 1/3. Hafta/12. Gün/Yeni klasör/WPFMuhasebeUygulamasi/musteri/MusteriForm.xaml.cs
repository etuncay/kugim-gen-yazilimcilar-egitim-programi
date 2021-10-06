using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WPFMuhasebeUygulamasi.musteri.Models;

namespace WPFMuhasebeUygulamasi.musteri
{
    /// <summary>
    /// Interaction logic for MusteriForm.xaml
    /// </summary>
    public partial class MusteriForm : Window
    {
        public MusteriForm()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var musteriListe = new MusteriListe();
            musteriListe.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var formData = new MusteriDbModel
            {
                Ad = Ad.Text,
                Soyad = Soyad.Text,
                TCNO = TCNO.Text,
                Adres = Adres.Text,
                CepTelefonu = CepTelefonu.Text
            };

            var musteriYonetim = new MusteriYonetim();

            musteriYonetim.Ekle(formData);


        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
