using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_Ecommerce.Models
{
    public class Foto
    {
        public int IdFoto { get; set; }
        public byte[] Imagem { get; set; }
        public int AnuncioId { get; set; }
        public Anuncio anuncio { get; set; }
    }
}
