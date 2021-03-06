﻿using System.Threading.Tasks;

namespace FileReader.Domain.Interfaces
{
    public interface IFileReader
    {
        Task<string> Read();
    }
}
