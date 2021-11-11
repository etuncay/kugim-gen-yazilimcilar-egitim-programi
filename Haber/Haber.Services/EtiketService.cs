using AutoMapper;
using Haber.Core.Interfaces.Services;
using Haber.Core.Validator;
using Haber.Data;
using Haber.Models.Enums;
using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Request;
using Haber.Models.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Services
{
    public class EtiketService : IEtiketService
    {
        private readonly HaberDbContext _haberDbContext;
        private readonly IMapper _mapper;

        public EtiketService(
            HaberDbContext haberDbContext,
            IMapper mapper)
        {
            _haberDbContext = haberDbContext;
            _mapper = mapper;
        }


        public ResponseResultModel<int> Ekle(EtiketRequestViewModel model)
        {
            var validator = new EtiketRequestValidator();

            var validate = validator.Validate(model);

            var result = new ResponseResultModel<int>();

            var slug = new Slugify.SlugHelper();

            if (validate.IsValid)
            {
                var entity = _mapper.Map<EtiketEntity>(model);
                entity.Slug = slug.GenerateSlug(entity.Ad);

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

        public ResponseResultModel<List<EtiketResponseViewModel>> Listele()
        {
            var result = new ResponseResultModel<List<EtiketResponseViewModel>>();

            var queries = _haberDbContext.Etiket.ToList();

            if (queries.Any())
            {
                result.Data = _mapper.Map<List<EtiketResponseViewModel>>(queries);
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

        public ResponseResultModel<EtiketResponseViewModel> Getir(int id)
        {
            var result = new ResponseResultModel<EtiketResponseViewModel>();
            var query = _haberDbContext.Etiket.FirstOrDefault(q => q.Id == id);
            if (query != null)
            {
                result.Data = _mapper.Map<EtiketResponseViewModel>(query);

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

        public ResponseResultModel Guncelle(int id, EtiketRequestViewModel model)
        {
            var result = new ResponseResultModel();

            var query = _haberDbContext.Etiket.FirstOrDefault(q => q.Id == id);
            if (query != null)
            {
                var slug = new Slugify.SlugHelper();
                query.Ad = model.Ad;
                query.Slug = slug.GenerateSlug(model.Ad);
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

            var query = _haberDbContext.Etiket.FirstOrDefault(q => q.Id == id);
            if (query != null)
            {
                _haberDbContext.Etiket.Remove(query);
                result.SaveChange(_haberDbContext.SaveChanges());
            }
            else
            {
                result.Message = ResponseResultMessageType.KayitBulunamadi;
                result.Type = EnumResponseResultType.Error;
            }

            return result;
        }
    }
}
