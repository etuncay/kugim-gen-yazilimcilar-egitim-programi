using Haber.Core.Interfaces.Services;
using Haber.Models.Dto;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Haber.Services
{
    public class TokenService : ITokenService
    {
        private const double EXPIRY_DURATION_MINUTES = 30;


        public string BuildToken(string key, string issuer, KullaniciTokenDTO kulanici)
        {
            var claims = new[] {
                new Claim (ClaimTypes.Name , kulanici.Ad+ " "+ kulanici.Soyad),
                new Claim(ClaimTypes.NameIdentifier, kulanici.Id.ToString()),
                new Claim(ClaimTypes.Email, kulanici.Eposta),
                new Claim(ClaimTypes.GivenName, kulanici.Ad),
                new Claim(ClaimTypes.Surname, kulanici.Soyad),
                new Claim(ClaimTypes.Role, string.Join(",",kulanici.Yetkiler))
            };


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }


        public bool IsTokenValid(string key, string issuer, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
