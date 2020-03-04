using FileReader.Domain.Enums;
using FileReader.Domain.FileReaders;
using FileReader.Domain.Helpers;
using FileReader.Domain.Interfaces;
using FileReader.Services.IServices;
using FileReader.Shared.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileReader.Services.Services
{
    public class FileService : IFileService
    {
        public async Task<FileReaderViewModel> Process(FileReaderViewModel vm)
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

            return vm;
        }

        private static IFileReader InitFileReader(FileType fileType, IFormFile file)
        {
            // factory design pattern
            // gets filereader based on fileType
            return FileReaderService.InitFactories().InitFileReader(fileType, file);
        }
    }
}
