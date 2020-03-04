using FileReader.Domain.Encryptors;
using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using System.Collections.Generic;

namespace FileReader.Domain.Factories.Encryptors
{
    public class ProtectEncryptorFactory : EncryptorFactory
    {
        public override IEncryptor Create(List<string> input, IDataProtector protector = null) => new ProtectEncryptor(input, protector);
    }
}
