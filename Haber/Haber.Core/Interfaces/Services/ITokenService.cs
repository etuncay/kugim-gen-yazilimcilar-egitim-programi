using Haber.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Core.Interfaces.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, KullaniciTokenDTO kullanici);
   
        bool IsTokenValid(string key, string issuer, string token);
    }
}
