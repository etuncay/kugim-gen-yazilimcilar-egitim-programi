using AutoMapper;
using Haber.Core.Interfaces.Services;
using Haber.Data;
using Haber.Models.ViewModels.Request;
using Haber.Models.ViewModels.Response;
using Haber.Services.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Services
{
    public class AutoMapperProfile : Profile
    {
     

        public AutoMapperProfile()
        {

            CreateMap<KullaniciEntity, KullaniciResponseViewModel>().ReverseMap();
            CreateMap<KullaniciRequestViewModel, KullaniciEntity>().ReverseMap();
        }
    }
}
