using Microsoft.AspNetCore.Mvc;
using PSI_Ecommerce.Models;
using System;

namespace PSI_Ecommerce.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Entrar()
        {
            Usuario usuario = new Usuario();

            return View(usuario);
        }

        [HttpGet]
        public IActionResult BuscaUsuario([Bind("Email, Senha")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var us = usuario.BuscaUsuario(usuario);
                    if (us != null)
                    {
                        return Redirect("https://localhost:44359/Home/Index"); // redirect para a página inicial
                    } else
                    {
                        return null; // retornar mensagem de usuário invalido pra view
                    }
                } else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
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

                    return RedirectToAction(nameof(Entrar));
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
