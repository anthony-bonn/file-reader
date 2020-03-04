using FileReader.Domain.Enums;
using System;
using System.Collections.Generic;
using FileReader.Domain.Factories.FileReaders;
using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FileReader.Domain.FileReaders
{
    public class FileReaderService
    {
        private readonly Dictionary<FileType, FileReaderFactory> _factories;

        private FileReaderService()
        {
            _factories = new Dictionary<FileType, FileReaderFactory>();

            // could work with a switch statement to return the required filereader
            //
            // could manualy add a new dictionary member per available filereader type
            // 
            // instead we chose to use reflection to create a new <Filetype, FileReaderFactory> dictionary based on Filetype enum members
            // this way we don't have to manually add Filetype/Factory creator for each filereader
            foreach (FileType fileType in Enum.GetValues(typeof(FileType)))
            {
                var factory = (FileReaderFactory)Activator
                    .CreateInstance(Type.GetType("FileReader.Domain.Factories.FileReaders." + Enum.GetName(typeof(FileType), fileType) + "ReaderFactory"));
                _factories.Add(fileType, factory);
            }
        }

        public static FileReaderService InitFactories() => new FileReaderService();

        public IFileReader InitFileReader(FileType fileType, IFormFile sourceFile) => _factories[fileType].Create(sourceFile);
    }
}
