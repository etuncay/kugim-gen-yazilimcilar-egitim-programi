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
using WPFMuhasebeUygulamasi.satis;
using WPFMuhasebeUygulamasi.urun.Models;

namespace WPFMuhasebeUygulamasi.urun
{
    /// <summary>
    /// Interaction logic for UrunListe.xaml
    /// </summary>
    public partial class UrunListe : Window
    {
        public UrunListe()
        {
            InitializeComponent();

            var urunYonetim = new UrunYonetim();

            urunYonetim.DataGridYenile(UrunDataGrid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var urunForm = new UrunForm();

            urunForm.Show();

            this.Close();
        }

        private void UrunDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var urunForm = new UrunForm();

            var seciliUrun = (UrunDbModel)UrunDataGrid.SelectedItem;

            urunForm.Id.Text = seciliUrun.Id.ToString();
            urunForm.Adi.Text = seciliUrun.Adi;
            urunForm.BirimFiyati.Text = seciliUrun.BirimFiyati.ToString();
            urunForm.DepoAdedi.Text = seciliUrun.DepoAdet.ToString();

            urunForm.EkleBtn.Content = "Güncelle";

            urunForm.Show();

            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var seciliUrun = (UrunDbModel)UrunDataGrid.SelectedItem;

            if (seciliUrun != null)
            {
                var satisYonetim = new SatisYonetim();

                var satis = satisYonetim.Getir(seciliUrun.Id);
                if (satis == null)
                {
                    MessageBoxResult result = MessageBox.Show(seciliUrun.Adi + " Ürününü Silmek istediğinize eminmisiniz ?",
                                "Silme İşlemi", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        var urunYonetim = new UrunYonetim();

                        urunYonetim.Sil(seciliUrun.Id);
                        urunYonetim.DataGridYenile(UrunDataGrid);

                    }
                }
                else
                {
                    MessageBox.Show(seciliUrun.Adi + " ürünün satış işlemi öncede yapılmıştır. Silinemez");
                }

                
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün seçiniz?");
            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();

            mainWindow.Show();

            this.Close();
        }
    }
}
