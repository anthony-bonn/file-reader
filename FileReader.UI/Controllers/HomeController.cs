using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileReader.Shared.Models.ViewModels;
using FileReader.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace FileReader.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IAuthService _authService;

        public HomeController(IFileService fileService, IAuthService authService)
        {
            _fileService = fileService;
            _authService = authService;
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
        public async Task<IActionResult> Index(FileReaderViewModel data)
        {
            if (!ModelState.IsValid) return View(data);

            Tuple<bool, byte[], string> result;

            try
            {
                result = await _fileService.Process(data, HttpContext.User);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new ErrorViewModel() { Message = e.Message });
            }

            if (!result.Item1) return RedirectToAction("Error", "Home", new ErrorViewModel() { Message = "User isn't allowed to read this file." });

            return File(result.Item2, result.Item3);
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

        public IActionResult Error(ErrorViewModel model)
        {
            return View(model);
        }
    }
}
