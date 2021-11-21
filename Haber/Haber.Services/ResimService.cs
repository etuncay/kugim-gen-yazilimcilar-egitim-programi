using AutoMapper;
using Haber.Core.Interfaces.Services;
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
    public class ResimService : IResimService
    {
        private readonly HaberDbContext _haberDbContext;
        private readonly IMapper _mapper;
        public ResimService(
            IMapper mapper,
            HaberDbContext haberDbContext)
        {
            _haberDbContext = haberDbContext;
            _mapper = mapper;
        }


        public ResponseResultModel Ekle(ResimRequestViewModel model)
        {
            var result = new ResponseResultModel();

            var query = _haberDbContext.Icerik.FirstOrDefault(q => q.Id == model.IcerikId);

            if (query != null)
            {
                var entity = _mapper.Map<ResimEntity>(model);

                _haberDbContext.Resim.Add(entity);

                if (_haberDbContext.SaveChanges() > 0)
                {
                    result.Type = Models.Enums.EnumResponseResultType.Success;
                    result.Message = ResponseResultMessageType.KayitBulundu;
                }
                else
                {
                    result.Type = Models.Enums.EnumResponseResultType.Error;
                    result.Message = ResponseResultMessageType.BasarisizIslem;
                }

                
            }
            else
            {
                result.Type = Models.Enums.EnumResponseResultType.Error;
                result.Message = ResponseResultMessageType.KayitBulunamadi;
            }


            return result;
        }

        public ResponseResultModel<List<ResimResponseViewModel>> Listele(int icerikId)
        {
            var result = new ResponseResultModel<List<ResimResponseViewModel>>();

            var query = _haberDbContext.Resim.Where(q => q.IcerikId == icerikId).ToList() ;

            if (query.Any())
            {
                result.Data = _mapper.Map<List<ResimResponseViewModel>>(query);

                result.Type = Models.Enums.EnumResponseResultType.Success;
                result.Message = ResponseResultMessageType.KayitBulundu;
            }
            else
            {
                result.Type = Models.Enums.EnumResponseResultType.Info;
                result.Message = ResponseResultMessageType.KayitBulunamadi;
            }

            return result;
        }

        public ResponseResultModel Sil(int id)
        {
            var result = new ResponseResultModel();

            var query = _haberDbContext.Resim.FirstOrDefault(q => q.Id == id);
            if (query != null)
            {
                _haberDbContext.Resim.Remove(query);
                if (_haberDbContext.SaveChanges() > 0)
                {
                    result.Type = Models.Enums.EnumResponseResultType.Success;
                    result.Message = ResponseResultMessageType.KayitBulundu;
                }
                else
                {
                    result.Type = Models.Enums.EnumResponseResultType.Error;
                    result.Message = ResponseResultMessageType.BasarisizIslem;
                }
            }
            else
            {
                result.Type = Models.Enums.EnumResponseResultType.Error;
                result.Message = ResponseResultMessageType.KayitBulunamadi;
            }

            return result;
        }
    }
}
