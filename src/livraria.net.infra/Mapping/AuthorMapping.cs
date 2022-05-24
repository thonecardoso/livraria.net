using livraria.net.domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace livraria.net.infra.Mapping
{
    public class AuthorMapping : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();
            builder.Property(x => x.Age)
                .IsRequired();
            builder.HasMany(x => x.Books);
            builder.Property(x => x.CreatedAt);
        }
    }
}
