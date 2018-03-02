using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers
{
    public class ProdutoController : Controller
    {
        static List<Produto> listaDeProdutos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "carro", Categoria = "auto",    Preco = 9 },
            new Produto { Id = 2, Nome = "Yo-yo",       Categoria = "brinque",         Preco = 3.95M },
            new Produto { Id = 3, Nome = "cd",      Categoria = "disco",     Preco = 20.99M }
        };
        // GET: Produto
        public ActionResult Index()
        {
            return View(listaDeProdutos);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            var produto = listaDeProdutos.FirstOrDefault(x => x.Id == id);
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            try
            {
                listaDeProdutos.Add(produto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = listaDeProdutos.FirstOrDefault(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id, Nome, Categoria, Preco")] Produto produto)
        {
            try
            {
                if (id != produto.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    //Atualizar produto encontrado na lista
                    var produtoTemp = listaDeProdutos.FirstOrDefault(c => c.Id == id);
                    if (produtoTemp != null)
                    {
                        produtoTemp.Categoria = produto.Categoria;
                        produtoTemp.Nome = produto.Nome;
                        produtoTemp.Preco = produto.Preco;
                    }
                    else
                    {
                        return NotFound();
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = listaDeProdutos.FirstOrDefault(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var produto = listaDeProdutos.FirstOrDefault(m => m.Id == id);
                listaDeProdutos.Remove(produto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}