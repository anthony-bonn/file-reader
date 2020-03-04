using FileReader.Domain.Encryptors;
using FileReader.Domain.Enums;
using FileReader.Domain.FileReaders;
using FileReader.Domain.Helpers;
using FileReader.Domain.Interfaces;
using FileReader.Services.IServices;
using FileReader.Shared.Models.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileReader.Services.Services
{
    public class FileService : IFileService
    {
        public async Task<FileReaderViewModel> Process(FileReaderViewModel vm, IDataProtector protector)
        {
            FileType fileType;

            try
            {
                // throws NotSupportedException if file type isn't supported
                Helpers.GetFileTypeEnumFromContentType(vm.File.ContentType, out fileType);
            }
            catch (NotSupportedException e)
            {
                vm.Original = new List<string>() { e.Message };
                return vm;
            }

            vm.Original = await InitFileReader(fileType, vm.File).ProcessFile();

            // encryption not required or filetype doesn't allow encryption
            if (!vm.Encrypt || fileType != FileType.Text) return vm;

            // encryption required
            vm.Encrypted = InitEcnryptor(vm.EncryptionType, new List<string>(vm.Original), protector).Encrypt();

            return vm;
        }

        private static IFileReader InitFileReader(FileType fileType, IFormFile file)
        {
            // factory design pattern
            // gets filereader based on fileType
            return FileReaderService.InitFactories().InitFileReader(fileType, file);
        }

        private static IEncryptor InitEcnryptor(EncryptionType encryptionType, List<string> source, IDataProtector protector)
        {
            // factory design pattern
            // get encryptor based on encryptionType
            return EncryptorService.InitFactories().InitEncryptor(encryptionType, source, protector);
        }
    }
}
