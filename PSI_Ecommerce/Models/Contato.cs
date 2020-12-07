using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PSI_Ecommerce.Models
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

        public void ManterContato(Contato _contato)
        {
            try
            {
                using (var contexto = new Context.EcommerceContext())
                {
                    contexto.Contato.Add(_contato);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível executar o comando no banco de Dados");
            }
        }

        public Contato BuscaContato(int _id)
        {
            if (_id <= 0)
            { return null; }

            try
            {
                Contato contato;
                using (var contexto = new Context.EcommerceContext())
                {
                    contato = (from cont in contexto.Contato
                               where cont.UsuarioId == _id
                               select cont).FirstOrDefault();
                }

                return contato;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível executar o comando no banco de Dados");
            }
        }
    }
}