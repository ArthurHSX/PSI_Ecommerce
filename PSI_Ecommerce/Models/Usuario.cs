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
            try
            {
                using (var contexto = new Context.EcommerceContext())
                {
                    contexto.Usuario.Add(_usuario);
                    contexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível executar o comando no banco de Dados");
            }
        }

        public Usuario BuscaUsuario(Usuario _usuario)
        {
            try
            {
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
                    else
                        return null;
                }
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível executar o comando no banco de Dados");
            }
        }

        public Usuario BuscaUsuario(int _id)
        {
            if (_id <= 0)
            { return null; }

            try
            {
                using (var contexto = new Context.EcommerceContext())
                {
                    return (from us in contexto.Usuario
                            where us.ID == _id
                            select us).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível executar o comando no banco de Dados");
            }
        }

        public void BuscarContatos()
        {
            throw new Exception("Implemmentar método de busca");
        }

        public void BuscarAnunciosUsuario()
        {
            try
            {
                this.ListaAnuncio = (List<Anuncio>)new Anuncio().BuscarTodosAnuncios(ID);
            }
            catch
            {
                this.ListaAnuncio = null;
            }
            
        }

        #endregion

    }
}
