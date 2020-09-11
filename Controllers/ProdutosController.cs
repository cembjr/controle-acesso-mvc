using CB.WebApp.MVC.Models;
using CB.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CB.WebApp.MVC.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await produtoService.ListarAsync());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = await produtoService.Obter(id);
            if (produtoViewModel == null)
                return NotFound();

            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produto)
        {
            if (!ModelState.IsValid) return View(produto);

            var produtoAdicionar = new AdicionarProdutoViewModel()
            {
                Descricao = produto.Descricao,
                Nome = produto.Nome,
                Valor = produto.Valor
            };

            var result = await produtoService.AdicionarProduto(produtoAdicionar);

            if (result)
                return RedirectToAction(nameof(Index));
            else
                return View(produto);

        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = await produtoService.Obter(id);
            if (produtoViewModel == null)
                return NotFound();

            return View(produtoViewModel);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(produtoViewModel);

            var ret = await produtoService.Atualizar(produtoViewModel);
            if (ret)
                return RedirectToAction(nameof(Index));
            else 
                return View(produtoViewModel);

        }

        //// GET: Produtos/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var produtoViewModel = await _context.ProdutoViewModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (produtoViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(produtoViewModel);
        //}

        //// POST: Produtos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var produtoViewModel = await _context.ProdutoViewModel.FindAsync(id);
        //    _context.ProdutoViewModel.Remove(produtoViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProdutoViewModelExists(Guid id)
        //{
        //    return _context.ProdutoViewModel.Any(e => e.Id == id);
        //}
    }
}
