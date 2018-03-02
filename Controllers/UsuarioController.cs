using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers
{
    public class UsuarioController : Controller
    {
        static List<Usuario> listaDeUsuario = new List<Usuario>
        {
           new Usuario {Id = 1,Nome = "Jefferson", Cpf="166.611.151-46", Email="te@tete.com"},
           new Usuario {Id = 2,Nome = "Sabes", Cpf="111.135.331-46", Email="tee@tese.com"},
           new Usuario {Id = 3,Nome = "Antonio", Cpf="111.155.111-46", Email="tese@tete.com"}
        };
        // GET: Usuario
        public ActionResult Index()
        {
            return View(listaDeUsuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            var usuario= listaDeUsuario.FirstOrDefault(x => x.Id == id);
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                listaDeUsuario.Add(usuario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = listaDeUsuario.FirstOrDefault(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id, Nome, Cpf, Email")] Usuario Usuario)
        {
            try
            {
                if (id != Usuario.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    //Atualizar usuario encontrado na lista
                    var produtoTemp = listaDeUsuario.FirstOrDefault(c => c.Id == id);
                    if (produtoTemp != null)
                    {
                        produtoTemp.Cpf = Usuario.Cpf;
                        produtoTemp.Nome = Usuario.Nome;
                        produtoTemp.Email = Usuario.Email;
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
        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = listaDeUsuario.FirstOrDefault(m => m.Id == id);
            if (usuario == null)
            {
                return View();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Deleteconfir(int id)
        {
            try
            {
                var usuario = listaDeUsuario.FirstOrDefault(m => m.Id == id);
                listaDeUsuario.Remove(usuario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}