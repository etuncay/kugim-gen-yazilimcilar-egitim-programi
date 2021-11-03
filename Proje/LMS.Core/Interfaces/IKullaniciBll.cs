using LMS.Models.Dto;
using LMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Core.Interfaces
{
    public interface IKullaniciBll
    {
        KullaniciTokenDTO Giris(KullaniciGirisViewModel model);
        int Kayit(KullaniciKayitViewModel model);
    }
}
