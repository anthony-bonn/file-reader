﻿using FileReader.Domain.ExtensionMethods;
using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileReader.Domain.FileReaders
{
    public class TextReader : IFileReader
    {
        private readonly IFormFile _sourceFile;

        public TextReader(IFormFile sourceFile)
        {
            _sourceFile = sourceFile;
        }

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