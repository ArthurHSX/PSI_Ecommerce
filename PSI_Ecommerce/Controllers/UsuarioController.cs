using Microsoft.AspNetCore.Mvc;
using PSI_Ecommerce.Dominio;

namespace PSI_Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult MeusAnuncios()
        {
            return View();
        }
    }
}
