using FileReader.Domain.FileReaders;
using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FileReader.Domain.Factories.FileReaders
{
    public class XmlReaderFactory : FileReaderFactory
    {
        public override IFileReader Create(IFormFile sourceFile) => new XmlReader(sourceFile);
    }
}
