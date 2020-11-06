using System.ComponentModel.DataAnnotations;


namespace PSI_Ecommerce.Models
{
    public class Comentario
    {
        [Key]
        public int IdComentario { get; set; }
        public Usuario Usuario { get; set; }
        public Anuncio Anuncio { get; set; }
        public Comentario ComentarioPai { get; set; }
        public string Descricao { get; set; }
    }
}
