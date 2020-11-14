using Microsoft.AspNetCore.Mvc;
using PSI_Ecommerce.Models;

namespace PSI_Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult MeusAnuncios(Usuario usuario)
        {
            /*  TO DO:
             *  1 - Dar um bind dos anuncios para o usuário. (Fazer uma busca no banco)
             */

            usuario.BuscarAnunciosUsuario();

            return View();
        }
    }
}
