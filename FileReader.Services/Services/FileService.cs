using FileReader.Domain.FileReaders;
using FileReader.Domain.Helpers;
using FileReader.Services.IServices;
using FileReader.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileReader.Services.Services
{
    public class FileService : IFileService
    {
        public async Task<FileReaderViewModel> Process(FileReaderViewModel vm)
        {
            // Exception NotSupportedException
            try
            {
                Helpers.GetFileTypeEnumFromContentType(vm.File.ContentType, out _);
            }
            catch (NotSupportedException e)
            {
                vm.Original = new List<string>() { e.Message };
                return vm;
            }

            vm.Original = await new TextReader(vm.File).ProcessFile();

            return vm;
        }
    }
}
