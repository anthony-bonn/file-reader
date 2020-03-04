﻿using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FileReader.Domain.Factories.FileReaders
{
    public abstract class FileReaderFactory
    {
        public abstract IFileReader Create(IFormFile sourceFile, ClaimsPrincipal user = null);
    }
}
