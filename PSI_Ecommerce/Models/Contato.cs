using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSI_Ecommerce.Models
{
    public class Contato
    {
        [Key]
        public int ID { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneMovel { get; set; }
        [ForeignKey("ID")]
        public Usuario Usuario { get; set; }

    }
}
