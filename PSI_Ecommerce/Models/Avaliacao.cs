using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PSI_Ecommerce.Models
{
    public class Avaliacao : Controller
    {
        public string Descricao { get; set; }
        public string Nota { get; set; }
        public Anuncio anuncio { get; set; }
        public int AnuncioId { get; set; }
    }
}
