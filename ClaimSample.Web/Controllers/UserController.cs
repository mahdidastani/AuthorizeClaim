using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClaimSample.Core.Services.Interfaces;
using ClaimSample.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using ClaimSample.DataLayer.Entities;

namespace ClaimSample.Web.Controllers
{
    public class UserController : Controller
    {

        IUserService _userservice { get; set; }

        public UserController(IUserService userService)
        {
            _userservice = userService;
        }


        public IActionResult Index()
        {
            return View();
        }


        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }


        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = _userservice.LoginUser(login);

            if (User!=null)
            {
                var cliams = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new Claim(ClaimTypes.Name          ,user.FirstName + " " + user.LastName),
                    new Claim(ClaimTypes.Email         ,user.Email) ,
                    new Claim(ClaimTypes.UserData ,user.LastLogin.ToString())

                };

                var Identity = new ClaimsIdentity(cliams, CookieAuthenticationDefaults.AuthenticationScheme );


                var Perincipal = new ClaimsPrincipal(Identity);
                var proptity = new AuthenticationProperties {IsPersistent= login.RememberMe};

                HttpContext.SignInAsync(Perincipal, proptity);

                return RedirectToAction(  nameof(UserPanel));
            }
            else
            {
                ModelState.AddModelError("Email", "چنین کاربری یافت نشد");
            }
            return View();
        }


        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

        [Route("UserPanel")]
        [Authorize]
        public IActionResult UserPanel() 
        {
            return View();
        }



        [Route("Register")]
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User user)
        {
            
            _userservice.addUser(user);
            return View();
        }
    }
}