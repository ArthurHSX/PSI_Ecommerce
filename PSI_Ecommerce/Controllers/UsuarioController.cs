using Microsoft.AspNetCore.Mvc;
using PSI_Ecommerce.Models;

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
