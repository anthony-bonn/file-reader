using FileReader.Domain.Decryptors;
using FileReader.Domain.Helpers;
using FileReader.Services.IServices;
using FileReader.Shared.Models.ViewModels;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FileReader.Services.Services
{
    public class FileService : IFileService
    {
        public async Task<Tuple<bool, byte[], string>> Process(FileReaderViewModel vm, ClaimsPrincipal user)
        {
            // throws NotSupportedException if file type isn't supported
            Helpers.IsFileTypeSupported(vm.File.ContentType);

            // is user allowed?
            if (!Helpers.IsUserAllowed(user)) return Tuple.Create(false, Array.Empty<byte>(), "");

            string content;

            // get file content
            if (!vm.Encrypted) content = await new Domain.FileReaders.FileReader(vm.File).Read();
            else content = await new ReverseDecryptor(vm.File).Decrypt();

            // get bytes from content
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(content);

            // return bytes and contenttype
            return Tuple.Create(true, bytes, vm.File.ContentType);
        }
    }
}
