using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSI_Ecommerce.Models
{
    public class Comentario
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ID")]
        public Usuario Usuario { get; set; }
        [ForeignKey("ID")]
        public Anuncio Anuncio { get; set; }
        public Comentario ComentarioPai { get; set; }
        public string Descricao { get; set; }
    }
}
