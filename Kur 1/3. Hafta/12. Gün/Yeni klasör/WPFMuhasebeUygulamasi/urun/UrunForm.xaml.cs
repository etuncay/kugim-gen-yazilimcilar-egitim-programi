using System.Windows;
using WPFMuhasebeUygulamasi.urun.Models;

namespace WPFMuhasebeUygulamasi.urun
{
    /// <summary>
    /// Interaction logic for UrunForm.xaml
    /// </summary>
    public partial class UrunForm : Window
    {
        public UrunForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var model = new UrunDbModel()
            {
                Adi = Adi.Text,
                BirimFiyati = int.Parse(BirimFiyati.Text),
                DepoAdet = int.Parse(DepoAdedi.Text)
            };
            var urunYonetim = new UrunYonetim();

            urunYonetim.Ekle(model);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var urunListe = new UrunListe();

            urunListe.Show();

            this.Close();
        }
    }
}
