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
        [HttpGet("")]
        public ActionResult Index()
        {
            try
            {
                return View("Anuncios", GetAnunciosMock());
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return View("Anuncios", GetAnunciosMock());
            }
        }

        // GET: AnuncioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnuncioController/Create
        public ActionResult NovoAnuncio(Usuario usuario)
        {
            return View(usuario);
        }

        // GET: AnuncioController/MeusAnuncios
        public ActionResult MeusAnuncios(Usuario vwUsuario)
        {
            vwUsuario.BuscarAnunciosUsuario();
            Anuncio anuncio = new Anuncio()
            {
                Usuario = vwUsuario,                
                UsuarioId = vwUsuario.ID,

            };

            ViewBag.Message = anuncio.Usuario;
            
            return View("MeusAnuncios", vwUsuario);
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
                        ID = 5,
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

        public List<Anuncio> GetAnunciosMock()
        {
            Anuncio anuncio = new Anuncio();
            List<Anuncio> anunciosList = new List<Anuncio>();

            if (anuncio.BuscarAnuncios() == null)
            {
                for (int i = 0; i < 10; i++)
                {
                    Anuncio an = new Anuncio();
                    an.ID = i + 310;
                    an.Titulo = "Título Anuncio " + i;
                    an.UsuarioId = 5;
                    an.Valor = 100 * i;
                    an.Descricao = "Descrição Anuncio " + i;
                    anunciosList.Add(an);
                }
            }
            else
            {
                anunciosList = anuncio.BuscarAnuncios();
            }

            return anunciosList;
        }

    }
}
