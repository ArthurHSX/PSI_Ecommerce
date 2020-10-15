using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_Ecommerce.Models
{
    public class Usuario
    {
        #region Propriedades

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        #endregion

        #region Métodos

        public void ManterCadastro(Usuario _usuario)
        {
            using (var contexto = new Context.EcommerceContext() )
            {
                contexto.Add(_usuario);
                contexto.SaveChanges();
            }
                
        }

        public Usuario RetornarUsuario(string _username)
        {
            using (var contexto = new Context.EcommerceContext())
            {
                return (from us in contexto.Usuario
                        where us.Username == _username
                        select us).FirstOrDefault();
            }
        }

        public void BuscarContatos()
        {
            throw new Exception("Implemmentar método de busca");
        }

        #endregion

    }
}
