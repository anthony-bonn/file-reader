using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FileReader.Domain.Factories.FileReaders
{
    public abstract class FileReaderFactory
    {
        public abstract IFileReader Create(IFormFile sourceFile);
    }
}
