using Authentication.Mvc.Contexto;
using Authentication.Mvc.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authentication.Mvc.Controllers
{
    public class CarrinhoController : Controller
    {
        private DbContexto db = new DbContexto();

        [HttpGet]
        public ActionResult Index()
        {
            return View(this.PegaCarrinhoDaSessao());
        }
        
        [HttpGet]
        public ActionResult Adicionar(int id = 0)
        {
            var carrinho = this.PegaCarrinhoDaSessao();
            var produto = db.Produtos.Find(id);

            carrinho.Produtos.Add(produto);
            
            return RedirectToAction("Index", "Produtos");
        }

        [HttpGet]
        public ActionResult Remover(int idx = 0)
        {
            var carrinho = this.PegaCarrinhoDaSessao();

            carrinho.Produtos.RemoveAt(idx);
            
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult CancelarCarrinho()
        {
            Session.Abandon();
            PegaCarrinhoDaSessao().Produtos.Clear();

            return RedirectToAction("Index", "Produtos");
        }


        private Carrinho PegaCarrinhoDaSessao()
        {

            if(Session["Carrinho"] == null)
            {
                Session["Carrinho"] = new Carrinho();
            }

            return Session["Carrinho"] as Carrinho;
        }

    }
}