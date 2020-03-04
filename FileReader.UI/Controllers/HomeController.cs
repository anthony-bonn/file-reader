using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileReader.Shared.Models.ViewModels;
using FileReader.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Authorization;

namespace FileReader.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IAuthService _authService;
        private readonly IDataProtector _protector;

        public HomeController(IFileService fileService, IAuthService authService, IDataProtectionProvider provider)
        {
            _fileService = fileService;
            _authService = authService;
            _protector = provider.CreateProtector("FileReader.UI.HomeController");
        }

        [HttpGet]
        public IActionResult Authentication() => View();

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationViewModel vm)
        {
            await _authService.Login(this, vm.AuthenticationType);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout(this);
            return RedirectToAction("Authentication");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(FileReaderViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            vm = await _fileService.Process(vm, _protector, HttpContext.User);

            return View(vm);
        }

        [HttpPost]
        public IActionResult SetTheme(string data)
        {
            CookieOptions cookieoptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(5)
            };

            Response.Cookies.Append("FileReader.UI.Theme", data == "dark" ? "light" : "dark", cookieoptions);
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
