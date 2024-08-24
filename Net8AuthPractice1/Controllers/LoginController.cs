using Microsoft.AspNetCore.Mvc;
using Net8AuthPractice1.Models;
using Net8AuthPractice1.Models.Dto;
using Net8AuthPractice1.Services;
using System.Text.Json;

namespace Net8AuthPractice1.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _userService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(UserService userService, ILogger<LoginController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            _logger.LogInformation($"Login attempt for user: {loginDto.UserName}");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is invalid");
                foreach (var key in ModelState.Keys)
                {
                    var modelStateEntry = ModelState[key];
                    foreach (var error in modelStateEntry.Errors)
                    {
                        _logger.LogWarning($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }
                return View(loginDto);
            }

            var (success, message) = await _userService.AuthenticateUser(loginDto.UserName, loginDto.Password);

            if (success)
            {
                _logger.LogInformation($"User {loginDto.UserName} authenticated successfully");
                var authenticatedUser = await _userService.GetUserByUsername(loginDto.UserName);
                if (authenticatedUser != null)
                {
                    HttpContext.Session.SetString("UserRole", authenticatedUser.Role);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _logger.LogError($"User {loginDto.UserName} not found after successful authentication");
                    ModelState.AddModelError(string.Empty, "User not found after authentication");
                }
            }
            else
            {
                _logger.LogWarning($"Authentication failed for user {loginDto.UserName}: {message}");
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }

            return View(loginDto);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
