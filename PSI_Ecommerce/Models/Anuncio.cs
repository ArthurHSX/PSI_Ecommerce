using System;
using System.ComponentModel.DataAnnotations;


namespace PSI_Ecommerce.Models
{
    public class Anuncio
    {
        #region Propriedades
        [Key]
        public int IdAnuncio { get; set; }
        public Usuario Usuario { get; set; }
        public string TituloAnuncio { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }

        #endregion

        #region Métodos

        public void ManterAnuncio()
        {
            throw new Exception("Implemmentar método Salvar, Excluir");
        }

        public void BuscarFotos(int idAnuncio)
        {
            throw new Exception("Implemmentar método de busca");
        }

        #endregion
    }
}
