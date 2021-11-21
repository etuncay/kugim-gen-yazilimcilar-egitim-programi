using AutoMapper;
using Haber.Core.Interfaces.Services;
using Haber.Core.Validator;
using Haber.Data;
using Haber.Models.Enums;
using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Request;
using Haber.Models.ViewModels.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Services
{
    public class IcerikService : IIcerikService
    {
        private readonly HaberDbContext _haberDbContext;
        private readonly IMapper _mapper;

        public IcerikService(
            HaberDbContext haberDbContext,
            IMapper mapper)
        {
            _haberDbContext = haberDbContext;
            _mapper = mapper;
        }


        public ResponseResultModel<int> Ekle(IcerikRequestViewModel model)
        {
            var validator = new IcerikRequestValidator();

            var validate = validator.Validate(model);

            var result = new ResponseResultModel<int>();

            var slug = new Slugify.SlugHelper();

            if (validate.IsValid)
            {
                var entity = _mapper.Map<IcerikEntity>(model);
                entity.Slug = slug.GenerateSlug(entity.Baslik);

                _haberDbContext.Add(entity);
                result.SaveChange(_haberDbContext.SaveChanges());
                result.Data = entity.Id;
                
            }
            else
            {
                result.SetErrors(validate);
            }

            return result;
        }

        public ResponseResultModel<List<IcerikResponseViewModel>> Listele(SayfalamaViewModel sayfalama)
        {
            var result = new ResponseResultModel<List<IcerikResponseViewModel>>();

            var query = _haberDbContext.Icerik
                .Include(q=>q.Kategori)
                .Include(q => q.Yorumlar).ThenInclude(q => q.Kullanici)
                .Include(q => q.Resimler)
                .Include(q => q.IcerikEtiketler).ThenInclude(q => q.Etiket)
                .AsQueryable();

            if (sayfalama.Sayfalama)
            {
                query = query.Skip(sayfalama.Atla).Take(sayfalama.Al).OrderByDescending(q => q.Tarih);
            }

            var queries = query.ToList();

            if (queries.Any())
            {
                result.Data = _mapper.Map<List<IcerikResponseViewModel>>(queries);
                result.Message = ResponseResultMessageType.KayitBulundu;
                result.Type = EnumResponseResultType.Success;
                result.TotalCount = result.Data.Count();

            }
            else
            {
                result.Message = ResponseResultMessageType.KayitBulunamadi;
                result.Type = EnumResponseResultType.Error;
            }


            return result;
        }

        public ResponseResultModel<IcerikResponseViewModel> Getir(int id)
        {
            var result = new ResponseResultModel<IcerikResponseViewModel>();
            var query = _haberDbContext.Icerik
                .Include(q => q.Kategori)
                .Include(q => q.Yorumlar).ThenInclude(q => q.Kullanici)
                .Include(q => q.Resimler)
                .Include(q => q.IcerikEtiketler).ThenInclude(q => q.Etiket)
                .FirstOrDefault(q => q.Id == id);
            if (query != null)
            {
                result.Data = _mapper.Map<IcerikResponseViewModel>(query);

                result.Message = ResponseResultMessageType.KayitBulundu;
                result.Type = EnumResponseResultType.Success;

            }
            else
            {
                result.Message = ResponseResultMessageType.KayitBulunamadi;
                result.Type = EnumResponseResultType.Error;
            }

            return result;
        }

        public ResponseResultModel Guncelle(int id, IcerikRequestViewModel model)
        {
            var result = new ResponseResultModel();

            var query = _haberDbContext.Icerik.FirstOrDefault(q => q.Id == id);
            if (query != null)
            {
                var slug = new Slugify.SlugHelper();
                query.Baslik = model.Baslik;
                query.IcerikTipi= model.IcerikTipi;
                query.KategoriId= model.KategoriId;
                query.Ozet= model.Ozet;
                query.ResimUrl= model.ResimUrl;
                query.Govde= model.Govde;
                query.Tarih = model.Tarih;

                query.Slug = slug.GenerateSlug(model.Baslik);
                result.SaveChange(_haberDbContext.SaveChanges());

            }
            else
            {
                result.Message = ResponseResultMessageType.KayitBulunamadi;
                result.Type = EnumResponseResultType.Error;
            }

            return result;
        }

        public ResponseResultModel Sil(int id)
        {
            var result = new ResponseResultModel();

            var query = _haberDbContext.Icerik.FirstOrDefault(q => q.Id == id);
            if (query != null)
            {
                _haberDbContext.Icerik.Remove(query);
                result.SaveChange(_haberDbContext.SaveChanges());
            }
            else
            {
                result.Message = ResponseResultMessageType.KayitBulunamadi;
                result.Type = EnumResponseResultType.Error;
            }

            return result;
        }

        public ResponseResultModel<int> YorumEkle(int id, int kullaniciId, string govde)
        {
            var result = new ResponseResultModel<int>();

            var query = _haberDbContext.Icerik.FirstOrDefault(q => q.Id == id);

            if (query != null)
            {
                var entity = new YorumEntity()
                {
                    KullaniciId = kullaniciId,
                    IcerikId = id,
                    Govde = govde,
                    Aktif = false,
                };

                _haberDbContext.Yorum.Add(entity);

                result.SaveChange(_haberDbContext.SaveChanges());
                result.Data = entity.Id;
            }
            else
            {
                result.Message = ResponseResultMessageType.KayitBulunamadi;
                result.Type = EnumResponseResultType.Error;

            }


                return result;
        }

        public ResponseResultModel YorumDurumDegistir(int yorumId, bool durum)
        {
            var result = new ResponseResultModel();

            var query = _haberDbContext.Yorum.FirstOrDefault(q => q.Id == yorumId);

            if (query != null)
            {
                query.Aktif = durum;

                result.SaveChange(_haberDbContext.SaveChanges());
            }
            else
            {
                result.Message = ResponseResultMessageType.KayitBulunamadi;
                result.Type = EnumResponseResultType.Error;
            }


            return result;
        }

        public ResponseResultModel<List<IcerikResponseViewModel>> Filtrele(IcerikFitreleRequestViewModel filtreModel)
        {
            var result = new ResponseResultModel<List<IcerikResponseViewModel>>();


            var query = _haberDbContext.Icerik
               .Include(q => q.Kategori)
               .Include(q => q.Yorumlar).ThenInclude(q => q.Kullanici)
               .Include(q => q.Resimler)
               .Include(q => q.IcerikEtiketler).ThenInclude(q => q.Etiket)
               .AsQueryable();

            if (filtreModel.KategoriId != null)
            {
                query = query.Where(q => q.KategoriId == filtreModel.KategoriId);
            }

            if (!string.IsNullOrEmpty(filtreModel.AraString))
            {
                query = query.Where(q => q.Baslik.Contains(filtreModel.AraString) || q.Govde.Contains(filtreModel.AraString));
            }

            if (filtreModel.Sayfalama.Sayfalama == true)
            {
                query = query.Skip(filtreModel.Sayfalama.Atla).Take(filtreModel.Sayfalama.Al);
            }

            if (query.Any())
            {
                query = query.OrderByDescending(q => q.Tarih);

                result.Data = _mapper.Map<List<IcerikResponseViewModel>>(query);
                result.Message = ResponseResultMessageType.KayitBulundu;
                result.Type = EnumResponseResultType.Success;
            }
            else
            {
                result.Message = ResponseResultMessageType.KayitBulunamadi;
                result.Type = EnumResponseResultType.Info;
            }

            return result;
        }
    }
}
