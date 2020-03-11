using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace FileReader.Domain.FileReaders
{
    public class FileReader : IFileReader
    {
        private readonly IFormFile _file;

        public FileReader(IFormFile file) => _file = file;

        public async Task<string> Read()
        {
            string content = string.Empty;

            using (var reader = new StreamReader(_file.OpenReadStream()))
            {
                content = await reader.ReadToEndAsync();
            }

            return content;
        }
    }
}
