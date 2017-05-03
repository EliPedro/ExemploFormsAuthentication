using Authentication.Mvc.ViewModel;
using System.Data.Entity.ModelConfiguration;

namespace Authentication.Mvc.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<UsuarioViewModel>
    {
        public UsuarioConfiguration()
        {
            HasKey(p => p.UsuarioId);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(100);
        }
        
    }
}