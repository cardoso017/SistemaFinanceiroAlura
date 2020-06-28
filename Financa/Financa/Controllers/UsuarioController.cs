using Financa.DAO;
using Financa.Entidades;
using Financa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Financa.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDao usuarioDao;

        public UsuarioController(UsuarioDao usuarioDao)
        {
            this.usuarioDao = usuarioDao;
        }
        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(UsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    WebSecurity.CreateUserAndAccount(model.Nome, model.Senha,
                        new { Email = model.Email });
                    return RedirectToAction("Index");
                }
                catch (MembershipCreateUserException e){
                    ModelState.AddModelError("Usuario.Invalido", e.Message);
                    return View("Form", model);
                }
            }
            else
            {
                return View("Form", model);
            }
        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuarioDao.Lista();
            return View(usuarios);
        }

    }
}