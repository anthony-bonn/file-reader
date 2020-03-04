using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;

namespace FileReader.Domain.Encryptors
{
    public class ProtectEncryptor : IEncryptor
    {
        private readonly List<string> _input;
        private readonly IDataProtector _protector;

        public ProtectEncryptor(List<string> input, IDataProtector protector)
        {
            _input = input;
            _protector = protector;
        }

        public List<string> Encrypt()
        {
            List<string> result = new List<string>();

            foreach (string line in _input)
            {
                result.Add(_protector.Protect(line));
            }

            return result;
        }
    }
}
