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
    }
}
