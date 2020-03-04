using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FileReader.Shared.Models.ViewModels
{
    public class FileReaderViewModel
    {
        [Required(ErrorMessage = "Please select a file.")]
        public IFormFile File { get; set; }
        public List<string> Original { get; set; } = new List<string>();
    }
}
