using System.ComponentModel.DataAnnotations;

namespace PSI_Ecommerce.Models
{
    public class Contato
    {
        [Key]
        public int IdContato { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneMovel { get; set; }
        public Usuario Usuario { get; set; }

    }
}
