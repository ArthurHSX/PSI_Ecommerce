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

        // GET: AnuncioController/Create
        //[HttpGet]
        //public IActionResult NovoAnuncio(Usuario usuario)
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult NovoAnuncio(Usuario usuario)
        {
            Anuncio anuncio = new Anuncio()
            {
                Usuario = usuario
            };

            return View("NovoAnuncio", anuncio);
        }

        // GET: AnuncioController/MeusAnuncios
        [HttpGet]
        public ActionResult MeusAnuncios(Usuario vwUsuario)
        {
            vwUsuario.BuscarAnunciosUsuario();
            Anuncio anuncio = new Anuncio()
            {
                Usuario = vwUsuario,                
                UsuarioId = vwUsuario.ID,

            };

            ViewBag.Message = anuncio.Usuario;
            
            return View("MeusAnuncios");
        }

        // POST: AnuncioController/Create
        [HttpPost]
        public ActionResult Create(Anuncio anuncio)
        {

            UsuarioController usuarioController = new UsuarioController();
            
            try
            {
                if (ModelState.IsValid)
                {
                    // Receber usuario
                    anuncio.Usuario = usuarioController.buscarUsuarioPorId(anuncio.UsuarioId);
                    anuncio.ManterAnuncio(anuncio);
                }
                return RedirectToAction("MeusAnuncios", anuncio.Usuario);
            }
            catch (Exception ex)
            {
                return View("MeusAnuncios");
            }
        }

        [HttpGet]
        public ActionResult Editar(Anuncio anuncio)
        {
            UsuarioController userController = new UsuarioController();
            anuncio.Usuario = userController.buscarUsuarioPorId(anuncio.UsuarioId);
            return View("NovoAnuncio", anuncio);
        }

        // POST: AnuncioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "TituloAnuncio, Descricao, Valor, ID, UsuarioId")] Anuncio anuncio)
        {
            UsuarioController usuarioController = new UsuarioController();
            try
            {
                if (ModelState.IsValid)
                {
                    // Receber usuario
                    anuncio.Usuario = usuarioController.buscarUsuarioPorId(anuncio.UsuarioId);
                    anuncio.ManterAnuncio(anuncio);
                }
                return RedirectToAction("MeusAnuncios", anuncio.Usuario);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeletarAnuncio(Anuncio anuncio)
        {
            UsuarioController usuarioController = new UsuarioController();
          
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = usuarioController.buscarUsuarioPorId(anuncio.UsuarioId);
                    anuncio.DeletarAnuncio(anuncio.ID);
                    return RedirectToAction("MeusAnuncios", usuario);
                }
                else
                {
                    return View("MeusAnuncios");
                }
            }
            catch (Exception ex)
            {
                return View("MeusAnuncios", anuncio.Usuario);
            }
        }

        [HttpGet]
        public IActionResult DetalheAnuncio(Anuncio anuncio)
        {
            if (anuncio == null) 
                return View("Index");
            else
            {
                anuncio.Usuario = new Usuario().BuscaUsuario(anuncio.UsuarioId);
                return View(anuncio);
            }                
        }

        public List<Anuncio> GetAnunciosMock()
        {
            Anuncio anuncio = new Anuncio();
            List<Anuncio> anunciosList = new List<Anuncio>();

            if (anuncio.BuscarTodosAnuncios() == null)
            {
                for (int i = 0; i < 10; i++)
                {
                    Anuncio an = new Anuncio();
                    an.ID = i + 310;
                    an.TituloAnuncio = "Título Anuncio " + i;
                    an.UsuarioId = 5;
                    an.Valor = 100 * i;
                    an.Descricao = "Descrição Anuncio " + i;
                    anunciosList.Add(an);
                }
            }
            else
            {
                anunciosList = anuncio.BuscarTodosAnuncios();
            }

            return anunciosList;
        }

        public Anuncio GetAnuncioByID(int id)
        {
            try
            {
                Anuncio an = new Anuncio();
                return an.BuscarAnuncio(id);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
