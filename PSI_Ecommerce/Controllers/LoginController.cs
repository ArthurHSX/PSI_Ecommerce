﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult BuscaUsuario([Bind("Email, Senha")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var us = usuario.BuscaUsuario(usuario);
                    if (us != null)
                    {
                        return RedirectToAction("Index", "Anuncio", usuario);
                        //return Redirect("https://localhost:44359/Home/Index"); // redirect para a página inicial
                    } else
                    {
                        ModelState.AddModelError("usuario.Invalido", "Credenciais inválidas!");  // retornar mensagem de usuário invalido pra view
                        return View("Entrar");
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

                    return RedirectToAction("MeusAnuncios", "Usuario", usuario);
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("usuario.Invalido", "Credenciais inválidas!");  // retornar mensagem de usuário invalido pra view
                return null;
            }
        }
    }
}
