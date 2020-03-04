using FileReader.Shared.Models.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using System.Threading.Tasks;

namespace FileReader.Services.IServices
{
    public interface IFileService
    {
        Task<FileReaderViewModel> Process(FileReaderViewModel vm, IDataProtector protector);
    }
}
