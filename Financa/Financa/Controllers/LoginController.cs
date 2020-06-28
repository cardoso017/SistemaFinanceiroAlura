using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Financa.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autenticar( string Login, string Senha)
        {
          if  (WebSecurity.Login(Login, Senha))
            {
                return RedirectToAction("Index");
            }
          else
            {
                ModelState.AddModelError("Login.Invalido", "Login ou senha incorretos");
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index");
        }

    }
}