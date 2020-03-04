using FileReader.Shared.Models.ViewModels;
using System.Threading.Tasks;

namespace FileReader.Services.IServices
{
    public interface IFileService
    {
        Task<FileReaderViewModel> Process(FileReaderViewModel vm);
    }
}
