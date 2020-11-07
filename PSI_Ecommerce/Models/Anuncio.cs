using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSI_Ecommerce.Models
{
    public class Anuncio
    {
        #region Propriedades
        [Key]
        public int ID { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string TituloAnuncio { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }

        #endregion

        #region Métodos

        public void ManterAnuncio(Anuncio _anuncio)
        {
            using (var contexto = new Context.EcommerceContext())
            {
                contexto.Anuncio.Add(_anuncio);
                contexto.SaveChanges();
            }
        }

        public void BuscarFotos(int idAnuncio)
        {
            throw new NotImplementedException("Implemmentar método de busca");
        }

        #endregion
    }
}
