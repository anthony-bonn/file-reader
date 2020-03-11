using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FileReader.Shared.Models.ViewModels
{
    public class FileReaderViewModel
    {
        [Required(ErrorMessage = "Please select a file.")]
        public IFormFile File { get; set; }

        public bool Encrypted { get; set; }
    }
}
