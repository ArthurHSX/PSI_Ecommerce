using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_Ecommerce.Models
{
    public class Anuncio
    {
        #region Propriedades

        public int ID { get; set; }
        public string TituloAnuncio { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        // IMPLEMENTAR AS CLASSES BASE
        //public int IDUsuario { get; set; }
        //public int IDCategoria { get; set; }
        //public int IDNota { get; set; }
        //public int IDEndereco { get; set; }

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
