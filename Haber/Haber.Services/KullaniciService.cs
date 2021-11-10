
using AutoMapper;
using FluentValidation.Results;
using Haber.Core.Interfaces.Services;
using Haber.Core.Validator;
using Haber.Data;
using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Request;
using Haber.Models.ViewModels.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Haber.Services
{
    public class KullaniciService : IKullaniciService
    {
        private readonly HaberDbContext _haberDbContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public KullaniciService(
            HaberDbContext haberDbContext,
            IMapper mapper,
            IPasswordHasher passwordHasher
            )
        {
            _haberDbContext = haberDbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public ResponseResultModel<KullaniciResponseViewModel> Giris(string kullaniciAdi, string sifre)
        {
            var result = new ResponseResultModel<KullaniciResponseViewModel>();

            var query = _haberDbContext.Kullanici.Include(q=>q.KullaniciYetki).Where(q => q.KullaniciAdi == kullaniciAdi).FirstOrDefault();

            if (query != null)
            {
                if(query.Sifre == sifre)
                {
                    result.Data = _mapper.Map<KullaniciResponseViewModel>(query);
                        

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

            result.Data = new List<KullaniciResponseViewModel>();

            foreach (var kullanici in _haberDbContext.Kullanici.Include(q => q.KullaniciYetki).ToList())
            {
                var data = _mapper.Map<KullaniciResponseViewModel>(kullanici);

                result.Data.Add(data);

            }

            if (result.Data.Count() > 0)
            {
                result.Type = Models.Enums.EnumResponseResultType.Success;
                result.Message = "Kayıt bulundu";
                result.TotalCount = result.Data.Count();
            }
            else
            {
                result.Type = Models.Enums.EnumResponseResultType.Info;
                result.Message = "Kayıt bulunamadı";
            }

            return result;
        }

        public ResponseResultModel<KullaniciResponseViewModel> Getir(int id)
        {
            var result = new ResponseResultModel<KullaniciResponseViewModel>();

            var query = _haberDbContext.Kullanici.Include(q => q.KullaniciYetki).Where(q => q.Id == id).FirstOrDefault();

            if (query != null)
            {
                result.Data = _mapper.Map<KullaniciResponseViewModel>(query);

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
            KullaniciRequestValidator validator = new KullaniciRequestValidator();

            ValidationResult validate = validator.Validate(model);
            var result = new ResponseResultModel<int>();
            if (validate.IsValid)
            {
                model.Sifre = _passwordHasher.Hash(model.Sifre);

                var entity = _mapper.Map<KullaniciEntity>(model);

                _haberDbContext.Kullanici.Add(entity);


                if (_haberDbContext.SaveChanges() > 0)
                {
                    result.Message = "Kayıt işlemi yapıldı";
                    result.Data = entity.Id;
                    result.Type = Models.Enums.EnumResponseResultType.Success;
                }
                else
                {
                    result.Message = "Kayıt işlemi yapılamadı";
                    result.Type = Models.Enums.EnumResponseResultType.Error;
                }
            }
            else
            {
                result.SetErrors(validate);
            }


            return result;
        }


        public ResponseResultModel Guncelle(int id, KullaniciRequestViewModel model)
        {
            var result = new ResponseResultModel();

            KullaniciRequestValidator validator = new KullaniciRequestValidator();

            ValidationResult validate = validator.Validate(model);
            if (validate.IsValid)
            {
                var query = _haberDbContext.Kullanici.FirstOrDefault(q => q.Id == id);
                if (query != null)
                {
                    query.Ad = model.Ad;
                    query.Soyad = model.Soyad;
                    query.Eposta = model.Eposta;
                    query.KullaniciAdi = model.KullaniciAdi;
                    query.GuncellenmeTarihi = DateTime.Now;

                    if (_haberDbContext.SaveChanges() > 0)
                    {
                        result.Message = "Güncelleme yapıldı";
                        result.Type = Models.Enums.EnumResponseResultType.Success;
                    }
                    else
                    {
                        result.Message = "Güncelleme yapılamadı";
                        result.Type = Models.Enums.EnumResponseResultType.Error;
                    }

                }
                else
                {
                    result.Message = "Kullanıcı bulunamadı";
                    result.Type = Models.Enums.EnumResponseResultType.Warning;
                }
            }
            else
            {
                result.SetErrors(validate);
            }

            

            return result;
        }

        

        public ResponseResultModel SifreGuncelle(int id, string yeniSifre)
        {
            var result = new ResponseResultModel();
            var query = _haberDbContext.Kullanici.FirstOrDefault(q => q.Id == id);

            if (query != null)
            {
                query.Sifre = _passwordHasher.Hash(yeniSifre+id);
                if (_haberDbContext.SaveChanges() > 0)
                {
                    result.Message = "Şifre Güncellemesi yapıldı";
                    result.Type = Models.Enums.EnumResponseResultType.Success;
                }
                else
                {
                    result.Message = "Şifre Güncellemesi yapılamadı";
                    result.Type = Models.Enums.EnumResponseResultType.Error;
                }
            }
            else
            {
                result.Message = "Kullanıcı bulunamadı";
                result.Type = Models.Enums.EnumResponseResultType.Warning;
            }


            return result;
        }

        public ResponseResultModel Sil(int id)
        {
            var result = new ResponseResultModel();

            var query = _haberDbContext.Kullanici.FirstOrDefault(q=>q.Id == id);

            if (query != null)
            {
                _haberDbContext.Kullanici.Remove(query);
                if (_haberDbContext.SaveChanges() > 0)
                {
                    result.Message = "Silme yapıldı";
                    result.Type = Models.Enums.EnumResponseResultType.Success;
                }
                else
                {
                    result.Message = "Silme yapılamadı";
                    result.Type = Models.Enums.EnumResponseResultType.Error;
                }
            }
            else
            {
                result.Message = "Kullanıcı bulunamadı";
                result.Type = Models.Enums.EnumResponseResultType.Warning;

            }


            return result;
        }
    }
}
