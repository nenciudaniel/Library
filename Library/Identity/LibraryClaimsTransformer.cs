using Library.Business.Models;
using Library.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Library.Identity
{
    public class LibraryClaimsTransformer : IClaimsTransformation
    {
        private readonly IUserService _userService;

        public LibraryClaimsTransformer(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            string userName = "danielnenciu"; //principal.Identity.Name.ToLower().Replace("ro\\", string.Empty);

            UserDTO user = await _userService.GetCurrentUserAsync(userName);
            ClaimsIdentity identity = new()
            {
                Label = "UserDetails"
            };

            identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Username));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));

            principal.AddIdentity(identity);

            return principal;
        }
    }
}
