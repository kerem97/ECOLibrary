using ECOLibrary.BusinessLayer.Services.UserService;
using ECOLibrary.DTOs.User.Requests;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ECOLibrary.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginRequest userLoginRequest)
        {
            if (ModelState.IsValid)
            {
                var isValidUser = await _userService.ValidateUserAsync(userLoginRequest.Username, userLoginRequest.Password);

                if (isValidUser)
                {
                    HttpContext.Session.SetString("Username", userLoginRequest.Username);
                    return RedirectToAction("Index", "Book"); 
                }

                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            }

            return View(userLoginRequest); 
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); 
            return RedirectToAction("Index", "Login"); 
        }
    }
}
