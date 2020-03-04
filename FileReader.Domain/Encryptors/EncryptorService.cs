using FileReader.Domain.Enums;
using FileReader.Domain.Factories.Encryptors;
using FileReader.Domain.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader.Domain.Encryptors
{
    public class EncryptorService
    {
        private readonly Dictionary<EncryptionType, EncryptorFactory> _factories;

        private EncryptorService()
        {
            _factories = new Dictionary<EncryptionType, EncryptorFactory>();

            // could work with a switch statement to return the required encryptor
            //
            // could manualy add a new dictionary member per available encryptor type
            // 
            // instead we chose to use reflection to create a new <EncryptorType, EncryptorFactory> dictionary based on EncryptorType enum members
            // this way we don't have to manually add EncryptorType/Factory creator for each encryptor
            foreach (EncryptionType encryptorType in Enum.GetValues(typeof(EncryptionType)))
            {
                var factory = (EncryptorFactory)Activator
                    .CreateInstance(Type.GetType("FileReader.Domain.Factories.Encryptors." + Enum.GetName(typeof(EncryptionType), encryptorType) + "EncryptorFactory"));
                _factories.Add(encryptorType, factory);
            }
        }

        public static EncryptorService InitFactories() => new EncryptorService();

        public IEncryptor InitEncryptor(EncryptionType encryptorType, List<string> input, IDataProtector protector = null) => _factories[encryptorType].Create(input, protector);
    }
}
