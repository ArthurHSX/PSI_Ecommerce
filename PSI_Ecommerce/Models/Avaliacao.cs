using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSI_Ecommerce.Models
{
    public class Avaliacao
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ID")]
        public Anuncio Anuncio { get; set; }
        [ForeignKey("ID")]
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }
        public string Nota { get; set; }
    }
}
