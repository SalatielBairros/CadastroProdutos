using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using CadastroProdutos.Helpers;
using CadastroProdutos.Models;

namespace CadastroProdutos.Controllers
{
    [SessionAuthorizeAttribute]
    public class ProdutoController : Controller
    {
        private CadastroProdutosContext db = new CadastroProdutosContext();

        // GET: /Produto/
        public async Task<ActionResult> Index()
        {
            return View(await db.Produtoes.ToListAsync());
        }

        // GET: /Produto/Create
        public ActionResult Create()
        {
            return View(Produto.Instance);
        }

        // POST: /Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Codigo,Nome,Tipo,Estoque,Valor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtoes.Add(produto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: /Produto/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtoes.FindAsync(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: /Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Codigo,Nome,Tipo,Estoque,Valor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // POST: /Produto/Delete/5
        [HttpPost]
        public async Task Delete(string id)
        {
            Produto produto = await db.Produtoes.FindAsync(id);
            db.Produtoes.Remove(produto);
            await db.SaveChangesAsync();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Filtrar(FiltroProduto filtro)
        {
            return View("Index", (await db.Produtoes.Where(x =>
                (string.IsNullOrEmpty(filtro.Nome.Trim()) || x.Nome.ToLower().Trim()
                    .Contains(filtro.Nome.ToLower().Trim())) &&
                (string.IsNullOrEmpty(filtro.Tipo.Trim()) || x.Tipo.ToLower().Trim()
                    .Contains(filtro.Tipo.ToLower().Trim())))
                .ToListAsync()));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
