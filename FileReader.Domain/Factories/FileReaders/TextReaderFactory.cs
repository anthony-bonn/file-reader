using FileReader.Domain.FileReaders;
using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FileReader.Domain.Factories.FileReaders
{
    public class TextReaderFactory : FileReaderFactory
    {
        public override IFileReader Create(IFormFile sourceFile, ClaimsPrincipal user) => new TextReader(sourceFile, user);
    }
}
