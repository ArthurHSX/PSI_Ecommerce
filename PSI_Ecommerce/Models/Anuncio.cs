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
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }

        #endregion

        #region Métodos

        public void ManterAnuncio(Anuncio _anuncio)
        {
            using (var contexto = new Context.EcommerceContext())
            {
                //contexto.Anuncio.Add(_anuncio);
                contexto.Anuncio.Add(new Anuncio()
                {
                    Valor = _anuncio.Valor,
                    Descricao = _anuncio.Descricao,
                    Titulo = _anuncio.Titulo,
                    Usuario = _anuncio.Usuario,
                    UsuarioId = 5
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
            using (var contexto = new Context.EcommerceContext())
            {
                return (from an in contexto.Anuncio
                        where an.UsuarioId == idUsuario
                        select an).ToList();
            }
        }

        #endregion
    }
}
