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

            builder.HasData(
                new Author
                {
                    Id = 1,
                    Name = "Stephen King",
                    Age = 75
                },
                 new Author
                 {
                     Id = 2,
                     Name = "Joe Hill",
                     Age = 49
                 },
                 new Author
                 {
                     Id = 3,
                     Name = "Dan Brown",
                     Age = 57
                 },
                 new Author
                 {
                     Id = 4,
                     Name = "Ken Follett",
                     Age = 72
                 },
                 new Author
                 {
                     Id = 5,
                     Name = "Sidney Sheldon",
                     Age = 89
                 }
            );
        }
    }
}
