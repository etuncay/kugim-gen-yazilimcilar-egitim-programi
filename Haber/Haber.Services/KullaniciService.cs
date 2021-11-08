
using Haber.Core.Interfaces.Services;
using Haber.Data;
using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Request;
using Haber.Models.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Haber.Services
{
    public class KullaniciService : IKullaniciService
    {
        private readonly HaberDbContext _haberDbContext;

        public KullaniciService(HaberDbContext haberDbContext)
        {
            _haberDbContext = haberDbContext;
        }

        public ResponseResultModel<KullaniciResponseViewModel> Giris(string kullaniciAdi, string sifre)
        {
            var result = new ResponseResultModel<KullaniciResponseViewModel>();

            var query = _haberDbContext.Kullanici.Where(q => q.KullaniciAdi == kullaniciAdi).FirstOrDefault();

            if (query != null)
            {
                if(query.Sifre == sifre)
                {
                    result.Data = new KullaniciResponseViewModel() {
                        Id  = query.Id,
                        Ad = query.Ad,
                        Soyad = query.Soyad,
                        KullaniciAdi = query.KullaniciAdi,
                        Eposta = query.Eposta,
                        OlusturulmaTarihi = query.OlusturulmaTarihi,
                        GuncellenmeTarihi = query.GuncellenmeTarihi
                    };

                    result.Type = Models.Enums.EnumResponseResultType.Success;
                    result.Message = "Kullanıcı Bulundu.";
                }
                else
                {
                    result.Type = Models.Enums.EnumResponseResultType.Error;
                    result.Message = "Hatalı kullanıcı bilgileri";
                }
            }
            else
            {
                result.Type = Models.Enums.EnumResponseResultType.Error;
                result.Message = "Kullanıcı Bulunamadı";
            }

            return result;
        }

        public ResponseResultModel<List<KullaniciResponseViewModel>> Listele()
        {
            var result = new ResponseResultModel<List<KullaniciResponseViewModel>>();

            foreach (var kullanici in _haberDbContext.Kullanici.ToList())
            {
                result.Data.Add(new KullaniciResponseViewModel() {
                    Id = kullanici.Id,
                    Ad = kullanici.Ad,
                    Soyad = kullanici.Soyad,
                    KullaniciAdi = kullanici.KullaniciAdi,
                    Eposta = kullanici.Eposta,
                    OlusturulmaTarihi = kullanici.OlusturulmaTarihi,
                    GuncellenmeTarihi = kullanici.GuncellenmeTarihi
                });
            }

            if (result.Data.Count() > 0)
            {
                result.Type = Models.Enums.EnumResponseResultType.Success;
                result.Message = "Keyıt bulundu";
                result.TotalCount = result.Data.Count();
            }
            else
            {
                result.Type = Models.Enums.EnumResponseResultType.Info;
                result.Message = "Keyıt bulunamadı";
            }

            return result;
        }

        public ResponseResultModel<KullaniciResponseViewModel> Getir(int id)
        {
            var result = new ResponseResultModel<KullaniciResponseViewModel>();

            var query = _haberDbContext.Kullanici.Where(q => q.Id == id).FirstOrDefault();

            if (query != null)
            {
                result.Data = new KullaniciResponseViewModel()
                {
                    Id = query.Id,
                    Ad = query.Ad,
                    Soyad = query.Soyad,
                    KullaniciAdi = query.KullaniciAdi,
                    Eposta = query.Eposta,
                    OlusturulmaTarihi = query.OlusturulmaTarihi,
                    GuncellenmeTarihi = query.GuncellenmeTarihi
                };

                result.Type = Models.Enums.EnumResponseResultType.Success;
                result.Message = "Kullanıcı Bulundu.";
            }
            else
            {
                result.Type = Models.Enums.EnumResponseResultType.Error;
                result.Message = "Kullanıcı Bulunamadı";
            }


            return result;
        }

        public ResponseResultModel<int> Ekle(KullaniciRequestViewModel model)
        {
            throw new NotImplementedException();
        }


        public ResponseResultModel Guncelle(int id, KullaniciResponseViewModel mode)
        {
            throw new NotImplementedException();
        }

        

        public ResponseResultModel SifreGuncelle(string kullaniciAdi, string yeniSifre)
        {
            throw new NotImplementedException();
        }

        public ResponseResultModel Sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
