using System.ComponentModel.DataAnnotations;

namespace PSI_Ecommerce.Models
{
    public class Avaliacao
    {
        [Key]
        public int IdAvaliacao { get; set; }
        public Anuncio Anuncio { get; set; }
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }
        public string Nota { get; set; }
    }
}
