using FileReader.Domain.ExtensionMethods;
using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FileReader.Domain.FileReaders
{
    public class XmlReader : IFileReader
    {
        private readonly IFormFile _sourceFile;
        private readonly ClaimsPrincipal _user;

        public XmlReader(IFormFile sourceFile, ClaimsPrincipal user)
        {
            _sourceFile = sourceFile;
            _user = user;
        }

        // For now all ReadFile methods perform the same logic
        // Deserialization logic could be added here if required
        public async Task<Tuple<bool, List<string>>> ProcessFile()
        {
            if (!Helpers.Helpers.IsUserAllowed(_user)) return Tuple.Create(false, new List<string>() { });

            List<string> content = new List<string>();

            using (var reader = new StreamReader(_sourceFile.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    var line = await reader.ReadLineAsync();
                    content.Add(line.FormatForDisplay());
                }
            }

            return Tuple.Create(true, content);
        }
    }
}
