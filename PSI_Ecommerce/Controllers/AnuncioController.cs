using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSI_Ecommerce.Models;

namespace PSI_Ecommerce.Controllers
{
    public class AnuncioController : Controller
    {
        // GET: AnuncioController
        public ActionResult Index()
        {
            try
            {
                Anuncio anuncio = new Anuncio();
                List<Anuncio> lista = new List<Anuncio>();
                lista = anuncio.ListarAnuncios();
                if (lista != null)
                    return View("MeusAnuncios");
                else
                {
                    return View();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return View("MeusAnuncios");
            }
        }

        // GET: AnuncioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnuncioController/Create
        public ActionResult NovoAnuncio()
        {
            return View();
        }

        // POST: AnuncioController/Create
        [HttpPost]
        public ActionResult Create([Bind("TituloAnuncio, Descricao, Valor, Senha")] Anuncio anuncio, Usuario usuario)
        {
            // Redireciona para login
            try
            {
                if (ModelState.IsValid)
                {
                    // Receber usuario
                    anuncio.Usuario = new Usuario()
                    {
                        //ID = 1,
                        Email = "arthurwesley7@gmail.com",
                        Username = "arthurwesley7"
                    };
                    anuncio.ManterAnuncio(anuncio);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: AnuncioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnuncioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnuncioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnuncioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
