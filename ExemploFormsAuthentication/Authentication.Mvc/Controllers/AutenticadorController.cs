using Authentication.Mvc.Contexto;
using Authentication.Mvc.ViewModel;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Authentication.Mvc.Controllers
{
    public class AutenticadorController : Controller
    {
        private DbContexto db = new DbContexto();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(UsuarioViewModel usuario)
        {
            if(ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(usuario.Nome, false);

                return RedirectToAction("Index", "Produtos");
            }

            return View(usuario);
        }


        [HttpGet]
        public ActionResult Entrar()
        {
            return View();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Entrar(UsuarioViewModel usuario)
        {
            if(ModelState.IsValid)
            {
                if (IsValidUser(usuario) && IsValidPassword(usuario))
                {                   
                    FormsAuthentication.SetAuthCookie(usuario.Nome, false);
                         
                    return RedirectToAction("Index", "Produtos");
                }
            }

            return View(usuario);
        }

        [HttpGet]
        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Entrar");
        }

        #region IsValid
        private bool IsValidUser(UsuarioViewModel usuario)
        {
            var aux = false;
            var user = (from c in db.Usuarios
                        where c.Nome == usuario.Nome
                        select c.Nome).ToList().Count;

            if(user != 0)
            {
                aux = true;
            }

            return aux ;
        }

        private bool IsValidPassword(UsuarioViewModel usuario)
        {
            var aux = false;

            var password = (from c in db.Usuarios
                        where c.Password == usuario.Password
                        select c.Nome).ToList().Count;
            
            if (password != 0)
            {
                aux = true;
            }

            return aux;
        }

        #endregion
    }
}