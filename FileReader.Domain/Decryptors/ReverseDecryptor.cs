using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileReader.Domain.Decryptors
{
    public class ReverseDecryptor : IDecryptor
    {
        private readonly IFormFile _file;

        public ReverseDecryptor(IFormFile file) => _file = file;

        public async Task<string> Decrypt()
        {
            string content = string.Empty;

            using (var reader = new StreamReader(_file.OpenReadStream()))
            {
                content = await reader.ReadToEndAsync();
            }

            char[] arr = content.ToCharArray();
            Array.Reverse(arr);

            return new string(arr);
        }
    }
}
