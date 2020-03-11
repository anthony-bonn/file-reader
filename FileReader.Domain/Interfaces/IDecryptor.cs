using System.Threading.Tasks;

namespace FileReader.Domain.Interfaces
{
    public interface IDecryptor
    {
        Task<string> Decrypt();
    }
}
