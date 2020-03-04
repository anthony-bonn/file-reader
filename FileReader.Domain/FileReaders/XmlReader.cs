using FileReader.Domain.ExtensionMethods;
using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileReader.Domain.FileReaders
{
    public class XmlReader : IFileReader
    {
        private readonly IFormFile _sourceFile;

        public XmlReader(IFormFile sourceFile) => _sourceFile = sourceFile;

        // For now all ReadFile methods perform the same logic
        // Deserialization logic could be added here if required
        public async Task<List<string>> ProcessFile()
        {
            List<string> content = new List<string>();

            using (var reader = new StreamReader(_sourceFile.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    var line = await reader.ReadLineAsync();
                    content.Add(line.FormatForDisplay());
                }
            }

            return content;
        }
    }
}
