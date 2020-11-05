using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_Ecommerce.Models
{
    public class Comentario
    {
        public string Descricao { get; set; }
        public int IdComentario { get; set; }
        public int ID { get; set; }
        public Usuario usuario { get; set; }
        public Comentario pai { get; set; }
    }
}
