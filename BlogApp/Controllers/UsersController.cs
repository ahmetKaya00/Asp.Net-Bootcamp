using System.Security.Claims;
using Blogapp.Data.Abstract;
using Blogapp.Data.Concrete.EfCore;
using Blogapp.Entity;
using Blogapp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogapp.Controllers
{
    public class UsersController : Controller{

        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository){
                _userRepository = userRepository;
        }

        public async Task<IActionResult> Logout(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        public IActionResult Register(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model){
            
            if(ModelState.IsValid)
            {
                var user = await _userRepository.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName || x.Email == model.Email);
                if(user == null)
                {
                    _userRepository.CreateUser(new User {
                        UserName  = model.UserName,
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password,
                        Image = "p11.jpg"
                    });
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Username ya da Email kullanımda.");
                }
            }
            return View(model);
        }
        public IActionResult Login(){
            if(User.Identity!.IsAuthenticated){
                return RedirectToAction("Index","Posts");
            }
            return View();
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model){
            if(ModelState.IsValid){
                var isUser = await _userRepository.Users.FirstOrDefaultAsync(x=>x.Email == model.Email && x.Password == model.Password);

                if(isUser != null){
                    var userClaims = new List<Claim>();

                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUser.UserId.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, isUser.UserName ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.GivenName, isUser.Name ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.UserData, isUser.Image ?? ""));

                    if(isUser.Email == "info@ahmetkaya.com"){
                        userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                    }

                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties{
                        IsPersistent = true
                    };

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

                    return RedirectToAction("Index","Posts");

                }
            }
            else
            {
                ModelState.AddModelError("","Kullanıcı adı veya şifre yanlış!");
            }

            return View();
        }
      
    }
}