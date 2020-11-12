using Microsoft.EntityFrameworkCore;
using PSI_Ecommerce.Dominio;

namespace PSI_Ecommerce.Context
{
    public class EcommerceContext : DbContext
    {
        #region Tables

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Anuncio> Anuncio { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Foto> Foto { get; set; }


        #endregion

        // Adicionar depois o nome do arquivo de conexão do BD no método base("nome...")
        public EcommerceContext() : base()      
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Ecommerce_PSI;Trusted_Connection=True;");
        }
    }
}
