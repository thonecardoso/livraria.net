using livraria.net.domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace livraria.net.infra.Mapping
{
    public class PublisherMapping : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();
            builder.Property(x => x.Code)
                .IsRequired();
            builder.Property(x => x.FundationDate)
                .IsRequired();
            builder.HasMany(x => x.Books);
            builder.Property(x => x.CreatedAt);
        }
    }
}