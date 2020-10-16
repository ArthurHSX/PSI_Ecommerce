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

        public Usuario BuscaUsuario(Usuario usuario)
        {
            if(String.IsNullOrEmpty(usuario.Username) && String.IsNullOrEmpty(usuario.Email))
            { return null; }

            using (var contexto = new Context.EcommerceContext())
            {
                if (String.IsNullOrEmpty(usuario.Username))
                {
                    return (from us in contexto.Usuario
                            where us.Email == usuario.Email
                            select us).FirstOrDefault();
                }
                else if (String.IsNullOrEmpty(usuario.Email))
                {
                    return (from us in contexto.Usuario
                            where us.Username == usuario.Username
                            select us).FirstOrDefault();
                }
            }
            return null;
        }

        public void BuscarContatos()
        {
            throw new Exception("Implemmentar método de busca");
        }

        #endregion

    }
}
