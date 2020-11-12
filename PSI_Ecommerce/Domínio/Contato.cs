using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSI_Ecommerce.Dominio
{
    public class Contato
    {
        [Key]
        public int ID { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneMovel { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
