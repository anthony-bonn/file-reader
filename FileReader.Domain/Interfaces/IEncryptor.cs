using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader.Domain.Interfaces
{
    public interface IEncryptor
    {
        List<string> Encrypt();
    }
}
