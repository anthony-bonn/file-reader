using FileReader.Domain.Enums;
using FileReader.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FileReader.Services.Services
{
    public class AuthService : IAuthService
    {
        public async Task Login(ControllerBase context, AuthenticationType authenticationType)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, authenticationType.ToString())
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "Filereader Identity");

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await context.HttpContext.SignInAsync(principal);
        }

        public async Task Logout(ControllerBase context)
        {
            await context.HttpContext.SignOutAsync();
        }
    }
}
