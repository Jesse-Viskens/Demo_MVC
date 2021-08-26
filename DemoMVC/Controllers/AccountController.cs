using DemoMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> RegisterUser(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid == true)
            {
                var user = new IdentityUser { UserName = loginViewModel.UserName,PasswordHash = loginViewModel.Password, Email = loginViewModel.Email };
                var result = await _userManager.CreateAsync(user, loginViewModel.Password);

                if (result.Succeeded)
                {
                    //show popup
                    return View("Login");
                }
                else
                {
                    //what if the user couldn't be added?
                    //logging
                    //exception handling
                    //...
                }
            }
            return View("register",loginViewModel);
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Authenticate(LoginViewModel login)
        {
            if(ModelState.IsValid == true)
            {
                var user = await _userManager.FindByNameAsync(login.UserName);
                if(user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, true, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Auto");
                    }
                }
            }
            return View("Login",login);
        }
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Route("/Account/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
