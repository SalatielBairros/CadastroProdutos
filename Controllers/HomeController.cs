using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using CadastroProdutos.Models;

namespace CadastroProdutos.Controllers
{
    public class HomeController : Controller
    {
        private CadastroProdutosContext db = new CadastroProdutosContext();
        const string DefaultPassword = "123456";
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string password)
        {
            try
            {
                if (DefaultPassword.Equals(password))
                {
                    Session["CADPRODUSER"] = "AUTORIZADO";
                    return RedirectToAction("Index", "Produto");
                }
                else
                {
                    ViewBag.ErrorMessage = "Senha inválida.";
                    return View();
                }

            }
            catch
            {
                ViewBag.ErrorMessage = "Erro interno ao realizar login. Por favor tente mais tarde.";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["CADPRODUSER"] = null;
            return RedirectToAction("Index", "Home");            
        }

        public async Task<ActionResult> ListProdutos()
        {
            return View(await db.Produtoes.ToListAsync());
        }
    }
}