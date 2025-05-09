using ITI_BL.DTO.User;
using ITI_BL.Manager.User;
using ITI_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ITI_BL.DTO;
using ITI_BL.Manager;

namespace ITI_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManagerIdentity;
        private readonly SignInManager<User> signInManager ;

        public AccountController(UserManager<User> manager, SignInManager<User> userManagerIdentity)
        {
            _userManagerIdentity = manager;
            signInManager = userManagerIdentity;
        }


        #region Authentication
        [HttpGet]
        public IActionResult Login()=>View();
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin _user)
        {
            if (!ModelState.IsValid)
            {
                return View(_user);
            }
            var user = await _userManagerIdentity.FindByNameAsync(_user.Name);
            if (user is null) {
                ModelState.AddModelError("", "Invalid User");
                
                return View(_user);
            
            }
            if(_user.Password is null)
            {
                ModelState.AddModelError("", "Enter Password");

                return View(_user);

            }
            var isValidPass = await _userManagerIdentity.CheckPasswordAsync(user, _user.Password);
            if (!isValidPass)
            {
                ModelState.AddModelError("", "Invalid User");
                return View(_user);
            }
            var claims = await _userManagerIdentity.GetClaimsAsync(user);
            await signInManager.SignInWithClaimsAsync(user,false,claims);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult register() => View();
        [HttpPost]
        public async Task<IActionResult> register(UserCreate _user)
        {
            if (!ModelState.IsValid) return View(_user);
            var user = new User()
            {
                Email = _user.Email,
                UserName = _user.Name,
                Name = _user.Name,
            };
            if (_user.Password is null)
            {
                ModelState.AddModelError("", "Enter Password");

                return View(_user);

            }
            var result = await _userManagerIdentity.CreateAsync(user, _user.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.Errors.First().Description.ToString());
                return View(_user);
            }
            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Email, user.Email.ToString()),
            };
            await _userManagerIdentity.AddClaimsAsync(user, claims);
            return RedirectToAction("Login");
        }
        
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
