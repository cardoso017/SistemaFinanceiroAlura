using Financa.DAO;
using Financa.Entidades;
using Financa.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financa.Controllers
{
    [Authorize] 
    public class MovimentacaoController : Controller
    {
        private MovimentacaoDao movimentacaodao;
        private UsuarioDao usuariodao;

        public MovimentacaoController(MovimentacaoDao movimentacaodao, UsuarioDao usuariodao)
        {
            this.movimentacaodao = movimentacaodao;
            this.usuariodao = usuariodao;
        }

        

        public ActionResult Form()
        {
            ViewBag.Usuarios = usuariodao.Lista();
            return View();
        }

        public ActionResult Adiciona(Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                movimentacaodao.Adicionar(movimentacao);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Usuarios = usuariodao.Lista();
                return View("Form", movimentacao);
            }
        }

        public ActionResult Index() {


            IList<Movimentacao> movimentacaos = movimentacaodao.Lista();

            return View(movimentacaos); 
        }


        public ActionResult MovimentacaoPorUsuario(MovimentacaoPorUsuarioModel model)
        {
            model.usuarios = usuariodao.Lista();
            model.Movimentacaos =   movimentacaodao.BuscaPorUsuario(model.UsuarioId);
            return View(model);
        }

        public ActionResult Busca(BuscaMovimentacaoModel model)
        {
            model.Usuarios = usuariodao.Lista();
            model.Movimentacaos = movimentacaodao.Busca(model.ValorMinimo, model.ValorMaximo,
                                                        model.DataMinima, model.DataMaxima,
                                                        model.Tipo, model.IdUsuario);

            return View(model);

        }



    }
}