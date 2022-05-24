using livraria.net.domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace livraria.net.infra.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();
            builder.Property(x => x.Isbn)
                .IsRequired();
            builder.Property(x => x.Pages)
                .IsRequired();
            builder.Property(x => x.Chapters)
                .IsRequired();
            builder.Property(x => x.PublisherId)
                .IsRequired();
            builder.Property(x => x.AuthorId)
                .IsRequired();
            builder.Property(x => x.CreatedAt);
        }
    }
}
