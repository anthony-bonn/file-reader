using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileReader.Domain.Interfaces
{
    public interface IFileReader
    {
        Task<Tuple<bool, List<string>>> ProcessFile();
    }
}
