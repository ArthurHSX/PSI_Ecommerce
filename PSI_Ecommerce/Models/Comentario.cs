using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSI_Ecommerce.Models
{
    public class Comentario
    {
        [Key]
        public int ID { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int AnuncioId { get; set; }
        public Anuncio Anuncio { get; set; }
        public Comentario ComentarioPai { get; set; }
        public string Descricao { get; set; }
    }
}
