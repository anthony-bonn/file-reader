using FileReader.Domain.FileReaders;
using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FileReader.Domain.Factories.FileReaders
{
    public class TextReaderFactory : FileReaderFactory
    {
        public override IFileReader Create(IFormFile sourceFile) => new TextReader(sourceFile);
    }
}
