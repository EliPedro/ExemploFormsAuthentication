using Authentication.Mvc.Contexto;
using Authentication.Mvc.ViewModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authentication.Mvc.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos

        private DbContexto db = new DbContexto();

        [Authorize]
        public ActionResult Index()
        {       
              return View(db.Produtos.ToList());
        }


        [HttpGet]
        [Authorize]
        public ActionResult Cadastra()
        {

            return View();

        }


        [Authorize]
        [HttpPost]
        public ActionResult Cadastra(ProdutoViewModel produto)
        {
            if(ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(produto);
        }
    }
}