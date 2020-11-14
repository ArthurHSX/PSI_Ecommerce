using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PSI_Ecommerce.Models
{
    public class Usuario
    {
        #region Propriedades
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        [NotMapped]
        public List<Anuncio> ListaAnuncio { get; set; }
        #endregion

        #region Métodos

        public Usuario()
        { }

        public Usuario(int _usuarioId)
        {
            this.BuscaUsuario(_usuarioId);
            this.BuscarAnunciosUsuario();
        }

        public void ManterCadastro(Usuario _usuario)
        {
            using (var contexto = new Context.EcommerceContext() )
            {
                contexto.Usuario.Add(_usuario);
                contexto.SaveChanges();
            }                
        }

        public Usuario BuscaUsuario(Usuario _usuario)
        {
            if(String.IsNullOrEmpty(_usuario.Username) && String.IsNullOrEmpty(_usuario.Email))
            { return null; }

            using (var contexto = new Context.EcommerceContext())
            {
                if (String.IsNullOrEmpty(_usuario.Username))
                {
                    return (from us in contexto.Usuario
                            where us.Email == _usuario.Email
                            select us).FirstOrDefault();
                }
                else if (String.IsNullOrEmpty(_usuario.Email))
                {
                    return (from us in contexto.Usuario
                            where us.Username == _usuario.Username
                            select us).FirstOrDefault();
                }
            }
            return null;
        }

        public Usuario BuscaUsuario(int _id)
        {
            if (_id <= 0)
            { return null; }

            using (var contexto = new Context.EcommerceContext())
            {
                return (from us in contexto.Usuario
                        where us.ID == _id
                        select us).FirstOrDefault();
            }
        }

        public void BuscarContatos()
        {
            throw new Exception("Implemmentar método de busca");
        }

        public void BuscarAnunciosUsuario() => ListaAnuncio = (List<Anuncio>)new Anuncio().BuscarAnuncios(ID);

        #endregion

    }
}
