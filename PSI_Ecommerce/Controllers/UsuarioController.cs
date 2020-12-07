using Microsoft.AspNetCore.Mvc;
using PSI_Ecommerce.Models;

namespace PSI_Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        public Usuario buscarUsuarioPorId(int id)
        {
            try
            {
                Usuario user = new Usuario();
                return user.BuscaUsuario(id);
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}
