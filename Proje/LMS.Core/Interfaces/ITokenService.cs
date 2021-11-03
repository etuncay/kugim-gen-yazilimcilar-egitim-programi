using LMS.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Core.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, KullaniciTokenDTO kullanici);
        string GetToken();
        bool IsTokenValid(string key, string issuer, string token);
    }
}
