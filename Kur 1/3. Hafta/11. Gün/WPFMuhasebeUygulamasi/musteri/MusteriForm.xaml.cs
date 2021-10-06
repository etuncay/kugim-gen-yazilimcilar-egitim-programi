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
    }
}
