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
using WPFMuhasebeUygulamasi.odeme.Models;

namespace WPFMuhasebeUygulamasi.odeme
{
    /// <summary>
    /// Interaction logic for OdemeListe.xaml
    /// </summary>
    public partial class OdemeListe : Window
    {
            private OdemeYonetim odemeYonetim = new OdemeYonetim();


        public OdemeListe()
        {
            InitializeComponent();
            odemeYonetim.DataGridYenile(OdemeDataGrid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var seciliOdeme = (OdemeDataGridModel)OdemeDataGrid.SelectedItem;

            if (seciliOdeme != null)
            {
                odemeYonetim.OdemeYap(new OdemeDbModel
                {
                    SatisId = seciliOdeme.SatisId,
                    ToplamFiyat = seciliOdeme.ToplamFiyat
                });
                odemeYonetim.DataGridYenile(OdemeDataGrid);
            }
            else
            {
                MessageBox.Show("Lütfen Seçim Yapınız");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();

            main.Show();

            this.Close();
        }
    }
}
