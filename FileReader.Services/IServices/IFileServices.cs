using FileReader.Shared.Models.ViewModels;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FileReader.Services.IServices
{
    public interface IFileService
    {
        Task<Tuple<bool, byte[], string>> Process(FileReaderViewModel vm, ClaimsPrincipal user);
    }
}
