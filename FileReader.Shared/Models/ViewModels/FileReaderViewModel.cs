using FileReader.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FileReader.Shared.Models.ViewModels
{
    public class FileReaderViewModel
    {
        [Required(ErrorMessage = "Please select a file.")]
        public IFormFile File { get; set; }
        public bool Encrypt { get; set; }
        public EncryptionType EncryptionType { get; set; }
        public bool IsAllowedToRead { get; set; } = true;
        public List<string> Original { get; set; } = new List<string>();
        public List<string> Encrypted { get; set; } = new List<string>();
    }
}
