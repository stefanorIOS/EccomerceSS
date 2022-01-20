using AutoMapper;
using EccomerceSS.Utilities.EmailSender;
using EccomerceSS.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EccomerceSS.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
                        UserManager<IdentityUser> userManager,
                        IMapper mapper,
                        IEmailSender emailSender,
                        ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _emailSender = emailSender;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "There is not any user with that email, type it again please");
                    return View();
                }
                if (!user.EmailConfirmed)
                {
                    ModelState.AddModelError("Account", "Your account is not confirmed, check your account inbox and press the confirmation link");
                    return View();
                }
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("Account", "Invalid login attempt");
                    return View();
                }
                _logger.LogInformation("The person was logged in succesfully");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                _logger.LogError(ex.Message);
                return View();
            }
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterUserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                IdentityUser user = _mapper.Map<IdentityUser>(model);
                var userExists = await _userManager.FindByEmailAsync(user.Email);
                if (userExists != null)
                {
                    ModelState.AddModelError("SignUp", "This email is already in use");
                    return View();
                }
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return View();
                }
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var urlConfirmation = Url.Action("ConfirmAccount", "Account", new
                {
                    token = token,
                    userId = user.Id
                }, Request.Scheme);
                await _emailSender.SendAsync(model, "Account confirmation", urlConfirmation);
                _logger.LogInformation("Succesfully created the account");
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                _logger.LogError(ex.Message);
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmAccount(string token, string userId)
        {
            try
            {

                if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(userId))
                {
                    ModelState.AddModelError("Confirmation", "Invalid Link");
                    return RedirectToAction("Login");
                }
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    ModelState.AddModelError("Confirmation", "Invalid link");
                    return RedirectToAction("Login");
                }
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (!result.Succeeded)
                {
                    return View("Login");
                }
                ModelState.AddModelError("Confirmation", "Your account has been succesfully created, please login");
                _logger.LogInformation("Succesfully confirmed the account");
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                _logger.LogError(ex.Message);
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ConfigUser()
        {
            return View();
        }
    }
    
}
