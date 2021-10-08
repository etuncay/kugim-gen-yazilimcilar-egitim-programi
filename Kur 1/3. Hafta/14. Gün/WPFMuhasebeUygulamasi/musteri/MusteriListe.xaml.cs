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
using System.Windows.Navigation;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            
            MusteriForm musteriForm = new MusteriForm();

            var seciliMusteri = (MusteriDbModel)MusteriDataGrid.SelectedItem;


            musteriForm.Id.Text = seciliMusteri.Id.ToString();
            musteriForm.Ad.Text = seciliMusteri.Ad;
            musteriForm.Soyad.Text = seciliMusteri.Soyad;
            musteriForm.TCNO.Text = seciliMusteri.TCNO;
            musteriForm.Adres.Text = seciliMusteri.Adres;
            musteriForm.CepTelefonu.Text = seciliMusteri.CepTelefonu;

            musteriForm.EkleBtn.Content = "Güncelle";

            musteriForm.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
