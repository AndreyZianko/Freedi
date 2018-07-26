using Freedi.Logic;
using Freedi.Logic.Interfaces;
using Freedi.Model.ViewModels;
using Freedi.Website.Models;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Freedi.Website.Controllers
{
    public class AccountController : Controller
    {
        IUserManager _um;
      
        public AccountController(IUserManager um)
        {
            _um = um;
            
          
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
           
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserViewModel userDto = new UserViewModel { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await _um.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Admin()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            //await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserViewModel userDto = new UserViewModel
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = await _um.Create(userDto);
                if (operationDetails.Succedeed)
                { 
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }

        private async Task SetInitialDataAsync()
        {
            await _um.SetInitialData(new UserViewModel
            {
                Email = "kxabog@mail.ru",
                UserName = "kxabog@mail.ru",
                Password = "kxabog123",
                Name = "Андрей Андреевич Андреев",
                Address = "ул. Спортивная, д.30, кв.75",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }
    }
}