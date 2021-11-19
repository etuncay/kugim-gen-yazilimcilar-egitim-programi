using AutoMapper;
using Haber.Core.Interfaces.Services;
using Haber.Data;
using Haber.Models.ViewModels;
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

            CreateMap<KullaniciEntity, KullaniciResponseViewModel>()
                .ForMember(q=>q.Yetkiler , opt => opt.MapFrom(src => src.KullaniciYetki.Select(q=>q.Yetki)))
                .ReverseMap();

            CreateMap<KullaniciRequestViewModel, KullaniciEntity>().ReverseMap();

            CreateMap<KategoriEntity, KategoriResponseViewModel>().ReverseMap();
            CreateMap<KategoriRequestViewModel, KategoriEntity>().ReverseMap();

            CreateMap<EtiketEntity, EtiketResponseViewModel>().ReverseMap();
            CreateMap<EtiketRequestViewModel, EtiketEntity>().ReverseMap();

            CreateMap<IcerikEntity, IcerikResponseViewModel>()
                .ForMember(q=>q.IcerikTipi , opt => opt.MapFrom(src => new LabelValueModel() {
                    Label = src.IcerikTipi.ToString(),
                    Value = src.IcerikTipi.GetHashCode()
                }))
                .ForMember(q=>q.Kategori , opt => opt.MapFrom(src => new LabelValueModel() {
                    Label = src.Kategori.Ad,
                    Value = src.KategoriId
                }))
                .ForMember(q=>q.Yorumlar, opt => opt.MapFrom(src => src.Yorumlar.Select(s => new YorumResponseViewModel()
                {
                    Id = s.Id,
                    Govde = s.Govde,
                    Aktif = s.Aktif,
                    Kullanici = new LabelValueModel()
                    {
                        Label = s.Kullanici.Ad+ " " + s.Kullanici.Soyad,
                        Value = s.KullaniciId
                    },
                    OlusturulmaTarihi = s.OlusturulmaTarihi,
                    GuncellenmeTarihi = s.GuncellenmeTarihi
                })))
                .ForMember(q => q.Resimler, opt => opt.MapFrom(src => src.Resimler.Select(s => new ResimResponseViewModel()
                {
                    Id = s.Id,
                    ResimUrl = s.ResimUrl,
                    Aciklama = s.Aciklama,
                    OlusturulmaTarihi = s.OlusturulmaTarihi,
                    GuncellenmeTarihi = s.GuncellenmeTarihi
                })))
                .ForMember(q => q.Etiketler, opt => opt.MapFrom(src => src.IcerikEtiketler.Select(s => new LabelValueModel()
                {
                    Label = s.Etiket.Ad,
                    Value = s.EtiketId
                })))
                .ReverseMap();
            CreateMap<IcerikRequestViewModel, IcerikEntity>().ReverseMap();



        }
    }
}
