using System;

namespace KisiDefteri
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kişi Bilgileri
            // Kişi Bilgileri Listele
            // Kişi Bilgisi Ekle
            // Kişi Bilgisi Güncelle
            // Kişi Bilgisi Sil
            
            var defter = new string[100,2];
            var cikis = true;
            var i = 0;
            while (cikis)
            {
                Menu();
                Console.WriteLine("İşlem yapmak için rakam giriniz");
                var menuRakamiString = Console.ReadLine();
                try
                {
                    var menurakamiInt = int.Parse(menuRakamiString);

                    Console.Clear();
                    switch (menurakamiInt)
                    {
                        case 1:
                            Console.WriteLine("###### Kişi Listesi ###### ");
                            for (int k = 0; k < (defter.Length / 2); k++)
                            {
                                if (!string.IsNullOrEmpty(defter[k, 0]) || !string.IsNullOrEmpty(defter[k, 1]))
                                {
                                    Console.WriteLine((k + 1) + ": Ad Soyad = " + defter[k, 0] + " " + defter[k, 1]);
                                }
                            }
                            Bekleme();
                            Console.Clear();
                            break;
                        case 2:
                            Console.WriteLine("###### Kişi Ekle ###### ");
                            Console.Write("Ad Bilgisini Giriniz = ");
                            string ad = Console.ReadLine();
                            Console.Write("Soyad Bilgisini Giriniz = ");
                            string soyad = Console.ReadLine();
                            defter[i, 0] = ad;
                            defter[i, 1] = soyad;
                            i++;
                            Bekleme();
                            Console.Clear();
                            break;
                        case 3:
                            Console.WriteLine("###### Kişi Güncelle ###### ");
                            Console.WriteLine("Güncellemek istediğiniz kullanıcının numarasını giriniz");
                            var numaraString = Console.ReadLine();
                            var numaraInt = int.Parse(numaraString)-1;
                            var adS = defter[numaraInt, 0];
                            var soyadS = defter[numaraInt, 1];
                            if (!string.IsNullOrEmpty(adS) || !string.IsNullOrEmpty(soyadS))
                            {
                                Console.WriteLine("Bulunan Ad Soyad =" + adS + " "+ soyadS);
                                Console.Write("Ad Bilgisini Giriniz = ");
                                string adS2 = Console.ReadLine();
                                Console.Write("Soyad Bilgisini Giriniz = ");
                                string soyadS2 = Console.ReadLine();
                                if (!string.IsNullOrEmpty(adS2))
                                {
                                    defter[numaraInt, 0] = adS2;
                                }
                                if (!string.IsNullOrEmpty(soyadS2))
                                {
                                    defter[numaraInt, 1] = soyadS2;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Aradığınız Kişi Bulunamadı");                                
                            }

                            Bekleme();
                            Console.Clear();
                            break;
                        case 4:
                            Console.WriteLine("###### Kişi Sil ###### ");
                            Console.WriteLine("Silmek istediğiniz kişinin numarasını giriniz");
                            var numaraString1 = Console.ReadLine();
                            var numaraInt1 = int.Parse(numaraString1)-1;
                            var adS3 = defter[numaraInt1, 0];
                            var soyadS3 = defter[numaraInt1, 1];
                            Console.WriteLine("Silmek istediğiniz Ad Soyad = '"+ adS3+ " "+ soyadS3+ "' buysa E Tuşuna basınız.Değilse H tuşuna basınız.");
                            var islem = Console.ReadLine();
                            //if(islem=="E" || islem == "e")
                            //if(islem.ToLower()=="e")
                            if (islem.ToUpper() == "E")
                            {
                                defter[numaraInt1, 0] = null;
                                defter[numaraInt1, 1] = null;
                                Console.Write("Silme işlemi tamamlandı.");
                            }
                            Bekleme();
                            Console.Clear();
                            break;
                        case 5:
                            Console.WriteLine("Çıkış Yaptınız.");
                            Console.Clear();
                            cikis = false;
                            break;
                        default:
                            MenuRakamKontrol();
                            break;
                    }
                }
                catch
                {

                    MenuRakamKontrol();
                }
                
                
            }
                     
        }

        public static void Menu()
        {
            Console.WriteLine("1 - Listele");
            Console.WriteLine("2 - Ekle");
            Console.WriteLine("3 - Güncelle");
            Console.WriteLine("4 - Sil");
            Console.WriteLine("5 - Çıkış");
        } 

        public static void Bekleme()
        {
            Console.WriteLine("Menüye geçmek için herhangi bir tuşa basınız");
            Console.ReadLine();
        }

        public static void MenuRakamKontrol()
        {
            Console.Clear();
            Console.WriteLine("Lütfen 1 ile 5 arası bir seçim yapınız. Menüye geçmek için herhangi bir tuşa basınız.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
