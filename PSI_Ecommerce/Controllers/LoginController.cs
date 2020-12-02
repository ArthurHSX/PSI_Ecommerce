using Microsoft.AspNetCore.Mvc;
using PSI_Ecommerce.Models;
using System;

namespace PSI_Ecommerce.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Entrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BuscaUsuario([Bind("Email, Senha")] Usuario vwUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var us = vwUsuario.BuscaUsuario(vwUsuario);
                    if (us != null)
                    {
                        //return RedirectToRoute()
                        return RedirectToAction("MeusAnuncios", "Anuncio", us);
                        //return RedirectToAction("MeusAnuncios", "Anuncio", us.ID);
                    }
                    else
                    {
                        ModelState.AddModelError("usuario.Invalido", "Credenciais inválidas!");  // retornar mensagem de usuário invalido pra view                        
                    }
                } else
                {
                    ModelState.AddModelError("usuario.Invalido", "Não foi possível fazer a busca de usuário");  // retornar mensagem de usuário invalido pra view
                }
                return View("Entrar");
            }
            catch (Exception ex)
            {
                return View("Entrar");
            }
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastraUsuario([Bind("Nome, Username, Email, Senha")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Persistir as informações do Usuario.
                    usuario.ManterCadastro(usuario);

                    return RedirectToAction("MeusAnuncios", "Anuncio", usuario);
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("usuario.Invalido", "Não foi possível fazer o cadastro do usuário");  // retornar mensagem de usuário invalido pra view
                return null;
            }
        }
    }
}
