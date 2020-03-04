using FileReader.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace FileReader.Domain.Encryptors
{
    public class ReverseEncryptor : IEncryptor
    {
        private readonly List<string> _input;

        public ReverseEncryptor(List<string> input) => _input = input;

        public List<string> Encrypt()
        {
            List<string> result = new List<string>();

            _input.Reverse();
            foreach (string line in _input)
            {
                var l = line.ToCharArray();
                Array.Reverse(l);
                result.Add(new string(l));
            }

            return result;
        }
    }
}
