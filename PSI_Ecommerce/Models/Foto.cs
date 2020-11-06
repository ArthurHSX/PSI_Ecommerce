using System.ComponentModel.DataAnnotations;

namespace PSI_Ecommerce.Models
{
    public class Foto
    {
        [Key]
        public int IdFoto { get; set; }
        public byte[] Imagem { get; set; }
        public Usuario Usuario { get; set; }
        public Anuncio Anuncio { get; set; }
    }
}
