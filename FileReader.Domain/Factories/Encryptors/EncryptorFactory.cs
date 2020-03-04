using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using System.Collections.Generic;

namespace FileReader.Domain.Factories.Encryptors
{
    public abstract class EncryptorFactory
    {
        public abstract IEncryptor Create(List<string> input, IDataProtector protector = null);
    }
}
