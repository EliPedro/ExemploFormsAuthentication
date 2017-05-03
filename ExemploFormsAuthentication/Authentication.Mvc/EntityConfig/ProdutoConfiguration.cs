using Authentication.Mvc.ViewModel;
using System.Data.Entity.ModelConfiguration;

namespace Authentication.Mvc.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<ProdutoViewModel>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.Preco)
                .IsRequired();
        }
    }
}