using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Request;
using Haber.Models.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Core.Interfaces.Services
{
    public interface IKullaniciService
    {
        ResponseResultModel<List<KullaniciResponseViewModel>> Listele();
        ResponseResultModel<KullaniciResponseViewModel> Getir(int id);
        ResponseResultModel<int> Ekle(KullaniciRequestViewModel model);
        ResponseResultModel Guncelle(int id, KullaniciResponseViewModel mode);
        ResponseResultModel Sil(int id);
        ResponseResultModel<KullaniciResponseViewModel> Giris(string kullaniciAdi, string sifre);
        ResponseResultModel SifreGuncelle(string kullaniciAdi, string yeniSifre);

    }
}
