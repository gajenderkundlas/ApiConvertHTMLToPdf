using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using TestAppServices.EmailService;
using TestAppServices.UserService;
using TestAppServices.UserService.Dto;

namespace TestAppWeb.Controllers
{
    public class UserController : Controller
    {
        IUserService userService;
        IEmailService emailService;
        IWebHostEnvironment env;
        public UserController(IUserService _userService, IEmailService _emailService, IWebHostEnvironment _env) { 
           userService = _userService;  
           emailService = _emailService;
            env = _env; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
           HttpContext.Session.Clear();
           return RedirectToAction("Login");
        }
        public async Task<IActionResult> LoginUser(LoginDto input)
        {
            if (ModelState.IsValid)
            {
                var response = await userService.LoginUser(input);
                if (response.Success)
                {
                    HttpContext.Session.SetString("apikey", response.Data.ApiKey);
                    HttpContext.Session.SetString("name", response.Data.Name);
                    HttpContext.Session.SetString("userId", response.Data.Id.ToString());
                    return RedirectToAction("Welcome", "Home");
                }
                else
                {
                    ViewBag.error = response.Error;
                }
            }
            return View("Login", input);
        }
        public async Task<IActionResult> VerifyUser(string Token) {
            var response = await userService.VerifyUser(Token);
            if (response.Success)
            {
                ViewBag.success = true;
                ViewBag.message = "Email verified successfully.";
            }
            else {
                ViewBag.success = false;
                ViewBag.message = response.Error;
            }
            return View();
        }
        public async Task<IActionResult> CreateAccount(UserDto input)
        {
            if (ModelState.IsValid)
            {
                var response = await userService.CreateUser(input);
                if (response.Success)
                {
                    string path = Path.Combine(env.ContentRootPath, "EmailTemplate", "SignupEmail.txt");
                    string html = System.IO.File.ReadAllText(path).Replace("{{name}}",input.Name).Replace("{{verificationtoken}}", response.Data.VerificationToken);
                    emailService.SendEmail(input.UserName, html);
                    return View("Success");
                }
                else
                {
                    ViewBag.error = response.Error;
                    return View("Signup", input);
                }
            }
            return View("Signup",input);
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
