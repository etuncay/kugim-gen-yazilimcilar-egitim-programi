using AutoMapper;
using Haber.Core.Interfaces.Services;
using Haber.Core.Validator;
using Haber.Data;
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
    public class KategoriService : IKategoriService
    {
        private readonly HaberDbContext _haberDbContext;
        private readonly IMapper _mapper;

        public KategoriService(
            HaberDbContext haberDbContext,
            IMapper mapper)
        {
            _haberDbContext = haberDbContext;
            _mapper = mapper;
        }


        public ResponseResultModel<int> Ekle(KategoriRequestViewModel model)
        {
            var validator = new KategoriRequestValidator();

            var validate = validator.Validate(model);

            var result = new ResponseResultModel<int>();

            if (validate.IsValid)
            {
                var entity = _mapper.Map<KategoriEntity>(model);
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

        public ResponseResultModel<KategoriResponseViewModel> Getir(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseResultModel Guncelle(int id, KategoriRequestViewModel model)
        {
            throw new NotImplementedException();
        }

        public ResponseResultModel<List<KategoriResponseViewModel>> Listele()
        {
            throw new NotImplementedException();
        }

        public ResponseResultModel Sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
