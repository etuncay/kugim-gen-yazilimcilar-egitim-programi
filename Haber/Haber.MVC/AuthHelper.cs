using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haber.MVC
{
    public class AuthHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public AuthHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuth()
        {

            return !string.IsNullOrEmpty(_session.GetString("Token")) ? true : false;
        }

        public string GetUserName()
        {
            return _session.GetString("User");
        }

    }
}
