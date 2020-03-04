using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileReader.Domain.Interfaces
{
    public interface IFileReader
    {
        Task<List<string>> ProcessFile();
    }
}
