using System;
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


            try
            {
                var model = new UrunDbModel()
                {
                    Adi = Adi.Text,
                    BirimFiyati = int.Parse(BirimFiyati.Text),
                    DepoAdet = int.Parse(DepoAdedi.Text)
                };
                var urunYonetim = new UrunYonetim();

                if (int.TryParse(Id.Text.ToString(), out int id))
                {
                    model.Id = id;
                    urunYonetim.Guncelle(model);
                    MessageBox.Show("Güncelleme İşlemi Tamamlandı.");

                }
                else
                {

                    urunYonetim.Ekle(model);
                    MessageBox.Show("Ekleme İşlemi Tamamlandı.");

                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("İşlem Yapılırken Hata Oluştur. Mesaj ="+ ex.Message);
            }
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var urunListe = new UrunListe();

            urunListe.Show();

            this.Close();
        }
    }
}
