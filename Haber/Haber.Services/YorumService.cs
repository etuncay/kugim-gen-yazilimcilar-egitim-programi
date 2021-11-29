using AutoMapper;
using Haber.Core.Interfaces.Services;
using Haber.Data;
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
    public class YorumService : IYorumService
    {
        private readonly HaberDbContext _haberDbContext;
        private readonly IMapper _mapper;
        private readonly IKullaniciService _kullaniciService;
        public YorumService(HaberDbContext haberDbContext, IKullaniciService kullaniciService, IMapper mapper)
        {
            _haberDbContext = haberDbContext;
            _kullaniciService = kullaniciService;
            _mapper = mapper;
        }

        public ResponseResultModel<int> Ekle(YorumRequestViewModel model)
        {
            var query = _haberDbContext.Icerik.Where(q => q.Id == model.IcerikId).FirstOrDefault();
            var result = new ResponseResultModel<int>();
            if (query != null)
            {
                var user = _kullaniciService.Getir(model.KullaniciAdi);

                model.KullaniciId = user.Data.Id;

                var entity = _mapper.Map<YorumEntity>(model);

                _haberDbContext.Yorum.Add(entity);

                if (_haberDbContext.SaveChanges() > 0)
                {
                    result.Type = Models.Enums.EnumResponseResultType.Success;
                    result.Message = ResponseResultMessageType.BasariliIslem;
                    result.Data = entity.Id;
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

        public ResponseResultModel<List<YorumResponseViewModel>> Listele(int icerikId)
        {
            var query = _haberDbContext.Yorum
                .Include(q=>q.Kullanici).Where(q => q.IcerikId == icerikId)
                .OrderByDescending(q=>q.OlusturulmaTarihi).ToList();
            var result = new ResponseResultModel<List<YorumResponseViewModel>>();

            if (query.Any())
            {
                result.Data = _mapper.Map<List<YorumResponseViewModel>>(query);
            }
            else
            {
                result.Type = Models.Enums.EnumResponseResultType.Info;
                result.Message = ResponseResultMessageType.KayitBulunamadi;
            }


            return result;
        }
    }
}
