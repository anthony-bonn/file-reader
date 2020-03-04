using FileReader.Domain.FileReaders;
using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FileReader.Domain.Factories.FileReaders
{
    public class XmlReaderFactory : FileReaderFactory
    {
        public override IFileReader Create(IFormFile sourceFile, ClaimsPrincipal user = null) => new XmlReader(sourceFile, user);
    }
}
