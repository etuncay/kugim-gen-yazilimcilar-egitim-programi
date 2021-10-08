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
using WPFMuhasebeUygulamasi.musteri;
using WPFMuhasebeUygulamasi.musteri.Models;
using WPFMuhasebeUygulamasi.satis.Models;
using WPFMuhasebeUygulamasi.urun;
using WPFMuhasebeUygulamasi.urun.Models;

namespace WPFMuhasebeUygulamasi.satis
{
    /// <summary>
    /// Interaction logic for SatisListe.xaml
    /// </summary>
    public partial class SatisListe : Window
    {
        private MusteriYonetim musteriYonetim = new MusteriYonetim();
        private UrunYonetim urunYonetim = new UrunYonetim();
        private SatisYonetim satisYonetim = new SatisYonetim();
        public SatisListe()
        {
            InitializeComponent();

            musteriYonetim.DataGridYenile(MusteriDataGrid);
            urunYonetim.DataGridYenile(UrunDataGrid);
            satisYonetim.DataGridYenile(SatisDataGrid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var seciliUrun = (UrunDbModel)UrunDataGrid.SelectedItem;

            var seciliMusteri = (MusteriDbModel)MusteriDataGrid.SelectedItem;

            if(seciliUrun!=null && seciliMusteri != null)
            {
                var adet = (int)Math.Floor(AdetSecimi.Value);
                if (adet > 0)
                {
                    satisYonetim.SatisYap(new Models.SatisDbModel
                    {
                        Adet = adet,
                        MusteriId = seciliMusteri.Id,
                        UrunId = seciliUrun.Id
                    });

                    satisYonetim.DataGridYenile(SatisDataGrid);
                }
                else
                {
                    MessageBox.Show("Lütfen adet giririniz");
                }
               
            }
        }

        private void AdetSecimi_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            AdetSecimiLabel.Content = Math.Floor(AdetSecimi.Value).ToString() ;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();

            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var seciliSatis = (SatisDataGridModel)SatisDataGrid.SelectedItem;

            var result = MessageBox.Show("Silmek istediğinize eminmisiniz", "Silme İşlemi",MessageBoxButton.YesNo);
        
            if(result == MessageBoxResult.Yes)
            {
                satisYonetim.Sil(seciliSatis.Id);
                satisYonetim.DataGridYenile(SatisDataGrid);
            }
        }
    }
}
