﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSI_Ecommerce.Models
{
    public class Foto
    {
        [Key]
        public int ID { get; set; }
        public byte[] Imagem { get; set; }
        public Usuario Usuario { get; set; }
        public Anuncio Anuncio { get; set; }
    }
}
