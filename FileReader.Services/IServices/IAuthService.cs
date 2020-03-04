using FileReader.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FileReader.Services.IServices
{
    public interface IAuthService
    {
        Task Login(ControllerBase context, AuthenticationType authenticationType);
        Task Logout(ControllerBase context);
    }
}
