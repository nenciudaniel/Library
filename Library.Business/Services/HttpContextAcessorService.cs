using Library.Business.Enums;
using Library.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Library.Business.Services
{
    public class HttpContextAcessorService : IHttpContextAcessorService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public HttpContextAcessorService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetSurname()
        {
            ClaimsIdentity claimsIdentity = _httpContextAccessor.HttpContext.User.Identities.Where(x => x.Label == "UserDetails").First();
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Surname);

            return claim?.Value ?? string.Empty;
        }

        public string GetName()
        {
            ClaimsIdentity claimsIdentity = _httpContextAccessor.HttpContext.User.Identities.Where(x => x.Label == "UserDetails").First();
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Name);

            return claim?.Value ?? string.Empty;
        }

        public string GetUsername()
        {
            ClaimsIdentity claimsIdentity = _httpContextAccessor.HttpContext.User.Identities.Where(x => x.Label == "UserDetails").First();
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);

            return claim?.Value ?? string.Empty;
        }

        public string GetRole()
        {
            ClaimsIdentity claimsIdentity = _httpContextAccessor.HttpContext.User.Identities.Where(x => x.Label == "UserDetails").First();
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);

            return claim?.Value ?? string.Empty;
        }

        public bool IsAdmin()
        {
            return GetRole().ToUpper() == UserRoleEnum.Admin.ToString().ToUpper();
        }
    }
}
