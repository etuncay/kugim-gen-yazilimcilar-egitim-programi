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
    /// Interaction logic for MusteriListe.xaml
    /// </summary>
    public partial class MusteriListe : Window
    {
        public MusteriListe()
        {
            InitializeComponent();

            var musteriYonetim = new MusteriYonetim();

            musteriYonetim.DataGridYenile(MusteriDataGrid);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var musteriForm = new MusteriForm();

            musteriForm.Show();
            this.Close();
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var musteriForm = new MainWindow();

            musteriForm.Show();
            this.Close();
        }
    }
}
