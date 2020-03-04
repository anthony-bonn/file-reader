using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileReader.Shared.Models.ViewModels;
using FileReader.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.DataProtection;

namespace FileReader.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IDataProtector _protector;

        public HomeController(IFileService fileService, IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("FileReader.UI.HomeController");
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(FileReaderViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            vm = await _fileService.Process(vm, _protector);

            return View(vm);
        }

        [HttpPost]
        public IActionResult SetTheme(string data)
        {
            CookieOptions cookieoptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(5)
            };

            Response.Cookies.Append("FileReader.theme", data == "dark" ? "light" : "dark", cookieoptions);
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
