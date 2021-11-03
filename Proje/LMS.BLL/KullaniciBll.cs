using LMS.Core.Interfaces;
using LMS.Data;
using LMS.Models.Dto;
using LMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.BLL
{
    public class KullaniciBll : IKullaniciBll
    {
        private readonly LMSDbContext _dbcontext;

        public KullaniciBll(LMSDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public KullaniciTokenDTO Giris(KullaniciGirisViewModel model)
        {
            var result = new KullaniciTokenDTO();

            var query = _dbcontext.Kullanici.FirstOrDefault(q => q.Eposta == model.Eposta && q.Sifre == model.Sifre);

            if (query != null)
            {
                result = new KullaniciTokenDTO()
                {
                    Id = query.Id,
                    Ad = query.Ad,
                    Soyad = query.Soyad,
                    Eposta = query.Eposta,
                    Yetki = query.Yetki
                };
            }


            return result;
        }

        public int Kayit(KullaniciKayitViewModel model)
        {

            var entity = new KullaniciEntity()
            {
                Ad = model.Ad,
                Soyad = model.Soyad,
                Eposta = model.Eposta,
                Sifre = model.Sifre,
                Aktif = true
            };
            _dbcontext.Kullanici.Add(entity);

            return _dbcontext.SaveChanges() > 0 ? entity.Id : 0;

        }

    }
}
