using Haber.Core.Interfaces.Services;
using Haber.Models.Dto;
using Haber.Models.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Haber.Models.ViewModels;
using Haber.Models.ViewModels.Response;

namespace Haber.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IKullaniciService _kullaniciService;
        private readonly ITokenService _tokenService;
        public AuthController(IKullaniciService kullaniciService, ITokenService tokenService, IConfiguration config)
        {
            _kullaniciService = kullaniciService;
            _tokenService = tokenService;
            _config = config;
        }
        [HttpPost]
        public ResponseResultModel<TokenResponseResultViewModel> SignIn(KullaniciGirisRequestViewModel model)
        {
            var kullaniciResulte = _kullaniciService.Giris(model.KullaniciAdi, model.Sifre);
            var result = new ResponseResultModel<TokenResponseResultViewModel>();
            if (kullaniciResulte.Type == Models.Enums.EnumResponseResultType.Success)
            {
                var kullanici = kullaniciResulte.Data;

                var kullaniciToken = new KullaniciTokenDTO()
                {
                   Id = kullanici.Id,
                   Ad =kullanici.Ad,
                   Soyad = kullanici.Soyad,
                   Eposta = kullanici.Eposta,
                   KullaniciAdi = kullanici.KullaniciAdi,
                   Yetkiler = kullanici.Yetkiler.Select(q=>q.ToString()).ToList()
                };
                var token ="Brearer " +_tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), kullaniciToken);

                result.Data = new TokenResponseResultViewModel()
                {
                    kullaniciAdi = kullanici.KullaniciAdi,
                    Ad = kullanici.Ad,
                    Soyad = kullanici.Soyad,
                    FotografUrl = "https://www.kafkas.edu.tr/dosyalar/ashmyo/image/default-user.png",
                    Token =token
                };

                result.Type = Models.Enums.EnumResponseResultType.Success;
                result.Message = ResponseResultMessageType.KayitBulundu;

            }
            else
            {
                result.Type = Models.Enums.EnumResponseResultType.Error;
                result.Message = ResponseResultMessageType.KayitBulunamadi;

            }

            return result;
        }
        
        [HttpPost]
        public ResponseResultModel<int> SignUp(KullaniciRequestViewModel model)
        {
            return _kullaniciService.Ekle(model);
        }

    }
}
