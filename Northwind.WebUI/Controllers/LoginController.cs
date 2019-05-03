
using Northwind.Entities.Concrete;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Northwind.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private IAuthenticationService _authentication;
        public LoginController(IAuthenticationService authentication)
        {
            _authentication = authentication;
        }

        // GET: Account
        public ActionResult Login()
        {
            return View(new User());
        }
        [HttpPost]
        public ActionResult Login(User user,string returnUrl)
        {
            if (_authentication.IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return Redirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError("Hata", "Girdiğiniz kullanıcı adı veya şifre eşleşmiyor");
                return View(user);
            }
          
        }


    }


}