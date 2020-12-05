using PSI_Ecommerce.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PSI_Ecommerce.Models
{
    public class Anuncio
    {
        #region Propriedades
        [Key]
        public int ID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string TituloAnuncio { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }

        #endregion

        #region Métodos

        public EcommerceContext GetAnuncio()
        {
            var contexto = new Context.EcommerceContext();
            if (contexto != null)
            {
                return contexto;
            }
            else
            {
                return null;
            }
        }

        public void ManterAnuncio(Anuncio _anuncio)
        {
            using (var contexto = new Context.EcommerceContext())
            {
                //contexto.Anuncio.Add(_anuncio);
                contexto.Anuncio.Add(new Anuncio()
                {
                    Valor = _anuncio.Valor,
                    Descricao = _anuncio.Descricao,
                    TituloAnuncio = _anuncio.TituloAnuncio,
                    UsuarioId = _anuncio.Usuario.ID
                });
                contexto.SaveChanges();
            }
        }

        public void BuscarFotos(int idAnuncio)
        {
            throw new NotImplementedException("Implemmentar método de busca");
        }

        public IEnumerable<Anuncio> BuscarAnuncios(int idUsuario)
        {
            var contexto = new Context.EcommerceContext();
            try
            {
                using (contexto)
                {
                    return (from an in contexto.Anuncio
                            where an.UsuarioId == idUsuario
                            select an).ToList();
                }

            }
            catch (Exception)
            { 
                return null; 
            }
        }

        public List<Anuncio> BuscarAnuncios()
        {
            var contexto = new Context.EcommerceContext();
            try
            {
                using (contexto)
                {
                    return (from an in contexto.Anuncio
                            select an).ToList();
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
