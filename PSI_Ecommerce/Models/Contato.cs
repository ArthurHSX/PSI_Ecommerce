using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_Ecommerce.Models
{
    public class Contato
    {
        public int IdContato { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneMovel { get; set; }
        public int UsuarioId { get; set; }
        public Usuario usuario { get; set; }

    }
}
