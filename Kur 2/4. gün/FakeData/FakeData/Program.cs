using System;
using Dapper;
using Bogus;
using System.Data.SqlClient;
using FakeData.Models;
using System.Linq;
namespace FakeData
{
    class Program
    {
        static void Main(string[] args)
        {

        var faker = new Faker("tr");

            var connectionString = "Server= localhost;Database=UZEM;user id=sa;password=qweqwe123";

            using (var con = new SqlConnection(connectionString))
            {
                //var fakerName = faker.Name;

                //for (int i = 0; i < 99; i++)
                //{
                //     var queryNufus = $"INSERT INTO UZEM.genel.Nufus (Ad,Soyad,TCNO,DogumYeri,ResimUrl) VALUES(N'{fakerName.FirstName()}'," +
                //        $" N'{fakerName.LastName()}', N'{faker.Random.Number(100000000,999999999)}'," +
                //        $" N'{faker.Address.State()}', N'{faker.Image.People()}');";

                //    con.Query(queryNufus);

                //}

                var nufusBilgileri = con.Query<Nufus>("Select * from genel.Nufus");

                //foreach (var nufus in nufusBilgileri)
                //{
                //    var queryTelefon = $"INSERT INTO UZEM.genel.Telefon (NufusId,TelefonTipiId,Numara) VALUES({nufus.Id}, 1, N'{faker.Phone.PhoneNumber()}');";
                //    queryTelefon += $"INSERT INTO UZEM.genel.Telefon (NufusId,TelefonTipiId,Numara) VALUES({nufus.Id}, 1, N'{faker.Phone.PhoneNumber()}');";

                //    con.Query(queryTelefon);
                //}


                //for (int i = 0; i < 600; i++)
                //{
                //    var basvuruDosya = con.Query($"INSERT INTO UZEM.genel.Dosya (DosyaYolu,Uzantisi,Boyutu) VALUES(N'{faker.Image.PlaceImgUrl()}', N'jpg', 150); ");

                //}

                //var d = 1;
                //for (int i = 0; i < 300; i++)
                //{


                //    var queryBasvuru = $"INSERT INTO UZEM.basvuru.Basvuru (Ad,Soyad,TCNO,CepTelefonu,BasvuruDosyaId,ResimDosyaId) " +
                //         $"VALUES(N'{faker.Name.FirstName()}', N'{faker.Name.LastName()}', N'{faker.Random.Number(100000000, 999999999)}', N'231', {d++}, {d++});";

                //    con.Query(queryBasvuru);
                //}


                

                //foreach (var item in nufusBilgileri.Skip(100).Take(100).ToList())
                //{
                //    var queryKullanici = $"INSERT INTO UZEM.genel.Kullanici (KullaniciAdi,Sifre,KisiTipiId)" +
                //        $" VALUES(N'{faker.Internet.UserName()}', N'{faker.Random.Words(1)}', 2);";

                //    con.Query(queryKullanici);
                //}


                //foreach (var basvuru in con.Query<Nufus>("Select top 100 * from basvuru.Basvuru"))
                //{
                //    var queryNufus = $"INSERT INTO UZEM.genel.Nufus (Ad,Soyad,TCNO,DogumYeri,ResimUrl) VALUES(N'{basvuru.Ad}'," +
                //       $" N'{basvuru.Soyad}', N'{basvuru.TCNO}'," +
                //       $" N'{faker.Address.State()}', N'{basvuru.ResimUrl}');";

                //    con.Query(queryNufus);
                //}
                var nufusId = 106;
                var kullaniciId = 5;
                foreach (var basvuru in con.Query<int>("Select top 55 Id from basvuru.Basvuru"))
                {
                    var queryOgrenci = $"INSERT INTO UZEM.ogrenci.Ogrenci (BasvuruId,NufusId,Numara,BirimId,GirisYili,KullaniciId,Donem) " +
                        $"VALUES({basvuru}, {nufusId++}, N'{faker.Random.Number(100000000, 999999999)}', 8, 2021, {kullaniciId++},1);";

                    con.Query(queryOgrenci);
                }

            }

        }
    }
}
